using Application.Enums;
using Application.Interfaces;
using Application.Services;
using Infrastructure.SpecificElevators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTests
{
    public class ElevatorControlServiceTests
    {
        [Fact]
        public void AssignElevators_ShouldAssignClosestIdleElevator()
        {
            // Arrange
            var elevators = new List<IElevator>
            {
                new PassengerElevator(1, 0),
                new HighSpeedElevator(2, 5),
                new GlassElevator(3, 10)
            };
            var service = new ElevatorControlService(elevators);

            // Act
            var result = service.AssignElevators(6, 3);

            // Assert
            Assert.Single(result);
            Assert.Equal(2, result[0].Id);
        }

        [Fact]
        public void MoveElevator_ShouldMoveElevatorToTargetFloor()
        {
            // Arrange
            var elevator = new PassengerElevator(1, 0);
            var elevators = new List<IElevator> { elevator };
            var service = new ElevatorControlService(elevators);

            // Act
            service.MoveElevator(elevator, 10);

            // Assert
            Assert.Equal(10, elevator.CurrentFloor);
            Assert.Equal(ElevatorStatus.Idle, elevator.Status);
        }

    }
}
