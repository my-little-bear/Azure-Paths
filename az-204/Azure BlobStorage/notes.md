# Develop solutions that use Blob Storage

- Interact with data using the appropriate SDK
- Set and Retrieve properties and metadata
- Implement data archiving and retension
- Implement hot, cool and archive storage
- Move items in blob storage between storage accounts and containers

# Blob Storage Overview

Object storage from the cloud that is able to store unstreuctured data such as:

- Text files, binary files, logs, virtual disks, images and more.

# Understand the storage account, blobs and containers

You create a storage account which contains **blob containers**. All this is accessed via https:

https://<storageaccountname>.blob.core.azureapp.net

Virtual directories can be established based on the naming of the files. For example: if a file is named "design/logo.png" and it is stored within the "images" container, you can access it by:

https://<storageaccountname>.blob.core.azureapp.net/images/design/logo.png

```ps1
az storage account create
--name <storageaccountname>
--resource-group <yourresourcegroup>
[--location westeurope]
[--sku Standard_RAGRS]
[-- StorageV2]
```

# Authorization

Blob storage by default is private and cannot be accessed anonymously. The following are the wasys to secure access to the storage account:

1. Shared Key
2. Shared Access Signature (SAS)
3. AAD
4. Anonymous Public Read Access

# Blob Storage Types

When a file is uploaded to the container the following types can be selected depending on the need.

Block Blob --> good for files where full file replacement needs to be done. Example: complete documents, images, video, etc.

Append Blob --> good files that require us to append information to it such as logs.

Page Blob --> for random read and write scenarios such as uploading isos, vhds, and disk files.

# Storage Account Kinds

Storage V2 --> general purpouse account. Supports Blob, file, queue and table.

Premium --> accounts of this type only support one kind of file type: Block blobs, file shares and page blobs.

# Replication Strategies

LRS --> This is the cheapest option of them all. Data is replicated under the same region in the same availability zone.

GRS --> geo redundant storage. Data is replicated in a secondary region close to the primary region.

ZRS --> zone redundant storage. It is replicated acros 3 availability zones on the same region. This is not supported on all regions.

You can only read from the primary region. If the primary region goes down you must perform a **FAILOVER** to make the secondary region the primaryu region. **Failovers** take up to 1hr.

RA_GRS and RA_GZRS --> if you want to set your secondary region as the read region, **READ ACCESS** geo redundant access. This will set the secondary region as the only read region.

https://<storage-account>-<secondary>.blob.core.windows.net

StorageV2 allows for all 6 replication strategies:

- LRS
- GRS
- ZRS
- GZRS
- RA-GRS
- RA-GZRS

Premium allows for LRS and ZRS since they use SSDs in the backend.

# Blob metadata

The blob container has several system properties. The properties that are good to memorize:

- eTag
- Last Modified

The containers / blobs can have user defined metadata as key-value pairs.

# Access Tiers

- Hot --> used for frequent accessed data.
- Cool --> infrequent accessed data, usually at at least 30 days
- Archive --> data can be archived for 180 days.

You can setup the default access tear from the storage account as hot or cool only.

On individual blobs, you can set the access tier as **hot, cool or archive**.

The reason **storage accounts** dont allow for **archive** access tier is because **archive** access sets the data of the file offliine. Metadata of the file can be retrieved but not the data itself. You need to move the access tier back to cool or active, this is called **rehydrating**.

**ONLY** astorageV2 blob storage support access tiers.

# Lifecycle Management

You can navigate to the "Lifecycle Management" and azure will run the rules within once a day to perform the operations such as: move to cool, move to hot or delete the blob.

# Data Protection

Allows you to set rules such as soft deletes, point time restore, versioning, change feed and more. Soft delete allows you to retain snapshots and versions of a blob.

- Blob versions --> track changes on a blob.
- Blob snapshots --> saves a version of the snapshot in a point in time.

# Leases

When you want a specific blob to only be changed by a specific entity you can **apply a lease** on the blob. This will provide an ID which will make the blob changes only available if the ID is used.
