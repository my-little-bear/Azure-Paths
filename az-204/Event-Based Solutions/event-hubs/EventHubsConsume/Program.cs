﻿using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;

using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;

namespace EventHubsConsume
{
    class Program
    {
        const string connectionString = "Endpoint=sb://mynamespace-ns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8e5MB7yBTUj7XhqXzijhLnkajNYEq0woQWGCNq94N98=";
        const string eventHubName = "myeventhub-hub";

        const string consumerGroup =
            EventHubConsumerClient.DefaultConsumerGroupName;

        static async Task Main(string[] args)
        {
            //await GetPartitionInfo();

            var readZero = ReadFromPartition("0");
            var readOne = ReadFromPartition("1");
            var readTwo = ReadFromPartition("2");
            var readThree = ReadFromPartition("3");

            await Task.WhenAll(readZero, readOne, readTwo, readThree);
        }

        static async Task ReadFromPartition(string partitionNumber)
        {
            var cancelToken = new CancellationTokenSource();
            cancelToken.CancelAfter(TimeSpan.FromSeconds(120));

            await using (var consumerClient =
                new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
            {
                try
                {
                    PartitionProperties props =
                        await consumerClient
                            .GetPartitionPropertiesAsync(partitionNumber);

                    EventPosition startingPosition =
                        EventPosition.FromSequenceNumber(
                            // props.LastEnqueuedSequenceNumber
                            props.BeginningSequenceNumber
                        );

                    await foreach (PartitionEvent partitionEvent in consumerClient
                        .ReadEventsFromPartitionAsync(partitionNumber, startingPosition, cancelToken.Token))
                    {
                        Console.WriteLine("***** NEW COFFEE *****");

                        string partitionId = partitionEvent.Partition.PartitionId;
                        var sequenceNumber = partitionEvent.Data.SequenceNumber;
                        var key = partitionEvent.Data.PartitionKey;

                        Console.WriteLine($"Partition Id: {partitionId}{Environment.NewLine}Sequence Number: {sequenceNumber}{Environment.NewLine}Partition Key: {key}");

                        var coffee = JsonSerializer
                            .Deserialize<CoffeeData>(partitionEvent.Data.Body.Span);

                        Console.WriteLine($"Type: {coffee.CoffeeType}{Environment.NewLine}Temp: {coffee.WaterTemperature}{Environment.NewLine}Date: {coffee.ReadingTime.ToShortDateString()}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    await consumerClient.CloseAsync();
                }
            }
        }

        static async Task GetPartitionInfo()
        {
            await using var consumerClient =
                new EventHubConsumerClient(consumerGroup, connectionString, eventHubName);

            var partitionIds = await consumerClient.GetPartitionIdsAsync();

            foreach (var id in partitionIds)
            {
                var partitionInfo = await
                    consumerClient.GetPartitionPropertiesAsync(id);

                Console.WriteLine("***** NEW PARTITION INFO *****");
                Console.WriteLine($"Partition Id: {partitionInfo.Id}{Environment.NewLine}Empty? {partitionInfo.IsEmpty}{Environment.NewLine}Last Sequence: {partitionInfo.LastEnqueuedSequenceNumber}");
            }
        }
    }
}
