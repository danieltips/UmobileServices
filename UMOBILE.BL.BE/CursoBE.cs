using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMOBILE.BL.BE
{
    public class CursoBE
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Codigo;

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }


        private int _Creditos;

        public int Creditos
        {
            get { return _Creditos; }
            set { _Creditos = value; }
        }
        private int _Nivel;

        public int Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }
        private string _Profesor;

        public string Profesor
        {
            get { return _Profesor; }
            set { _Profesor = value; }
        }
        private string _Seccion;

        public string Seccion
        {
            get { return _Seccion; }
            set { _Seccion = value; }
        }
        private decimal _Promedio;

        public decimal Promedio
        {
            get { return _Promedio; }
            set { _Promedio = value; }
        }
        private decimal _Peso;

        public decimal Peso
        {
            get { return _Peso; }
            set { _Peso = value; }
        }

    }
}
