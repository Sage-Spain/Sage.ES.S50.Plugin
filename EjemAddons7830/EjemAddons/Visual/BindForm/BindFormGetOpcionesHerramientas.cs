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
    /// BindFormBotonHerramientas
    /// 
    /// Ejemplo del evento _GetOpcionesHerramientas para el botón de "icono de herramientas" de los documentos de venta.
    /// Mediante este caso se puede añadir una nueva opción los formularios de venta de Sage 50 que nos presente un mensaje con el título del formulario.
    /// Este ejemplo es compatible con todos los formularios de Sage 50 que disponen el "icono de herramientas".
    /// </summary>
    public class BindFormGetOpcionesHerramientas : BindFormBase
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase BindFormGetOpcionesHerramientas
        /// </summary>
        /// <param name="toFormBase">Referencia al formulario al que estamos realizando el correspondiente _BindForm</param>
        public BindFormGetOpcionesHerramientas(IFormBase toFormBase) : base(toFormBase)
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
        /// Suscripción al evento "_GetOpcionesHerramientas" del formulario base de Sage 50 para poder añadir opciones en el botón de herramientas de los formularios de Sage 50
        /// </summary>
        public override void _SuscripcionEventos()
        {
            // Importante realizar siempre el código de la base al realizar un override
            base._SuscripcionEventos();

            if (_oFormBase != null)
                _oFormBase._GetOpcionesHerramientas += FrmDocBotonHerramientas__GetOpcionesHerramientas;
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
                _oFormBase._GetOpcionesHerramientas -= FrmDocBotonHerramientas__GetOpcionesHerramientas;
        }
        #endregion Métodos public override

        #region Métodos privados
        /// <summary>
        /// Ejemplo de cómo añadir opciones al menú contextual de herramientas de los formularios de Sage 50
        /// </summary>
        /// <param name="toEnventArgOpcionesHerramientas"></param>
        private void FrmDocBotonHerramientas__GetOpcionesHerramientas(EventArgsOpciones toEnventArgOpcionesHerramientas)
        {
            if (toEnventArgOpcionesHerramientas.Sender == null)
                return;

            if (toEnventArgOpcionesHerramientas.Sender is ContextMenuStrip)
            {
                ContextMenuStrip loContextMenuStrip = ((ContextMenuStrip)toEnventArgOpcionesHerramientas.Sender);

                string lcKeyOpcion = "NuevaOpcionHerramientas";

                // Es necesario validar si existe el item en el ContextMenuStrip
                if (!loContextMenuStrip.Items.ContainsKey(lcKeyOpcion))
                {
                    // Añadimos un separador para separar de las opciones estándar
                    loContextMenuStrip.Items.Add(new ToolStripSeparator());

                    // Importante utilizar el ToolStripMenuItemBase para poder gestionar los eventos _OnClickBefore, _OnClickAfter y _OnClickInvalidate si es necesario
                    ToolStripMenuItemBase loToolStripMenuItemBase = new ToolStripMenuItemBase();
                    loToolStripMenuItemBase.Name = lcKeyOpcion;
                    loToolStripMenuItemBase.Text = "Título del formulario (Ejemplo _GetOpcionesHerramientas)";
                    loToolStripMenuItemBase.Image = sage.ew.images.Properties.Resources.accounts_Level_16;
                    loToolStripMenuItemBase.Click += ToolStripMenuItemBaseTituloFormulario_Click;

                    // Añadimos el elemento
                    loContextMenuStrip.Items.Add(loToolStripMenuItemBase);
                }
            }
        }

        /// <summary>
        /// Presenta un mensaje con el título del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemBaseTituloFormulario_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"El título del formulario es {_oFormBase?.Text}.");
        }
        #endregion Métodos privados
    }
}
