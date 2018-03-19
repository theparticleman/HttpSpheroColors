using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpSpheroColors
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HostConfiguration
            {
                UrlReservations = new UrlReservations { CreateAutomatically = true },
                RewriteLocalhost = true
            };
            var uri = new Uri("http://localhost:80");
            using (var nancy = new NancyHost(config, uri))
            {
                nancy.Start();
                Console.WriteLine($"Listening at {uri}. Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
