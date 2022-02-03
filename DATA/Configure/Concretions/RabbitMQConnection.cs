using Consumer.Data.Configure.Abstractions;
using RabbitMQ.Client;

namespace Consumer.Data.Configure.Concretions;

public class RabbitMQConnection : IRabbitMQConnection
{

    public IConnection GetConnection()
    {
        {

            ConnectionFactory factory = new();
            {

                factory.UserName = "guest";
                factory.Password = "guest";
                factory.HostName = "localhost";
            }

            IConnection connection = factory.CreateConnection();
            return connection;

        }
    }
}