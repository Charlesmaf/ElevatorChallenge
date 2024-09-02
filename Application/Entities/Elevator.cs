using Application.Enums;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    /// <summary>
    /// Represents the base class for an elevator.
    /// </summary>
    /// <remarks>
    /// The Elevator class provides common properties and methods shared by all types of elevators.
    /// Derived classes should implement specific behavior such as movement logic.
    /// </remarks>
    public abstract class Elevator : IElevator
    {
        /// <summary>
        /// Gets or sets the unique identifier for the elevator.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the current floor where the elevator is located.
        /// </summary>
        public int CurrentFloor { get; set; }

        /// <summary>
        /// Gets or sets the number of passengers currently in the elevator.
        /// </summary>
        public int CurrentPassengers { get; set; }

        /// <summary>
        /// Gets or sets the current status of the elevator.
        /// </summary>
        public ElevatorStatus Status { get; set; }

        public abstract void MoveToFloor(int floor);
    }
}
