using Kei.EventSourcing.Demo.Events;

namespace Kei.EventSourcing.Demo
{
    public class Person : AggregateRoot
    {
        public Person()
        {
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"Hi, my name is {Name} and i'm {Age} years old.";
        }

        private void Apply(PersonCreatedEvent @event)
        {
            Name = @event.Name;
            Age = @event.Age;
        }

        private void Apply(AgeChangedEvent @event)
        {
            Age = @event.Age;
        }

        private void Apply(NameChangedEvent @event)
        {
            Name = @event.Name;
        }
    }
}
