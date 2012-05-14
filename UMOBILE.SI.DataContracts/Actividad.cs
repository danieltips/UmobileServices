using System.Runtime.Serialization;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class Actividad
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string mensaje { get; set; }

        [DataMember]
        public string fecha { get; set; }

        [DataMember]
        public string titulo { get; set; }

        [DataMember]
        public string ciclo { get; set; }

    }

    [DataContract]
    public class Actividades
    {
        [DataMember]
        public Actividad actividad { get; set; }

    }


}