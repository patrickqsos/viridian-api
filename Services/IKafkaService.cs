using Confluent.Kafka;

namespace viridian_api.Services
{
    public interface IKafkaService
    {
        Producer<Null, string> Producer {get; set;}
    }
}