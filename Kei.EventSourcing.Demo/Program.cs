using Kei.EventSourcing.Demo.Commands;
using Kei.EventSourcing.ServiceCollectionExtension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Kei.EventSourcing.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build(); ;

            ServiceCollection collection = new ServiceCollection();
            collection.AddEventSourcing();
            collection.AddTransient<IEventStore, AzureTableStorageEventStore.AzureTableStorageEventStore>(factory =>
            {
                return new AzureTableStorageEventStore.AzureTableStorageEventStore(
                    config.GetSection("AzureTableStorage")["ConnectionString"],
                    factory.GetService<EventPublisher>());
            });

            ServiceProvider provider = collection.BuildServiceProvider();

            using (var scope = provider.CreateScope())
            {
                CommandHandler handler = scope.ServiceProvider.GetService(typeof(CommandHandler)) as CommandHandler;

                Guid rootId = Guid.NewGuid();
                CreatePersonCommand createKoen = new CreatePersonCommand(rootId, "koen", 30);
                ChangeNameCommand changeNameToKoen = new ChangeNameCommand(rootId, "Koen");
                ChangeAgeCommand changeAgeTo31 = new ChangeAgeCommand(rootId, 31);
                ChangeAgeCommand changeAgeTo32 = new ChangeAgeCommand(rootId, 32);

                handler.Handle(createKoen);
                handler.Handle(changeNameToKoen);
                handler.Handle(changeAgeTo31);
                handler.Handle(changeAgeTo32);

                StateConnector stateConnector = scope.ServiceProvider.GetService(typeof(StateConnector)) as StateConnector;
                Person koen = stateConnector.Get<Person>(rootId);

                Console.WriteLine(koen);
                Console.ReadKey();
            }
        }
    }
}
