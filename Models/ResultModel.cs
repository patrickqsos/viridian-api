using System.Net;
using System.Runtime.Serialization;

namespace viridian_api.Models
{
    [DataContract]
    public class ResultModel
    {
        [DataMember]
        public object Data { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public object Error { get; set; }

        public bool Status { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
    }
}