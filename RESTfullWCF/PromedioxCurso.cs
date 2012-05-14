using System.Runtime.Serialization;

namespace RESTfullWCF
{
    [DataContract]
    public class PromedioxCurso
    {
        [DataMember]
        public decimal promedio { get; set; }

        [DataMember]
        public int id { get; set; }

    }

    [DataContract]
    public class PromediosxCurso
    {
        [DataMember]
        public PromedioxCurso promedio { get; set; }

    }
}