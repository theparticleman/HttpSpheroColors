using Nancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;

namespace HttpSpheroColors
{
    public class Index : NancyModule
    {
        private readonly string indexHtml;
        public Index()
        {
            indexHtml = File.ReadAllText("Index.html");

            Get["/"] = _ => indexHtml;

            Post["/"] = parameters =>
            {
                var request = this.Bind<ColorRequest>();
                Console.WriteLine($"Got a request with ({request.Red},{request.Green},{request.Blue})");
                return indexHtml;
            };
        }
    }
}
