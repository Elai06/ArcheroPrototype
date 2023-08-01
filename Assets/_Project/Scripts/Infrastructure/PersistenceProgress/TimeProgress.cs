using System;

namespace _Project.Scripts.Infrastructure.PersistenceProgress
{
    [Serializable]
    public class TimeProgress
    {
        public string ID;
        public int Time;

        public TimeProgress(string id, int time)
        {
            ID = id;
            Time = time;
        }
    }
}