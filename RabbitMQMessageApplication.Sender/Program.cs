using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQMessageApplication.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "MessageTest", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var sendingMessage = string.Empty;

                do
                {
                    Console.WriteLine("Mesajınız:");
                    sendingMessage = Console.ReadLine();

                    MessageInformation msg = new MessageInformation() { ID = new Random().Next(), MessageDate = DateTime.Now };

                    msg.Message = sendingMessage;

                    string message = JsonConvert.SerializeObject(msg);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "MessageTest", basicProperties: null, body: body);

                    Console.WriteLine($"{msg.ID} Gitti.");

                } while (sendingMessage != "0");
            }

            Console.WriteLine(" İlgili mesaj gönderildi...");
            Console.ReadLine();
        }
    }
}
