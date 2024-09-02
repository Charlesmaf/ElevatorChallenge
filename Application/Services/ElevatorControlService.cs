using Application.Enums;
using Application.Interfaces;


namespace Application.Services
{
    /// <summary>
    /// Service class responsible for controlling elevators, including assigning and moving them.
    /// </summary>
    public class ElevatorControlService
    {
        private readonly List<IElevator> _elevators; // List of elevators managed by the service
        private const int MaxPassengers = 10; // Maximum number of passengers an elevator can carry
        public ElevatorControlService(List<IElevator> elevators)
        {
            _elevators = elevators;
        }
        public List<IElevator> AssignElevators(int requestedFloor, int passengers)
        {
            List<IElevator> selectedElevators = new List<IElevator>();

            try
            {
                // Sort elevators by their proximity to the requested floor
                foreach (var elevator in _elevators.OrderBy(e => Math.Abs(e.CurrentFloor - requestedFloor)))
                {
                    // Only consider idle elevators for assignment
                    if (elevator.Status == ElevatorStatus.Idle)
                    {
                        selectedElevators.Add(elevator);

                        // Calculate the remaining capacity after taking some passengers
                        int capacityLeft = MaxPassengers - elevator.CurrentPassengers;
                        if (passengers <= capacityLeft)
                        {
                            // If the elevator can take all passengers, break the loop
                            break;
                        }
                        else
                        {
                            // Otherwise, assign as many passengers as possible and continue assigning more elevators
                            passengers -= capacityLeft;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while assigning elevators: {ex.Message}");
                // Optionally log the exception or handle it further
            }

            return selectedElevators;
        }
        public void MoveElevator(IElevator elevator, int targetFloor)
        {
            try
            {
                // Determine the direction of movement
                elevator.Status = elevator.CurrentFloor < targetFloor ? ElevatorStatus.MovingUp : ElevatorStatus.MovingDown;

                // Move the elevator one floor at a time until it reaches the target floor
                while (elevator.CurrentFloor != targetFloor)
                {
                    DrawBuilding(_elevators); // Update the building's visual representation
                    Thread.Sleep(500); // Simulate the time delay for moving between floors

                    // Adjust the current floor based on the direction of movement
                    if (elevator.Status == ElevatorStatus.MovingUp)
                        elevator.CurrentFloor++;
                    else if (elevator.Status == ElevatorStatus.MovingDown)
                        elevator.CurrentFloor--;
                }

                // Set the elevator's status to idle once it has reached the target floor
                elevator.Status = ElevatorStatus.Idle;
                DrawBuilding(_elevators); // Final update of the building's visual representation
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while moving the elevator: {ex.Message}");
                // Optionally log the exception or handle it further
            }
        }
        private void DrawBuilding(List<IElevator> elevators)
        {
            try
            {
                Console.Clear(); // Clear the console for a fresh display
                for (int i = 15; i >= 0; i--) // Iterate through each floor from the top down
                {
                    string floorLabel = (i == 0) ? "G" : i.ToString(); // Ground floor is labeled 'G'
                    Console.Write($"| {floorLabel,2} |");

                    // Display each elevator's position and status on the current floor
                    foreach (var elevator in elevators)
                    {
                        if (i == elevator.CurrentFloor)
                            Console.Write($" --- **** ({elevator.CurrentPassengers}) [{elevator.Status}]");
                        else
                            Console.Write(" ---                  "); // Blank space for floors without an elevator
                    }

                    Console.WriteLine();
                }

                // Draw a separator line and extra space at the bottom
                Console.WriteLine("------------------------------- ");
                Console.WriteLine();

                // Display the status of each elevator
                Console.WriteLine("Elevator Status:");
                Console.WriteLine("============================================================");
                foreach (var elevator in elevators)
                {
                    Console.WriteLine($"Elevator {elevator.Id}: Floor {elevator.CurrentFloor}, Passengers [{elevator.CurrentPassengers}], Status: [{elevator.Status}]");
                }
                Console.WriteLine("============================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while drawing the building: {ex.Message}");
                // Optionally log the exception or handle it further
            }
        }
    }
}
