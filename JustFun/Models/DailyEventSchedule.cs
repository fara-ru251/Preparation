using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    internal sealed class DailyEventSchedule
    {
        private EventData[] _eventDatas;

        public DailyEventSchedule(EventData[] eventDatas)
        {
            this._eventDatas = eventDatas;
        }


        public void PrintGroupedEvents()
        {
            List<List<EventData>> groupedEvents = new List<List<EventData>>();

            Array.Sort(this._eventDatas);




            int j = 0;
            DateTime min_time = DateTime.MinValue;

            for (int i = 0; i < _eventDatas.Length; i++)
            {
                //first element, just skip after
                if (i == 0)
                {
                    groupedEvents.Add(new List<EventData>() { _eventDatas[i] });
                    min_time = _eventDatas[i].EndTime;
                    continue;
                }

                if (min_time > _eventDatas[i].StartTime) // intersects
                {
                    groupedEvents[j].Add(_eventDatas[i]);

                    min_time = new DateTime(Math.Max(min_time.Ticks, _eventDatas[i].EndTime.Ticks));
                }
                else
                {
                    groupedEvents.Add(new List<EventData>() { _eventDatas[i] });
                    min_time = _eventDatas[i].EndTime;
                    j++; //increment
                }
            }

            //print results
            for (int i = 0; i < groupedEvents.Count; i++)
            {
                Console.WriteLine(i + ": ");
                var inner_events = groupedEvents[i];

                for (int k = 0; k < inner_events.Count; k++)
                {
                    Console.WriteLine("\t" + inner_events[k].StartTime + " - " + inner_events[k].EndTime);
                }
            }
        }


        #region Nested Classes
        internal sealed class EventData : IComparable<EventData>
        {
            public DateTime StartTime { get; private set; }
            public DateTime EndTime { get; private set; }

            public EventData(DateTime startTime, DateTime endTime)
            {
                this.StartTime = startTime;
                this.EndTime = endTime;
            }

            public int CompareTo(EventData other)
            {
                if (this.StartTime > other.StartTime)
                {
                    return 1;
                }
                if (this.StartTime < other.StartTime)
                {
                    return -1;
                }

                return 0;
            }
        }
        #endregion

    }
}
