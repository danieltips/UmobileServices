using System.Runtime.Serialization;

namespace RESTfullWCF
{
    [DataContract]
    public class Ponderado
    {
        [DataMember]
        public decimal ponderado { get; set; }

    }

    [DataContract]
    public class Ponderados
    {
        [DataMember]
        public Ponderado ponderado { get; set; }

    }
}