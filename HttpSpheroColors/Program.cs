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
        public static SpheroColorChanger ColorChanger { get; private set; }

        static void Main(string[] args)
        {
            ColorChanger = new SpheroColorChanger();
            var config = new HostConfiguration
            {
                UrlReservations = new UrlReservations { CreateAutomatically = true },
                RewriteLocalhost = true
            };
            var uri = new Uri("http://localhost:80");
            using (var nancy = new NancyHost(config, uri))
            {
                ColorChanger.Start();
                nancy.Start();
                Console.WriteLine($"Listening at {uri}. Press enter to quit");
                Console.ReadLine();
                ColorChanger.Stop();
            }
        }
    }
}
