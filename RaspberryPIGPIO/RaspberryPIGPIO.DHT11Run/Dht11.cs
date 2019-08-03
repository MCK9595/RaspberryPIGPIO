// 参照URL
// https://github.com/dotnet/iot/blob/master/src/devices/Dhtxx/Devices/Dht11.cs



using Iot.Units;
using System.Device.Gpio;

namespace RaspberryPIGPIO.DHT11Run
{
    /// <summary>
    /// Temperature and Humidity Sensor DHT11
    /// </summary>
    public class Dht11 : DhtBase
    {
        public Dht11(int pin, PinNumberingScheme pinNumberingScheme = PinNumberingScheme.Logical) : base(pin, pinNumberingScheme)
        {
        }

        internal override double GetHumidity(byte[] readBuff)
        {
            return readBuff[0] + readBuff[1] * 0.1;
        }

        internal override Temperature GetTemperature(byte[] readBuff)
        {
            var temp = readBuff[2] + readBuff[3] * 0.1;
            return Temperature.FromCelsius(temp);
        }
    }
}
