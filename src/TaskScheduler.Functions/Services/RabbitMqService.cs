using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using TaskScheduler.Shared.Interfaces;
using TaskScheduler.Shared.Models;
using Microsoft.Extensions.Logging;

namespace TaskScheduler.Functions.Services
{
    public class RabbitMqService : IMessageQueueService, IDisposable
    {
        private readonly ILogger<RabbitMqService> _logger;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        private const string QueueName = "task-queue";

        public RabbitMqService(ILogger<RabbitMqService> logger)
        {
            _logger = logger;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost", 
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: QueueName,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        public Task PublishAsync(TaskModel task)
        {
            var message = JsonSerializer.Serialize(task);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                                  routingKey: QueueName,
                                  basicProperties: null,
                                  body: body);

            _logger.LogInformation($"[RabbitMQ] Task queued: {task.Name}");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
