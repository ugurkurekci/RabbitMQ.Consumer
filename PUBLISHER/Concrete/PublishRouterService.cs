using Consumer.Data.Configure.Abstractions;
using Consumer.Data.Utilities.Constants;
using Consumer.Publisher.Abstract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Consumer.Publisher.Concrete;

public class PublishRouterService : IPublishRouterService
{

    private readonly IRabbitMQModel _rabbitMQModel;

    private IModel _channel;

    private IModel Channel => _channel ??= _rabbitMQModel.CreateOrGetChannel();

    public PublishRouterService(IRabbitMQModel rabbitMQModel)
    {

        _rabbitMQModel = rabbitMQModel;

    }

    public Task PublishExampleXYQUEUE(string exampleLog)
    {

        WriteDataToExchange(QueueExchangeConstans.ExchangeXY, QueueExchangeConstans.ROUTING_KEY_XY, exampleLog);
        return Task.CompletedTask;

    }

    private void WriteDataToExchange(string exchangeName, string routingkey, object data)
    {

        var dataArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
        Channel.BasicPublish(exchangeName, routingkey, null, dataArray);

    }
}