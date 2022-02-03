using Consumer.Data.Configure.Abstractions;
using Consumer.Data.Configure.Concretions;
using Consumer.Publisher.Abstract;
using Consumer.Publisher.Concrete;
using Microsoft.Extensions.DependencyInjection;
using YConsumer.Queue.Services.Abstractions;
using YConsumer.Queue.Services.Concretions;

namespace YConsumer.Queue.Extensions;

public static class DependencyInjections
{
    public static void YRegisterRabbitMQServiceInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IYConsumerService, YConsumerService>();
        serviceCollection.AddScoped<IPublishRouterService, PublishRouterService>();
        serviceCollection.AddScoped<IRabbitMQConnection, RabbitMQConnection>();
        serviceCollection.AddScoped<IRabbitMQModel, RabbitMQModel>();
    }
}
