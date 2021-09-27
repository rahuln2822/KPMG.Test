# KPMG.Test
#Challenge 1

Assumptions :
3-tier common setup considered as Subscription, ResourceGroup and Component

#Subscrition Provisioning
Latest 2020 deployment template allows us to create subscrition using ARM template
It is dependent on billing account. For now, subscription creation is possible with Enterprise Account only

#Resource Group and Cosmos DB Provisioning
Resource group and cosmos db deployment done via same template.

#Challenge 2

As a part of this challenge, fetching metadata for cosmosdb account.
To get cosmos db metadata, we have to assign role to our application in cosmosdb.
Added a step to assing sql role in template

#Challenge 3

#Assumptions
1. As a part of this challenge, I am assuming input is passed as a nested object and not plain string representing nested object.
2. Key and Value will be of string only

##Nested Class
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