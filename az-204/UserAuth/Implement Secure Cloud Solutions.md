# Microsoft Graph

It is the gateway to the data, Microsoft 365 information. Provides a unified programming model that you can use to access data in Microsoft365, Windows10, Calendar, user data and more.

Provides a common endpoint information to contact information to the application.

# Azure Keyvault

Service that allows you to securely store and access secrets.

1. Keys --> cryptographics strings in other azure resources
2. Secrets --> any sensitive data
3. Certificates --> https certificates

This has 2 pricing teirs:

- Standard --> only software
- Premium --> software + HSM

# Using Keyvault references

This is only allowed for App Services and Azure Functionss

1. Move app config to key vault
2. Deploy app to service or funciton
3. Create system-assigned identity
4. Add system-assigned identitiy as access policy to the keyvault
5. Update configuration values with the KV reference syntax
6. Verify app functionality

# Azure Keyvault Soft-Delete

This allows for the recovery of deleted resources in a keyvault. This is enabled by default.

Entities can only be deleted running the **PURGE** operations and only made by a user with those permissions.

**PURGE** can be blocked by setting purge protection on the keyvault resource.
