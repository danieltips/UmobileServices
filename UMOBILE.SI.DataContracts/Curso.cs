using System.Runtime.Serialization;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class Curso
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public int creditos { get; set; }

        [DataMember]
        public int nivel { get; set; }

        [DataMember]
        public string profesor { get; set; }

        [DataMember]
        public string seccion { get; set; }

        [DataMember]
        public decimal promedio { get; set; }

        [DataMember]
        public decimal peso { get; set; }
    }

    [DataContract]
    public class Cursos
    {
        [DataMember]
        public Curso curso { get; set; }

    }


}