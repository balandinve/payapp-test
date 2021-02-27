using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using payapp.data.Models;
using payapp.services.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace payapp.message.receive.OrderReceiver
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderReceiver: BackgroundService
    {
        private readonly IClientPayService clientPayService;
        private readonly IServiceScopeFactory scopeFactory;
        private readonly string hostname;
        private readonly string queue;
        private readonly string username;
        private readonly string password;
        private IConnection connection;
        private IModel channel;

        public OrderReceiver(IServiceScopeFactory scopeFactory, IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            this.scopeFactory = scopeFactory;
            this.hostname = rabbitMqOptions.Value.Hostname;
            this.queue = rabbitMqOptions.Value.QueueName;
            this.username = rabbitMqOptions.Value.UserName;
            this.password = rabbitMqOptions.Value.Password;
            InitializeRabbitMqConnection();
        }
        private void InitializeRabbitMqConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = hostname,
                UserName = username,
                Password = password
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
        private void HandleMessage(ClientOperation operation)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                clientPayService.Movement(operation);
            }
            //clientPayService.Movement(operation);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var clientOperation = JsonConvert.DeserializeObject<ClientOperation>(content);

                HandleMessage(clientOperation);

                channel.BasicAck(ea.DeliveryTag, false);
            };
            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerCancelled;

            channel.BasicConsume(queue, false, consumer);

            return Task.CompletedTask;
        }

        private void OnConsumerCancelled(object sender, ConsumerEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
            throw new NotImplementedException();
        }
        public override void Dispose()
        {
            channel.Close();
            connection.Close();
            base.Dispose();
        }
    }
}
