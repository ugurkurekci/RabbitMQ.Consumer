using Consumer.Data.Configure.Abstractions;
using RabbitMQ.Client;

namespace Consumer.Data.Configure.Concretions;

public class RabbitMQModel : IRabbitMQModel

{

    private readonly IRabbitMQConnection _mQConnection;

    IConnection _connection;

    public RabbitMQModel(IRabbitMQConnection mQConnection)
    {

        _mQConnection = mQConnection;

    }

    public IModel CreateOrGetChannel()
    {

        _connection = _mQConnection.GetConnection();
        return _connection.CreateModel();

    }
}