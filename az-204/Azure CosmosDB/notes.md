# Notes

Always make sure to create a cosmosdb account before creating the database instance.

- az cosmosdb create --name <your-account-name> --resource-group <your-rg>

- create a sql database: az cosmosdb sql database create --acount-name <your-account-name> --name <db-name>

# Selecting an SDK

- when using the SQL api, utilize the cosmos db latest sdk
- if you are using a different API such as MongoDB, Cassandra, etc... download the correct SDKs
- understand the differences of usin the Azure Table API.

# CosmosDB Performance

- Vertical Scaling --> adding more resources to the current server
- Horizontal Scaling --> spreading the demand accross servers

**Request Unit (RU)** --> consolidate the vertical / horizontal scaling operations. One RU == 1kb item read operation from a container. This encapsulates:

- CPU
- Memory
- I / O per second

Throughput can be set either **provisioned** or **serverless**.
- Provisioned --> good for an always on provisioned implementation and can be configured on the database. Throughput is evenly distributed to the partitions. Required 10RUs per GB of storage. Once RUs are consumed for a partition, future requests will be rate limited. This requires a manual scaling approach. **AutoScaling** can be setup but the minimum thoughput is **10%** of the maximum. This is good for prod and not DEV 

- **Serverless** --> good for on / off workloads such as development workloads. This has a max of 5000 RUs requires a new ccount and only works with SQL api.

# Best Practices

- use a partition key strategy.
- set the throughput at the container level.
- use serverless for dev
- understand the link between consistency types and RUs consumed.

# Data Consistency Levels

- Eventual --> lower latency / higher throughput / higher availability: guarantees for the order of data.
- Consisten Prefix --> guarantees that the updates are returned in order.
- Session --> guarantees that the client session will read it own writes.
- Bounded Stateless --> read has a max lag.
- Strong --> higher latency / lower throughput / lower availability: this guarantess the most recent version of an item.

# Cosmos DB Partitions

**Partition Key** serves as the means of routing your request to the partition. Made up of both the key and the value. Is a value that does not change on the value. **CosmosDB** uses hash-based partitioning to sprea logical partitions accross the physical partition.

***MAKE SURE THE PARTITION KEY IS A VALUE THAT DOESN'T CHANGE***

***HOT-PARITIONING*** when a partition holds most of the data. It is best to distribute the data along multiple partitions. 

**Strategy COnsiderations**:
- Throughput is distributed evenly accross partitions.
- Milti-item transactions require triggers or stored procedures.
- You will want to minimize cross-partition queries for heavier workloads

- Logical Partition --> items on the container that share the same partition key.
- Physical Partition -->
- Partition Key
- Replica Set --> multiple replicas of the data. By having data replicated.

# Server Side Capabilities

- **Stored Procedures** --> must be defined on JavaScript and are single partition. Parititon Key **must** be provided. Supports transactional model.
- **Triggers** --> must be defined with JS. These are done PRE adn POST triggers. This operate on a single partition. These are not guatanteed to execute as they have to be specified. Allows for rollback on POST trigger.
- **User Defined Funcitons (UDFs)** --> defined on JS. Define a custom function to encapsulate a query.
- **ChangeFeed** --> enables notification on insert and data upate. Deletes are not supported but you can leverage a soft-delete flag (use a field to set it to "isDeleted"). A change will appear only **ONCE** on the feed. Partition updated will be in order, but between partitions there is no guarantee.  



