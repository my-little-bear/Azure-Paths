﻿using System;
using System.Threading.Tasks;

using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.EventGrid;

namespace SendEvent
{
    class Program
    {

        async static Task Main(string[] args)
        {
            string endpoint = "https://mycustomeventgrid.westus-1.eventgrid.azure.net/api/events";
            string key = "TFAiBuzcGL7LfGU3LhuuG0CaLvsuehtwfIM0F3BX3xQ=";
            string topicHostName = new Uri(endpoint).Host;

            EventGridEvent acct = new EventGridEvent(
                id: Guid.NewGuid().ToString(),
                subject: "New Account",
                data: new { Message = "hi" },
                eventType: "NewAccountCreated",
                eventTime: DateTime.Now,
                dataVersion: "1.0");

            TopicCredentials credentials = new TopicCredentials(key);

            EventGridClient client = new EventGridClient(credentials);

            await client.PublishEventsAsync(topicHostName, new EventGridEvent[] { acct });
        }
    }
}
