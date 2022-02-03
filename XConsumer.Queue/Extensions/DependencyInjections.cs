using Consumer.Data.Configure.Abstractions;
using Consumer.Data.Configure.Concretions;
using Consumer.Publisher.Abstract;
using Consumer.Publisher.Concrete;
using Microsoft.Extensions.DependencyInjection;
using XConsumer.Queue.Services.Abstractions;
using XConsumer.Queue.Services.Concretions;

namespace XConsumer.Queue.Extensions;

public static class DependencyInjections
{
    public static void XRegisterRabbitMQServiceInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IXConsumerService, XConsumerService>();
        serviceCollection.AddScoped<IPublishRouterService, PublishRouterService>();
        serviceCollection.AddScoped<IRabbitMQConnection, RabbitMQConnection>();
        serviceCollection.AddScoped<IRabbitMQModel, RabbitMQModel>();
    }
}
