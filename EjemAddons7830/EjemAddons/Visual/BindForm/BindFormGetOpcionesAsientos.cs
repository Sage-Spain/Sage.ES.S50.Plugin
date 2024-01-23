using sage.ew.formul;
using sage.ew.global;
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
    /// BindFormGetOpcionesAsientos
    /// 
    /// Ejemplo del evento _GetOpciones en el formulario de asientos contables
    /// 
    /// Mediante el siguiente código se podrá acceder a las opciones que se presentan en el formulario de asientos contables poder gestionar acciones adicionales,
    /// limitar la ejecución de alguna opción y podremos ver cómo añadir una nueva opción en el botón de opciones.
    /// 
    /// Ejemplos:
    /// - Cómo añadir una nueva opción en el botón de opciones
    /// - Actualizar la descripción de una opción del botón de opciones
    /// - Modificar el estilo de la fuente a Negrita
    /// - Cambiar el color de una opción
    /// - Ocultar una opción a partir de si contiene un texto
    /// - Desactivar una opción con la lógica correspondiente
    /// - Bloquear una opción de menú en función del usuario actual
    /// 
    /// Se pueden realizar más acciones, el código simplemente es para ver cómo acceder a las opciones y varias de las posibilidades que tenemos.
    /// 
    /// Adicionalmente tenemos el ejemplo de cómo suscribirnos a los eventos OnClickInvalidate, OnClickBefore y OnClickAfter del "ToolStripMenuItemBase"
    /// </summary>
    public class BindFormGetOpcionesAsientos : BindFormBase
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase BindFormGetOpcionesAsientos
        /// </summary>
        /// <param name="toFormBase">Referencia al formulario al que estamos realizando el correspondiente _BindForm</param>
        public BindFormGetOpcionesAsientos(IFormBase toFormBase) : base(toFormBase)
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
        /// Suscripción al evento "_GetOpciones" del formulario base de Sage 50 para poder gestionar las opciones del formulario de asientos
        /// </summary>
        public override void _SuscripcionEventos()
        {
            base._SuscripcionEventos();

            if (_oFormBase != null)
                _oFormBase._GetOpciones += BindFormGetOpcionesAsientos__GetOpciones;
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
                _oFormBase._GetOpciones -= BindFormGetOpcionesAsientos__GetOpciones;
        }
        #endregion Métodos public override

        #region Métodos privados
        /// <summary>
        /// Ejemplo de cómo añadir opciones al menú contextual de herramientas del formulario de asientos contables
        /// </summary>
        /// <param name="toEnventArgOpciones">EventArgs con las opciones del ContextMenu</param>
        private void BindFormGetOpcionesAsientos__GetOpciones(ew.objetos.EventArgsOpciones toEnventArgOpciones)
        {
            if (toEnventArgOpciones.Sender == null)
                return;

            if (toEnventArgOpciones.Sender is ContextMenuStrip)
            {
                ContextMenuStrip loContextMenuStrip = ((ContextMenuStrip)toEnventArgOpciones.Sender);

                string lcKeyOpcion = "NuevaOpcionAsientos"; // Asignamos un nombre para certificar que no existe el ToolStripMenuItemBase en la colección del ContextMenuStrip

                Control loParent = loContextMenuStrip.Parent;

                // Es necesario validar si existe el item en el ContextMenuStrip
                if (!loContextMenuStrip.Items.ContainsKey(lcKeyOpcion))
                {
                    // Añadimos un separador para separar del resto de opciones
                    loContextMenuStrip.Items.Add(new ToolStripSeparator());
                    
                    // Instanciamos / configuramos el ToolStripMenuItemBase
                    ToolStripMenuItemBase loToolStripMenuItemBase = new ToolStripMenuItemBase();
                    loToolStripMenuItemBase.Name = lcKeyOpcion;
                    loToolStripMenuItemBase.Text = "Ejemplo nueva opción del botón de opciones en asientos contables (Ejemplo _GetOpciones)";
                    loToolStripMenuItemBase.Image = sage.ew.images.Properties.Resources.company_con_16;
                    loToolStripMenuItemBase.Click += ToolStripMenuItemBase_Click;

                    // Añadimos la opción
                    loContextMenuStrip.Items.Add(loToolStripMenuItemBase);
                }

                // Antes de presentar las opciones podremos personalizar o controlar las acciones a realizar
                FrmAsientosGestionarOpciones(toEnventArgOpciones);
            }
        }

        /// <summary>
        /// Acción a ejecutar al realizar el click sobre el ToolStripMenuItemBase añadido en el botón de opciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemBase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click sobre la nueva opción del botón de opciones en asientos contables (Ejemplo _GetOpciones)" , _oFormBase.Text);
        }

        /// <summary>
        /// Antes de presentar las opciones podremos personalizar o controlar las acciones a realizar
        /// 
        /// toEnventArgOpciones.Opciones es una colección ToolStripMenuItemBase donde tenemos las diferentes opciones del botón
        /// </summary>
        /// <param name="tlstOpciones">Lista de opciones a presentar</param>
        private void FrmAsientosGestionarOpciones(EventArgsOpciones toEnventArgOpciones)
        {
            if (toEnventArgOpciones.Opciones == null || toEnventArgOpciones.Opciones.Count == 0) // No debe de pasar nunca
                return;

            // Recorremos las diferentes opciones que se presentan en el botón de opciones
            foreach (ToolStripMenuItemBase loToolStripMenuItemBase in toEnventArgOpciones.Opciones)
            {
                string lcLowertext = loToolStripMenuItemBase.Text.ToLower();

                // Actualizamos la descripción de una opción del botón de opciones
                if (lcLowertext.Contains("zoom"))
                    loToolStripMenuItemBase.Text = loToolStripMenuItemBase.Text + " del asiento contable y detalla de los impuestos";

                // Modificamos el estilo de la fuente a Negrita
                if (lcLowertext.Contains("revisión"))
                    loToolStripMenuItemBase.Font = new System.Drawing.Font(loToolStripMenuItemBase.Font, System.Drawing.FontStyle.Bold);

                // Actualizamos el color
                if (lcLowertext.Contains("factura"))
                    loToolStripMenuItemBase.ForeColor = System.Drawing.Color.Blue;

                // Ocultar una opción a partir de si contiene un texto
                if (lcLowertext.Contains("dua"))
                    loToolStripMenuItemBase.Visible = false;

                // Desactivamos una opción con la lógica que pertoque, en esta caso desactivamos los datos adicionales del SII
                if (loToolStripMenuItemBase.Text.Contains("adicionales"))
                    loToolStripMenuItemBase.Enabled = false;

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
        /// En este ejemplo únicamente dejamos utilizar la opción de "Ver factura" al usuario SUPERVISOR
        /// </summary>
        /// <param name="toToolStripMenuItemBase">Referencia al ítem</param>
        /// <param name="tlCancel">Es necesario devolver true para que no continue con la ejecución del click</param>
        private void ToolStripMenuItemBase_OnClickInvalidate(ToolStripMenuItemBase toToolStripMenuItemBase, ref bool tlCancel)
        {
            // Podemos acceder al text y al nombre del ToolStripMenuItemBase
            string lcText = toToolStripMenuItemBase.Text;
            string lcName = toToolStripMenuItemBase.Name;

            // Bloquear una opción de menú en función del usuario actual
            if (lcText.ToLower().Contains("ver factura") && Convert.ToString(EW_GLOBAL._GetVariable("wc_usuario")) != "SUPERVISOR")
            {
                tlCancel = true; // Asignamos el valor "true" a "tlCancel" para cancelar la ejecución de la acción
                MessageBox.Show($"OnClickInvalidate del ítem {lcText}. Únicamente puede acceder a ver factura el usuario SUPERVISOR.");
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
