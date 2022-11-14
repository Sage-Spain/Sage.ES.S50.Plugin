using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace sage.addons.EjemAddons.Negocio.Clases
{
    public class Importacion
    {

        #region eventos
        /// <summary>
        /// Delegado con la acción a ejecutar 
        /// </summary>
        protected internal delegate void _Mostrar_Progreso(String message);

        /// <summary>
        /// Desencadena el evento
        /// </summary>
        protected internal event _Mostrar_Progreso _Mostrar_Progreso_Async;

        #endregion eventos

        #region Propiedades
        private string _cTextStep = "";
        private string _cTextStepDetalle = "";

        /// <summary>
        /// Background worker a utilizar en el asistente
        /// </summary>
        private BackgroundWorker _oWorker = null;
        /// <summary>
        /// Número de pasos totales
        /// </summary>
        private int _TotalSteps = 0;
        /// <summary>
        /// Paso actual
        /// </summary>
        private int _StepActual = 0;

        /// <summary>
        /// Lista de incidencias
        /// </summary>
        protected internal List<IncidenciaImportacion> _lstIncidencias = new List<IncidenciaImportacion>();

        /// <summary>
        /// Descripción del paso
        /// </summary>
        public string _TextStep
        {
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _cTextStep = value;
                    ActualizarBarraProgreso();
                    _TextStepDetalle = value;
                }
            }
            get { return _cTextStep; }
        }


        /// <summary>
        /// Descripción del paso detalle
        /// </summary>
        public string _TextStepDetalle
        {
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _cTextStepDetalle = value;
                    ActualizarProgresoDetalle();
                }
            }
            get { return _cTextStepDetalle; }
        }
        #endregion Propiedades

        /// <summary>
        /// Importar datos a Force Manager CRM
        /// </summary>        
        /// <returns></returns>
        public bool _Importar(BackgroundWorker toWorker = null)
        {
            _oWorker = toWorker;

            //_TotalSteps = 1 + ( (ISVobjetoImportar1) != null && ISVobjetoImportar1.Count > 0 ? 1 : 0) + (ISVobjetoImportar2 != null && ISVobjetoImportar2.Count > 0 ? 1 : 0) + 2;
            _StepActual = 0;
            EscribirLog("Inicio importación", TipoValidacion.Ok);

            // Métodos propios del ISV

            //_InicializarImportacion();

            //_RevisarCuentasEquivalentes();

            //_ImportarDatos()

            EscribirLog("La importación ha terminado", TipoValidacion.Ok);

            //SaveResults();

            EscribirLog("Logs guardados", TipoValidacion.Ok);

            return true;
        }

        /// <summary>
        /// Método para actualizar la barra de progreso asociada al BackgroundWorker
        /// </summary>
        private void ActualizarBarraProgreso()
        {
            if (_oWorker != null && _TotalSteps > 0)
            {
                // Calculamos el progreso relativo a la barra teniendo en cuenta que la barra va de 0 a 100 %
                _StepActual++;
                int lnProgresoRelativo100 = (_StepActual * 100) / _TotalSteps;

                if (lnProgresoRelativo100 > 100)
                    lnProgresoRelativo100 = 100;

                _oWorker.ReportProgress(lnProgresoRelativo100);
            }
        }

        /// <summary>
        /// Método para actualizar el detalle del progreso
        /// </summary>
        private void ActualizarProgresoDetalle()
        {
            if (_Mostrar_Progreso_Async != null)
                _Mostrar_Progreso_Async(_TextStepDetalle);
        }


        /// <summary>
        /// Escribir detalle importación y log
        /// </summary>
        /// <param name="tcTexto"></param>
        /// <param name="teTipo"></param>
        private void EscribirLog(string tcTexto, TipoValidacion teTipo)
        {
            _TextStepDetalle = tcTexto;
            _lstIncidencias.Add(new IncidenciaImportacion(tcTexto, TipoValidacion.Error));
        }

    }

    /// <summary>
    /// Clase que contendrá todas las incidencias que se han producido
    /// </summary>
    public class IncidenciaImportacion
    {

        #region Propiedades privadas
        private TipoValidacion _eTipoValidacion = TipoValidacion.Ok;
        private string _cDescripcion = string.Empty;
        #endregion Propiedades privadas

        #region Propiedades públicas

        /// <summary>
        /// Identifica el tipo de incidencia
        /// </summary>
        public TipoValidacion _TipoIncidencia
        {
            get
            {
                return _eTipoValidacion;
            }
            set
            {
                _eTipoValidacion = value;
            }
        }

        /// <summary>
        /// Descripción detallada del error de validación
        /// </summary>
        public string _Descripcion
        {
            get
            {
                return _cDescripcion;
            }
            set
            {
                _cDescripcion = value;
            }
        }

        #endregion Propiedades públicas

        #region Constructores

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public IncidenciaImportacion()
        {
        }

        #endregion Constructores

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tcDescripcionIncidencia"></param>
        /// <param name="teTipoValidacion"></param>
        public IncidenciaImportacion(string tcDescripcionIncidencia, TipoValidacion teTipoValidacion)
        {
            _Descripcion = tcDescripcionIncidencia;
            _TipoIncidencia = teTipoValidacion;
        }
    }

    /// <summary>
    /// Emuns
    /// Tipos de validación
    /// </summary>
    public enum TipoValidacion
    {
        /// <summary>
        /// Error
        /// </summary>
        [DescriptionAttribute("Error")]
        Error = 1,
        /// <summary>
        /// Aviso
        /// </summary>
        [DescriptionAttribute("Aviso")]
        Aviso = 2,
        /// <summary>
        /// Ok
        /// </summary>
        [DescriptionAttribute("Ok")]
        Ok
    }

    /// <summary>
    /// Emuns
    /// Resultado de la importación
    /// </summary>
    public enum ResultadoImportacion
    {
        [Description("Con incidencias")]
        ConIncidencias = 1,
        [Description("Con errores")]
        ConErrores = 2,
        [Description("Correcta")]
        Correcto = 3,
        [Description("Cancelada")]
        Cancelada = 4
    }
}