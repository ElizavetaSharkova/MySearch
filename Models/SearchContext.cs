using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySearch.Models
{
    public class SearchContext: DbContext
    {
        public SearchContext(DbContextOptions<SearchContext> options) : base(options) { }
        public DbSet<SearchResult> SearchResults { get; set; }
        public DbSet<SearchRequest> SearchRequests { get; set; }
        public DbSet<SearchEngine> SearchEngines { get; set; }
        public DbSet<RequestsParameter> RequestsParameters { get; set; }
        public DbSet<ResponseType> ResponseTypes { get; set; }
        public DbSet<RequestHeader> RequestHeaders { get; set; }
    }
}
