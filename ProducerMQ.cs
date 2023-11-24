using CoreLibrary;
using RabbitMQ.Client;
using System.Net.Security;
using System.Text;

namespace API_Inscription
{
    public class ProducerMQ
    {
        public EventHandler<String> OnMessage;

        public ProducerMQ()
        {
            try
            {
                var channel = RabbitMQManager.Instance.CreateChannel("rabbitmq", "users");

                OnMessage += (sender, e) =>
                {
                    Console.WriteLine(e);

                    string message = e;

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: string.Empty, routingKey: "users", basicProperties: null, body: body);
                };

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
