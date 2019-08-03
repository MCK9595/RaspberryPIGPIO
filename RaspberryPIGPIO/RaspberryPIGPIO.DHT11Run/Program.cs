using Iot.Device.DHTxx;
using Iot.Units;
using System;

namespace RaspberryPIGPIO.DHT11Run
{
    class Program
    {
        static void Main(string[] args)
        {
            using(Dht11 dht=new Dht11(4))
            {
                Temperature temperature = dht.Temperature;
                double humidity = dht.Humidity;

                Console.WriteLine($"気温:{temperature.Celsius}度\t湿度:{humidity}パーセント");
            }
        }
    }
}
