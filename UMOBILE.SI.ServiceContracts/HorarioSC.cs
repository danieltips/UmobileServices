using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BC;
using UMOBILE.BL.BE;
using UMOBILE.SI.DataContracts;
using System.Globalization;

namespace UMOBILE.SI.ServiceContracts
{
    public class HorarioSC
    {

        public List<Horario> GetHorario(string codigo, string periodo, string fecha)
        {
            
            HorarioBC bc = new HorarioBC();
            List<HorarioBE> be = new List<HorarioBE>();
            HorarioCruceBE dc;
            List<HorarioBE> rawData = new List<HorarioBE>();
            List<HorarioCruceBE> lst = new List<HorarioCruceBE>();

            //Se obtiene el nro de la semana en que estamos
            int semana = GetWeekNumber(Convert.ToDateTime(fecha));
            
            //Se obtiene el rango de la semana con la que se va a trabajar
            DateTime[] rango = GetWeekRange(Convert.ToDateTime(fecha));
            
            //Se obtiene los ids unicos para cada día de la semana
            List<int> ids = GetDaysId(rango[0]);
            
            //Se verifica que los horarios a traer sean de la semana
            rawData = bc.GetHorario(codigo, periodo);

            for (int i = 0; i < rawData.Count; i++)
            {
                HorarioBE hora = rawData[i];
                String inicio = hora.fechainicio;
                String fin = hora.fechafin;

                String[] split_inicio = inicio.Split('/');
                String[] split_fin = fin.Split('/');
                inicio = split_inicio[1] + "/" + split_inicio[0] + "/" + split_inicio[2];

                DateTime inicioDate = new DateTime( Int32.Parse(split_inicio[2]), Int32.Parse(split_inicio[1]), Int32.Parse(split_inicio[0]));
                DateTime finDate = new DateTime(Int32.Parse(split_fin[2]), Int32.Parse(split_fin[1]), Int32.Parse(split_fin[0]));

                int validate_die = 0;

                switch (hora.frec)
                {
                    case 1:
                        be.Add(hora);
                        break;
                    case 2: while (!inicioDate.ToString().Equals(finDate.ToString()))
                        {
                            if (validate_die > 50)
                                break;
                            String temp_date = inicioDate.Day + "/" + inicioDate.Month + "/" + inicioDate.Year;
                            if (temp_date.Equals(fecha))
                            {
                                be.Add(hora);
                                break;
                            }
                            inicioDate.AddDays(7);
                            validate_die++;
                        }
                        break;
                    case 4:
                        if((DateTime.Compare(Convert.ToDateTime(inicio),rango[0]) == 1) && (DateTime.Compare(Convert.ToDateTime(inicio),rango[1]) == -1))
                            be.Add(hora);
                        break;
                    default: continue;
                }
                
            }

            //Se juntan los horarios que tienen cruce
            for (int i = 0; i <  be.Count; i++)
            {
                bool seGeneroCruce = false;
                for (int k = i+1; k < be.Count; k++)
                {
                    if(ExisteCruce(be[i],be[k]))
                    {
                        if (be[i].cruce == false && be[k].cruce == false)
                        {
                            //crear div
                            dc = new HorarioCruceBE();
                            dc.id = be[i].id;
                            dc.dia = be[i].dia;
                            dc.semana = semana;

                            dc.horarios.Add(be[i]);
                            dc.horarios.Add(be[k]);

                            be[i].cruce = true;
                            be[k].cruce = true;
                            be[i].horarioCruce = dc;
                            be[k].horarioCruce = dc;

                            lst.Add(dc);
                            seGeneroCruce = true;
                        }
                        else if (be[i].cruce && be[k].cruce)
                        {
                            if (be[i].horarioCruce != be[k].horarioCruce)
                            {
                                dc = MergeHorarioCruce(be[i].horarioCruce, be[k].horarioCruce);
                                lst.Remove(be[k].horarioCruce);
                            }
                        }
                        else
                        {
                            HorarioBE horarioBE;
                            if (be[i].cruce)
                            {
                                dc = be[i].horarioCruce;
                                horarioBE = be[k];
                            }
                            else
                            {
                                dc = be[k].horarioCruce;
                                horarioBE = be[i];
                            }
                            horarioBE.horarioCruce = dc;
                            horarioBE.cruce = true;
                            dc.horarios.Add(horarioBE);
                        }
                    }
                }

                //Se generan div HTML para horarios normales
                if (!seGeneroCruce && be[i].cruce == false)
                {
                    String divHorario = CrearDivNormal(be[i]);
                    dc = new HorarioCruceBE();
                    dc.id = be[i].id;
                    dc.dia = be[i].dia;
                    dc.horario = divHorario;
                    dc.semana = semana;
                    lst.Add(dc);
                }
            }

            //Se generan los div HTML para los cruces
            List<Horario> lstHorario = new List<Horario>();
            for (int i = 0; i < lst.Count; i++)
            {
                Horario horario = new Horario();
                horario.id = lst[i].id;
                horario.dia = lst[i].dia;
                horario.semana = lst[i].semana;
                if (lst[i].horarios.Count == 0)
                {
                    horario.horario = lst[i].horario;
                }
                else if (lst[i].horarios.Count == 2)
                {
                    horario.horario = CrearDivCruce(lst[i].horarios[0], lst[i].horarios[1]);
                }
                else
                {
                    horario.horario = CrearDivCruceMayorADos(lst[i].horarios);
                }
                lstHorario.Add(horario);
            }

            //creamos lista con los dias que tiene clase
            List<Horario> re = new List<Horario>();
            Horario ho;
            int cruce = 0;
            List<int> cc = new List<int>();

            for (int i = 0; i < lstHorario.Count; i++)
            {
                for (int j = i + 1; j < lstHorario.Count; j++)
                {
                    if ((lstHorario[i].dia == lstHorario[j].dia))
                    {
                        if (!(lstHorario[i].dia == cruce))
                        {
                            ho = new Horario();
                            ho.id = lstHorario[i].id;
                            ho.dia = lstHorario[i].dia;
                            ho.horario = lstHorario[i].horario + lstHorario[j].horario;
                            ho.semana = semana;
                            cruce = ho.dia;
                            cc.Add(ho.dia);
                            re.Add(ho);
                        }
                    }
                }
            }

            //Agrupamos los divs por dias
            int cr = cruce;
            int vv = 0;

            for (int w = 0; w < lst.Count; w++)
            {
                vv = 0;
                for (int i = 0; i < cc.Count; i++)
                {
                    if ((lstHorario[w].dia != cc[i]))
                    {

                        vv += 0;
                    }
                    else
                    {
                        vv += 1;
                    }


                }
                if (vv == 0)
                {
                    ho = new Horario();
                    ho.id = lstHorario[w].id;
                    ho.dia = lstHorario[w].dia;
                    ho.horario = lstHorario[w].horario;
                    ho.semana = semana;
                    re.Add(ho);
                }
            }

            for (int e = 0; e < re.Count; e++)
            {
                switch (re[e].dia)
                {
                    case 1: re[e].id = ids[0];
                        break;
                    case 2: re[e].id = ids[1];
                        break;
                    case 3: re[e].id = ids[2];
                        break;
                    case 4: re[e].id = ids[3];
                        break;
                    case 5: re[e].id = ids[4];
                        break;
                    case 6: re[e].id = ids[5];
                        break;
                    case 7: re[e].id = ids[6];
                        break;

                }
            }
            return re;
        }

