using System;
using System.Device.Gpio;

namespace RaspberryPIGPIO.DHT11Run
{
    class Program
    {
        static void Main(string[] args)
        {
            int pinNum = 7;
            GpioController controller = new GpioController(PinNumberingScheme.Board);
            controller.OpenPin(pinNum, PinMode.Input);

            var a = controller.Read(pinNum);

            Console.WriteLine($"{a}");

            // 今は使えないので、コメントアウト
            //using (Dht11 dht = new Dht11(7, System.Device.Gpio.PinNumberingScheme.Board))
            //{
            //    Temperature temperature = dht.Temperature;
            //    double humidity = dht.Humidity;

            //    Console.WriteLine($"気温:{temperature.Celsius}度\t湿度:{humidity}パーセント");
            //}
        }
    }
}
