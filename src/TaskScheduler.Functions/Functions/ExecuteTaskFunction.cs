using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using TaskScheduler.Shared.Interfaces;
using TaskScheduler.Shared.Models;

namespace TaskScheduler.Functions.Functions
{
    public class ExecuteTaskFunction
    {
        private readonly ILogger<ExecuteTaskFunction> _logger;
        private readonly ITaskExecutor _taskExecutor;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public ExecuteTaskFunction(ILogger<ExecuteTaskFunction> logger, ITaskExecutor taskExecutor)
        {
            _logger = logger;
            _taskExecutor = taskExecutor;

            var factory = new ConnectionFactory
            {
                HostName = "localhost", 
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "task-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        [Function("ExecuteTaskFunction")]
        public async Task RunAsync([TimerTrigger("*/10 * * * * *")] TimerInfo timer)
        {
            _logger.LogInformation("Checking for RabbitMQ messages...");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var task = JsonSerializer.Deserialize<TaskModel>(message);

                _logger.LogInformation($"Executing task: {task?.Name}");
                await _taskExecutor.ExecuteAsync(task);

                _channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            _channel.BasicConsume(queue: "task-queue", autoAck: false, consumer: consumer);
        }
    }
}