        public List<Evaluacion> GetEvaluacion(string codigo, string periodo)
        {
            HorarioBC bc = new HorarioBC();
            List<EvaluacionBE> be = new List<EvaluacionBE>();
            Evaluacion dc;
            List<Evaluacion> lst = new List<Evaluacion>();

            be = bc.GetEvaluacion(codigo, periodo);

            for (int i = 0; i < be.Count; i++)
            {
                dc = new Evaluacion();
                dc.id = be[i].id;
                dc.nombrecurso = be[i].nombre;
                dc.tipo = be[i].tipo;
                dc.horario = be[i].horainicio + " - " + be[i].horafin;
                dc.lugar = be[i].lugar;
                dc.nombrecurso = be[i].nombre;
                dc.fecha = be[i].fecha;
                lst.Add(dc);
            }


            return lst;

        }

        public List<HorarioCurso> GetHorarioCurso(string codigo, string periodo)
        {
            HorarioBC bc = new HorarioBC();
            List<HorarioCursoBE> be = new List<HorarioCursoBE>();
            HorarioCurso dc;
            List<HorarioCurso> lst = new List<HorarioCurso>();

            be = bc.GetHorarioCurso(codigo, periodo);

            for (int i = 0; i < be.Count; i++)
            {
                dc = new HorarioCurso();
                dc.id = be[i].Id;
                dc.idcurso = be[i].Idcurso;
                dc.dia = be[i].Dia;
                dc.horainicio = be[i].Horainicio;
                dc.horafin = be[i].Horafin;
                dc.salon = be[i].Salon;
                dc.sede = be[i].Sede;
                dc.tipo = be[i].Tipo;
                lst.Add(dc);
            }

            return lst;

        }

