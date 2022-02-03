using Consumer.Data.Utilities.Constants;
using Microsoft.Extensions.DependencyInjection;
using XConsumer.Queue.Extensions;
using XConsumer.Queue.Services.Abstractions;

var serviceProvider = new ServiceCollection();
serviceProvider.XRegisterRabbitMQServiceInjection();
var app = serviceProvider.BuildServiceProvider();

app.GetService<IXConsumerService>()
    .ListenConsumerQueue(QueueExchangeConstans.PublishXQueue);
