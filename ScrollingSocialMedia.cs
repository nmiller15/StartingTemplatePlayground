using System;
using Services.Interfaces;

namespace Services
{
    public class ScrollingSocialMedia : ITimeWaster
    {
        private readonly string[] _activities = new[]
        {
            "Scrolling through Instagram",
            "Watching TikTok videos",
            "Checking Facebook updates",
            "Browsing Twitter feeds",
            "Watching YouTube shorts"
        };

        public string WasteTime()
        {
            var random = new Random();
            int activityIndex = random.Next(_activities.Length);
            int minutesWasted = random.Next(1, 61); // Random number of minutes between 1 and 60
            return $"{_activities[activityIndex]} for {minutesWasted} minutes.";
        }
    }
}


