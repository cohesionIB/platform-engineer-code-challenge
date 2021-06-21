using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionIB.PlatformEngineer.CodeChallenge.Lib.Services
{
    using static Constants;
    public class ElevatorService : IElevatorService
    {        
        public class Elevator : IElevator
        {
            private static readonly TimeSpan _timeBetweenFloors = TimeSpan.FromSeconds(3);

            private async Task Move(int floor) 
            {
                while (floor != CurrentFloor)
                {
                    await Task.Delay(_timeBetweenFloors);
                    if (Movement == ElevatorMovement.Down)
                        CurrentFloor--;
                    else
                        CurrentFloor++;
                }
            }

            public async Task GoToFloor(int floor)
            {
                Task task = null;
                lock (this) 
                {
                    if (Movement != ElevatorMovement.Stationary)
                        return;

                    floor = Math.Min(Math.Max(floor, BottomFloor), TopFloor);
                    if (floor > CurrentFloor)
                        Movement = ElevatorMovement.Up;
                    else if (floor < CurrentFloor)
                        Movement = ElevatorMovement.Down;

                    task = Move(floor);
                }

                await task;
                Movement = ElevatorMovement.Stationary;
            }

            public ElevatorMovement Movement { get; private set; }
            public int CurrentFloor { get; private set; } = BottomFloor;
        }

        private readonly Elevator[] _elevators = Enumerable.Range(0, 6).Select(i => new Elevator()).ToArray();

        public IEnumerable<IElevator> Elevators => _elevators;

        public async Task GoToFloor(int elevatorIndex, int floor)
        {
            if (elevatorIndex < 0 || elevatorIndex > _elevators.Length)
                return;

            await _elevators[elevatorIndex].GoToFloor(floor);
        }
    }
}
