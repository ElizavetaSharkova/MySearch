using MySearch.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace MySearch.Controllers
{
    public class Parser
    {
        /// <summary>
        /// Read response, call parse method according to response type and returns data as a List of SearchResult.
        /// </summary>
        public static List<SearchResult> ParseResponse(ParseResponseStruct prs)
        {
            if (prs.engine.Type.Type == "xml")
            {
                XmlReader xmlReader = XmlReader.Create(prs.webResponse.GetResponseStream());
                XDocument xmlResponse = XDocument.Load(xmlReader);

                return ParseXml(xmlResponse, prs.engine);
            }
            else if (prs.engine.Type.Type == "json")
            {
                string responseString;
                using (Stream responseStream = prs.webResponse.GetResponseStream())
                {
                    responseString = new StreamReader(responseStream).ReadToEnd();
                }

                if (string.IsNullOrEmpty(responseString))
                    return new List<SearchResult>();

                return ParseJson(responseString, prs.engine);
            }
            return new List<SearchResult>();
        }

        public static List<SearchResult> ParseJson(string json, SearchEngine engine)
        {
            List<SearchResult> results = new List<SearchResult>();
            ResponseType responseType = engine.Type;

            JObject doc = JObject.Parse(json);
            JToken RootElement = doc.SelectToken(responseType.RootElementPath);
            foreach (JToken childElement in RootElement)
            {
                SearchResult result = new SearchResult
                {
                    SearchResultId = default,
                    SearchEngine = engine,
                    Title = childElement[responseType.TitleElement].ToString(),
                    Url = childElement[responseType.UrlElement].ToString(),
                    Description = childElement[responseType.DescriptionElement].ToString()
                };

                if (!string.IsNullOrEmpty(responseType.DateElement))
                {
                    string dateString = childElement[responseType.DateElement].ToString();
                    result.IndexedTime = TryParseStringDate(dateString);
                }
                else
                {
                    result.IndexedTime = null;
                }

                results.Add(result);
            }
            return results;
        }

        // <summary>
        // Parse xml from response from Yandex.Xml API and returns data as a List of SearchResult.
        // </summary>
        public static List<SearchResult> ParseXml(XDocument xmlResponse, SearchEngine engine)
        {
            List<SearchResult> results = new List<SearchResult>();

            ResponseType responseType = engine.Type;

            string[] path = responseType.RootElementPath.Split(".");

            IEnumerable<XElement> groupQuery = xmlResponse.Elements(path[0]);
            for (int i = 1; i < path.Length; i++)
            {
                groupQuery = groupQuery.Elements(path[i]);
            }

            for (int i = 0; i < groupQuery.Count(); i++)
            {
                SearchResult result = new SearchResult
                {
                    SearchResultId = default,
                    Url = GetValue(groupQuery.ElementAt(i), responseType.UrlElement),
                    Title = GetValue(groupQuery.ElementAt(i), responseType.TitleElement),
                    Description = GetValue(groupQuery.ElementAt(i), responseType.DescriptionElement),
                    SearchEngine = engine
                };
                if (result.Description == string.Empty)
                {
                    result.Description = GetValue(groupQuery.ElementAt(i), "headline");
                }

                string modtime = GetValue(groupQuery.ElementAt(i), responseType.DateElement); //example: modTime = 20160331T032014
                result.IndexedTime = TryParseStringDate(modtime);

                results.Add(result);
            }

            return results;
        }

        public static DateTime? TryParseStringDate(string stringDate)
        {
            try
            {
                string[] format = { "dd.MM.yyyy HH:mm:ss", "dd.MM.yyyy H:mm:ss", "dd-MM-yyyyTHH:mm:ss.fffZ", "dd-MM-yyyyTH:mm:ss.fffZ", "yyyyMMddTHHmmss" };
                return DateTime.ParseExact(stringDate, format, null);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Get string from XML element by element's name.
        /// </summary>
        public static string GetValue(XElement group, string name)
        {
            try
            {
                return group.Element("doc").Element(name).Value;
            }
            //if response hasn't this element
            catch
            {
                return string.Empty;
            }
        }
    }
}
