using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SpheroNET;

namespace HttpSpheroColors
{
    public class SpheroColorChanger
    {
        private readonly ConcurrentQueue<Color> colors = new ConcurrentQueue<Color>();
        private Thread thread;
        private bool running;
        private SpheroConnector connector;
        private Sphero sphero;

        public void Start()
        {
            AttemptToConnect();
            thread = new Thread(ThreadBody)
            {
                IsBackground = true
            };
            running = true;
            thread.Start();
        }

        internal void AddColor(Color color)
        {
            colors.Enqueue(color);
        }

        private void AttemptToConnect()
        {
            connector = new SpheroConnector();
            connector.Scan();
            foreach (var device in connector.DeviceNames)
            {
                if (device.ToLower().Contains("sphero"))
                {
                    Console.WriteLine($"Attempting to connect to {device}");
                    sphero = connector.Connect(device);
                    return;
                }
            }
        }

        public void Stop()
        {
            running = false;
            var stopwatch = Stopwatch.StartNew();
            while (thread.IsAlive && stopwatch.ElapsedMilliseconds < 5000) Thread.Sleep(50);
            connector.Close();
        }

        private void ThreadBody()
        {
            while (running)
            {
                if (colors.Count > 0)
                {
                    if (colors.TryDequeue(out Color color))
                    {
                        sphero.SetRGBLEDOutput(color.Red, color.Green, color.Blue);
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
