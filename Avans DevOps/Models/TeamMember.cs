﻿namespace Avans_DevOps.Models
{
    public class TeamMember
    {
        private string Name { get; set; } = "";


        public TeamMember(string name) 
        {
            Name = name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetName() { return Name; }
    }
}
