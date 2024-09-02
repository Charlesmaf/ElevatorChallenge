using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IElevator
    {
        int Id { get; set; }
        int CurrentFloor { get; set; }
        int CurrentPassengers { get; set; }
        ElevatorStatus Status { get; set; }

        void MoveToFloor(int floor);
    }
}
