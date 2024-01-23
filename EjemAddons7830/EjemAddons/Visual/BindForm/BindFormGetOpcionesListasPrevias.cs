using sage.ew.formul;
using sage.ew.formul.Forms;
using sage.ew.formul.UserControls;
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
    /// Ejemplo del evento _GetOpciones en el formulario de listas previas
    /// 
    /// En este ejemplo adicionalmente se realizará la modificación para las listas previas de asientos contables
    /// 
    /// Mediante el siguiente código se podrá acceder a las opciones que se presentan en el formulario de listas previas asientos contables poder gestionar acciones adicionales,
    /// limitar la ejecución de alguna opción y podremos ver cómo añadir una nueva opción en el botón de opciones.
    /// 
    /// Ejemplos:
    /// - Cómo añadir una nueva opción en el botón de opciones
    /// - Actualizar la descripción de una opción del botón de opciones
    /// - Modificar el estilo de la fuente a Negrita
    /// - Cambiar el color de una opción
    /// - Desactivar una opción con la lógica correspondiente
    /// - Bloquear una opción de menú en función del usuario actual
    /// 
    /// Se pueden realizar más acciones, el código simplemente es para ver cómo acceder a las opciones y varias de las posibilidades que tenemos.
    /// 
    /// Adicionalmente tenemos el ejemplo de cómo suscribirnos a los eventos OnClickInvalidate, OnClickBefore y OnClickAfter del "ToolStripMenuItemBase"
    /// </summary>
    public class BindFormGetOpcionesListasPrevias : BindFormBase
    {
        #region Propiedades privadas
        /// <summary>
        /// Referencia al formulario de listas previas
        /// </summary>
        private frmListasPrevias _ofrmListasPrevias = null;
        #endregion Propiedades privadas

        #region Constructor
        /// <summary>
        /// Constructor de la clase BindFormGetOpcionesListasPrevias
        /// </summary>
        /// <param name="toFormBase">Referencia al formulario al que estamos realizando el correspondiente _BindForm</param>
        public BindFormGetOpcionesListasPrevias(IFormBase toFormBase) : base(toFormBase)
        {
            // Asignamos la referencia del formulario de listas previas
            _ofrmListasPrevias = (sage.ew.formul.Forms.frmListasPrevias)toFormBase;
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
        /// Suscripción al evento "_GetOpciones" del formulario base de Sage 50 para poder gestionar las opciones de la lista previas del formulario de asientos
        /// </summary>
        public override void _SuscripcionEventos()
        {
            base._SuscripcionEventos();

            if (_oFormBase != null)
                _oFormBase._GetOpciones += BindFormGetOpcionesListasPrevias__GetOpciones;
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
                _oFormBase._GetOpciones -= BindFormGetOpcionesListasPrevias__GetOpciones;
        }
        #endregion Métodos public override

        #region Métodos privados
        /// <summary>
        /// Devuelve si la lista previa es de asientos
        /// 
        /// En el formulario de listas previas podemos tener en ejecución varios tipos de documento.
        /// En este método se gestiona si la lista previa es del tipo de asiento contable
        /// </summary>
        /// <returns></returns>
        private bool EsListaPreviaAsiento()
        {
            bool llAsientos = false;

            // Certificamos si el control activo es del tipo "ListasPreviasTab"
            if (_ofrmListasPrevias.ActiveControl is ListasPreviasTab)
            {
                ListasPreviasTab lofomListasPreviasTab = (ListasPreviasTab)_ofrmListasPrevias.ActiveControl;

                dynamic loformDocumento = lofomListasPreviasTab.ActiveControl;

                // Validamos si el control activo de la instancia de la clase "ListasPreviasTab" es una lista previa de asientos (ListasPreviasDocsAsientos)
                llAsientos = (loformDocumento is ListasPreviasDocsAsientos);
            }

            return llAsientos;
        }

        /// <summary>
        /// Ejemplo de cómo añadir opciones al menú contextual de herramientas del formulario de la lista previa de asientos contables
        /// </summary>
        /// <param name="toEnventArgOpciones">EventArgs con las opciones del ContextMenu</param>
        private void BindFormGetOpcionesListasPrevias__GetOpciones(ew.objetos.EventArgsOpciones toEnventArgOpciones)
        {
            if (toEnventArgOpciones.Sender == null)
                return;

            if (_ofrmListasPrevias == null)
                return;

            // Certificamos si la lista previa es de asientos contables
            bool llListaPreviasAsientos = EsListaPreviaAsiento();

            if (toEnventArgOpciones.Sender is ContextMenuStrip && llListaPreviasAsientos)
            {
                {
                    ContextMenuStrip loContextMenuStrip = ((ContextMenuStrip)toEnventArgOpciones.Sender);

                    string lcKeyOpcion = "NuevaOpcionListaPreviaAsientos"; // Asignamos un nombre para certificar que no existe el ToolStripMenuItemBase en la colección del ContextMenuStrip

                    Control loParent = loContextMenuStrip.Parent;

                    // Es necesario validar si existe el item en el ContextMenuStrip
                    if (!loContextMenuStrip.Items.ContainsKey(lcKeyOpcion))
                    {
                        // Añadimos un separador para separar del resto de opciones
                        loContextMenuStrip.Items.Add(new ToolStripSeparator());

                        // Instanciamos / configuramos el ToolStripMenuItemBase
                        ToolStripMenuItemBase loToolStripMenuItemBase = new ToolStripMenuItemBase();
                        loToolStripMenuItemBase.Name = lcKeyOpcion;
                        loToolStripMenuItemBase.Text = "Ejemplo nueva opción del botón de opciones de la lista previa de asientos contables (Ejemplo _GetOpciones)";
                        loToolStripMenuItemBase.Image = sage.ew.images.Properties.Resources.company_con_16;
                        loToolStripMenuItemBase.Click += ToolStripMenuItemBase_Click;

                        // Añadimos la opción
                        loContextMenuStrip.Items.Add(loToolStripMenuItemBase);
                    }

                    // Antes de presentar las opciones podremos personalizar o controlar las acciones a realizar
                    FrmListasPreviasGestionarOpciones(toEnventArgOpciones);
                }
            }
        }

        /// <summary>
        /// Acción a ejecutar al realizar el click sobre el ToolStripMenuItemBase añadido en el botón de opciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemBase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click sobre la nueva opción del botón de opciones en asientos contables (Ejemplo _GetOpciones)", _oFormBase.Text);
        }

        /// <summary>
        /// Antes de presentar las opciones podremos personalizar o controlar las acciones a realizar
        /// 
        /// toEnventArgOpciones.Opciones es una colección ToolStripMenuItemBase donde tenemos las diferentes opciones del botón
        /// </summary>
        /// <param name="tlstOpciones">Lista de opciones a presentar</param>
        private void FrmListasPreviasGestionarOpciones(EventArgsOpciones toEnventArgOpciones)
        {
            if (toEnventArgOpciones.Opciones == null || toEnventArgOpciones.Opciones.Count == 0) // No debe de pasar nunca
                return;

            foreach (ToolStripMenuItemBase loToolStripMenuItemBase in toEnventArgOpciones.Opciones)
            {
                string lcLowertext = loToolStripMenuItemBase.Text.ToLower();

                // Podemos gestionar las opciones por el valor de la propiedad Text
                if (lcLowertext.Contains("editar"))
                {
                    loToolStripMenuItemBase.Text = loToolStripMenuItemBase.Text + " asiento contable";
                    loToolStripMenuItemBase.ForeColor = System.Drawing.Color.Green;
                }

                // Modificamos el estilo de la fuente a Negrita y cambiamos el color
                if (lcLowertext.Contains("nuevo"))
                {
                    loToolStripMenuItemBase.Font = new System.Drawing.Font(loToolStripMenuItemBase.Font, System.Drawing.FontStyle.Bold);
                    loToolStripMenuItemBase.ForeColor = System.Drawing.Color.Green;
                }

                // Desactivar una opción
                if (lcLowertext.Contains("eliminar"))
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
        /// En este ejemplo únicamente dejamos utilizar la opción de "Exportar" al usuario SUPERVISOR
        /// </summary>
        /// <param name="toToolStripMenuItemBase">Referencia al ítem</param>
        /// <param name="tlCancel">Es necesario devolver true para que no continue con la ejecución del click</param>
        private void ToolStripMenuItemBase_OnClickInvalidate(ToolStripMenuItemBase toToolStripMenuItemBase, ref bool tlCancel)
        {
            // Podemos acceder al text y al nombre del ToolStripMenuItemBase
            string lcText = toToolStripMenuItemBase.Text;
            string lcName = toToolStripMenuItemBase.Name;

            // Bloquear la ejecución de una opción de menú en función del usuario actual
            if (lcText.ToLower().Contains("nuevo") && Convert.ToString(EW_GLOBAL._GetVariable("wc_usuario")) != "SUPERVISOR")
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

