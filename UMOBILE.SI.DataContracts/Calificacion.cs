using System.Runtime.Serialization;
using System.Collections.Generic;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class Calificacion
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int idcurso { get; set; }

        [DataMember]
        public string tipo { get; set; }

        [DataMember]
        public string evaluacion     { get; set; }

        [DataMember]
        public int numero { get; set; }

        [DataMember]
        public decimal peso { get; set; }

        [DataMember]
        public string nota { get; set; }

    }

    [DataContract]
    public class Calificaciones
    {
        [DataMember]
        public Calificacion calificacion { get; set; }

    }

}