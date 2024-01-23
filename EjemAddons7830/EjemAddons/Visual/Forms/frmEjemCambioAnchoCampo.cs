using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sage.ew.formul.Forms;
using sage.ew.functions;
using sage._50;
using System.Linq;
using sage.ew.usuario;
using Sage.ES.S50.Addons;
using sage.ew.interficies;
using sage.ew.global;
using sage.ew.db;
using sage.ew.ewbase;

namespace sage.addons.EjemAddons.Visual.Forms
{
    /// <summary>
    /// Formulario de ejemplo de implementación de cambio de anchura de campos.
    /// </summary>
    public partial class frmEjemCambioAnchoCampo : FormDialog, IAddons
    {
        #region PROPIEDADES PRIVADAS


        /// <summary>
        /// Objeto de negocio que nos permite consultar la lista de todos los campos configurables en anchura de Sage50 y utilizar sus métodos para proceder
        /// al cambio de anchura.
        /// </summary>
        CambioAnchuraCampos cambioAnchuraCampos = null;


        /// <summary>
        /// Diccionario donde cargaremos las extensiones para cambio de anchra de campos que tengan los addons disponibles, para ejecutar en el proceso de 
        /// validaciones previas antes de ejecutar definitivamente el cambio de anchura en los campos solicitados. Algunos addons incluyen algunas
        /// restricciones en el cambio de anchura de campos.
        /// </summary>
        public Dictionary<string, object> _Addons
        {
            get { return this._oAddons; }
            set { this._oAddons = value; }
        }
        private Dictionary<string, object> _oAddons = new Dictionary<string, object>();


        #endregion PROPIEDAES PRIVADAS


        #region CONSTRUCTOR


        /// <summary>
        /// Constructor.
        /// </summary>
        public frmEjemCambioAnchoCampo()
        {
            InitializeComponent();

            if (this.DesignMode || !EW_GLOBAL._EsEjecutable)
                return;

            this.cambioAnchuraCampos = new CambioAnchuraCampos();

            this.addons_Cargar();

            this.configuracionVisual();

            return;
        }


        #endregion CONSTRUCTOR


        #region MÉTODOS PROTECTED OVERRIDE


        /// <summary>
        /// Se ejecuta al mostrarse el formulario por pantalla.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.ewNumArticuloAnchoStandar._ReadOnly = true;
            this.ewNumArticuloAnchoActual._ReadOnly = true;
            this.ewNumArticuloAnchoMinimo._ReadOnly = true;
            this.ewNumArticuloAnchoMaximo._ReadOnly = true;

            this.ewNumCuentaAnchoStandar._ReadOnly = true;
            this.ewNumCuentaAnchoActual._ReadOnly = true;
            this.ewNumCuentaAnchoMinimo._ReadOnly = true;
            this.ewNumCuentaAnchoMaximo._ReadOnly = true;


            return;
        }


        #endregion MÉTODOS PROTECTED OVERRIDE


        #region MÉTODOS PÚBLICOS


