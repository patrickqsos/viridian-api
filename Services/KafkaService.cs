using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using viridian_api.Services;

namespace viridian_api.Services
{
    public class KafkaService : IKafkaService
    {
        public Producer<Null, string> Producer { get; set ; }

        public KafkaService()
        {
            // El host y puerto pueden ser movidos al appsettings.json
            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", "localhost:9092" }
            };
            
            this.Producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8));
        }

    }
}