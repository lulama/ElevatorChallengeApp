﻿using ElevatorChallengAPI.Shared;

namespace ElevatorChallengAPI.Domain
{
    public class Building : AuditDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Elevator> Elevators { get; set; } = [];

        public Building()
        {
            
        }

        public Building(int id, string name, string address, List<Elevator> elevators)
        {
            Id = id;
            Name = name;
            Address = address;
            Elevators = elevators;
        }
    }

    
}