using System;

namespace Kei.EventSourcing.Demo.Commands
{
    public class ChangeNameCommand : Command
    {
        public ChangeNameCommand(Guid id, string name)
        {
            AggregateRootId = id;
            Name = name;
        }

        public string Name { get; set; }
    }
}
