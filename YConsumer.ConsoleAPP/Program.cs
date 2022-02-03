using Consumer.Data.Utilities.Constants;
using Microsoft.Extensions.DependencyInjection;
using YConsumer.Queue.Extensions;
using YConsumer.Queue.Services.Abstractions;


var serviceProvider = new ServiceCollection();
serviceProvider.YRegisterRabbitMQServiceInjection();
var app = serviceProvider.BuildServiceProvider();

app.GetService<IYConsumerService>()
    .ListenConsumerQueue(QueueExchangeConstans.PublishYQueue);
