# Objectives

1. Integrate cachine and content delivery solutions

- configure cache and expiration policies for azure redis cache.
- Implement secure and optimized application cache patterns including data sizing, conenctions, encryptions and expiration

2. Instrument solutions to support monitoring and logging

- Configure an app service to use app insights
- Analyze and troubleshoot solutions by using azure monitor
- implement app insights web tests and alerts

# Azure Redis Cache Review

Azure redis cache use cases

- Database caching
- user session storage for distributed apps
- content caching
- distributed transaction
- message broker

## Cache tier considerations:

Always consider cache size, network performance, number of client connections.

1. Basic -> NO SLA
2. Standard -> SLA, moderate and high performance network
3. Premium -> passive geo-replication, low-high net performance
4. Enterprise -> supports redis search
5. Enterprise Flash -> support redis on flash drives, supports

Encryption is placed by default with TLS 1.1, TLS 1.1, TLS 1.2. Encryption can be disabled.

Removing items on the cache can be deleted with the:
- TTL
- Manual Deletion
- Eviction --> only when in memory presure is applied on the cache.

## Eviction policies
- Least recently used value (default)
- allkeys-LRU
- NO eviction -> no values will be evicted
- volatile-random
- allkeys-random
- volatile-ttl 

## Configuration Best practices for Redis Cache
1. Set the maxmemory reserved setting
2. Reuse client connections whenever possible
3. Use redis pipelining
4. Store small value

# Review Monitoring and Logging
Areas of focus
1. Enabl app service logging
2. Transient faults
3. configure docker containers
4. Web test alerts

## Enable webapp login
``` sh
# Works for both linux and windows
az webapp log config --name sampleWebApp 
--resource-group sampleResourceGroup 
--web-server-logging sampleResourceGroup

# Only works for windows
az webapp log config --name sampleWebApp
--resource-group sampleResourceGroup
--application-logging sampleAzureBlobStorage

# Configure logs to go within the docker filesystem
az webapp log config --name sampleWebApp
--resource-group sampleResourceGroup
--docker-container-logging filesystem

# Tail logs from app service
az webapp log tail --name sampleWebApp
--resource-group sampleResourceGroup

# Tail and filter
az webapp log tail --name sampleWebApp
--resource-group sampleResourceGroup
--filter Error
```

## Transient Faults
Any fault that is likely self-correcting.

Apps should be able to log transientfaults and have a retry strategy. Retry is mostly set on SDKs. Make sure to always implement architectural patterns that deal with transient faults: retry pattern, circuit breaker 

## Docker ENV vars for App Service

**WEBSITES_CONTAINER_START_TIME_LIMIT** -> set the amount of time the platform will wait before it restarts your container

**WEBSITES_ENABLE_APP_SERVICE_STORAGE** -> if not set to true, the /home directory will be shared accross container instances and files will persist

**WEBSITES_WEBDEPLOY_USE_SCM** -> deploy container-based web application using WebDeploy/MSDeploy, this value must be set to false.


