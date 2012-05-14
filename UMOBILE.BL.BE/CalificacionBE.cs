using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMOBILE.BL.BE
{
    public class CalificacionBE
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
        private string _Tipo;

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        private string _Evaluacion;

        public string Evaluacion
        {
            get { return _Evaluacion; }
            set { _Evaluacion = value; }
        }
        private int _Numero;

        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }
        private decimal _Peso;

        public decimal Peso
        {
            get { return _Peso; }
            set { _Peso = value; }
        }
        private string _Nota;

        public string Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

    }
}
