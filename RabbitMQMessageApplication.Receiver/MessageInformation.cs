using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQMessageApplication.Receiver
{
    public class MessageInformation
    {
        public int ID { get; set; }
        public DateTime MessageDate { get; set; }
        public string Message { get; set; }
    }
}
