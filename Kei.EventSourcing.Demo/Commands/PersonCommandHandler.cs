using Kei.EventSourcing.Demo.Events;

namespace Kei.EventSourcing.Demo.Commands
{
    public class PersonCommandHandler : ICommandHandler<CreatePersonCommand>,
        ICommandHandler<ChangeNameCommand>,
        ICommandHandler<ChangeAgeCommand>
    {
        private readonly StateConnector stateConnector;

        public PersonCommandHandler(StateConnector stateConnector)
        {
            this.stateConnector = stateConnector;
        }

        public void Handle(CreatePersonCommand command)
        {
            Person existingPerson = stateConnector.Get<Person>(command.AggregateRootId);

            if (existingPerson == null)
            {
                PersonCreatedEvent personCreated = new PersonCreatedEvent(command.AggregateRootId, command.Name, command.Age);
                stateConnector.Save(personCreated);
            }
        }

        public void Handle(ChangeNameCommand command)
        {
            Person existingPerson = stateConnector.Get<Person>(command.AggregateRootId);

            if (existingPerson != null)
            {
                NameChangedEvent nameChangedEvent = new NameChangedEvent(command.AggregateRootId, command.Name);
                stateConnector.Save(nameChangedEvent);
            }
        }

        public void Handle(ChangeAgeCommand command)
        {
            Person existingPerson = stateConnector.Get<Person>(command.AggregateRootId);

            if (existingPerson != null)
            {
                AgeChangedEvent ageChangedEvent = new AgeChangedEvent(command.AggregateRootId, command.Age);
                stateConnector.Save(ageChangedEvent);
            }
        }
    }
}
