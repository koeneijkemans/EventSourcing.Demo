using System;

namespace Kei.EventSourcing.Demo.Events
{
    public class NameChangedEvent : Event
    {
        public NameChangedEvent()
        {
        }

        public NameChangedEvent(Guid id, string name)
        {
            AggregateRootId = id;
            Name = name;
        }

        public string Name { get; set; }
    }
}
