using sage.ew.formul;
using sage.ew.interficies;
using sage.ew.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sage.addons.EjemAddons.Visual.BindForm
{
    /// <summary>
    /// BindFormGetOpcionesDocumentosVenta
    /// 
    /// Ejemplo del evento _GetOpciones en los documentos de venta
    /// 
    /// Mediante el siguiente código se podrá acceder a las opciones que se presentan en los documentos para poder gestionar acciones adicionales
    /// así cómo limitar la ejecución de alguna opción.
    /// 
    /// Ejemplos: 
    /// - Cambiar el estilo de la fuente de una opción a negrita
    /// - Bloquear una opción del menú en función del día y presentando un aviso mediante el evento OnClickInvalidate
    /// - Ocultar una opción
    /// - Y desactivar una opción si es necesario
    /// - Cambiar el texto de una opción
    /// 
    /// Se pueden realizar más acciones, el código simplemente es para ver cómo acceder a las opciones y varias de las posibilidades que tenemos.
    /// 
    /// Adicionalmente tenemos el ejemplo de cómo suscribirnos a los eventos OnClickInvalidate, OnClickBefore y OnClickAfter del "ToolStripMenuItemBase"
    /// </summary>
    public class BindFormGetOpcionesDocumentosVenta : BindFormBase
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase BindFormGetOpcionesDocumentosVenta
        /// </summary>
        /// <param name="toFormBase">Referencia al formulario al que estamos realizando el correspondiente _BindForm</param>
        public BindFormGetOpcionesDocumentosVenta(IFormBase toFormBase) : base(toFormBase)
        {
        }
        #endregion Constructor

        #region Métodos public override
        /// <summary>
        /// Suscripción a los eventos necesarios
        /// </summary>
        public override void _Init()
        {
            base._Init();

            _SuscripcionEventos();
        }

        /// <summary>
        /// Suscripción al evento "_GetOpciones" del formulario base de Sage 50 para poder gestionar las opciones que presenta en los diferentes documentos
        /// </summary>
        public override void _SuscripcionEventos()
        {
            // Importante realizar siempre el código de la base al realizar un override
            base._SuscripcionEventos();

            if (_oFormBase != null)
                _oFormBase._GetOpciones += BindFormGetOpcionesDocumentosVenta__GetOpciones;
        }

        /// <summary>
        /// Cancelación a suscripción de los eventos para la correcta liberación de la memoria
        /// 
        /// Se llamará este método cuando se realice el Dispose (Está implementado en el Dispose de la base)
        /// </summary>
        public override void _CancelarSuscripcionEventos()
        {
            base._CancelarSuscripcionEventos();

            if (_oFormBase != null)
                _oFormBase._GetOpciones -= BindFormGetOpcionesDocumentosVenta__GetOpciones;
        }
        #endregion Métodos public override

        #region Métodos privados
        /// <summary>
        /// Ejemplo de cómo modificar opciones del menú contextual de herramientas de los formularios de Sage 50
        /// y gestionar las acciones al suscribirnos a los 3 eventos disponibles para gestionar la invalidación de una acción
        /// </summary>
        /// <param name="toEnventArgOpciones">EventArgs con las opciones del ContextMenu</param>
        private void BindFormGetOpcionesDocumentosVenta__GetOpciones(EventArgsOpciones toEnventArgOpciones)
        {
            if (toEnventArgOpciones.Opciones == null || toEnventArgOpciones.Opciones.Count == 0) // Si no hay opciones ya podemos salir
                return;

            foreach (ToolStripMenuItemBase loToolStripMenuItemBase in toEnventArgOpciones.Opciones)
            {
                // Actualizamos el estilo de la fuente a Negrita
                if (loToolStripMenuItemBase.Text.Contains("factura"))
                {
                    if (loToolStripMenuItemBase.Text == "Ver factura")
                        loToolStripMenuItemBase.Text = loToolStripMenuItemBase.Text + " del cliente"; // Podemos cambiar el texto de una opción

                    loToolStripMenuItemBase.Font = new System.Drawing.Font(loToolStripMenuItemBase.Font, System.Drawing.FontStyle.Bold);
                }

                // Ocultar una opción
                if (loToolStripMenuItemBase.Text.Contains("vales"))
                    loToolStripMenuItemBase.Visible = false; // Podemos ocultar opciones

                // Adicionalmente podemos gestionar suscribirnos a los 3 eventos disponibles para gestionar la invalidación de una acción
                loToolStripMenuItemBase.OnClickInvalidate += ToolStripMenuItemBase_OnClickInvalidate;

                // Evento Before si es necesario realizar alguna acción previa 
                loToolStripMenuItemBase.OnClickBefore += ToolStripMenuItemBase_OnClickBefore;

                // Evento Before si es necesario realizar alguna acción previa 
                loToolStripMenuItemBase.OnClickAfter += ToolStripMenuItemBase_OnClickAfter;
            }
        }

        /// <summary>
        /// Controles previos al click del ToolStripMenuItem para poder cancelar la ejecución de la acción
        /// 
        /// En este ejemplo no permitimos realizar una acción hasta que el día del mes no sea superior o igual a 15
        /// </summary>
        /// <param name="toToolStripMenuItemBase">Referencia al ítem</param>
        /// <param name="tlCancel">Es necesario devolver true para que no continue con la ejecución del click</param>
        private void ToolStripMenuItemBase_OnClickInvalidate(ToolStripMenuItemBase toToolStripMenuItemBase, ref bool tlCancel)
        {
            // Podemos acceder al text y al nombre del ToolStripMenuItemBase
            string lcText = toToolStripMenuItemBase.Text; 
            string lcName = toToolStripMenuItemBase.Name;

            // Bloquear una opción de menú en función del día y presentando un aviso
            if (lcText.Contains("contado") && DateTime.Now.Date.Day < 15)
            {
                tlCancel = true; // Asignamos el valor "true" a "tlCancel" para cancelar la ejecución de la acción
                MessageBox.Show($"OnClickInvalidate del ítem {lcText}. Acción no permitida hasta que hasta el día 15 de cada mes.");
                return;
            }

            MessageBox.Show($"OnClickInvalidate del ítem {lcText}.", _oFormBase.Text);
        }

        /// <summary>
        /// Realizamos las acciones necesarias antes de ejecutar el click del ToolStripMenuItem
        /// 
        /// Ejemplo: Presentamos un mensaje con el valor de la propiedad "Text" que visualiza el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemBase_OnClickBefore(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItemBase))
                return;

            string lcText = ((ToolStripMenuItemBase)sender).Text;

            MessageBox.Show($"Click Before de la opción {lcText}.", _oFormBase.Text);
        }

        /// <summary>
        /// Realizamos las acciones necesarias antes de ejecutar el click del ToolStripMenuItem
        /// 
        /// Ejemplo: Presentamos un mensaje con el valor de la propiedad "Text" que visualiza el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemBase_OnClickAfter(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItemBase))
                return;

            string lcText = ((ToolStripMenuItemBase)sender).Text;

            MessageBox.Show($"Click After de la opción {lcText}.", _oFormBase.Text);
        }
        #endregion Métodos privados
    }
}
