using Consumer.Data.Configure.Abstractions;
using Consumer.Data.Utilities.Constants;
using Consumer.Publisher.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using YConsumer.Queue.Services.Abstractions;

namespace YConsumer.Queue.Services.Concretions;

public class YConsumerService : IYConsumerService
{

    private readonly IPublishRouterService _publishRouter;

    private readonly IRabbitMQModel _rabbitMQModel;

    private IModel _channel;

    private IModel Channel => _channel ??= _rabbitMQModel.CreateOrGetChannel();


    public YConsumerService(IPublishRouterService publishRouter, IRabbitMQModel rabbitMQModel)
    {
        _publishRouter = publishRouter;
        _rabbitMQModel = rabbitMQModel;
    }

    public Task ListenConsumerQueue(string queueName)
    {
        var consumerEvent = new EventingBasicConsumer(Channel);
        Console.WriteLine(queueName + "Listening ! \n");
        consumerEvent.Received += (ch, e) =>
        {
            var byteArr = e.Body.ToArray();
            var bodyStr = Encoding.UTF8.GetString(byteArr);
            if (bodyStr != null)
            {
                Console.WriteLine(RabbitMQMainConstans.ReceiveMessage + bodyStr + "\n");
                var retval = _publishRouter.PublishExampleXYQUEUE(bodyStr); // Bir kuyruğa gönderiyorum burada.
                Console.WriteLine(RabbitMQMainConstans.PublishMessage + bodyStr + "\n");
                if (retval.IsCompleted)
                {
                    Channel.BasicAck(e.DeliveryTag, true);
                }
            }
        };

        Channel.BasicConsume(queueName, false, consumerEvent);
        Console.ReadLine();
        return Task.CompletedTask;

    }
}