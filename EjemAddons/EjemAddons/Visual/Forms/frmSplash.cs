using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sage.addons.EjemAddons.Visual.Forms
{
    /// <summary>
    /// Formulario splash que se muestra al acabar de cargar el escritorio de Sage50, en el arranque del addon de ejemplos.
    /// </summary>
    /// <remarks>
    /// Se llama a este formulario desde SageAddons.cs del addon de ejemplos mediante el método _ShowOnDesktopLoa() que se hereda
    /// de la clase Modulo de la cual deriva la clase sage.addons.EjemAddons.EjemAddons
    /// </remarks>
    public partial class frmSplash : Form
    {
        #region CONSTRUCTORES


        /// <summary>
        /// Constructor.
        /// </summary>
        public frmSplash()
        {
            InitializeComponent();

            this.ewSage50.Image = sage.ew.images.Properties.Resources.logo_verde_login;

            // Programación del Shown para activar timer y cierre el formulario al cabo de n segundos.
            //
            this.Shown += new System.EventHandler(this.frmSplash_Shown);

            // Programación del KeyDown para permitir al usuario cerrar el splash pulsando Escape antes de que se alcance el límite
            // de tiempo para mostrarse el splash en pantalla.
            //
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSplash_KeyDown);

            return;
        }


        #endregion CONSTRUCTORES


        #region METODOS PRIVADOS


        /// <summary>
        /// Programación del Shown para activar timer que una vez mostrado el splash, cierre el formulario al cabo de n segundos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSplash_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer loTimer = new System.Windows.Forms.Timer();
            
            // Programación del timer para que ejecute al cabo de 3 segundos (3000 ms).
            loTimer.Interval = 3000;   
            loTimer.Tick += LoTimer_Tick;
            loTimer.Enabled = true;
            loTimer.Start();

            return;
        }


        /// <summary>
        /// Método que se ejecutará a cada tick del timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoTimer_Tick(object sender, EventArgs e)
        {
            // Parar el timer.
            //
            System.Windows.Forms.Timer loTimer = (System.Windows.Forms.Timer)sender;
            loTimer.Stop();
            loTimer.Enabled = false;

            // Cerrar el formulario.
            //
            this.Close();

            return;
        }


        /// <summary>
        /// Programación del KeyDown para permitir al usuario cerrar el splash pulsando Escape antes de que se alcance el límite
        /// de tiempo para mostrarse el splash en pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmSplash_KeyDown(object sender, KeyEventArgs e)
        {
            // Si se detecta pulsación de tecla escape, cerrar formulario.
            //
            if (e.KeyValue == 27)  
                this.Close();

            return;
        }


        #endregion METODOS PRIVADOS
    }
}
