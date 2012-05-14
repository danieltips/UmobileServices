using System.Runtime.Serialization;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class Horario
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int dia { get; set; }

        [DataMember]
        public string horario { get; set; }

        [DataMember]
        public int semana { get; set; }

    }

    [DataContract]
    public class Horarios
    {
        [DataMember]
        public Horario horario { get; set; }

    }
}