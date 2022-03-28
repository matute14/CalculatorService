# CalculatorService
Coding Challenge Calculator Service
calculator solution
The application code is made in c# using .net core 3.1
Composition
has a console application in which the client is integrated,
The client has a menu where he chooses the desired menu option
And it asks if you want to persist them to optionally see the history of operations

A server application that is where you have the controllers that are going to communicate with the client
through JSON the responses and requests are made through objects serialized with JSON since it is a REST API

Another solution that serves as a library to have the response and request models

For the deployment of the application it will be necessary to start the CalculatorClient and CalculatorServer solutions
