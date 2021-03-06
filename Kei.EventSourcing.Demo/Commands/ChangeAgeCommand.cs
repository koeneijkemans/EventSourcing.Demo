using System;

namespace Kei.EventSourcing.Demo.Commands
{
    public class ChangeAgeCommand : Command
    {
        public ChangeAgeCommand(Guid id, int age)
        {
            AggregateRootId = id;
            Age = age;
        }

        public int Age { get; set; }
    }
}
