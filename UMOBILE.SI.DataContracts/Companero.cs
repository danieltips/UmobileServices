using System.Runtime.Serialization;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class Companero
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string correo { get; set; }

        [DataMember]
        public int idcurso { get; set; }

        [DataMember]
        public string seccion { get; set; }

    }

    [DataContract]
    public class Companeros
    {
        [DataMember]
        public Companero companero { get; set; }

    }


}