# Message Based Solutions In Azure

## Why App Messaging?

- Encourages application logic modulatiry and create the data in chunks.
- Fault tolerance between modules since when one module is down other services may NOT go down.

## Azure Queue Storage
Fully managed service that is part of the azure storage suite that enabled durable and configurable messages queues to enable application modularity and fault tolerance.

- Requires an **Azure Storage Account* with (general-purpose v2)*.
- Queues are created within a single storage account
- Supports messaging up to 64KiB.
- Message exists within a single queue
- Number of messages is limited only by the size of the storage acct
- Support a configurable time-to-live per message (with the default at 7 days)

Data redundancy is the same as the storage acct level.


### Queue URL structure:

https://**<storage-account-name>**.queue.core.windows.net/**<queue-name>**

### Queue Security 

Data in queues is encrypteed by default. Storage account SAS works with the queue.

### Visibility Timeout
Messages are delived to consumers but are not immediately deleted from the queue. However, messages will not be visible in the queue again until a period of time has passed from initial delivery. This period of time is the **visibility timeout** and it enables fault tolerance for your applications.

- A single queue has a capacity of 500TiB.
- A single message cannot exceed 64KiB.
- A queue supports no more than 5 stored accsss policies
- A single queue can support up to 2000 messages per second.

Create / Delete / Peek / Clear queue:
```ps1
az storage queue create --name <queue-name>
az storage queue delete --name <queue-name>
azure storage message oeek --queue-name <my-message>
```

## Azure Service Bus
Fully-managed enterprise message broker service that eanbles multiple modes of messaging with integrations with common messaging systems including JMS.

Supports:
- Ordering
- Batching
- Dead Letter queue
- Duplicate Detection

### Basic Tier
Only supports queues and no topics. Good for testing

### Standard Tier
- Pay as you go
- Variable throughput and variable latency
- does not support geo-disaster recovery.
- auto scaling

### Pricing Tiers
- fixed pricing
- fixed troughput
- Dedicated resources
- Scaling rules are configurable
- Support up to 1MB messages
- Support availability zones

### Message Ordering
Support FIFO ordering by leveraging sessions. This should be enabled on th equeue or topic.

Service bus supports partitioning of queues and topics. Partitioning enables stores and brokers for single entity. Partitioned queues and topics can use a partition key to determine the partition.

**Note:** If you are making use of transactional operations use a partition key.

Dead-Letter Queue -> enables you to capture the messages that were not acted upon on their lifetime and act accordingly on those messages.


# Selecting the correct Messaging solutions

Queue Storgae:
- Storage queues need to be over 80GB
- track progress of message processing

Service Bus:
- support for messages without polling
- need guaranteed processing order (fifo)
- require one-to-many infrastrcuture (topics)

```
az servicebus queue create --namespace-name <your-namespace> --name <queue-name> --resource-group <rg>

az servicebus queue delete --namespace-name <your-namespace> --name <your-queue>
```

## Azure Service Bus Tipcs

Enables one-to-many relationship with messages and consumers. Subscriptions in a topic worka s dedicated queues for a subscriber with configuration options. Topics can be filtered:
- boolean filters
- SQL filters
- Correlation filters

``` sh
az servicebus topic create --namespace-name <service-bus-name> --name <topic-name> -g <rg-name>
az servicebus topic delete --namespace-name <service-bus-name> --name <topic-name>
az servicebus topic subscription create  --namespace-name <service-bus-name> --topic-name <topic-name> --name <subscription-name>
```