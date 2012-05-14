using System.Runtime.Serialization;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class Autentificacion
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string periodo { get; set; }
    }

    [DataContract]
    public class Autentificaciones
    {
        [DataMember]
        public Autentificacion autentificacion { get; set; }

    }

}
