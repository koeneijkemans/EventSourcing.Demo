using System;

namespace Kei.EventSourcing.Demo.Events
{
    public class PersonCreatedEvent : Event
    {
        public PersonCreatedEvent()
        {
        }

        public PersonCreatedEvent(Guid id, string name, int age)
        {
            AggregateRootId = id;
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
