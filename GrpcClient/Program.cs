// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcServer;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("https://localhost:7068");

var client = new Greeter.GreeterClient(channel);
var customerClient = new Customer.CustomerClient(channel);

var reply = await client.SayHelloAsync(
       new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);


var customerInfo = await customerClient.GetCustomerInfoAsync(
       new CustomerLookupModel { UserId = 1 });

Console.WriteLine("Customer Info: " + customerInfo.FirstName + " " + customerInfo.LastName);

customerInfo = await customerClient.GetCustomerInfoAsync(
          new CustomerLookupModel { UserId = 2 });
Console.WriteLine("Customer Info: " + customerInfo.FirstName + " " + customerInfo.LastName);

Console.ReadLine();
