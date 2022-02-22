# Secure Azure Storge

There are several planes to maintain control off:

1. Management Plane
2. Data Plane
3. Encryption Plane

## Management Plane: RBAC

1. Security Principal --> an entity to allow access to things. These can be users, groups, service-principal or managed identities.

2. Role Definitions --> defines the set of permissions a security pricnipal is able to do.

3. Scope --> the resources a security principal is able to apply their roles.

All these come toghether in the "**Role Assignment**".

- If you have muliple role assignments to a security-principal, they are **aditive**.
- If you have a **deny** asssignment, this taskes precedence over anything else.

## Data Plane

1. Keys --> these are long string that an app can use to access data. Note, these are the equivalent of root password to the resource. We need to secure the security-principals who have access to these keys.

2. Shared Access Signatures --> is aleast priviledge mechanism and are attached to a specific permission, time, etc. Which allow for better dynamic acces.

3. Aure AD --> you will access it with standard openIP mechanism.

## Shared Access Signatures (SAS)

1. User deletagtion SAS --> a user is accessign the resource
2. Service SAS --> delegates access to a resource and only one of the resources.
3. Account SAS --> delegates access to one or more of the services.

From a SAS token, the signature is the important portion that token since it is hash of a combination from the key.

## Kind of SAS

1. Ad-Hoc --> applied from the SAS token on the resource itself
2. SAS with Stores Access Policy --> reusable by multiple SAS that points to the policies of the resource and its linked to the resource itslef.

# Authenticate with AAD

- **Authentication** --> who you are?

The core of the AAD system is the **Microsoft Identity Platform** which collectively is an authentication service, open source libraries and application management toolset.

1. Authentication Services:

- **Active Directory** --> allows for identity management and it is connected to systems like: **Azure AD Connect**

- OpenSource Libraries --> **MSAL** is the Microsoft authentication library. It is a collection of libraries for all services such as .NET Core, node, python etc.

- Application Management --> gallery apps and non gallery apps, single tenant or multi-tenant

## Modern Identity

- OAuth
- SAML and WS-\*
- OpenID Connect

# Authorization with Azure AD

- **Authorization** --> what are you able to do?

**DO NOT OVERENGINEER authorization**

Authorization can be applied as an app (service prinvipa) or user (security principal)

You can apply roles, custom claims and app roles.

## Groups based authorization
