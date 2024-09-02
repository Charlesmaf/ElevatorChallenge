using Application.Interfaces;
using Application.Services;
using Infrastructure.Factories;

namespace Elevator_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initialize a list of elevators with different types, IDs, and starting floors
                var elevators = new List<IElevator>
                {
                    ElevatorFactory.CreateElevator("passenger", 1, 0),  // Passenger elevator at ground floor (0)
                    ElevatorFactory.CreateElevator("highspeed", 2, 5),  // High-speed elevator starting at floor 5
                    ElevatorFactory.CreateElevator("glass", 3, 8)       // Glass elevator starting at floor 8
                };

                // Initialize the ElevatorControlService with the list of elevators
                var elevatorControlService = new ElevatorControlService(elevators);

                while (true) // Main loop for continuous operation
                {
                    try
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("=== Elevator Control System ===");

                        // Prompt user for the current floor
                        System.Console.WriteLine("Please select your current floor (G, 1-15): ");
                        string input = System.Console.ReadLine();

                        // Validate the user's floor input
                        if (!ParseFloorInput(input, out int userFloor))
                        {
                            System.Console.WriteLine("Invalid floor selection. Please try again.");
                            Thread.Sleep(2000); // Wait for 2 seconds before retrying
                            continue; // Restart the loop to ask for input again
                        }

                        // Prompt user for the number of passengers entering the elevator
                        System.Console.WriteLine("Enter the number of passengers entering the elevator: ");
                        if (!int.TryParse(System.Console.ReadLine(), out int enteringPassengers) || enteringPassengers <= 0)
                        {
                            System.Console.WriteLine("Invalid passenger count. Please try again.");
                            Thread.Sleep(2000); // Wait for 2 seconds before retrying
                            continue; // Restart the loop to ask for input again
                        }

                        // Assign elevators based on the current floor and number of passengers
                        List<IElevator> selectedElevators = elevatorControlService.AssignElevators(userFloor, enteringPassengers);
                        if (selectedElevators.Count == 0)
                        {
                            System.Console.WriteLine("No elevators are available at the moment.");
                            Thread.Sleep(2000); // Wait for 2 seconds before retrying
                            continue; // Restart the loop to ask for input again
                        }

                        // Load passengers into the selected elevators and move them to the requested floor
                        foreach (var elevator in selectedElevators)
                        {
                            // Calculate how many passengers can be loaded into the elevator
                            int passengersToLoad = Math.Min(enteringPassengers, 10 - elevator.CurrentPassengers);
                            elevator.CurrentPassengers += passengersToLoad;
                            enteringPassengers -= passengersToLoad;

                            System.Console.WriteLine($"Elevator {elevator.Id} is moving to your floor.");
                            // Move the elevator to the user's current floor
                            elevatorControlService.MoveElevator(elevator, userFloor);
                            System.Console.WriteLine($"Elevator {elevator.Id} has arrived at your floor with {passengersToLoad} passengers.");

                            if (enteringPassengers == 0)
                            {
                                break; // All passengers have been accommodated
                            }
                        }

                        // Handle the case where not all passengers could be accommodated
                        if (enteringPassengers > 0)
                        {
                            System.Console.WriteLine($"Not all passengers could be accommodated. {enteringPassengers} passengers could not be boarded.");
                            Thread.Sleep(2000); // Wait for 2 seconds before retrying
                            continue; // Restart the loop to handle the remaining passengers
                        }

                        // Prompt user for the destination floor and handle passenger exit
                        while (selectedElevators.Any(e => e.CurrentPassengers > 0))
                        {
                            System.Console.WriteLine("Please select your destination floor (G, 1-15): ");
                            input = System.Console.ReadLine();

                            // Validate the user's floor input for the destination floor
                            if (!ParseFloorInput(input, out int destinationFloor))
                            {
                                System.Console.WriteLine("Invalid floor selection. Please try again.");
                                Thread.Sleep(2000); // Wait for 2 seconds before retrying
                                continue; // Restart the loop to ask for input again
                            }

                            foreach (var elevator in selectedElevators)
                            {
                                if (elevator.CurrentPassengers > 0)
                                {
                                    System.Console.WriteLine($"Elevator {elevator.Id} is moving to floor {destinationFloor}.");
                                    // Move the elevator to the destination floor
                                    elevatorControlService.MoveElevator(elevator, destinationFloor);

                                    System.Console.WriteLine("You have arrived at your destination.");

                                    // Prompt user for the number of passengers exiting the elevator
                                    System.Console.WriteLine($"Elevator {elevator.Id} has {elevator.CurrentPassengers} passengers.");
                                    System.Console.WriteLine("Enter the number of passengers exiting the elevator: ");
                                    int exitingPassengers;
                                    while (!int.TryParse(System.Console.ReadLine(), out exitingPassengers) || exitingPassengers < 0 || exitingPassengers > elevator.CurrentPassengers)
                                    {
                                        System.Console.WriteLine($"Invalid number of exiting passengers. Must be between 0 and {elevator.CurrentPassengers}. Please try again.");
                                    }

                                    // Reduce the number of passengers in the elevator
                                    elevator.CurrentPassengers -= exitingPassengers;

                                    System.Console.WriteLine($"There are now {elevator.CurrentPassengers} passengers remaining in Elevator {elevator.Id}.");
                                }
                            }
                        }

                        // Ask user if they want to exit the program or continue with another request
                        System.Console.WriteLine("Press 'E' to exit or any other key to make another request.");
                        var exitInput = System.Console.ReadKey();
                        if (exitInput.Key == ConsoleKey.E)
                        {
                            break; // Exit the program
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine($"An error occurred: {ex.Message}");
                        Thread.Sleep(2000); // Wait for 2 seconds before retrying
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"A critical error occurred: {ex.Message}");
            }
        }
        // Method to parse the floor input from the user
        static bool ParseFloorInput(string input, out int floor)
        {
            floor = -1; // Initialize floor to an invalid value
            try
            {
                if (input.Equals("G", StringComparison.OrdinalIgnoreCase))
                {
                    floor = 0; // Set floor to 0 if the input is "G" (ground floor)
                    return true;
                }
                else if (int.TryParse(input, out int parsedFloor))
                {
                    if (parsedFloor >= 1 && parsedFloor <= 15)
                    {
                        floor = parsedFloor; // Set floor to the parsed value if it's between 1 and 15
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"An error occurred while parsing the floor input: {ex.Message}");
                // Optionally, log the exception or handle it in a way appropriate for your application
            }
            return false; // Return false if the input is invalid
        }

    }
}
