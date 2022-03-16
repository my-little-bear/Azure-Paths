# Exam Alert: Azure Security

Covers 20-25% of the exam.

### Implement User Authentication and 
- Authenticate and authorize users by using the Microsoft Identity Platform.
- Authenticate and authorize users by using Azure Active Directory.
- Create and implement shared access signatures.

### Implement Secure Cloud Solution
- Secure app configuration data by using AppConfiguration in Azure Key Vault
- Develop code that uses keys, secrets and certs in AZ kevault
- Implement solutions that interact with MS Graph

## User Authentication and Authorization

The following are the focus areas of the exam for authentication and authorization.

### 1. Microsoft Identity Platform

Consists of several components that enable tdevelopers to integrate identity into their custom apps while also integrating with Microsoft API's.

- Standards-based auth service
- OpenSourece libs
- App Management portal
- App Configuration
- Developer content

For authentication is going to leverage **OpenID Connect**. For authorization it uses **oAuth2**

Notes to know:

- Understand auth flows for SPA's, desktop app, mnobile app, daemon app.
- Understand JWTs
- Understand the tools you can leverage to integrate the platform with your apps.
- How to configure you apps to properly leverage the platform

### 2. AAD app manifests

The definition of the application object within the Microsoft Identity Platform which includes all configuration for allowed authentication and authorization integrations.

Take time to understand from the manifest how the following attributes work.

Attributes to review:
- appRoles
- groupMembershipClaims
- optionalClaims
- **oauth2AllowImplicitFlow
- **oauth2Permissions
- signInAudience --> types of MSFT accounts that are supported for the application.

### 3. Azure RBAC

- Security Principal --> represents users, groups, and managed identities.
- Role Definitions --> what is the security principal able to do for a role.
- Sopes --> what can be applied
- Role Assignedment --> ties the scopes and role definitions toghether with a security principal.




### 4. Azure Storage SAS

Provides secure delegated access to resources in your storage account with compromising security of your data.

Types of SAS:
1. User Delegation --> We are not using the storage account key to access the signature. This only works for BLOB storage.
2. Service SAS --> scoped to a specific service within the storage account.
3. Account SAS --> scoped to one or more services to the storage account.

SAS Forms:
- Ad Hoc SAS
- Service SAS --> defined within the storage access policy and all the SAS generated will have the service information.

SAS Best Practices:
- Always use HTTPS when creating / distributing SAS tokens.
- Use user delegation whenever possible.
- Defined a stored access policy for a service specific SAS
- Use short-term expiration on ad hoc, service or account SAS.
- Follow LEAST privilege


### 5. Azure App Service Mutual TLS Authentication

This is not supported in free or shared tiers.

App certificate is added to the **X-ARR-ClientCert** http header. The value is base64 encoded and need to be managed by code.

Secenario Understanding:
- Review different use cases for authentication approaches
- Understand the order to implement different approaches.
- Know thge limits of service and service tiers.
- Be able to spot poor security implementations



## Review Cloud Solutions

### 1. Microsoft Graph

It is the gateway to data and intelligence to all Microsoft 365.

Graph Services:
- Identity and Access
- Productivity
- Collaboration
- People and Workspace Intelligence
- Device management
- etc

Integrating with Microsoft Graph:

1. Register app with AAD as an **App Registration**.
2. Leverage the Microsoft Identity Platform with defined scopes.
3. User signs in with creds and accepts scopes.
4. App recieves authorization code.
5. Authorization code can be used to get a token from the token endpoint.
6. Token can be leveraged to access Microsoft Graph

### 2. Azure Keyvault

All azure feature **Soft Delete** will keep the value on the keyvault with a retention period of 7-9 days. Items can be deleted if they are **Purged**

``` ps1
New-AzKeyVault -Name '<vault-name>' -ResourceGroupName '<rg-name>' -Location '<location>'
```

``` ps1
az keyvault create --name <name> --resource-group <rg-name> --location <location> 
```

# Sample Scenarios

**Scenario 1:**

Silvia is building a prototype for a new internal React webapp. One of the requirements is that users can manage their profile info from the app. The user's Microsoft365 profile will be leveraged. Silvia plans to use AAD for identity, how can she accomplish this approach?

MyAnswer: Update the app registration to have the permissions for user writes.

Solution: Use MS Graph with the Microsoft Graph toolkit and MSAL v2


**Scenario 2:**

Edward currently has a .NEt Core app running as a function app. He is storing a connection string for CosmosDB in his application settings. He wants to avoid redeployments. What is the most effective approach he can take to improve security?

MySolution: Attach the string as an app secret

Solution:  Utilize azure keyvault reference for the cosmos db connection.

**Scenario 3:**

Integrating nodeapp. The app will leverage the MutualTLS for authentication. Cindy is responsible for writing the code to validate the client cert. How can she access the certificate that the client has used for the requests?

Solution: certificate in http header x-arr-clientcert and needs to be decoded.

**Scenario 4:**

William is creating an app using AAD for authentication. He wants to allow users from his company's directory to login. He wants to retrieve group membership for groups assigned tthis app. How should William configure his app manifest for these requirements?

Solution: Update groupMembershipClaims in the app manifest to have "Application Group"


**Scenario 5:**

App that tracks customer rebates. Part of the app us storing the submited reciepts images. The app uses an account SAS that is stored in the app configuration. How can oscar ensure the most secure access to storage resources?

Solution: Utilize user-delegation SAS which uses Azure AD credentials.

**Scenario 6:**

James processes data. All data must be encrypted using keys. They require HSM for storage key storage. He moved to azure keyvault using the standard tier. Does his approach meet his orgs standards?

Solution: Use premium tier for the keyvault to gain access to HSM module.