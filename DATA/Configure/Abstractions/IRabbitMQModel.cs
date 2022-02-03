using RabbitMQ.Client;

namespace Consumer.Data.Configure.Abstractions;

public interface IRabbitMQModel
{

    IModel CreateOrGetChannel();

}