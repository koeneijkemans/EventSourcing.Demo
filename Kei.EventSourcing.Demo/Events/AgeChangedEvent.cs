using System;

namespace Kei.EventSourcing.Demo.Events
{
    public class AgeChangedEvent : Event
    {
        public AgeChangedEvent()
        {
        }

        public AgeChangedEvent(Guid id, int age)
        {
            AggregateRootId = id;
            Age = age;
        }

        public int Age { get; set; }
    }
}
