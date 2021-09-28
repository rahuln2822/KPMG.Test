### KPMG.Test
###Challenge 1

Assumptions :
3-tier common setup considered as Subscription, ResourceGroup and Component

###Subscrition Provisioning
Latest 2020 deployment template allows us to create subscrition using ARM template
It is dependent on billing account. For now, subscription creation is possible with Enterprise Account only

###Cosmos DB Provisioning
Cosmos db deployment using CosmosDb.deploy.json and CosmosDb.parameters.json template.

###CosmosDb.deploy.json file
Contains the cosmos db resource to be provisioned.
Account Name is the name of Cosmos Db
Database Name is sql database in Cosmos db

###CosmosDb.parameters.json file
Takes the input from devops pipeline

Due to time constraints, I am not able to finish end to end pipeline.
But as thought process, I have added some pseudo steps and folder structure.

Pseudo steps
Install nuget
Build Proejct
Run unit and integration tests
Publish templates and code to specific location
Replace variables in parameters file
Provision resource (and/or assign specific roles)
(OR assign roles using powershell script) 

Jobs folder - will take common template for jobs in this folder like a main deploy job which will provision and deploy resources
Steps folder - common steps can be moved to this folder
Variables folder - will have common as well as env specific variable files - dev.yml files added in folder
azure-pipelines.yml (some proviosioning code is added) will be main file containing different required stages as per env.


###Challenge 2

As a part of this challenge, fetching metadata for cosmosdb account.
To get cosmos db metadata, we have to assign role to our application/user/group in cosmosdb.

For now, I have added the role manually via personal microsoft account on Cosmos Db.

###KPMG.Processor
AzureAuthHandler - Responsible for getting access token and add in request for authorization.
Once, user has appropriate role in cosmos db, it will fetch its metadata. 

###KPMG.Test.IntegrationTests
Added integration test for this challenge to cover the functionality.

Screen shot is attached in Output folder in same repository.

###Challenge 3

###Assumptions
1. As a part of this challenge, I am assuming input is passed as a nested object and not plain string representing nested object.
2. Key and Value will be of string only

###Nested Class
This class represents nested object. It is self referencing class.

###Constructors:
2 constructors are exposed in order to create nested object.

First constructor - (string, Nested)
This constructor can be used to create nesting of objects.

Second Constructor - (string, string)
This constructor will finally be used to setup a value

### GetKeys() Method
Returns all keys in nested object

### GetValue() Method
Returns the final value of nested object

### GetValueByKey() Method
Returns the object (string or Nested class object) depending upon the input key
For now, it supports single key input.

##KPMG.Test.UnitTests
This project will have unit tests cases for Nested class
Unit testing all above methods along with a check if invalid key is passed to GetValueByKey() method