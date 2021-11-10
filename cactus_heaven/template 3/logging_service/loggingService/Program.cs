using System;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;
using System.IO;

namespace loggingService
{
    class Program
    {
        static void Main()
        {
            var exName = "order_exchange";
            var inputRK = "create_order";
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel()){
                channel.ExchangeDeclare(exchange: "direct_logs", type: "direct");
                var queueName = channel.QueueDeclare().QueueName;



                channel.QueueBind(queue: queueName, exchange: exName, routingKey: inputRK);
                var consumer = new EventingBasicConsumer(channel);


                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);

                    string path = Directory.GetCurrentDirectory();
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "log.txt"), true))
                    {
                        outputFile.WriteLine("Log: " + message);
                    }
                };
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                Console.ReadLine();
            }   
        }
    }
}
