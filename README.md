## Overview
This project is an Elevator Simulation System built in C#. It simulates the operation of multiple elevators in a building, allowing users to interact 
with the system by selecting their current floor, entering the number of passengers, and choosing a destination floor. The system then assigns the most 
suitable elevator, moves it to the user's floor, and handles the loading and unloading of passengers.

## Features

* Elevator Types: The simulation includes different types of elevators: PassengerElevator, HighSpeedElevator, and GlassElevator. Each elevator type can
  have specific characteristics, and they can be easily extended by implementing the IElevator interface.
* Dynamic Elevator Assignment: The system dynamically assigns elevators based on the user's current floor and the number of passengers. Elevators are
  selected based on proximity to the user's floor and availability.
* Real-Time Elevator Movement: The simulation visually represents the movement of elevators between floors in real-time, updating their status as they travel.
* Passenger Management: The system manages passenger loading and unloading, ensuring elevators do not exceed their maximum capacity.
* Interactive Console Application: The simulation is an interactive console application that allows users to input their floor, passengers, and destination, providing feedback on elevator status and actions.

## Installation
### Clone the repository
```bash
git clone https://github.com/yourusername/ElevatorSimulation.git
cd ElevatorSimulation
```
### Build the project: Open the solution in Visual Studio or use the .NET CLI:
```bash
dotnet build
```
### Run the application: You can run the project directly from Visual Studio or use the .NET CLI:
```bash
dotnet run
```

## Usage

* When the application starts, you will be prompted to select your current floor.Enter G for the ground floor or a number between 1 and 15 for other floors.
* Enter the number of passengers who will be entering the elevator.
* The system will assign one or more elevators to accommodate the passengers. You will be informed which elevators are moving to your floor.
* Once the elevator(s) arrive, you will be prompted to select your destination floor.
* After reaching the destination, you will be asked to specify how many passengers are exiting the elevator.
* The system will continue running, allowing you to perform additional operations or exit by pressing E.

## Code Structure
* Program.cs: Contains the main application logic, handling user input, elevator assignment, movement, and the drawing of the building and elevator status.
* ElevatorStatus.cs: An enum that defines the possible statuses of an elevator (Idle, MovingUp, MovingDown).
* IElevator.cs: An interface that outlines the properties and methods required for all elevator types.
* Elevator.cs: An abstract class that implements the IElevator interface. It provides the basic properties of an elevator, such as Id, CurrentFloor, CurrentPassengers, and Status.
* PassengerElevator.cs: A class that represents a standard passenger elevator. It inherits from Elevator and implements specific movement logic.
* HighSpeedElevator.cs: A class that represents a high-speed elevator. It inherits from Elevator and implements specific movement logic.
* GlassElevator.cs: A class that represents a glass elevator. It inherits from Elevator and implements specific movement logic.
* ElevatorFactory.cs: A factory class used to create instances of different types of elevators based on the provided type.

## Future Improvements
* Custom Elevator Logic: Extend the movement logic for each elevator type to include specific behaviors, such as different speeds for the HighSpeedElevator.
* Building Visualization: Enhance the DrawBuilding method to provide a more detailed and visually appealing representation of the building and elevator positions.
* Elevator Scheduling: Implement a more sophisticated elevator scheduling algorithm that considers multiple factors like traffic patterns and peak hours.
* Elevator Scheduling: Implement a more sophisticated elevator scheduling algorithm that considers multiple factors like traffic patterns and peak hours.
* Multi-User Simulation: Extend the simulation to support multiple users interacting with the system simultaneously.
* UI Implementation: Develop a graphical user interface (GUI) to improve user interaction and visualization.

