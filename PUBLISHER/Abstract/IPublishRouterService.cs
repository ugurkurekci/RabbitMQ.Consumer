namespace Consumer.Publisher.Abstract;

public interface IPublishRouterService
{

    Task PublishExampleXYQUEUE(string exampleLog);

}
