using System.Runtime.Serialization;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class Evaluacion
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int tipo { get; set; }

        [DataMember]
        public string horario { get; set; }

        [DataMember]
        public string lugar { get; set; }

        [DataMember]
        public string nombrecurso { get; set; }

        [DataMember]
        public string fecha { get; set; }

    }

    [DataContract]
    public class Evaluaciones
    {
        [DataMember]
        public Evaluacion evaluacion { get; set; }

    }
}