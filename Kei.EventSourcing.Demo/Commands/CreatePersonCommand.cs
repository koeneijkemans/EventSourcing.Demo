using System;

namespace Kei.EventSourcing.Demo.Commands
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand(Guid id, string name, int age)
        {
            AggregateRootId = id;
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
