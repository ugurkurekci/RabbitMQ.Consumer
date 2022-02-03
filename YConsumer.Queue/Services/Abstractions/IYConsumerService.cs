namespace YConsumer.Queue.Services.Abstractions;

public interface IYConsumerService
{
    Task ListenConsumerQueue(string queueName);

}