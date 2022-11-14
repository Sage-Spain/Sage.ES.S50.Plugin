using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Sage50
using sage.ew.botones;
using sage.ew.empresa;
using sage.ew.objetos;
using sage.ew.contabilidad;
using sage.ew.ewbase;
using sage.addons.EjemAddons.Negocio.Clases;

namespace sage.addons.EjemAddons.Visual.UserControls
{
    public partial class EjemAsistente_PaginaProceso : UserControl
    {
        #region Propiedades


        /// <summary>
        /// Referencia al objeto de negocio para la importación de XDiario
        /// </summary>
        public Importacion _Importacion
        {
            get { return _oImportacion; }
            set { _oImportacion = value; }
        }
        private Importacion _oImportacion = null;

        /// <summary>
        /// Propiedad pública para mostrar en el cuadro de texto el progreso
        /// </summary>
        public string _TextoDetalle
        {
            set
            {
                if (!String.IsNullOrEmpty(value) && value != _Texto)
                {
                    _Texto = value;

                    if (!this.txtDetalle.Visible)
                        this.txtDetalle.Visible = true;
                }
            }
        }
        private string _Texto = "";


        /// <summary>
        /// Propiedad pública para mostrar texto del progreso
        /// </summary>
        public string _TextProgreso
        {
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.lblProgreso.Text = value;

                    if (!this.lblProgreso.Visible)
                        this.lblProgreso.Visible = true;
                }
            }
        }

        /// <summary>
        /// Propiedad pública para cambiar el % de la barra de progreso
        /// </summary>
        public int _BarraProgreso
        {
            set
            {
                if (value >= 0)
                {
                    this.ewProgressBar.Value = value;

                    if (!this.ewProgressBar.Visible)
                        this.ewProgressBar.Visible = true;
                }
            }
        }

        /// <summary>
        /// Para mostrar detalle
        /// </summary>
        private string _Resumen = "";

        /// <summary>
        /// Para saber si ya hemos iniciado esta página
        /// </summary>
        private bool _lIniciado = false;

        #endregion Propiedades

        public EjemAsistente_PaginaProceso()
        {
            InitializeComponent();
        }


        #region Métodos privados

        /// <summary>
        /// Para poder mostrar progreso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AsistenteImportacionProceso_Enter(object sender, EventArgs e)
        {
            if (_oImportacion != null)
            {
                if (!_lIniciado)
                {
                    _Estado("inicial");
                    _lIniciado = true;
                }

                _oImportacion._Mostrar_Progreso_Async -= _oImportaXDiario__Mostrar_Progreso_Async;
                _oImportacion._Mostrar_Progreso_Async += _oImportaXDiario__Mostrar_Progreso_Async;
            }
        }

        /// <summary>
        /// Para poder mostrar detalle
        /// </summary>
        /// <param name="message"></param>
        private void _oImportaXDiario__Mostrar_Progreso_Async(string message)
        {
            if (txtDetalle.Parent == null)
                return;

            try
            {
                _Resumen = _Resumen + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " " + message + Environment.NewLine;
                txtDetalle.Invoke((MethodInvoker)(() => txtDetalle.Text = _Resumen));
                txtDetalle.Invoke((MethodInvoker)(() => txtDetalle.SelectionStart = txtDetalle.Text.Length));
                txtDetalle.Invoke((MethodInvoker)(() => txtDetalle.ScrollToCaret()));
            }
            catch (Exception) { }
        }

        #endregion Métodos privados


        #region Métodos públicos

        /// <summary>
        /// Estado de la página
        /// </summary>
        /// <param name="tlFinal"></param>
        public void _Estado(string tcEstado = "inicial")
        {
            bool llVisible = false, llDetalleVisible = false;
            string lcTituloDetalle = "";


            switch (tcEstado)
            {
                case "inicial":
                    lcTituloDetalle = "Pulsa el botón Empezar para iniciar la importación";
                    llVisible = false;
                    llDetalleVisible = false;
                    break;

                case "importando":
                    lcTituloDetalle = "Resumen de la importación";
                    llVisible = true;
                    llDetalleVisible = true;
                    break;

                case "final":
                    lcTituloDetalle = "Resumen de la importación";
                    llVisible = false;
                    llDetalleVisible = true;
                    txtDetalle.Invoke((MethodInvoker)(() => txtDetalle.Height += 65));
                    break;
            }

            lblTituloDetalle.Invoke((MethodInvoker)(() => lblTituloDetalle.Text = lcTituloDetalle));
            txtDetalle.Invoke((MethodInvoker)(() => txtDetalle.Visible = llDetalleVisible));
            lblProgreso.Invoke((MethodInvoker)(() => lblProgreso.Visible = llVisible));
            ewProgressBar.Invoke((MethodInvoker)(() => ewProgressBar.Visible = llVisible));
        }

        #endregion Métodos públicos


    }
}
