# Asp.netcoreProtobuf
Just a short test impl for protobuf-net in asp.net core

- To run the API use the ProtobufPOC project.
- To run the test client: run the WebClientProtobuf project.

We want to demonstrate how easy it is to add a Protobuf serialization to your API.
You can switch between JSON and Protobuf using the accept headers in the request.
Benefit here is that if set up right, you don' thave to change anything in your code except setting which serializer to be used when adding protobuf to an existing API.