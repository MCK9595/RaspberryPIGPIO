using Iot.Device.DHTxx;
using Iot.Units;
using System;
using System.Device.Gpio;
using System.Threading.Tasks;

namespace RaspberryPIGPIO.DHT11Run
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                int pinNum = 7;

                //今は使えないので、コメントアウト
                using (Dht11 dht = new Dht11(pinNum, System.Device.Gpio.PinNumberingScheme.Board))
                {
                    Temperature temperature = dht.Temperature;
                    double humidity = dht.Humidity;

                    Console.WriteLine($"気温:{temperature.Celsius}度\t湿度:{humidity}パーセント");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"エラー発生:{ex.Message}");
            }
        }
    }
}
