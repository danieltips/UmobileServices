using System.ServiceModel;
using System.ServiceModel.Web;
using UMOBILE.SI.DataContracts;


namespace RESTfullWCF
{
    [ServiceContract]
    public interface IWidgetManager
    {

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Autentificacion/{codigo}/{password}")]
        Autentificaciones[] GetAutentificacion(string codigo, string password);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Alumno/{codigo}")]
        Alumnos[] GetAlumno(string codigo);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Companero/{curso}/{seccion}/{periodo}")]
        Companeros[] GetCompanero(string curso, string seccion, string periodo);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Profesor/{curso}/{seccion}/{periodo}")]
        Profesores[] GetProfesor(string curso, string seccion, string periodo);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Curso/{codigo}/{periodo}")]
        Cursos[] GetCursos(string codigo, string periodo);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Calificacion/{codigo}/{periodo}")]
        Calificaciones[] GetCalificaciones(string codigo, string periodo);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "HorarioCurso/{codigo}/{periodo}")]
        HorariosCurso[] GetHorarioCurso(string codigo, string periodo);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Horario/{codigo}/{periodo}/{fecha}")]
        Horarios[] GetHorario(string codigo, string periodo, string fecha);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Evaluacion/{codigo}/{periodo}")]
        Evaluaciones[] GetEvaluacion(string codigo, string periodo);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Actividad/{periodo}")]
        Actividades[] GetActividad(string periodo);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Cruce/{curso1}/{curso2}/{dia}/{horainicio}/{horafin}")]
        Cruces[] GetCruce(string curso1, string curso2, string dia, string horainicio, string horafin);

    }
}
