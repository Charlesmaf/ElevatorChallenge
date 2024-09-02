﻿
using Application.Entities;
using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SpecificElevators
{
    public class GlassElevator : Elevator
    {
        public GlassElevator(int id, int currentFloor)
        {
            Id = id;
            CurrentFloor = currentFloor;
            Status = ElevatorStatus.Idle;
            CurrentPassengers = 0;
        }
        public override void MoveToFloor(int floor)
        {
            // Implement the logic for moving a glass elevator
        }
    }
}