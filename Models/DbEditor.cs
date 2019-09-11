using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySearch.Models
{
    public class DbEditor
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
            return context.SearchResults.Where(x => x.Request.SearchString.Contains(requestStr))
                .OrderByDescending(y => y.IndexedTime).Take(10);
        }

        //сохранить новый request вместе со всеми results в БД
        public void SaveRequest(SearchRequest request)
        {
            if (request.SearchRequestId == default)
            {
                context.Entry(request).State = EntityState.Added;
                if (request.SearchResults != null)
                {
                    foreach (SearchResult result in request.SearchResults)
                    {
                        if (result.SearchResultId == default)
                            context.Entry(result).State = EntityState.Added;
                    }
                }
            }
            context.SaveChanges();
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
