using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UMOBILE.SI.DataContracts
{
    [DataContract]
    public class Profesor
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string correo { get; set; }

        [DataMember]
        public int idcurso { get; set; }

        [DataMember]
        public string seccionid { get; set; }


    }

    [DataContract]
    public class Profesores
    {
        [DataMember]
        public Profesor profesor { get; set; }

    }


}
