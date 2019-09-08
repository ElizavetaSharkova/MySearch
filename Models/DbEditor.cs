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
            return context.SearchEngines.OrderBy(x => x.Name);
        }

        //найти все результаты по строке запроса
        public IQueryable<SearchResult> GetResultsByRequest(string requestStr)
        {
            return context.SearchResults.Where(x => x.Request.SearchString == requestStr);
        }

        //сохранить новый request вместе со всеми results в БД
        public int SaveRequest(SearchRequest request)
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

            return request.SearchRequestId;
        }

    }
}
