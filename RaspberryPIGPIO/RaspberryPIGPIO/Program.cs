using System;
using System.Device.Gpio;
using System.Threading;

namespace RaspberryPIGPIO
{
    class Program
    {
        // ピン番号
        private static readonly int pinNum = 7;
        // 繰り返し回数
        private static readonly int N = 3;
        // 光っている時間(ms)
        private static readonly int lightTime = 300;
        static void Main(string[] args)
        {
            Console.WriteLine($"{pinNum}を付けたり消したりします。");
            // 物理のPIN位置を指定
            GpioController controller = new GpioController(PinNumberingScheme.Board);
            controller.OpenPin(pinNum, PinMode.Input);

            try
            {
                for(var i = 0; i < N; i++)
                {
                    // 電気を流す
                    controller.Write(pinNum, PinValue.High);
                    Console.WriteLine($"{pinNum}をHighにしました。");
                    Thread.Sleep(lightTime);
                    // 電気を消す
                    controller.Write(pinNum, PinValue.Low);
                    Console.WriteLine($"{pinNum}をLowにしました。");
                    Thread.Sleep(lightTime);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
