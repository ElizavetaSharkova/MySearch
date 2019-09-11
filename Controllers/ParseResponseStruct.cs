using MySearch.Models;
using System.Net;

namespace MySearch.Controllers
{
    public struct ParseResponseStruct
    {
        public SearchEngine engine;
        public HttpWebResponse webResponse;
    }
}
