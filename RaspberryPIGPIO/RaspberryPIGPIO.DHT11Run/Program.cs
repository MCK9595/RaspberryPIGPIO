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
                int loopCount = 100000;
                GpioController controller = new GpioController(PinNumberingScheme.Board);
                controller.OpenPin(pinNum);
                // 対象のPinをHighにする
                controller.SetPinMode(pinNum, PinMode.Output);
                controller.Write(pinNum, PinValue.Low);
                await Task.Delay(20);
                controller.Write(pinNum, PinValue.High);
                await Task.Delay(30);

                controller.SetPinMode(pinNum, PinMode.InputPullUp);
                var count = loopCount;

                // 正常性チェック・・・？
                while (controller.Read(pinNum) == PinValue.Low)
                {
                    if (count-- == 0)
                    {
                        Console.WriteLine($"{loopCount}回Highが続いたので、終了します。");
                        return;
                    }
                }

                count = loopCount;
                while (controller.Read(pinNum) == PinValue.High)
                {
                    if (count-- == 0)
                    {
                        Console.WriteLine($"{loopCount}回Highが続いたので、終了します。");
                        return;
                    }
                }

                // 今は使えないので、コメントアウト
                //using (Dht11 dht = new Dht11(7, System.Device.Gpio.PinNumberingScheme.Board))
                //{
                //    Temperature temperature = dht.Temperature;
                //    double humidity = dht.Humidity;

                //    Console.WriteLine($"気温:{temperature.Celsius}度\t湿度:{humidity}パーセント");
                //}
            }catch(Exception ex)
            {
                Console.WriteLine($"エラー発生:{ex.Message}");
            }
        }
    }
}
