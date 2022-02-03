namespace XConsumer.Queue.Services.Abstractions;

public interface IXConsumerService
{
    Task ListenConsumerQueue(string queueName);

}