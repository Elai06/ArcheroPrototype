using System;

namespace _Project.Scripts.Infrastructure.PersistenceProgress
{
    public class TimeModel
    {
        public event Action<int> Tick;
        public event Action<TimeModel> Stopped;

        public TimeProgress TimeProgress;

        public bool IsWork { get; set; } = true;

        public TimeModel(TimeProgress progress, int time)
        {
            TimeProgress = progress;
            TimeProgress.Time = time;
        }

        public void AboutTick()
        {
            if (!IsWork)
            {
                return;
            }
            
            TimeProgress.Time -= 1;
            
            Tick?.Invoke(TimeProgress.Time);

            if (TimeProgress.Time <= 0)
            {
                StopTimer();
            }
        }

        public void StopTimer()
        {
            Stopped?.Invoke(this);
            IsWork = false;
        }
    }
}