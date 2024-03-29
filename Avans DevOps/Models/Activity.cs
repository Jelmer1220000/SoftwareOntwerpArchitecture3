﻿namespace Avans_DevOps.Models
{
    public class Activity
    {
        public string name { get; set; } = "";
        public string description { get; set; } = "";
        private bool _isDone = false;

        public Activity(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public bool SetActivityState(bool  isDone)
        {
           return _isDone = isDone;
        }

        public bool isActivityDone()
        {
            return _isDone;
        }
    }
}
