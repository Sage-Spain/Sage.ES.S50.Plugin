using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace sage.addons.EjemAddons.Negocio.Clases
{
    /// <summary>
    /// Clase de negocio utilizada para soportar todas las propiedades y características definidas a nivel visual en todos los pasos
    /// del asistente.
    /// </summary>
    public class Importacion
    {
        #region EVENTOS


        /// <summary>
        /// Delegado con la acción a ejecutar 
        /// </summary>
        protected internal delegate void _Mostrar_Progreso(String message);


        /// <summary>
        /// Desencadena el evento
        /// </summary>
        protected internal event _Mostrar_Progreso _Mostrar_Progreso_Async;


        #endregion EVENTOS


        #region PROPIEDADES PRIVADAS


        /// <summary>
        /// Texto a mostrar en la progressbar
        /// </summary>
        private string _cTextStep = "";


        /// <summary>
        /// Texto detallado a mostrar en la progressbar
        /// </summary>
        private string _cTextStepDetalle = "";


        /// <summary>
        /// Background worker a utilizar en el asistente
        /// </summary>
        private BackgroundWorker _oWorker = null;


        /// <summary>
        /// Número de pasos totales
        /// </summary>
        private int totalSteps = 0;


        /// <summary>
        /// Paso actual
        /// </summary>
        private int stepActual = 0;


        /// <summary>
        /// Lista de incidencias
        /// </summary>
        private List<IncidenciaImportacion> _lstIncidencias = new List<IncidenciaImportacion>();


        #endregion PROPIEDADES PRIVADAS


        #region PROPIEDADES PÚBLICAS


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
        /// Descripción del paso detallado.
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


        #endregion PROPIEDADES PÚBLICAS


        #region MÉTODOS PRIVADOS


        /// <summary>
        /// Método para actualizar la barra de progreso asociada al BackgroundWorker.
        /// </summary>
        private void ActualizarBarraProgreso()
        {
            if (_oWorker != null && totalSteps > 0)
            {
                // Calculamos el progreso relativo a la barra teniendo en cuenta que la barra va de 0 a 100 %.
                //
                stepActual++;
                int lnProgresoRelativo100 = (stepActual * 100) / totalSteps;

                if (lnProgresoRelativo100 > 100)
                    lnProgresoRelativo100 = 100;

                _oWorker.ReportProgress(lnProgresoRelativo100);
            }

            return;
        }


        /// <summary>
        /// Método para actualizar el detalle del progreso.
        /// </summary>
        private void ActualizarProgresoDetalle()
        {
            if (_Mostrar_Progreso_Async != null)
                _Mostrar_Progreso_Async(_TextStepDetalle);

            return;
        }


        /// <summary>
        /// Escribir detalle importación y log.
        /// </summary>
        /// <param name="tcTexto"></param>
        /// <param name="teTipo"></param>
        private void EscribirLog(string tcTexto, TipoValidacion teTipo)
        {
            _TextStepDetalle = tcTexto;
            _lstIncidencias.Add(new IncidenciaImportacion(tcTexto, TipoValidacion.Error));
        }


        #endregion MÉTODOS PRIVADOS


        #region MÉTODOS PÚBLICOS


        /// <summary>
        /// Importar datos a Force Manager CRM
        /// </summary>        
        /// <returns></returns>
        public bool _Importar(BackgroundWorker toWorker = null)
        {
            _oWorker = toWorker;

            //_TotalSteps = 1 + ( (ISVobjetoImportar1) != null && ISVobjetoImportar1.Count > 0 ? 1 : 0) + (ISVobjetoImportar2 != null && ISVobjetoImportar2.Count > 0 ? 1 : 0) + 2;

            stepActual = 0;
            EscribirLog("Inicio importación", TipoValidacion.Ok);

            //_InicializarImportacion();

            //_RevisarCuentasEquivalentes();

            //_ImportarDatos()

            EscribirLog("La importación ha terminado", TipoValidacion.Ok);

            //SaveResults();

            EscribirLog("Logs guardados", TipoValidacion.Ok);

            return true;
        }


        #endregion MÉTODOS PÚBLICOS
    }


    /// <summary>
    /// Clase que contendrá todas las incidencias que se han producido en la ejecución del proceso de importación.
    /// </summary>
    public class IncidenciaImportacion
    {
        #region PROPIEDADES PRIVADAS
        
        /// <summary>
        /// 
        /// </summary>
        private TipoValidacion _eTipoValidacion = TipoValidacion.Ok;


        /// <summary>
        /// 
        /// </summary>
        private string _cDescripcion = string.Empty;
        
        
        #endregion PROPIEDADES PRIVADAS


        #region PROPIEDADES PÚBLICAS


        /// <summary>
        /// Identifica el tipo de incidencia.
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
        /// Descripción detallada del error de validación.
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


        #endregion PROPIEDADES PÚBLICAS

        
        #region CONSTRUCTORES


        /// <summary>
        /// Constructor vacio
        /// </summary>
        public IncidenciaImportacion()
        {
        }


        /// <summary>
        /// Constructor con el tipo de validación y la descripción de la incidencia.
        /// </summary>
        /// <param name="tcDescripcionIncidencia">Descripción de la incidencia.</param>
        /// <param name="teTipoValidacion">Tipo de validación.</param>
        public IncidenciaImportacion(string tcDescripcionIncidencia, TipoValidacion teTipoValidacion)
        {
            _Descripcion = tcDescripcionIncidencia;
            _TipoIncidencia = teTipoValidacion;
        }


        #endregion CONSTRUCTORES
    }

    /// <summary>
    /// Enumeración de tipos de validación.
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
    /// Enumeración de resultado de la importación.
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