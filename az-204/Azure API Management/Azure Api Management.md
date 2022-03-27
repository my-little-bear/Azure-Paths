# Azure API Management

Azure service to create consisten and modern api gateways for existing backend-services. Provides secure, scalable API access to the application.

API gateways provides a single surface to the backend apis for centralized distribution of requests.

1. Accepts api call and routes them to your services
2. Verify API keys, JWT tokens, certificates and other credentials.
3. Enforce quota usage and rate limits.
4. Cache backend responses.

## Azure Port Capabilities

1. Define or import api schema
2. Setup policies like quotas or transformations on the APIs
3. Package APIs into products
4. Manage user access.

## Developer Portal Capabilities
1. Read api documentation
2. create an account to subscrube to get api keys
3. Try out the api via console
4. Access to analytics

## Api versions and revisions

- Versions allow to represent groups of related apis to the developers. Used only when the chaneg on the API may cause a break point.
- revisions allow you to make changes to the APIs in a controlled and safe way, without disturbiung the API.

# APIs and their operations

For api access there is a concept of *products* and *groups*:

## Products

This is how APIs are sufaced to developers and have one or more APIs, title, description and terms of use.

- Can be opened or protected. Protected products must be subscribed to before they can be used.

- When a producs is ready for use by developer, it can be published for developers to use it.

- Subscription apprroval is configured at the product level. Developers need this subscription to access products.

## Groups

Administrators --> manage api service instances, creating apis and operations products.

Developers --> granted access to the portal to test applications

Guests --> unauthenticated developer portal users with certain read-only access


# Concepts of Azure API Management Security and Policies

## Policies
powerful capabilitites that allow tchanging the behavior of the api through config.

Collection of statements that are executed sequentially on the request or response API.

- Used to change the format of the data.
- restrict the amount of incomming calls.
- enforce existence of HTTP headers
- cache responses according to the cache control configuration

### Access Restriction Policies
- Limit Call Rate --> Prevents API usage by limiting the call rate on a per key basis.
- Validate JWT Tokens --> enforces existence and validitiy of a JWT token in header or query parameter
- Set quota usage --> enforces a renreable or lifetame call
- HTTP header presencec --> enforces existance of a header value
- Limit call rate on a per subscription basis

### Advanced Policies
- Mock response --> 
- Forward Request --> 
- Retry
- Set Request Method --> 
- Trace


### Transformation Policies
### Caching Policies

## Policy Scope
- Global Scope
- Product Scope
- Api Scope
- Operation Scope
