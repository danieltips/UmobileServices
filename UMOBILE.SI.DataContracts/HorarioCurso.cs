using System.Runtime.Serialization;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class HorarioCurso
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int idcurso { get; set; }

        [DataMember]
        public int dia { get; set; }

        [DataMember]
        public string horainicio { get; set; }

        [DataMember]
        public string horafin { get; set; }

        [DataMember]
        public string salon { get; set; }

        [DataMember]
        public string sede { get; set; }

        [DataMember]
        public int tipo { get; set; }

    }

    [DataContract]
    public class HorariosCurso
    {
        [DataMember]
        public HorarioCurso horariocurso { get; set; }

    }
}