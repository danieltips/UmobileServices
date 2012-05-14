using System.Runtime.Serialization;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class Alumno
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string carrera { get; set; }

        [DataMember]
        public string ciclo { get; set; }

        [DataMember]
        public string correo { get; set; }

        [DataMember]
        public string foto { get; set; }

    }

    [DataContract]
    public class Alumnos
    {
        [DataMember]
        public Alumno alumno { get; set; }

    }


}