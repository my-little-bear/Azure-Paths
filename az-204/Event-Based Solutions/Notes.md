# Event-Based solutions

Azure offers three event services

## Event types

1. Descrete -> repost state changes and are actionable. (Event Grid)
2. Series -> time ordered and analyzable events such as conditions, time-ordered, and analyzable. (EventHub)
3. Notification -> prompt user or their device for attention

# Event Grids

Event-based architctures (pub / sub) where subscribers consume the messages. Support many subscribers to one publisher and subscribers can place filters to get specific events. 

Scalable up and down up to zero.

Event Grid needs to be enables as such

```sh
az provider register --namespace Microsoft.EventGrid

az provider register --namespace Microsoft.EventGrid --query "registrationState"
```

## Pub/Sub Concepts

An event signifies something has changed. Publisher has no expectation on what the subscribers performs.

- Event -> describes what happened with the smallest amount of data.
- Publishers -> its the entity that created the event and it tells azure, something happened.
- Topics -> event grid construct and endpoint to to fetch events
- Subscriptions -> event grid routes and filters events to handlers.
- Handlers -> apps that consume events.

Several azure service push events to the event hubs such as: app config, service bus, media services, logic apps, etc.

Custom topics can be userdefined and 

**Event Handlers** are any application that is able to consume events from the event grid. Azure functions, event hubs, storage queues, webhooks, etc.

When creating an event grid solutions:

1. Create a topic for related events.
2. Publisher app needs to create events.
3. Add subscriber info with filtering.

# Event Hubs

Scalable event ingestion service, perfect for big data scenarios for IoT scenario. Daecouples the sending and recieving data. Integrations with non-azure services. Capture events in blob storage.

Scenarios include:

1. Telemetry data capture
2. Data archival
3. Transaction processing
4. Anomaly detection

Component for event hubs include the following:

1. Namespace -> container of 1 or more event hubs
2. Event producers -> send data to event hubs
3. Partitions -> bucket of messages
4. Consumer Groups - > a view of the event groups
5. Subscribers / Consumers -> 

## Event Hub Namespace

Its a scoping container where one or more event hubs can reside. Options apply to all event hub units. **Throughput** units

You need to create the event hub namespace prior to creating the actual event hub:

```sh
# Create namespace
az eventhubs namespace create -g <resource-group> --location <location> /
-n <name>
--sku Standard

# Create event hub
az eventhubs eventhub create --name <eventhubname> /
    --namespace <name> /
    --message-retention 3 / # Default is 7 days
    --partition-count 4 / # default is 4
    -g <resource-group-name>
```

Event Hub sku can be **Standard** or **Basic**.

## Partitions on Event Hubs

Its a bucket for event messgaes that are held in a time-ordered fashion as they arrive. Events not deleted once read.

Event hubs decide which partition the events are sent if it is not specified.

``` csharp
// SendEventOptions
var options = new SendEventOptions();
options.PartitionKey = "device1";
```

# Azure Notification Hubs (ANH)

Means by which you can send push notifications to users.
- Cross platform
- Multiple delivery formats
- Telemetry
- Scalable

## Hubs and Namespaces
Namespace is a collection of notification hubs. Usually we create:
- one namespace per application
- one hub per app environment (dev / prod)
- Access hubs via credentials
- billing is at the hub level



