using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using viridian_api.Models;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System;
using viridian_api.Services;

namespace viridian_api.Controllers
{
    [Route("api/[controller]")]
    public class KafkaController : Controller
    {
        private readonly IKafkaService _kafkaService;

        public KafkaController(IKafkaService kafkaService)
        {
            _kafkaService = kafkaService;
        }

        // POST api/kafka
        [HttpPost]
        public IActionResult Post([FromBody]DataModel postModel)
        {
            // Instancia resultado.
            var result =  new ResultModel();
                
            try
            {
                // Objeto de configuracion.
                // var config = new Dictionary<string, object>
                // {
                //     { "bootstrap.servers", "localhost:9092" }
                // };

                // Instancia al producer.
                //using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
                //{
                    string jsonData = JsonConvert.SerializeObject(postModel);

                    var data = _kafkaService.Producer.ProduceAsync("viridian-test", null, jsonData).GetAwaiter().GetResult();;
                    _kafkaService.Producer.Flush(100);

                    result.Data = data;
                    result.Message = "Se inserto la data en el topic";
                    result.HttpStatusCode = HttpStatusCode.OK;
                //}
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Error = ex;
                result.Message = "Ocurrió un error en la consulta";
                result.HttpStatusCode = HttpStatusCode.InternalServerError;
            }
            

            return StatusCode((int) result.HttpStatusCode, result);
        }
    }
}
