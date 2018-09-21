using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Vagalume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {

        // GET api/quotes/
        [HttpGet]
        public async  Task<Quote> Get(int id)
        {
            using(StreamReader r = new StreamReader("./quotes.json")){
                var json = await r.ReadToEndAsync();
                var list = JsonConvert.DeserializeObject<List<Quote>>(json);
                Random rnd = new Random();
                return list[rnd.Next(0, list.Count - 1)];
            }
        }
    }
}


public class Quote{
    public String texto;
    public String autor;

}
