# Integrate Caching and Content Delivery

What is a content delivery network?

- A CDN is a globally distributed network.
- Reduced asset load times
- Reduced hosting bandwidth
- Increased availability and redundancy
- Protection against DDoS

Content Types:
1. Static Content
2. Dynamic Content

## Azure CDN Catching

Caching Rules have 3 types: ()

- Global --> one rule per endpoint on the CDN. Overrides any cache headers
- Custom --> one or many rules that can beapplied to a specific path or filetype. Overrides the global rules.
- QueryString --> controls how requests that contains query strings within the URL. Default scenario is to ignore the query string. Bypass query string and request from the original server. Cache every unique URL.


# Azure Redic Cache Policies and Cache

Pricing tier:

1. Basic --> no SLA, Minimal Feature Set, only used testing
2. Standard --> SLA 99.9%, 2 nodes, 53GB memory, 20k clients
3. Premium
4. Enterprise --> 
5. Enterprise Flash --> fast non-volatile storage.

YOU CANNOT SCALE DOWN RedisCache

## Understanding caching
The reason caching is done is to improve the performance and scalability, move frequent accessed data closer to locations, improved response time.

When should we cache?
- Repeatedly accessed data
- data source performance --> reading from DB is way slower than cached data.
- data connection availability
- location

## Managing lifetime in redis cache
- No default expiration is set on the cache.
- need to set the TTL on the for the expiration time.

Consider the "rate of change" and the "risk of outdated data"

## Redis Cache Best Practices

- Watch out for data loss since it is an in-memory database. Keys may not be there.
- Set expiry times to manage content lifetime.
- Add jitter to spread database load --> vary the expiry time of objects
- Avoid caching large objects. Storing large data can lead to timeouts.
- Host redis in the same region as your application. 

# Common Caching Patterns

Application performance is what draws people for caching as well as scalability and resilience.

## Cache-Aside Pattern
Store the most recent data to the cache system.
1. Does the data exist on the cache?
2. If not, retrieve data from data store
3. Store a copy in the cache.

## Content Cache pattern
Cache static content such as images, templates, style sheets.
Reduces server load

## User Session Caching
Maintain application state using something like session cookies or local storage.

## Advanced Patterns
1. Job and Message Queueing
2. Distributed Transactions


# Configuring Redis Cache for Optimization
- Number of concurrent cached objects
- Size of the cached objects
- Number of cache requests
- Cache expiration policy 

Redis offers TLS for encryption in transit.

Redis encryption is not encrypted. On premium tier, you can backup the data on a storage account and encrypted.

