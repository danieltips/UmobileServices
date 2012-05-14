using System.Runtime.Serialization;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class Cruce
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public double horainicio { get; set; }

        [DataMember]
        public double horafin { get; set; }

        [DataMember]
        public string salon { get; set; }

        [DataMember]
        public int tipo { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string cruce { get; set; }

    }

    [DataContract]
    public class Cruces
    {
        [DataMember]
        public Cruce cruce { get; set; }

    }
}