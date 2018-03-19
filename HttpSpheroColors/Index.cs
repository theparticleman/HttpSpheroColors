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
                var color = this.Bind<Color>();
                Console.WriteLine($"Got a request with ({color.Red},{color.Green},{color.Blue})");
                Program.ColorChanger.AddColor(color);
                return indexHtml;
            };
        }
    }
}
