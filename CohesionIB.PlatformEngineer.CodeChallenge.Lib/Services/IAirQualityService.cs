using System.Collections.Generic;

namespace CohesionIB.PlatformEngineer.CodeChallenge.Lib.Services
{
    public interface IAirQuality
    {
        int Value { get; }
    }

    public interface IAirQualityService
    {
        IEnumerable<IAirQuality> AirQualities { get; }
    }
}