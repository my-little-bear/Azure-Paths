# Develop for AzureStorage

It is **15-20%** of the following:

## Solutions that use CosmosDB storage

- Select the appropriate API and SDK
- Implement partitioning schemes and partition keys.
- Perform operarions on data and CosmosDB containers.
- Set appropriate consistency level of operations.
- Manage change feed on notifications

- Be able to select an API for the CosmosDB based scenario.
- Be able to select a consistency level for CosmosDB.
- Understand serverside execution code (triggers, procedures, UDFs, change feed notifications)
- Understand how to implement partition strategy
- Select redundancy options

Supported CosmosDB APIs

1. SQL
2. Cassandra
3. MongoDB
4. Gremlin --> good for something that uses connected data and relationship mappings for GRAPH database.
5. AzureTable

**SQL** is the core API.

- Understand the consistency level of the database spectrum

Eventual---Consistent---Prefix---Session---BoundedStaleness-----Strong

Serverside operations are Javascript based: StoredProcedures, Triggers, UDFs and ChangeFeed

## Solutions that use Blob Storage

- Move items in blob storage between storage accounts or containers
- Set and retrieve properties and metadata of blobs.
- Perform operations on data by using the appropriate sdk.
- Implement storage policies and data archiving and retention.

- Know the steps of copying data between storage accounts
- Review differences between v1 and v2 storage acct.
- Examine the capabilities of change feed for blob storage.
- Archive lyfecicle
- Data redundancy

Data Access Tiers: Hot, Cool, Archive

Data Rehydration:

- Standard Priority --> 5min to 15 hours depending on the size of the data that needs to be restored.
- High Priority --> takes less time.
