# Objectives for the Exam

## IaaS Solutions
1. Provision VMs
2. Configure, validate and deploy ARM templates
3. Create container images for solutions
4. Publish images to Azure Container Registry (ACR)
5. Run Azure Container Instances

### Review as IaaS

- Managed Identities - make sure that you make sure to use powershell on how this works.
- Backup and Restore Approaches - make sure you know how to effectively backup your resources.
- Accelerated Networking - helps to deal with specific challenges with lag and jitter from network communication. Increase communication within the Vnet.
- When NOT use a VM!!! - make sure you always pickup the most cost effective solution. Using a VM is more costly, most of the time, rather than using SaaS / PaaS solutions.

## App Service WebApp Solutions

1. Create WebApp
2. Enable diagnostics logging
3. Deploy code to webapp
4. Configure web app settings: SSL, API and connection strings
5. Implement autoscaling, including scheduled and via metrics.

## Review App Services

This is the largest coverd sections.

- Pricing Tier --> understand how these capabilities apply on a real world scenario.
- Deployment Order --> you should understand the right order to create an azure app service. Example: have the App Service Plan prior to the AppService.
- Deployment Slots --> understand to know when to use swap or not.
- Scaling Setup --> configure scaling and which tiers provide the option.
- Isolation Tier --> know when to use the isolation tier.
- Azure Container Deployment --> understand how the ACRs and ACIs differ and deployment process.

## App Service Pricing Tiers
- Free (F) --> not supported for prod workloads and its VM  shared.
- Shared (D) --> not supported for prod workloads and its VM shared.
- Basic (B) --> not supported for prod workloads and it has load balancing capabilities.
- Standard (S) - good for prod / allows for scaling / load balancing. This is the 1st tier that allows for scaling capabilities.
- Premium (P) --> excellent for prod work / increased resources / higher scaling than S.
- Isolated --> mission critical workloads / deploys the ASE

## App Service Caveats

- Acccessing logs
- Review the CLI
- Azure App Service Environment (ASE) --> used with P tier
- Custom Warm-Up Deployment Slots --> how to make sure swapping resource have all the necessary background resources in play.

## Azure Functions

1. Create and deploy az functions.
2. Implement input and output bindings
3. Implement function triggers by using data operations, timers, and webhooks
4. Implement durable functions
5. Implement custom handlers

## Azure Functions Review

1. Bindings --> understand input / output binding capabilities such as: cosmosDB, azure queue storage.
2. Funcitons Roles --> azure funcitons are excelent for non-support for compute resources as they are self sufficient and dont require maintenance.
3. Cross Service Integration --> understand the architecture that azure functions makes sens to use in.
4. Use Cases --> understand the use cases of the durable functions.
5. Function Metrics --> understand the monitoring of funcitons.

## Azure Funcitons: Funciton Patterns

- Functions Chaining --> the result of a functions goes to another function.
- Fan-out / Fan-in --> kick a process and several process in paralell and the computed result aggregates the data.
- Async HTTP APIs -->
- Monitoring --> use a pattern when something is completed.
- Human Interaction --> wait for human interaction to happen and proceed to the chain.
- Aggregator --> good for stateful entities.


# Example Scenarios

## Scenario 1

Silvias company is in the process of moving multiple web apps to azure. The web appliactions themselves are deployed as containers. Application demand varies and they struggle with uptime. What is the most effective solution for her company when onboarding to Azure?

Use AppServices for containers - S tier with linux runtime.

## Scenario 2

Edward has created a document processing service for his company. After his app uploads the document, the app calls the API and the API that starts the process on the VM. Is this the most cost effective solution?

No. You can use an azure function with a trigger based on blob storage.

## Scenario 3

Cindy provides SaaS solution and they are trying to find ways to process LARGE videos and she thinks that this can be solved with durable functions?

No. This needs to be proccessed by other resources or dedicated VMs

## Scenario 4

Currenlty they perform multiple actions actions on a VM when a new user is added. Is this solvable with durable functions?

yes using azure funciton chaining.

## Scenario 5

Oscar deployes an app using AppService and using a new account. What is the correct steps are the correct ones?

create a new resource group --> az group create
Needs to create a service principal --> az appservice plan create
Create weabpp --> az webapp create
deploy app --> az webapp deploy

## Scenario 6

Which solution or approach could reduce the latency of VMs trying to process a lot of streaming data?

Aceelerated Networking

