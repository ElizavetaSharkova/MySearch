using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using MySearch.Models;
using Newtonsoft.Json.Linq;

namespace MySearch.Services
{
    public class ParseService
    {
        private static readonly string[] dateTimeFormats = { "dd.MM.yyyy HH:mm:ss", "dd.MM.yyyy H:mm:ss", "yyyy-MM-ddTHH:mm:ss.fffZ", "yyyy-MM-ddTH:mm:ss.fffZ", "yyyyMMddTHHmmss" };

        /// <summary>
        /// Read response, call parse method according to response type and returns data as a List of SearchResult.
        /// </summary>
        public static List<SearchResult> ParseResponse(ParsedResponse response)
        {
            string type = response.Engine.Type.Type;
            Stream stream = response.WebResponse.GetResponseStream();
            
            if (type != "xml" && type != "json" || stream == null)
                return new List<SearchResult>();
            
            return type == "json"
                ? ParseJson(stream, response.Engine)
                : ParseXml(stream, response.Engine);
        }

        public static List<SearchResult> ParseJson(Stream responseStream, SearchEngine engine)
        {
            List<SearchResult> results = new List<SearchResult>();
            
            ResponseType responseType = engine.Type;

            string responseString;
            using (responseStream)
            {
                responseString = new StreamReader(responseStream).ReadToEnd();
            }

            if (string.IsNullOrEmpty(responseString))
                return results;
            
            JObject doc = JObject.Parse(responseString);
            JToken rootElement = doc.SelectToken(responseType.RootElementPath);
            results.AddRange(rootElement
                .Select(childElement => 
                    GetSearchResultFromJToken(engine, responseType, childElement)
                )
            );
            return results;
        }

        // <summary>
        // Parse xml from response from Yandex.Xml API and returns data as a List of SearchResult.
        // </summary>
        public static List<SearchResult> ParseXml(Stream responseStream, SearchEngine engine)
        {
            ResponseType responseType = engine.Type;

            return GetXElements(responseStream, responseType)
                .Select(element => GetSearchResultFromXElement(engine, element, responseType))
                .ToList();

            // IEnumerable<XElement> groupQuery = GetXElements(responseStream, responseType);
            // for (int i = 0; i < groupQuery.Count(); i++)
            // {
            //     XElement element = groupQuery.ElementAt(i);
            //     SearchResult result = GetSearchResultFromXElement(engine, element, responseType);
            //     results.Add(result);
            // }
            //
            // return results;
        }

        private static IEnumerable<XElement> GetXElements(Stream responseStream, ResponseType responseType)
        {
            string[] path = responseType.RootElementPath.Split(".");
            XmlReader xmlReader = XmlReader.Create(responseStream);
            XDocument xmlResponse = XDocument.Load(xmlReader);
            IEnumerable<XElement> groupQuery = xmlResponse.Elements(path[0]);
            for (int i = 1; i < path.Length; i++)
            {
                groupQuery = groupQuery.Elements(path[i]);
            }

            return groupQuery.ToList();
        }

        private static SearchResult GetSearchResultFromXElement(SearchEngine engine, XElement element, ResponseType responseType)
        {
            string description = GetValue(element, responseType.DescriptionElement)
                                 ?? GetValue(element, "headline");
            string modtime = GetValue(element, responseType.DateElement); //example: modTime = 20160331T032014

            return new SearchResult
            {
                SearchResultId = default,
                Url = GetValue(element, responseType.UrlElement),
                Title = GetValue(element, responseType.TitleElement),
                Description = description,
                IndexedTime = TryParseStringDate(modtime),
                SearchEngine = engine
            };
        }
        
        private static SearchResult GetSearchResultFromJToken(SearchEngine engine, ResponseType responseType,
            JToken childElement)
        {
            string dateString = !string.IsNullOrEmpty(responseType.DateElement)
                ? childElement[responseType.DateElement].ToString()
                : "";
            DateTime? indexedTime = TryParseStringDate(dateString);

            SearchResult result = new SearchResult
            {
                SearchResultId = default,
                SearchEngine = engine,
                Title = childElement[responseType.TitleElement].ToString(),
                Url = childElement[responseType.UrlElement].ToString(),
                Description = childElement[responseType.DescriptionElement].ToString(),
                IndexedTime = indexedTime
            };
            return result;
        }

        public static DateTime? TryParseStringDate(string stringDate)
        {
            try
            {
                return DateTime.ParseExact(stringDate, dateTimeFormats, null);
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
            XElement element = group.Element("doc")?.Element(name);
            string value = element?.Value.Replace("\r\n", "").Trim() ?? "";
            value = Regex.Replace(value, "[ ]+", " ");
            return value;
        }
    }
}
