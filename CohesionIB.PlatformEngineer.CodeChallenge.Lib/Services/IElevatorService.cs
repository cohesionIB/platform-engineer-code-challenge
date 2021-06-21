using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CohesionIB.PlatformEngineer.CodeChallenge.Lib.Services
{
    public enum ElevatorMovement
    {
        Stationary,
        Up,
        Down,
    }

    public interface IElevator
    {
        public ElevatorMovement Movement { get; }
        public int CurrentFloor { get; }
    }

    public interface IElevatorService
    {
        IEnumerable<IElevator> Elevators { get; }

        Task GoToFloor(int elevatorIndex, int floor);
    }
}
