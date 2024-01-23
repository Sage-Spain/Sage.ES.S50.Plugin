using sage.ew.functions;
using sage.ew.interficies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sage.addons.EjemAddons.Visual.BindForm
{
    /// <summary>
    /// Clase para gestionar los eventos sobre click de un botón
    /// 
    /// En el proceso de facturación general una vez presenta la lista de albaranes a facturar, se realizará la búsqueda del botón aceptar
    /// y realizaremos un ejemplo de los 3 eventos que tenemos disponibles para realizar acciones antes, después o para invalidar el proceso.
    /// 
    /// Se realiza la búsqueda del botón de aceptar para gestionar los 3 eventos : OnClickBefore, OnClickAfter y OnClickInvalidate
    /// </summary>
    public class BindFormEventosClick : BindFormBase
    {
        #region Propiedades privadas
        /// <summary>
        /// Referencia al botón de aceptar
        /// </summary>
        private sage.ew.botones.btDocAceptar _obtDocAceptar = null;
        #endregion Propiedades privadas

        #region Constructor
        /// <summary>
        /// Constructor de la clase BindFormBotonHerramientas
        /// </summary>
        /// <param name="toFormBase">Referencia al formulario al que estamos realizando el correspondiente _BindForm</param>
        public BindFormEventosClick(IFormBase toFormBase) : base(toFormBase)
        {
        }
        #endregion Constructor

        #region Métodos public override
        /// <summary>
        /// Buscamos el botón de aceptar y suscripción a los eventos para gestionar
        /// </summary>
        public override void _Init()
        {
            base._Init();

            // Buscamos el botón de aceptar del formulario
            FindBotonAceptar();

            _SuscripcionEventos();
        }

        /// <summary>
        /// Método que busca el botón de aceptar
        /// 
        /// Si existen dos controles del mismo tipo se puede buscar por nombre  _FindControl("nombreObjetoBuscado") o con el método _FindControl() del formulario base que devuelve una lista de controles de un tipo específico
        /// </summary>
        private void FindBotonAceptar()
        {
            Control loControl = _FindControl<ew.botones.btDocAceptar>(); // Buscamos el botón de aceptar por un tipo en concreto "ew.botones.btDocAceptar"

            if (loControl != null)
                _obtDocAceptar = (ew.botones.btDocAceptar)loControl;
        }

        /// <summary>
        /// suscripción a los 3 eventos que vamos a gestionar en esta clase
        /// </summary>
        public override void _SuscripcionEventos()
        {
            base._SuscripcionEventos();

            if (_obtDocAceptar != null)
            {
                _obtDocAceptar.OnClickInvalidate += BotonDocAceptar_OnClickInvalidate;
                _obtDocAceptar.OnClickBefore += BotonDocAceptar_OnClickBefore;
                _obtDocAceptar.OnClickAfter += BotonDocAceptar_OnClickAfter; ;
            }
        }

        /// <summary>
        /// Cancelar la suscripción a los eventos para la correcta liberación de la memoria
        /// Muy importante desuscribirse de los eventos suscritos para 
        /// </summary>
        public override void _CancelarSuscripcionEventos()
        {
            base._SuscripcionEventos();

            if (_obtDocAceptar != null)
            {
                _obtDocAceptar.OnClickInvalidate -= BotonDocAceptar_OnClickInvalidate;
                _obtDocAceptar.OnClickBefore -= BotonDocAceptar_OnClickBefore;
                _obtDocAceptar.OnClickAfter -= BotonDocAceptar_OnClickAfter; ;
            }
        }

        /// <summary>
        /// Gestión del Dispose
        /// 
        /// Asignamos _obtDocAceptar a null para eliminar referencias y permitir liberar la memoria correctamente
        /// </summary>
        public override void Dispose()
        {
            base.Dispose(); // Realizamos el Dispose de la base para su correcta liberarción de la memoria

            _obtDocAceptar = null; // Asignamos la referencia a null para poder liberar la memoria
        }
        #endregion Métodos public override

        #region Métodos privados
        /// <summary>
        /// Controles previos a la ejecución de la acción relacionada con el click
        /// 
        /// Presentaremos el mensaje de si desea continuar con el proceso de facturación
        /// Mediante este evento podremos cancelar la ejecución de cualquier proceso
        /// </summary>
        /// <param name="toButton">Referencia al botón</param>
        /// <param name="tlCancel">Para poder cancelar el proceso es necesario asignar => tlCancel = true</param>
        private void BotonDocAceptar_OnClickInvalidate(ew.objetos.ewbutton toButton, ref bool tlCancel)
        {
            if (FUNCTIONS._MessageBox("¿Desea continuar con el proceso de facturación (Evento OnClickInvalidate)?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, DialogResult.Yes) == DialogResult.No)
                tlCancel = true; // Asignamos el valor true a tlCancel para cancelar el proceso de facturación
        }

        /// <summary>
        /// Realizamos las acciones necesarias antes de ejecutar el click del botón de Aceptar
        /// 
        /// En este caso presentamos un aviso de que se va a empezar el proceso de facturación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonDocAceptar_OnClickBefore(object sender, EventArgs e)
        {
            if (!(sender is ew.botones.btDocAceptar))
                return;

            MessageBox.Show("Se va a iniciar el proceso de facturación (Evento OnClickBefore)");
        }

        /// <summary>
        /// Realizamos las acciones necesarias después de ejecutar el click del botón de Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonDocAceptar_OnClickAfter(object sender, EventArgs e)
        { 
              if (!(sender is ew.botones.btDocAceptar))
                    return;

            MessageBox.Show("Se va a iniciar el proceso de facturación (Evento OnClickAfter)");
        }
        #endregion Métodos privados
    }
}
