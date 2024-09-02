using Application.Entities;
using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SpecificElevators
{
    /// <summary>
    /// Represents a passenger elevator.
    /// </summary>
    /// <remarks>
    /// The PassengerElevator class is derived from the Elevator base class and implements specific
    /// logic for passenger elevators, including their movement and status.
    /// </remarks>
    public class PassengerElevator : Elevator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PassengerElevator"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the elevator.</param>
        /// <param name="currentFloor">The current floor where the elevator is located.</param>
        public PassengerElevator(int id, int currentFloor) 
        {
            Id = id;
            CurrentFloor = currentFloor;
            Status = ElevatorStatus.Idle;
            CurrentPassengers = 0;
        }
        /// <summary>
        /// Moves the elevator to the specified floor.
        /// </summary>
        /// <param name="floor">The target floor to move the elevator to.</param>
        public override void MoveToFloor(int floor)
        {
            // Implement the logic for moving a passenger elevator
        }
    }
}

