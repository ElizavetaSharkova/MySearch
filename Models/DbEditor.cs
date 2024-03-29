﻿using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MySearch.Models
{
    public class DbEditor: IDbEditor
    {
        private readonly SearchContext context;
        public DbEditor(SearchContext context)
        {
            this.context = context;
        }

        //выбрать все записи из таблицы SearchEngine
        public IQueryable<SearchEngine> GetEngines()
        {
            var engines = context.SearchEngines.OrderBy(x => x.Name)
                .Include(e => e.Type)
                .Include(e => e.Headers)
                .Include(e => e.Parameters);

            return engines;
        }

        //найти все результаты по строке запроса
        public IQueryable<SearchResult> GetResultsByRequest(string requestStr)
        {
            return context.SearchResults
                .Where(x => x.Request.SearchString.Contains(requestStr))
                .OrderByDescending(y => y.IndexedTime)
                .Take(10)
                .Include(e => e.Request)
                .Include(e => e.SearchEngine);
        }

        //сохранить новый request вместе со всеми results в БД
        public void SaveRequest(SearchRequest request)
        {
            if (request.SearchRequestId == default)
            {
                if (request.SearchResults != null)
                {
                    foreach (SearchResult result in request.SearchResults)
                    {
                        if (result.SearchResultId == default && !IsExistResult(result))
                        {
                            context.Entry(result).State = EntityState.Added;
                        }
                    }
                }
                context.Entry(request).State = EntityState.Added;
            }
            context.SaveChanges();
        }

        public bool IsExistResult(SearchResult result)
        {
            IQueryable<SearchRequest> requests = context.SearchRequests.Where(x => 
                x.SearchString == result.Request.SearchString
            );
            if (requests == null)
            {
                return false;
            }
            IQueryable<SearchResult> results = context.SearchResults.Where(x => 
                x.Url == result.Url &&
                x.IndexedTime >= result.IndexedTime
            );

            return (results != null);
        }

        public void SaveRequestHeaderValue(int id, string value)
        {
            RequestHeader header = context.RequestHeaders.Where(x => x.RequestHeaderId == id).First();
            header.HeaderValue = value;
            context.Entry(header).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
