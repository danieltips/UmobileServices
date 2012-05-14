using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMOBILE.BL.BE
{
    public class HorarioCursoBE
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int _Idcurso;

        public int Idcurso
        {
            get { return _Idcurso; }
            set { _Idcurso = value; }
        }
        private int _Dia;

        public int Dia
        {
            get { return _Dia; }
            set { _Dia = value; }
        }
        private string _Horainicio;

        public string Horainicio
        {
            get { return _Horainicio; }
            set { _Horainicio = value; }
        }
        private string _Horafin;

        public string Horafin
        {
            get { return _Horafin; }
            set { _Horafin = value; }
        }
        private string _Salon;

        public string Salon
        {
            get { return _Salon; }
            set { _Salon = value; }
        }
        private string _Sede;

        public string Sede
        {
            get { return _Sede; }
            set { _Sede = value; }
        }
        private int _Tipo;

        public int Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

    }
}