        public int GetWeekNumber(DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        private bool ExisteCruce(HorarioBE horario1, HorarioBE horario2)
        {
            if (horario1.horainicio >= horario2.horainicio && horario1.horainicio < horario2.horafin && horario1.dia == horario2.dia)
                return true;
            if (horario1.horafin > horario2.horainicio && horario1.horafin <= horario2.horainicio && horario1.dia == horario2.dia)
                return true;
            return false;
        }

        private String CrearDivNormal(HorarioBE horario)
        {
            int padding = 5;
            int height = 35;
            int alturaxcurso = (int)(height * (horario.horafin - horario.horainicio) - (padding * 2));

            int topinicial = 210;
            int iniciodia = 7;

            int topxcurso = (int)((horario.horainicio - iniciodia) * height + topinicial);

            string color = "";
            int tipo = horario.tipo;
            string tipoclase = "";
            switch (tipo)
            {
                case 1: color = "rgba(255, 204, 119, 0.5)";
                    tipoclase = "Clase Regular";
                    break;
                case 4: color = "rgba(170, 85, 34, 0.5)";
                    tipoclase = "Examen Parcial";
                    break;
                case 5: color = "rgba(170, 85, 34, 0.5)";
                    tipoclase = "Examen Final";
                    break;
                case 2: color = "rgba(255, 102, 0, 0.5)";
                    tipoclase = "Recuperación";
                    break;
                case 3: color = "rgba(85, 51, 17, 0.5)";
                    tipoclase = "Devolución de Examen";
                    break;
            }

            return "<div  class='estilohorario' style='background-color:" + color.ToString()
                    + "; height:" + alturaxcurso.ToString()
                    + "px; top:" + topxcurso.ToString()
                    + "px; padding:" + padding.ToString()
                    + "px;'>" + horario.nombre + "<br>" +
                    horario.salon + " - " +
                    tipoclase +
                     "</div>";
        }

        private String CrearDivCruceIndividual(HorarioBE horario, bool first)
        {
            int padding = 5;
            int height = 35;
            double horainicio = horario.horainicio;
            double horafin = horario.horafin;
            int alturaxcurso = (int)(height * (horafin - horainicio) - (padding * 2));

            int topinicial = 210;
            int iniciodia = 7;

            int topxcurso = (int)((horainicio - iniciodia) * height + topinicial);

            string color = "rgba(161, 48, 52, 0.5)";
            if (first)
                return "<div  class='estilohorario' style='background-color:" + color.ToString()
                        + "; height:" + alturaxcurso.ToString()
                        + "px; width: 60px; top:" + topxcurso.ToString()
                        + "px; padding:" + padding.ToString()
                        + "px;'>" + "<a href='<%= url_for :controller => :Cruce, :action => :cruce_dos,:query => {:detalle => " + GetDetalleDeCurso(horario) + "} %>'>" + horario.nombre + "</a>" +
                         "</div>";
            else
                return "<div  class='estilohorario' style='background-color:" + color.ToString()
                    + "; height:" + alturaxcurso.ToString()
                    + "px; width: 60px; left: 60px; top:" + topxcurso.ToString()
                    + "px; padding:" + padding.ToString()
                    + "px;'>" + "<a href='<%= url_for :controller => :Cruce, :action => :cruce_dos,:query => {:detalle => " + GetDetalleDeCurso(horario) + "} %>'>" + horario.nombre + "</a>" +
                     "</div>";
        }

        private String CrearDivCruce(HorarioBE horario1, HorarioBE horario2)
        {
            return CrearDivCruceIndividual(horario1, true) + CrearDivCruceIndividual(horario2, false);
        }

        private String CrearDivCruceMayorADos(List<HorarioBE> horarios)
        {
            int padding = 5;
            int height = 35;

            double horainicio = 99999;
            double horafin = 0;
            String detalle = "";
            for (int i = 0; i < horarios.Count; i++)
            {
                if (horarios[i].horainicio < horainicio)
                    horainicio = horarios[i].horainicio;
                if (horarios[i].horafin > horafin)
                    horafin = horarios[i].horafin;
                detalle += (GetDetalleDeCurso(horarios[i]) + "<br><br>");
            }
            String sHorainicio = (horainicio % 100).ToString() + ":" + ((horainicio * 100) % 100).ToString();
            String sHorafin = (horafin % 100).ToString() + ":" + ((horafin * 100) % 100).ToString();
            detalle += "Cruce: " + sHorainicio + " - " + sHorafin;

            int alturaxcurso = (int)(height * (horafin - horainicio) - (padding * 2));

            int topinicial = 210;
            int iniciodia = 7;

            int topxcurso = (int)((horainicio - iniciodia) * height + topinicial);

            string color = "rgba(161, 48, 52, 0.5)";
            return "<div  class='estilohorario' style='background-color:" + color.ToString()
                    + "; height:" + alturaxcurso.ToString()
                    + "px; top:" + topxcurso.ToString()
                    + "px; padding:" + padding.ToString()
                    + "px;'>" + "<a href='<%= url_for :controller => :Cruce, :action => :cruce,:query => {:detallle => } %>'>CRUCE</a>" +
                     "</div>";
        }

        private DateTime[] GetWeekRange(DateTime dateToCheck)
        {
            DateTime[] result = new DateTime[2];
            TimeSpan duration = new TimeSpan(0, 0, 0, 0); //One day 
            DateTime dateRangeBegin = dateToCheck;
            DateTime dateRangeEnd = DateTime.Today.Add(duration);

            dateRangeBegin = dateToCheck.AddDays(+1 -(int)dateToCheck.DayOfWeek);
            dateRangeEnd = dateToCheck.AddDays(7 - (int)dateToCheck.DayOfWeek);

            result[0] = dateRangeBegin.Date;
            result[1] = dateRangeEnd.Date;
            return result;

        }

        private List<int> GetDaysId(DateTime dia_inicio)
        {
            List<int> ids = new List<int>();
            DateTime dia = dia_inicio;

            for (int i = 0; i < 7; i++)
            {
                dia = dia.AddDays(1);
                String[] split_dia = dia.ToShortDateString().Split('/');
                string id_dia = split_dia[0] + split_dia[1] + split_dia[2];
                ids.Add(Convert.ToInt32(id_dia));

                
            }
            return ids;
            
        }

        private HorarioCruceBE MergeHorarioCruce(HorarioCruceBE horario1, HorarioCruceBE horario2)
        {
            for (int i = 0; i < horario2.horarios.Count; i++)
            {
                horario1.horarios.Add(horario2.horarios[i]);
                horario2.horarios[i].horarioCruce = horario1;
            }
            return null;
        }

        private String GetDetalleDeCurso(HorarioBE horario)
        {
            String tipoclase = "";
            switch (horario.tipo)
            {
                case 1: tipoclase = "Clase Regular";
                    break;
                case 4: tipoclase = "Examen Parcial";
                    break;
                case 5: tipoclase = "Examen Final";
                    break;
                case 2: tipoclase = "Recuperación";
                    break;
                case 3: tipoclase = "Devolución de Examen";
                    break;
            }
            String horainicio = (horario.horainicio % 100).ToString() + ":" + ((horario.horainicio * 100) % 100).ToString();
            String horafin = (horario.horafin % 100).ToString() + ":" + ((horario.horafin * 100) % 100).ToString();
            return horario.nombre + "<br>" + horainicio + " - " + horafin + "<br>" + horario.salon + "<br>" + tipoclase;
        }



    }
}
