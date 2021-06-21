using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionIB.PlatformEngineer.CodeChallenge.Lib.Services
{
    using static Constants;
    public class AirQualityService : IAirQualityService
    {
        public class AirQuality : IAirQuality
        {
            private const int _best = 0;
            private const int _worst = 500;

            private static readonly TimeSpan _delay = TimeSpan.FromSeconds(1);
            private readonly Random _rand = new Random();
            private int _value = 0;

            public AirQuality()
            {
                _value = _rand.Next(_best, _worst);
                Task.Run(Adjust);
            }

            public int Value => _value;

            private async Task Adjust()
            {
                while (true)
                {
                    await Task.Delay(_delay);
                    var next = _rand.Next(-5, 5);
                    var tempValue = _value += next;
                    _value = Math.Min(Math.Max(_best, tempValue), _worst);
                }
            }
        }

        private IAirQuality[] _airQualities = Enumerable.Range(0, TopFloor).Select(i => new AirQuality()).ToArray();
        public IEnumerable<IAirQuality> AirQualities => _airQualities;
    }
}
