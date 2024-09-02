using Application.Enums;
using Application.Interfaces;
using Infrastructure.SpecificElevators;

namespace Infrastructure.Factories
{
    public static class ElevatorFactory
    {
        /// <summary>
        /// Factory method to create an instance of an elevator based on the provided type.
        /// </summary>
        /// <param name="type">The type of elevator to create (e.g., "passenger", "highspeed", "glass").</param>
        /// <param name="id">The unique identifier for the elevator.</param>
        /// <param name="currentFloor">The current floor where the elevator is located.</param>
        /// <returns>An instance of an elevator implementing the IElevator interface.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid elevator type is provided.</exception>
        public static IElevator CreateElevator(string type, int id, int currentFloor)
        {
            switch (type.ToLower())
            {
                case "passenger":
                    return new PassengerElevator ( id,  currentFloor);
                case "highspeed":
                    return new HighSpeedElevator(id, currentFloor); ;
                case "glass":
                    return new GlassElevator(id, currentFloor); ;
                default:
                    throw new ArgumentException("Invalid elevator type");
            }
        }
    }
}