        /// <summary>
        /// Click sobre el botón Aceptar para ejecutar el proceso de cambio de anchura de campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDocAceptar1_Click(object sender, EventArgs e)
        {
            // Comprobaciones varias antes empezar la ejecución del proceso de cambio de anchura de campos.
            //
            if (!this.validacionesPreProceso())
                return;

            // Avisar al usuario de los cambios que se van a realizar y preguntar si quiere continuar con los cambios.
            //
            if (!this.preguntarUsuario())
                return;

            // Realizar proceso de cambio de anchura de campos en los campos seleccionados.
            //
            bool llOk = this.cambiarAnchurasCampos(out string lcMensajeError);
            if (!llOk)
            {
                // Algo no fue bien.
                //
                FUNCTIONS._MessageBox("El proceso de cambio de anchura de campos ha finalizado con incidencias." +
                                      Environment.NewLine + Environment.NewLine + lcMensajeError +
                                      Environment.NewLine +
                                      "Revise los campos con incidencias." +
                                      Environment.NewLine + Environment.NewLine +
                                      "Se reiniciará la aplicación a continuación.",
                                      "Cambio de anchura de campos", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                // Los cambios se pudieron realizar correctamente.
                //
                string lcCampoAmpliados = "";
                foreach (CambioAnchuraCampos.Campo loCampo in this.cambioAnchuraCampos._ListaCamposAmpliables.Where(campo => (campo._Nombre=="ARTICULO" || 
                                                                                                                    campo._Nombre == "CUENTAS") && 
                                                                                                                    campo._AnchoNuevo != campo._AnchoActual))
                {
                    lcCampoAmpliados += "Campo " + loCampo._Nombre.Trim() + " nueva longitud: " + loCampo._AnchoNuevo.ToString().Trim() + Environment.NewLine;
                }

                FUNCTIONS._MessageBox("El proceso de cambio de anchura de campos se ha realizado correctamente." + Environment.NewLine + Environment.NewLine +
                                      "Campos modificados: " + Environment.NewLine + Environment.NewLine +
                                      lcCampoAmpliados +
                                      Environment.NewLine +
                                      "Para el correcto funcionamiento se reiniciará la aplicación a continuación.", "Cambio de anchura de campos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            // Cuando se ha realizado el cambio de anchura de algún campo hay que reiniciar la aplicación sí o sí. No se puede permitir al usuario entrar
            // en ninguna pantalla sin antes reiniciar la aplicación y entonces ya cargará todo correctamente. 
            //
            // No existe la posibilidad de ejecutar alguna recarga de configuración de algún tipo que permita continuar trabajando como si nada hubiera
            // pasado, hay que reiniciar la aplicacion sí o sí.
            //
            FUNCTIONS._CerrarAplicacion();

            return;
        }

        
        /// <summary>
        /// Click sobre el botón Cancelar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDocCancelar1_Click(object sender, EventArgs e)
        {
            this.Close();

            return;
        }


        #endregion MÉTODOS PÚBLICOS


        #region MÉTODOS PRIVADOS


        /// <summary>
        /// Cargar contenido de campos visuales en pantalla.
        /// </summary>
        private void configuracionVisual()
        {
            // Obtenemos toda la informacion sobre el campo ARTICULO: ancho actual, ancho estándar, ancho mínimo, ancho máximo, etc., y la ponemos en los
            // campos respectivos de pantalla.
            //
            // Recordar que en this.cambioAnchuraCampos._ListaCamposAmpliables están todos los campos que se pueden cambiar la anchura.
            //
            // En este ejemplo concreto nos vamos a ocupar sólamente de dos de elos ARTICULO y CUENTA.
            //
            CambioAnchuraCampos.Campo loCampoArticulo = this.cambioAnchuraCampos._ListaCamposAmpliables.
                                                        Where(campo => campo._Nombre == "ARTICULO").FirstOrDefault();
            if (loCampoArticulo != null)
            {
                ewNumArticuloAnchoStandar.Value = loCampoArticulo._AnchoEstandar;
                ewNumArticuloAnchoActual.Value = loCampoArticulo._AnchoActual;

                ewNumArticuloAnchoMinimo.Value = loCampoArticulo._AnchoMinimo;
                ewNumArticuloAnchoMaximo.Value = loCampoArticulo._AnchoMaximo;

                ewNumArticuloAnchoNuevo.Value = loCampoArticulo._AnchoActual;
                ewNumArticuloAnchoNuevo.Minimum = loCampoArticulo._AnchoMinimo;
                ewNumArticuloAnchoNuevo.Maximum = loCampoArticulo._AnchoMaximo;

                ewTxtArticuloRellenarCon.Text = loCampoArticulo._RellenoValor;
                ewNumArticuloAPartirPosicion.Value = loCampoArticulo._RellenoPosicion;

                ewComboArticuloEmpezarPor.DisplayMember = "izqder";
                ewComboArticuloEmpezarPor.ValueMember = "codigo";
                ewComboArticuloEmpezarPor.MaxDropDownItems = 10;
                ewComboArticuloEmpezarPor.DataSource = this.tiposIzqDer();
                ewComboArticuloEmpezarPor.SelectedValue = loCampoArticulo._RellenoIzqDer;
            }


            // Obtenemos toda la informacion sobre el campo CUENTA: ancho actual, ancho estándar, ancho mínimo, ancho máximo, etc., y la ponemos en los
            // campos respectivos de pantalla.
            //
            CambioAnchuraCampos.Campo loCampoCuenta = this.cambioAnchuraCampos._ListaCamposAmpliables.
                                                        Where(campo => campo._Nombre == "CUENTAS").FirstOrDefault();
            if (loCampoArticulo != null)
            {
                ewNumCuentaAnchoStandar.Value = loCampoCuenta._AnchoEstandar;
                ewNumCuentaAnchoActual.Value = loCampoCuenta._AnchoActual;

                ewNumCuentaAnchoMinimo.Value = loCampoCuenta._AnchoMinimo;
                ewNumCuentaAnchoMaximo.Value = loCampoCuenta._AnchoMaximo;

                ewNumCuentaAnchoNuevo.Value = loCampoCuenta._AnchoActual;
                ewNumCuentaAnchoNuevo.Minimum = loCampoCuenta._AnchoMinimo;
                ewNumCuentaAnchoNuevo.Maximum = loCampoCuenta._AnchoMaximo;

                ewTxtCuentaRellenarCon.Text = loCampoCuenta._RellenoValor;
                ewNumCuentaAPartirPosicion.Value = loCampoCuenta._RellenoPosicion;

                ewComboCuentaEmpezarPor.DisplayMember = "izqder";
                ewComboCuentaEmpezarPor.ValueMember = "codigo";
                ewComboCuentaEmpezarPor.MaxDropDownItems = 10;
                ewComboCuentaEmpezarPor.DataSource = this.tiposIzqDer();
                ewComboCuentaEmpezarPor.SelectedValue = loCampoCuenta._RellenoIzqDer;
            }

            return;
        }


        /// <summary>
        /// Crear DataTable con los diferentes tipos de ajuste izquierda derecha para mostrarlos en las combos de "Empezando por la" 
        /// </summary>
        private DataTable tiposIzqDer()
        {
            DataTable ldtIzqDer = new DataTable();
            ldtIzqDer.Columns.Add("codigo", typeof(int));
            ldtIzqDer.Columns.Add("izqder", typeof(string));

            List<object> lstListaElemIzqDer = new List<object>();
            var values = Enum.GetValues(typeof(CambioAnchuraCampos.RellenarIzqDer)).Cast<CambioAnchuraCampos.RellenarIzqDer>();
            foreach (CambioAnchuraCampos.RellenarIzqDer item in values)
            {
                DataRow loRow = ldtIzqDer.NewRow();
                loRow["codigo"] = item;
                loRow["izqder"] = (object)sage.ew.functions.FUNCTIONS._GetEnumDescription(item);
                ldtIzqDer.Rows.Add(loRow);
            }

            return ldtIzqDer;
        }


        /// <summary>
        /// Validaciones a efectuar antes de ejecutar el proceso de cambio de anchura de campos en los campos que se hayan seleccionado.
        /// </summary>
        /// <returns>Devuelve true si se puede ejecutar el proceso, false caso contrario.</returns>
        private bool validacionesPreProceso()
        {
            if (ewNumArticuloAnchoActual.Value == ewNumArticuloAnchoNuevo.Value &&
                ewNumCuentaAnchoActual.Value == ewNumCuentaAnchoActual.Value)
            {
                FUNCTIONS._MessageBox("No ha declarado ningún cambio de anchura a realizar ni en el campo ARTÍCULO ni en el campo CUENTA", "Cambio de anchura campos", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return false;
            }

            // Comprobar que sea el usuario SUPERVISOR.
            //
            if (Usuario._This._Codigo != "SUPERVISOR")
            {
                FUNCTIONS._MessageBox("Sólo el usuario SUPERVISOR puede ejecutar el proceso de cambio de anchura de campos.", "Cambio de anchura de campos", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return false;
            }


            // No se puede ejecutar el proceso de cambio de anchura de campos si en este momento hay otros usuarios conectados.
            //
            if (FUNCTIONS._UsuariosConectados())
            {
                FUNCTIONS._MessageBox("Se ha detectado que hay otros usuarios conectados a la aplicación en este momento." + Environment.NewLine + Environment.NewLine +
                                      "El proceso de cambio de anchuras de campos no se puede ejecutar con usuarios conectados a la aplicación. " +
                                      Environment.NewLine + Environment.NewLine + "Salga de la aplicación en todos los terminales que la estén utilizando y vuelva " +
                                      "a ejecutar el proceso.", "Cambio de anchura de campos", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return false;
            }

            // Dejar a los addons que hagan las comprobaciones oportunas, p.e., el addon de facturación certificada, si está activo y 
            // se trabaja con territorio Vizcaya no debe permitir ampliar el nº de factura de compra más allá de 40 dígitos (el máximo
            // permitido en condiciones normales es 60).
            //
            string lcMensajeError = "";
            if (!this.addonsComprobaciones(ref lcMensajeError))
            {
                FUNCTIONS._MessageBox(lcMensajeError, "Cambio de anchura de campos", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return false;
            }

            return true;
        }


        /// <summary>
        /// Dejar a los addons que hagan las comprobaciones oportunas, p.e., el addon de facturación certificada, si está activo y 
        /// se trabaja con territorio Vizcaya no debe permitir ampliar el nº de factura de compra más allá de 40 dígitos (el máximo
        /// permitido en condiciones normales es 60).
        /// </summary>
        /// <param name="tcMensajeError">Mensaje de error caso de que algún addon responda que no se pueden ampliar los campos solicitados
        /// por el motivo que sea.</param>
        /// <returns>Devuelve true si todos los Addons permiten ampliar los campos solicitados, false caso contrario, es decir, solo que
        /// haya un addon que responda que no puede ampliar, ya devolverá false.</returns>
        private bool addonsComprobaciones(ref string tcMensajeError)
        {
            bool llReturn = true;

            // De todos los campos ampliables nos quedamos sólamente con los dos que tratamos en este ejemplo, ARTICULO y CUENTAS
            //
            BindingList<CambioAnchuraCampos.Campo> lstCamposAmpliables = new BindingList<CambioAnchuraCampos.Campo> 
                                                                         (this.cambioAnchuraCampos._ListaCamposAmpliables.
                                                                          Where(campo => campo._Nombre == "ARTICULO" || campo._Nombre == "CUENTAS").
                                                                          ToList());

            if (lstCamposAmpliables == null)
                return true;

            Dictionary<string, object> loAddons = AddonsController.Instance.AddonsManager.GetAddons();

            if (loAddons.Count <= 0)  // Si no hay addons disponibles, salimos
                return true;

            IExtensionCambioAnchuraCampos loExtension = null;

            foreach (KeyValuePair<string, object> loItem in this._Addons)  // Recorrido por los addons disponibles, para ejecutar el método deseado en las extensiones
            {
                try
                {
                    // Obtenemos el objeto de extensiones y ejecutamos el método que hace las prevalidaciones propias del addon
                    //
                    loExtension = (ExtensionCambioAnchuraCamposBase)loItem.Value;
                    loExtension._LstCamposAmpliables = lstCamposAmpliables;
                    llReturn = loExtension._ValidacionesPreProceso(ref tcMensajeError);
                    if (!llReturn) // Si una extensión ya ha retornado false, no debe seguir mirando extensiones de otros módulos. El resultado será false
                        break;
                }
                catch (Exception)
                {
                }
            }

            return llReturn;
        }


        /// <summary>
        /// Método para cargar en el diccionario _Addons todas las extensiones para cambio de anchura de campos que tengan los addons disponibles.
        /// </summary>
        /// <returns></returns>
        private void addons_Cargar()
        {
            // Si no hay addons cargados en el diccionario de la global, salimos.
            //
            if (!AddonsController.Instance.AddonsManager.HasAddonsLoaded())
            {
                return;
            }

            // Si ya hemos cargado el diccionario, salimos
            if (_Addons.Count > 0)
            {
                return;
            }

            // Recorrido por los addons disponibles para ir cargando sus extensiones en el diccionario de extensiones para
            // el controla actual.
            //
            AddonsController
                .Instance
                .Commands
                .CargarExtensionesCambioAnchuraCampos(this);
        }


        /// <summary>
        /// Preguntar al usuario si iniciar el proceso.
        /// </summary>
        private bool preguntarUsuario()
        {
            string lcCadenaCamposLongInf = "";
            string lcCadenaCampos = "";


            // Recorro solo los campos que tratamos en este ejemplo, es decir, ARTICULO y CUENTA
            foreach (CambioAnchuraCampos.Campo loCampo in this.cambioAnchuraCampos._ListaCamposAmpliables.
                                                          Where(campo => campo._Nombre == "ARTICULO" || campo._Nombre=="CUENTAS"))
            {
                // Campos que se va a modificar la longitud.
                //
                if (loCampo._AnchoNuevo != loCampo._AnchoActual)
                {
                    lcCadenaCampos += "Campo: " + loCampo._Nombre.Trim().ToUpper() + " Longitud Actual: " + loCampo._AnchoActual.ToString().Trim() + " " +
                                      "Longitud nueva: " + loCampo._AnchoNuevo.ToString().Trim() + Environment.NewLine;
                }

                // Campos en los que se disminuye la longitud.
                //
                if (loCampo._AnchoNuevo < loCampo._AnchoActual)
                {
                    lcCadenaCamposLongInf += loCampo._Nombre.Trim().ToUpper() + Environment.NewLine;
                }
            }

            string lcCadenaCopiaSeg = "";
            if (this.ewChkCopiaSeg.Checked)
                lcCadenaCopiaSeg = "Antes de ejecutar el proceso de cambio de anchuras de campos, se realizará copia de seguridad local de los datos actuales." + Environment.NewLine + Environment.NewLine;
            else
                lcCadenaCopiaSeg = "No ha marcado la opción de realizar copia de seguridad. Es recomendable hacer copia de seguridad de los datos actuales antes de ejecutar el proceso." + Environment.NewLine + Environment.NewLine;



            string lcMensaje = "Se van a realizar los siguientes cambios en las longitudes de los campos:" + Environment.NewLine + Environment.NewLine +
                        lcCadenaCampos + Environment.NewLine + Environment.NewLine +
                        (!string.IsNullOrWhiteSpace(lcCadenaCamposLongInf) ? "Se disminuirá la longitud de los siguientes campos lo cual " +
                        "podría provocar pérdida de datos, asegúrese antes de continuar: " + Environment.NewLine + lcCadenaCamposLongInf + Environment.NewLine : "") +
                        "Los cambios afectarán a todas las empresa existentes en el grupo activo '" + DB.DbComunes.Substring(4) + "'." + Environment.NewLine + Environment.NewLine +
                        lcCadenaCopiaSeg +
                        "¿Está seguro de ejecutar el proceso de cambio de anchuras especificado?";

            DialogResult loDlgResult = FUNCTIONS._MessageBox(lcMensaje, "Cambio de anchura de campos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (loDlgResult == DialogResult.No)
                return false;

            // Preparar label para mostrar estado de la copia si se hace, y del proceso de cambio de anchura.
            //
            this.txtEstadoProceso.Visible = true;

            // Si el usuario marcó la opción, realizar copia de seguridad.
            if (this.ewChkCopiaSeg.Checked)
                this.realizarCopiaSeg();

            return true;
        }


        /// <summary>
        /// Realizar copia de seguridad de todas las empresas del grupo activo.
        /// </summary>
        private void realizarCopiaSeg()
        {
            string lcGrupoActual = FUNCTIONS._Grupo_Actual();
            string lcPathServidor = FUNCTIONS._AddBS(Convert.ToString(EW_GLOBAL._GetVariable("wc_iniservidor")));

            // Cargar negocio del grupo actual.
            //
            GrupoEmpresa loGrupo = new GrupoEmpresa(lcGrupoActual);

            // Si la ruta está vacia, poner la copia en la carpeta 'CopiasegSQL' del servidor
            //
            string lcRutaCopia = string.IsNullOrWhiteSpace(loGrupo._RutaLocalCopia) ?
                                 Path.Combine(lcPathServidor, "CopiasegSQL") :
                                 Path.Combine(loGrupo._RutaLocalCopia, "Actualizacion");

            // Preparar copia
            //
            sage.ew.ewbase.CopiaSeguridad loCopia = new CopiaSeguridad(lcGrupoActual, lcRutaCopia, "",
                                                        loGrupo._CopiaReports, loGrupo._CopiaImagenes, loGrupo._CopiaDocumentos,
                                                        loGrupo._CopiaFacturasElec, 1, false, "", "", 1,
                                                        Convert.ToString(EW_GLOBAL._GetVariable("wc_versionexe")), DB.VersionSQLServer);
            loCopia._Ejercicio = "Todos";

            // Programo el evento para que actualice lo que va haciendo la copia en la label de estado que tenemos en el formulario.
            //
            loCopia._ActualizarEstado += this.copiaseg__ActualizarEstado;

            // Ejecutar copia
            //
            loCopia._EjecutarCopia();

            return;
        }


        /// <summary>
        /// Actualizar el txtbox de estado del proceso de copia de seguridad con el estado de la copia.
        /// </summary>
        /// <param name="tcEstado">Texto del estado de la copia de seguridad.</param>
        /// <param name="tnPorcentaje">Porcentaje de la copia de seguidad llevado a cabo hasta el momento.</param>
        /// <param name="tbCopiaCancelada">Si se ha de cancelar la copia, parámetro de entrada/salida.</param>
        private void copiaseg__ActualizarEstado(string tcEstado, int tnPorcentaje, ref bool tbCopiaCancelada)
        {
            this.txtEstadoProceso.Text = "Realizando copia de seguridad. " + tcEstado;
            this.txtEstadoProceso.Refresh();

            Application.DoEvents();

            return;
        }


        /// <summary>
        /// Realizar proceso de cambio de anchura de campos en los campos que se ha indicado.
        /// </summary>
        /// <param name="tcMensajeError">Mensaje de error, parámetro de salida.</param>
        private bool cambiarAnchurasCampos(out string tcMensajeError)
        {
            bool llOk = true;
            string lcCamposError = "", lcCamposNoError = "";

            tcMensajeError = "";


            // Ponemos en los registros correspondientes a ARTICULO y CUENTAS de this.cambioAnchuraCampos._ListaCamposAmpliables los campos
            // que el usuario ha dejado en pantalla tras editar su contenido.
            //

            CambioAnchuraCampos.Campo loCampoCuentas = this.cambioAnchuraCampos._ListaCamposAmpliables.
                                                       Where(campo => campo._Nombre == "CUENTAS").FirstOrDefault();
            if (loCampoCuentas != null)
            {
                loCampoCuentas._AnchoNuevo = Convert.ToInt32(this.ewNumCuentaAnchoNuevo.Value);
                loCampoCuentas._RellenoValor = this.ewTxtCuentaRellenarCon.Text;
                loCampoCuentas._RellenoPosicion = Convert.ToInt32(this.ewNumCuentaAPartirPosicion.Value);
                loCampoCuentas._RellenoIzqDer = Convert.ToInt32(this.ewComboCuentaEmpezarPor.SelectedValue);
            }


            CambioAnchuraCampos.Campo loCampoArticulo = this.cambioAnchuraCampos._ListaCamposAmpliables.
                                                        Where(campo => campo._Nombre == "ARTICULO").FirstOrDefault();
            if (loCampoArticulo != null)
            {
                loCampoArticulo._AnchoNuevo = Convert.ToInt32(this.ewNumArticuloAnchoNuevo.Value);
                loCampoArticulo._RellenoValor = this.ewTxtArticuloRellenarCon.Text;
                loCampoArticulo._RellenoPosicion = Convert.ToInt32(this.ewNumArticuloAPartirPosicion.Value);
                loCampoArticulo._RellenoIzqDer = Convert.ToInt32(this.ewComboArticuloEmpezarPor.SelectedValue);
            }


            // De todas la lista de campos disponibles como aquí en este ejemplo solo tratamos ARTICULO y CUENTAS, nos quedamos solo con estos
            // dos elementos de la lista.
            //
            List<CambioAnchuraCampos.Campo> lstCamposAmpliables = new List<CambioAnchuraCampos.Campo>
                                                                  (this.cambioAnchuraCampos._ListaCamposAmpliables.
                                                                  Where(campo => campo._Nombre == "ARTICULO" || campo._Nombre == "CUENTAS").
                                                                  ToList());

            // Recorrer cada campo en los que se detecta cambio de anchura de campo y hacer el cambio de longitud correspondiente.
            //
            foreach (CambioAnchuraCampos.Campo loCampo in lstCamposAmpliables.Where(campo => campo._AnchoNuevo != campo._AnchoActual))
            {
                this.txtEstadoProceso.Text = "Cambiando anchura de campo " + loCampo._Nombre.Trim() + " de " + loCampo._AnchoActual.ToString().Trim() +
                                             " a " + loCampo._AnchoNuevo.ToString().Trim() + " ...";
                this.txtEstadoProceso.Refresh();

                // Hacer efectivo el cambio de anchura de campo.
                //
                llOk = loCampo._CambiarAnchura();

                if (!llOk || !string.IsNullOrWhiteSpace(loCampo._MensajeError))
                    lcCamposError += loCampo._Nombre + " " + (!string.IsNullOrWhiteSpace(loCampo._MensajeError) ? "(" + loCampo._MensajeError + ")" : "") + Environment.NewLine;
                else
                    lcCamposNoError += loCampo._Nombre + Environment.NewLine;
            }

            this.txtEstadoProceso.Visible = false;

            if (!string.IsNullOrWhiteSpace(lcCamposError))
            {
                tcMensajeError = (!string.IsNullOrWhiteSpace(lcCamposNoError) ? "Campos ampliados sin incidencias: " +
                                  Environment.NewLine + Environment.NewLine + lcCamposNoError + Environment.NewLine + Environment.NewLine : "") +
                                 "Campos ampliados con alguna incidencia: " + Environment.NewLine + Environment.NewLine + lcCamposError;
                return false;
            }

            return true;
        }


        #endregion MÉTODOS PRIVADOS
    }
}
