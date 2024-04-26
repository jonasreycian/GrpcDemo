using Grpc.Core;

namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;
        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            var model = new CustomerModel();

            if(request.UserId == 1)
            {
                model.FirstName = "John";
                model.LastName = "Doe";
            }
            else
            {
                model.FirstName = "Jane";
                model.LastName = "Doe";
            }


            model.EmailAddress = "doesibs@gmail.com";
            model.IsAlive = true;
            model.Age = 30;

            return Task.FromResult(model);
        }

        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            var customerModels = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FirstName = "Sue",
                    LastName = "Storm",
                    EmailAddress = ""
                },
                new CustomerModel
                {
                    FirstName = "Reed",
                    LastName = "Richards",
                    EmailAddress = ""
                },
                new CustomerModel
                {
                    FirstName = "Ben",
                    LastName = "Grimm",
                    EmailAddress = ""
                },
                new CustomerModel
                {
                    FirstName = "Johnny",
                    LastName = "Storm",
                    EmailAddress = ""
                }
            };

            foreach (var customerModel in customerModels)
            {
                await Task.Delay(3000);
                await responseStream.WriteAsync(customerModel);
            }

        }
    }
}
