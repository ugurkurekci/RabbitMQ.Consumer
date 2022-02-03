using RabbitMQ.Client;

namespace Consumer.Data.Configure.Abstractions;

public interface IRabbitMQConnection
{
    IConnection GetConnection();

}