

using sage.ew.objetos;

namespace sage.addons.EjemAddons.Visual.Forms
{
    partial class frmEjemCambioAnchoCampo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEjemCambioAnchoCampo));
            this.ewlabelCampoArticulo = new sage.ew.objetos.ewlabel();
            this.ewlabelCampoCuenta = new sage.ew.objetos.ewlabel();
            this.ewlblAnchoActual = new sage.ew.objetos.ewlabel();
            this.ewlblAnchoNuevo = new sage.ew.objetos.ewlabel();
            this.txtEstadoProceso = new sage.ew.objetos.ewtextbox();
            this.ewChkCopiaSeg = new sage.ew.objetos.ewcheckbox();
            this.ewNumArticuloAnchoNuevo = new sage.ew.objetos.ewnumericupdown();
            this.ewNumCuentaAnchoNuevo = new sage.ew.objetos.ewnumericupdown();
            this.ewNumCuentaAnchoActual = new sage.ew.objetos.ewnumericupdown();
            this.ewNumArticuloAnchoActual = new sage.ew.objetos.ewnumericupdown();
            this.ewNumCuentaAnchoStandar = new sage.ew.objetos.ewnumericupdown();
            this.ewNumArticuloAnchoStandar = new sage.ew.objetos.ewnumericupdown();
            this.ewlblAnchoStandar = new sage.ew.objetos.ewlabel();
            this.ewNumCuentaAnchoMinimo = new sage.ew.objetos.ewnumericupdown();
            this.ewNumArticuloAnchoMinimo = new sage.ew.objetos.ewnumericupdown();
            this.ewlblAnchoMinimo = new sage.ew.objetos.ewlabel();
            this.ewNumCuentaAnchoMaximo = new sage.ew.objetos.ewnumericupdown();
            this.ewNumArticuloAnchoMaximo = new sage.ew.objetos.ewnumericupdown();
            this.ewlblAnchoMaximo = new sage.ew.objetos.ewlabel();
            this.ewLblRellenarCon = new sage.ew.objetos.ewlabel();
            this.ewLblApartir1 = new sage.ew.objetos.ewlabel();
            this.ewLblApartir2 = new sage.ew.objetos.ewlabel();
            this.ewLblEmpezandoPor = new sage.ew.objetos.ewlabel();
            this.ewNumCuentaAPartirPosicion = new sage.ew.objetos.ewnumericupdown();
            this.ewNumArticuloAPartirPosicion = new sage.ew.objetos.ewnumericupdown();
            this.ewComboArticuloEmpezarPor = new sage.ew.objetos.ewcombobox();
            this.ewComboCuentaEmpezarPor = new sage.ew.objetos.ewcombobox();
            this.ewTxtArticuloRellenarCon = new System.Windows.Forms.TextBox();
            this.ewTxtCuentaRellenarCon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._oErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAnchoNuevo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAnchoNuevo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAnchoActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAnchoActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAnchoStandar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAnchoStandar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAnchoMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAnchoMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAnchoMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAnchoMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAPartirPosicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAPartirPosicion)).BeginInit();
            this.SuspendLayout();
            // 
            // btDocCancelar1
            // 
            this.btDocCancelar1._PropiedadesDeEstilos._ColorUnderlineEntering = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(192)))), ((int)(((byte)(163)))));
            this.btDocCancelar1._PropiedadesDeEstilos._ColorUnderlineSelected = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btDocCancelar1.Image = ((System.Drawing.Image)(resources.GetObject("btDocCancelar1.Image")));
            this.btDocCancelar1.Location = new System.Drawing.Point(962, 223);
            this.btDocCancelar1.Click += new System.EventHandler(this.btDocCancelar1_Click);
            // 
            // btSalir1
            // 
            this.btSalir1._PropiedadesDeEstilos._ColorUnderlineEntering = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(192)))), ((int)(((byte)(163)))));
            this.btSalir1._PropiedadesDeEstilos._ColorUnderlineSelected = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btSalir1.Image = ((System.Drawing.Image)(resources.GetObject("btSalir1.Image")));
            this.btSalir1.Location = new System.Drawing.Point(983, 223);
            this.btSalir1.Size = new System.Drawing.Size(99, 44);
            // 
            // btDocAceptar1
            // 
            this.btDocAceptar1._PropiedadesDeEstilos._ColorUnderlineEntering = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(192)))), ((int)(((byte)(163)))));
            this.btDocAceptar1._PropiedadesDeEstilos._ColorUnderlineSelected = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btDocAceptar1.Image = ((System.Drawing.Image)(resources.GetObject("btDocAceptar1.Image")));
            this.btDocAceptar1.Location = new System.Drawing.Point(837, 223);
            this.btDocAceptar1.Click += new System.EventHandler(this.btDocAceptar1_Click);
            // 
            // ewlabelCampoArticulo
            // 
            this.ewlabelCampoArticulo._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewlabelCampoArticulo.AutoSize = true;
            this.ewlabelCampoArticulo.Font = new System.Drawing.Font("Sage UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewlabelCampoArticulo.Location = new System.Drawing.Point(23, 65);
            this.ewlabelCampoArticulo.Name = "ewlabelCampoArticulo";
            this.ewlabelCampoArticulo.Size = new System.Drawing.Size(129, 18);
            this.ewlabelCampoArticulo.TabIndex = 5;
            this.ewlabelCampoArticulo.Text = "Campo ARTÍCULO:";
            // 
            // ewlabelCampoCuenta
            // 
            this.ewlabelCampoCuenta._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewlabelCampoCuenta.AutoSize = true;
            this.ewlabelCampoCuenta.Font = new System.Drawing.Font("Sage UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewlabelCampoCuenta.Location = new System.Drawing.Point(23, 105);
            this.ewlabelCampoCuenta.Name = "ewlabelCampoCuenta";
            this.ewlabelCampoCuenta.Size = new System.Drawing.Size(117, 18);
            this.ewlabelCampoCuenta.TabIndex = 6;
            this.ewlabelCampoCuenta.Text = "Campo CUENTA:";
            // 
            // ewlblAnchoActual
            // 
            this.ewlblAnchoActual._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewlblAnchoActual.AutoSize = true;
            this.ewlblAnchoActual.Font = new System.Drawing.Font("Sage UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewlblAnchoActual.Location = new System.Drawing.Point(315, 27);
            this.ewlblAnchoActual.Name = "ewlblAnchoActual";
            this.ewlblAnchoActual.Size = new System.Drawing.Size(81, 16);
            this.ewlblAnchoActual.TabIndex = 7;
            this.ewlblAnchoActual.Text = "Ancho actual";
            // 
            // ewlblAnchoNuevo
            // 
            this.ewlblAnchoNuevo._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewlblAnchoNuevo.AutoSize = true;
            this.ewlblAnchoNuevo.Font = new System.Drawing.Font("Sage UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewlblAnchoNuevo.Location = new System.Drawing.Point(424, 27);
            this.ewlblAnchoNuevo.Name = "ewlblAnchoNuevo";
            this.ewlblAnchoNuevo.Size = new System.Drawing.Size(81, 16);
            this.ewlblAnchoNuevo.TabIndex = 8;
            this.ewlblAnchoNuevo.Text = "Nuevo ancho";
            // 
            // txtEstadoProceso
            // 
            this.txtEstadoProceso._CanChangeStyle = false;
            this.txtEstadoProceso._DescripcionError = "";
            this.txtEstadoProceso._DescripcionOpcional = null;
            this.txtEstadoProceso._EditMode = false;
            this.txtEstadoProceso._ErrorValidation = false;
            this.txtEstadoProceso._EsOpcionalConfigUser = false;
            this.txtEstadoProceso._NoMostrarTecladoTactil = false;
            this.txtEstadoProceso._PasswordChar = '\0';
            this.txtEstadoProceso._PermitirConfigUser = true;
            this.txtEstadoProceso._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.txtEstadoProceso._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.txtEstadoProceso._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.txtEstadoProceso._SoloNumeros = false;
            this.txtEstadoProceso._Tactil_Teclat_Numeric = false;
            this.txtEstadoProceso._Tooltip = "";
            this.txtEstadoProceso._UsuarioPermiteConfigUser = false;
            this.txtEstadoProceso.Font = new System.Drawing.Font("Sage UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoProceso.Location = new System.Drawing.Point(23, 181);
            this.txtEstadoProceso.Name = "txtEstadoProceso";
            this.txtEstadoProceso.ReadOnly = true;
            this.txtEstadoProceso.Size = new System.Drawing.Size(1056, 23);
            this.txtEstadoProceso.TabIndex = 13;
            this.txtEstadoProceso.Visible = false;
            // 
            // ewChkCopiaSeg
            // 
            this.ewChkCopiaSeg._DescripcionError = "";
            this.ewChkCopiaSeg._DescripcionOpcional = null;
            this.ewChkCopiaSeg._EditMode = false;
            this.ewChkCopiaSeg._EsOpcionalConfigUser = false;
            this.ewChkCopiaSeg._GuardarEnSettings = false;
            this.ewChkCopiaSeg._OpcionConfiguracion = "";
            this.ewChkCopiaSeg._PermitirConfigUser = true;
            this.ewChkCopiaSeg._PropiedadesDeEstilos._ColorUnderlineEntering = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(192)))), ((int)(((byte)(163)))));
            this.ewChkCopiaSeg._PropiedadesDeEstilos._ColorUnderlineSelected = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewChkCopiaSeg._UsuarioPermiteConfigUser = false;
            this.ewChkCopiaSeg.AutoSize = true;
            this.ewChkCopiaSeg.Checked = true;
            this.ewChkCopiaSeg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ewChkCopiaSeg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ewChkCopiaSeg.Location = new System.Drawing.Point(23, 152);
            this.ewChkCopiaSeg.Name = "ewChkCopiaSeg";
            this.ewChkCopiaSeg.Size = new System.Drawing.Size(347, 21);
            this.ewChkCopiaSeg.TabIndex = 14;
            this.ewChkCopiaSeg.Text = "Realizar copia seguridad antes de realizar los cambios";
            this.ewChkCopiaSeg.UseVisualStyleBackColor = true;
            // 
            // ewNumArticuloAnchoNuevo
            // 
            this.ewNumArticuloAnchoNuevo._DescripcionError = "";
            this.ewNumArticuloAnchoNuevo._DescripcionOpcional = null;
            this.ewNumArticuloAnchoNuevo._EditMode = false;
            this.ewNumArticuloAnchoNuevo._ErrorValidation = false;
            this.ewNumArticuloAnchoNuevo._EsOpcionalConfigUser = false;
            this.ewNumArticuloAnchoNuevo._PermitirConfigUser = true;
            this.ewNumArticuloAnchoNuevo._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumArticuloAnchoNuevo._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumArticuloAnchoNuevo._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumArticuloAnchoNuevo._ReadOnly = false;
            this.ewNumArticuloAnchoNuevo._SelectOnEntry = false;
            this.ewNumArticuloAnchoNuevo._Tooltip = "";
            this.ewNumArticuloAnchoNuevo._UsuarioPermiteConfigUser = false;
            this.ewNumArticuloAnchoNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumArticuloAnchoNuevo.Location = new System.Drawing.Point(431, 62);
            this.ewNumArticuloAnchoNuevo.Name = "ewNumArticuloAnchoNuevo";
            this.ewNumArticuloAnchoNuevo.Size = new System.Drawing.Size(71, 23);
            this.ewNumArticuloAnchoNuevo.TabIndex = 15;
            this.ewNumArticuloAnchoNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumArticuloAnchoNuevo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewNumCuentaAnchoNuevo
            // 
            this.ewNumCuentaAnchoNuevo._DescripcionError = "";
            this.ewNumCuentaAnchoNuevo._DescripcionOpcional = null;
            this.ewNumCuentaAnchoNuevo._EditMode = false;
            this.ewNumCuentaAnchoNuevo._ErrorValidation = false;
            this.ewNumCuentaAnchoNuevo._EsOpcionalConfigUser = false;
            this.ewNumCuentaAnchoNuevo._PermitirConfigUser = true;
            this.ewNumCuentaAnchoNuevo._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumCuentaAnchoNuevo._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumCuentaAnchoNuevo._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumCuentaAnchoNuevo._ReadOnly = false;
            this.ewNumCuentaAnchoNuevo._SelectOnEntry = false;
            this.ewNumCuentaAnchoNuevo._Tooltip = "";
            this.ewNumCuentaAnchoNuevo._UsuarioPermiteConfigUser = false;
            this.ewNumCuentaAnchoNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumCuentaAnchoNuevo.Location = new System.Drawing.Point(431, 101);
            this.ewNumCuentaAnchoNuevo.Name = "ewNumCuentaAnchoNuevo";
            this.ewNumCuentaAnchoNuevo.Size = new System.Drawing.Size(71, 23);
            this.ewNumCuentaAnchoNuevo.TabIndex = 16;
            this.ewNumCuentaAnchoNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumCuentaAnchoNuevo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewNumCuentaAnchoActual
            // 
            this.ewNumCuentaAnchoActual._DescripcionError = "";
            this.ewNumCuentaAnchoActual._DescripcionOpcional = null;
            this.ewNumCuentaAnchoActual._EditMode = false;
            this.ewNumCuentaAnchoActual._ErrorValidation = false;
            this.ewNumCuentaAnchoActual._EsOpcionalConfigUser = false;
            this.ewNumCuentaAnchoActual._PermitirConfigUser = true;
            this.ewNumCuentaAnchoActual._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumCuentaAnchoActual._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumCuentaAnchoActual._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumCuentaAnchoActual._ReadOnly = true;
            this.ewNumCuentaAnchoActual._SelectOnEntry = false;
            this.ewNumCuentaAnchoActual._Tooltip = "";
            this.ewNumCuentaAnchoActual._UsuarioPermiteConfigUser = false;
            this.ewNumCuentaAnchoActual.Enabled = false;
            this.ewNumCuentaAnchoActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumCuentaAnchoActual.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ewNumCuentaAnchoActual.Location = new System.Drawing.Point(322, 101);
            this.ewNumCuentaAnchoActual.Name = "ewNumCuentaAnchoActual";
            this.ewNumCuentaAnchoActual.ReadOnly = true;
            this.ewNumCuentaAnchoActual.Size = new System.Drawing.Size(71, 23);
            this.ewNumCuentaAnchoActual.TabIndex = 18;
            this.ewNumCuentaAnchoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumCuentaAnchoActual.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewNumArticuloAnchoActual
            // 
            this.ewNumArticuloAnchoActual._DescripcionError = "";
            this.ewNumArticuloAnchoActual._DescripcionOpcional = null;
            this.ewNumArticuloAnchoActual._EditMode = false;
            this.ewNumArticuloAnchoActual._ErrorValidation = false;
            this.ewNumArticuloAnchoActual._EsOpcionalConfigUser = false;
            this.ewNumArticuloAnchoActual._PermitirConfigUser = true;
            this.ewNumArticuloAnchoActual._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumArticuloAnchoActual._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumArticuloAnchoActual._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumArticuloAnchoActual._ReadOnly = true;
            this.ewNumArticuloAnchoActual._SelectOnEntry = false;
            this.ewNumArticuloAnchoActual._Tooltip = "";
            this.ewNumArticuloAnchoActual._UsuarioPermiteConfigUser = false;
            this.ewNumArticuloAnchoActual.Enabled = false;
            this.ewNumArticuloAnchoActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumArticuloAnchoActual.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ewNumArticuloAnchoActual.Location = new System.Drawing.Point(322, 62);
            this.ewNumArticuloAnchoActual.Name = "ewNumArticuloAnchoActual";
            this.ewNumArticuloAnchoActual.ReadOnly = true;
            this.ewNumArticuloAnchoActual.Size = new System.Drawing.Size(71, 23);
            this.ewNumArticuloAnchoActual.TabIndex = 17;
            this.ewNumArticuloAnchoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumArticuloAnchoActual.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewNumCuentaAnchoStandar
            // 
            this.ewNumCuentaAnchoStandar._DescripcionError = "";
            this.ewNumCuentaAnchoStandar._DescripcionOpcional = null;
            this.ewNumCuentaAnchoStandar._EditMode = false;
            this.ewNumCuentaAnchoStandar._ErrorValidation = false;
            this.ewNumCuentaAnchoStandar._EsOpcionalConfigUser = false;
            this.ewNumCuentaAnchoStandar._PermitirConfigUser = true;
            this.ewNumCuentaAnchoStandar._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumCuentaAnchoStandar._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumCuentaAnchoStandar._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumCuentaAnchoStandar._ReadOnly = true;
            this.ewNumCuentaAnchoStandar._SelectOnEntry = false;
            this.ewNumCuentaAnchoStandar._Tooltip = "";
            this.ewNumCuentaAnchoStandar._UsuarioPermiteConfigUser = false;
            this.ewNumCuentaAnchoStandar.Enabled = false;
            this.ewNumCuentaAnchoStandar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumCuentaAnchoStandar.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ewNumCuentaAnchoStandar.Location = new System.Drawing.Point(213, 101);
            this.ewNumCuentaAnchoStandar.Name = "ewNumCuentaAnchoStandar";
            this.ewNumCuentaAnchoStandar.ReadOnly = true;
            this.ewNumCuentaAnchoStandar.Size = new System.Drawing.Size(71, 23);
            this.ewNumCuentaAnchoStandar.TabIndex = 21;
            this.ewNumCuentaAnchoStandar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumCuentaAnchoStandar.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewNumArticuloAnchoStandar
            // 
            this.ewNumArticuloAnchoStandar._DescripcionError = "";
            this.ewNumArticuloAnchoStandar._DescripcionOpcional = null;
            this.ewNumArticuloAnchoStandar._EditMode = false;
            this.ewNumArticuloAnchoStandar._ErrorValidation = false;
            this.ewNumArticuloAnchoStandar._EsOpcionalConfigUser = false;
            this.ewNumArticuloAnchoStandar._PermitirConfigUser = true;
            this.ewNumArticuloAnchoStandar._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumArticuloAnchoStandar._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumArticuloAnchoStandar._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumArticuloAnchoStandar._ReadOnly = true;
            this.ewNumArticuloAnchoStandar._SelectOnEntry = false;
            this.ewNumArticuloAnchoStandar._Tooltip = "";
            this.ewNumArticuloAnchoStandar._UsuarioPermiteConfigUser = false;
            this.ewNumArticuloAnchoStandar.Enabled = false;
            this.ewNumArticuloAnchoStandar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumArticuloAnchoStandar.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ewNumArticuloAnchoStandar.Location = new System.Drawing.Point(213, 62);
            this.ewNumArticuloAnchoStandar.Name = "ewNumArticuloAnchoStandar";
            this.ewNumArticuloAnchoStandar.ReadOnly = true;
            this.ewNumArticuloAnchoStandar.Size = new System.Drawing.Size(71, 23);
            this.ewNumArticuloAnchoStandar.TabIndex = 20;
            this.ewNumArticuloAnchoStandar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumArticuloAnchoStandar.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewlblAnchoStandar
            // 
            this.ewlblAnchoStandar._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewlblAnchoStandar.AutoSize = true;
            this.ewlblAnchoStandar.Font = new System.Drawing.Font("Sage UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewlblAnchoStandar.Location = new System.Drawing.Point(191, 27);
            this.ewlblAnchoStandar.Name = "ewlblAnchoStandar";
            this.ewlblAnchoStandar.Size = new System.Drawing.Size(97, 16);
            this.ewlblAnchoStandar.TabIndex = 19;
            this.ewlblAnchoStandar.Text = "Ancho estándar";
            // 
            // ewNumCuentaAnchoMinimo
            // 
            this.ewNumCuentaAnchoMinimo._DescripcionError = "";
            this.ewNumCuentaAnchoMinimo._DescripcionOpcional = null;
            this.ewNumCuentaAnchoMinimo._EditMode = false;
            this.ewNumCuentaAnchoMinimo._ErrorValidation = false;
            this.ewNumCuentaAnchoMinimo._EsOpcionalConfigUser = false;
            this.ewNumCuentaAnchoMinimo._PermitirConfigUser = true;
            this.ewNumCuentaAnchoMinimo._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumCuentaAnchoMinimo._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumCuentaAnchoMinimo._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumCuentaAnchoMinimo._ReadOnly = true;
            this.ewNumCuentaAnchoMinimo._SelectOnEntry = false;
            this.ewNumCuentaAnchoMinimo._Tooltip = "";
            this.ewNumCuentaAnchoMinimo._UsuarioPermiteConfigUser = false;
            this.ewNumCuentaAnchoMinimo.Enabled = false;
            this.ewNumCuentaAnchoMinimo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumCuentaAnchoMinimo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ewNumCuentaAnchoMinimo.Location = new System.Drawing.Point(540, 101);
            this.ewNumCuentaAnchoMinimo.Name = "ewNumCuentaAnchoMinimo";
            this.ewNumCuentaAnchoMinimo.ReadOnly = true;
            this.ewNumCuentaAnchoMinimo.Size = new System.Drawing.Size(71, 23);
            this.ewNumCuentaAnchoMinimo.TabIndex = 27;
            this.ewNumCuentaAnchoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumCuentaAnchoMinimo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewNumArticuloAnchoMinimo
            // 
            this.ewNumArticuloAnchoMinimo._DescripcionError = "";
            this.ewNumArticuloAnchoMinimo._DescripcionOpcional = null;
            this.ewNumArticuloAnchoMinimo._EditMode = false;
            this.ewNumArticuloAnchoMinimo._ErrorValidation = false;
            this.ewNumArticuloAnchoMinimo._EsOpcionalConfigUser = false;
            this.ewNumArticuloAnchoMinimo._PermitirConfigUser = true;
            this.ewNumArticuloAnchoMinimo._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumArticuloAnchoMinimo._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumArticuloAnchoMinimo._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumArticuloAnchoMinimo._ReadOnly = true;
            this.ewNumArticuloAnchoMinimo._SelectOnEntry = false;
            this.ewNumArticuloAnchoMinimo._Tooltip = "";
            this.ewNumArticuloAnchoMinimo._UsuarioPermiteConfigUser = false;
            this.ewNumArticuloAnchoMinimo.Enabled = false;
            this.ewNumArticuloAnchoMinimo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumArticuloAnchoMinimo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ewNumArticuloAnchoMinimo.Location = new System.Drawing.Point(540, 62);
            this.ewNumArticuloAnchoMinimo.Name = "ewNumArticuloAnchoMinimo";
            this.ewNumArticuloAnchoMinimo.ReadOnly = true;
            this.ewNumArticuloAnchoMinimo.Size = new System.Drawing.Size(71, 23);
            this.ewNumArticuloAnchoMinimo.TabIndex = 26;
            this.ewNumArticuloAnchoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumArticuloAnchoMinimo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewlblAnchoMinimo
            // 
            this.ewlblAnchoMinimo._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewlblAnchoMinimo.AutoSize = true;
            this.ewlblAnchoMinimo.Font = new System.Drawing.Font("Sage UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewlblAnchoMinimo.Location = new System.Drawing.Point(527, 27);
            this.ewlblAnchoMinimo.Name = "ewlblAnchoMinimo";
            this.ewlblAnchoMinimo.Size = new System.Drawing.Size(87, 16);
            this.ewlblAnchoMinimo.TabIndex = 25;
            this.ewlblAnchoMinimo.Text = "Ancho mínimo";
            // 
            // ewNumCuentaAnchoMaximo
            // 
            this.ewNumCuentaAnchoMaximo._DescripcionError = "";
            this.ewNumCuentaAnchoMaximo._DescripcionOpcional = null;
            this.ewNumCuentaAnchoMaximo._EditMode = false;
            this.ewNumCuentaAnchoMaximo._ErrorValidation = false;
            this.ewNumCuentaAnchoMaximo._EsOpcionalConfigUser = false;
            this.ewNumCuentaAnchoMaximo._PermitirConfigUser = true;
            this.ewNumCuentaAnchoMaximo._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumCuentaAnchoMaximo._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumCuentaAnchoMaximo._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumCuentaAnchoMaximo._ReadOnly = true;
            this.ewNumCuentaAnchoMaximo._SelectOnEntry = false;
            this.ewNumCuentaAnchoMaximo._Tooltip = "";
            this.ewNumCuentaAnchoMaximo._UsuarioPermiteConfigUser = false;
            this.ewNumCuentaAnchoMaximo.Enabled = false;
            this.ewNumCuentaAnchoMaximo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumCuentaAnchoMaximo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ewNumCuentaAnchoMaximo.Location = new System.Drawing.Point(649, 101);
            this.ewNumCuentaAnchoMaximo.Name = "ewNumCuentaAnchoMaximo";
            this.ewNumCuentaAnchoMaximo.ReadOnly = true;
            this.ewNumCuentaAnchoMaximo.Size = new System.Drawing.Size(71, 23);
            this.ewNumCuentaAnchoMaximo.TabIndex = 24;
            this.ewNumCuentaAnchoMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumCuentaAnchoMaximo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewNumArticuloAnchoMaximo
            // 
            this.ewNumArticuloAnchoMaximo._DescripcionError = "";
            this.ewNumArticuloAnchoMaximo._DescripcionOpcional = null;
            this.ewNumArticuloAnchoMaximo._EditMode = false;
            this.ewNumArticuloAnchoMaximo._ErrorValidation = false;
            this.ewNumArticuloAnchoMaximo._EsOpcionalConfigUser = false;
            this.ewNumArticuloAnchoMaximo._PermitirConfigUser = true;
            this.ewNumArticuloAnchoMaximo._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumArticuloAnchoMaximo._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumArticuloAnchoMaximo._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumArticuloAnchoMaximo._ReadOnly = true;
            this.ewNumArticuloAnchoMaximo._SelectOnEntry = false;
            this.ewNumArticuloAnchoMaximo._Tooltip = "";
            this.ewNumArticuloAnchoMaximo._UsuarioPermiteConfigUser = false;
            this.ewNumArticuloAnchoMaximo.Enabled = false;
            this.ewNumArticuloAnchoMaximo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumArticuloAnchoMaximo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ewNumArticuloAnchoMaximo.Location = new System.Drawing.Point(649, 62);
            this.ewNumArticuloAnchoMaximo.Name = "ewNumArticuloAnchoMaximo";
            this.ewNumArticuloAnchoMaximo.ReadOnly = true;
            this.ewNumArticuloAnchoMaximo.Size = new System.Drawing.Size(71, 23);
            this.ewNumArticuloAnchoMaximo.TabIndex = 23;
            this.ewNumArticuloAnchoMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumArticuloAnchoMaximo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewlblAnchoMaximo
            // 
            this.ewlblAnchoMaximo._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewlblAnchoMaximo.AutoSize = true;
            this.ewlblAnchoMaximo.Font = new System.Drawing.Font("Sage UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewlblAnchoMaximo.Location = new System.Drawing.Point(633, 27);
            this.ewlblAnchoMaximo.Name = "ewlblAnchoMaximo";
            this.ewlblAnchoMaximo.Size = new System.Drawing.Size(90, 16);
            this.ewlblAnchoMaximo.TabIndex = 22;
            this.ewlblAnchoMaximo.Text = "Ancho máximo";
            // 
            // ewLblRellenarCon
            // 
            this.ewLblRellenarCon._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewLblRellenarCon.AutoSize = true;
            this.ewLblRellenarCon.Font = new System.Drawing.Font("Sage UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewLblRellenarCon.Location = new System.Drawing.Point(743, 27);
            this.ewLblRellenarCon.Name = "ewLblRellenarCon";
            this.ewLblRellenarCon.Size = new System.Drawing.Size(78, 16);
            this.ewLblRellenarCon.TabIndex = 28;
            this.ewLblRellenarCon.Text = "Rellenar con";
            // 
            // ewLblApartir1
            // 
            this.ewLblApartir1._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewLblApartir1.AutoSize = true;
            this.ewLblApartir1.Font = new System.Drawing.Font("Sage UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewLblApartir1.Location = new System.Drawing.Point(843, 8);
            this.ewLblApartir1.Name = "ewLblApartir1";
            this.ewLblApartir1.Size = new System.Drawing.Size(68, 16);
            this.ewLblApartir1.TabIndex = 29;
            this.ewLblApartir1.Text = "A partir de";
            // 
            // ewLblApartir2
            // 
            this.ewLblApartir2._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewLblApartir2.AutoSize = true;
            this.ewLblApartir2.Font = new System.Drawing.Font("Sage UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewLblApartir2.Location = new System.Drawing.Point(843, 27);
            this.ewLblApartir2.Name = "ewLblApartir2";
            this.ewLblApartir2.Size = new System.Drawing.Size(68, 16);
            this.ewLblApartir2.TabIndex = 30;
            this.ewLblApartir2.Text = "la posición";
            // 
            // ewLblEmpezandoPor
            // 
            this.ewLblEmpezandoPor._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewLblEmpezandoPor.AutoSize = true;
            this.ewLblEmpezandoPor.Font = new System.Drawing.Font("Sage UI", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewLblEmpezandoPor.Location = new System.Drawing.Point(949, 27);
            this.ewLblEmpezandoPor.Name = "ewLblEmpezandoPor";
            this.ewLblEmpezandoPor.Size = new System.Drawing.Size(110, 16);
            this.ewLblEmpezandoPor.TabIndex = 31;
            this.ewLblEmpezandoPor.Text = "Empezando por la";
            // 
            // ewNumCuentaAPartirPosicion
            // 
            this.ewNumCuentaAPartirPosicion._DescripcionError = "";
            this.ewNumCuentaAPartirPosicion._DescripcionOpcional = null;
            this.ewNumCuentaAPartirPosicion._EditMode = false;
            this.ewNumCuentaAPartirPosicion._ErrorValidation = false;
            this.ewNumCuentaAPartirPosicion._EsOpcionalConfigUser = false;
            this.ewNumCuentaAPartirPosicion._PermitirConfigUser = true;
            this.ewNumCuentaAPartirPosicion._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumCuentaAPartirPosicion._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumCuentaAPartirPosicion._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumCuentaAPartirPosicion._ReadOnly = false;
            this.ewNumCuentaAPartirPosicion._SelectOnEntry = false;
            this.ewNumCuentaAPartirPosicion._Tooltip = "";
            this.ewNumCuentaAPartirPosicion._UsuarioPermiteConfigUser = false;
            this.ewNumCuentaAPartirPosicion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumCuentaAPartirPosicion.Location = new System.Drawing.Point(840, 100);
            this.ewNumCuentaAPartirPosicion.Name = "ewNumCuentaAPartirPosicion";
            this.ewNumCuentaAPartirPosicion.Size = new System.Drawing.Size(71, 23);
            this.ewNumCuentaAPartirPosicion.TabIndex = 33;
            this.ewNumCuentaAPartirPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumCuentaAPartirPosicion.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewNumArticuloAPartirPosicion
            // 
            this.ewNumArticuloAPartirPosicion._DescripcionError = "";
            this.ewNumArticuloAPartirPosicion._DescripcionOpcional = null;
            this.ewNumArticuloAPartirPosicion._EditMode = false;
            this.ewNumArticuloAPartirPosicion._ErrorValidation = false;
            this.ewNumArticuloAPartirPosicion._EsOpcionalConfigUser = false;
            this.ewNumArticuloAPartirPosicion._PermitirConfigUser = true;
            this.ewNumArticuloAPartirPosicion._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.ewNumArticuloAPartirPosicion._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.ewNumArticuloAPartirPosicion._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.ewNumArticuloAPartirPosicion._ReadOnly = false;
            this.ewNumArticuloAPartirPosicion._SelectOnEntry = false;
            this.ewNumArticuloAPartirPosicion._Tooltip = "";
            this.ewNumArticuloAPartirPosicion._UsuarioPermiteConfigUser = false;
            this.ewNumArticuloAPartirPosicion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewNumArticuloAPartirPosicion.Location = new System.Drawing.Point(840, 61);
            this.ewNumArticuloAPartirPosicion.Name = "ewNumArticuloAPartirPosicion";
            this.ewNumArticuloAPartirPosicion.Size = new System.Drawing.Size(71, 23);
            this.ewNumArticuloAPartirPosicion.TabIndex = 32;
            this.ewNumArticuloAPartirPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ewNumArticuloAPartirPosicion.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ewComboArticuloEmpezarPor
            // 
            this.ewComboArticuloEmpezarPor._DescripcionError = "";
            this.ewComboArticuloEmpezarPor._DescripcionOpcional = null;
            this.ewComboArticuloEmpezarPor._EditMode = false;
            this.ewComboArticuloEmpezarPor._ErrorValidation = false;
            this.ewComboArticuloEmpezarPor._EsOpcionalConfigUser = false;
            this.ewComboArticuloEmpezarPor._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewComboArticuloEmpezarPor._PermitirConfigUser = true;
            this.ewComboArticuloEmpezarPor._PropiedadesDeEstilos._ColorFondoTextBoxAsociado = System.Drawing.SystemColors.Window;
            this.ewComboArticuloEmpezarPor._PropiedadesDeEstilos._ColorFunteTextBoxAsociado = System.Drawing.SystemColors.ControlText;
            this.ewComboArticuloEmpezarPor._UsuarioPermiteConfigUser = false;
            this.ewComboArticuloEmpezarPor.BackColor = System.Drawing.SystemColors.Window;
            this.ewComboArticuloEmpezarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ewComboArticuloEmpezarPor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewComboArticuloEmpezarPor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ewComboArticuloEmpezarPor.FormattingEnabled = true;
            this.ewComboArticuloEmpezarPor.Location = new System.Drawing.Point(949, 61);
            this.ewComboArticuloEmpezarPor.Name = "ewComboArticuloEmpezarPor";
            this.ewComboArticuloEmpezarPor.Size = new System.Drawing.Size(121, 24);
            this.ewComboArticuloEmpezarPor.TabIndex = 34;
            // 
            // ewComboCuentaEmpezarPor
            // 
            this.ewComboCuentaEmpezarPor._DescripcionError = "";
            this.ewComboCuentaEmpezarPor._DescripcionOpcional = null;
            this.ewComboCuentaEmpezarPor._EditMode = false;
            this.ewComboCuentaEmpezarPor._ErrorValidation = false;
            this.ewComboCuentaEmpezarPor._EsOpcionalConfigUser = false;
            this.ewComboCuentaEmpezarPor._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewComboCuentaEmpezarPor._PermitirConfigUser = true;
            this.ewComboCuentaEmpezarPor._PropiedadesDeEstilos._ColorFondoTextBoxAsociado = System.Drawing.SystemColors.Window;
            this.ewComboCuentaEmpezarPor._PropiedadesDeEstilos._ColorFunteTextBoxAsociado = System.Drawing.SystemColors.ControlText;
            this.ewComboCuentaEmpezarPor._UsuarioPermiteConfigUser = false;
            this.ewComboCuentaEmpezarPor.BackColor = System.Drawing.SystemColors.Window;
            this.ewComboCuentaEmpezarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ewComboCuentaEmpezarPor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewComboCuentaEmpezarPor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ewComboCuentaEmpezarPor.FormattingEnabled = true;
            this.ewComboCuentaEmpezarPor.Location = new System.Drawing.Point(949, 100);
            this.ewComboCuentaEmpezarPor.Name = "ewComboCuentaEmpezarPor";
            this.ewComboCuentaEmpezarPor.Size = new System.Drawing.Size(121, 24);
            this.ewComboCuentaEmpezarPor.TabIndex = 35;
            // 
            // ewTxtArticuloRellenarCon
            // 
            this.ewTxtArticuloRellenarCon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewTxtArticuloRellenarCon.Location = new System.Drawing.Point(758, 61);
            this.ewTxtArticuloRellenarCon.MaxLength = 1;
            this.ewTxtArticuloRellenarCon.Name = "ewTxtArticuloRellenarCon";
            this.ewTxtArticuloRellenarCon.Size = new System.Drawing.Size(44, 23);
            this.ewTxtArticuloRellenarCon.TabIndex = 36;
            // 
            // ewTxtCuentaRellenarCon
            // 
            this.ewTxtCuentaRellenarCon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewTxtCuentaRellenarCon.Location = new System.Drawing.Point(758, 100);
            this.ewTxtCuentaRellenarCon.MaxLength = 1;
            this.ewTxtCuentaRellenarCon.Name = "ewTxtCuentaRellenarCon";
            this.ewTxtCuentaRellenarCon.Size = new System.Drawing.Size(44, 23);
            this.ewTxtCuentaRellenarCon.TabIndex = 37;
            // 
            // frmEjemCambioAnchoCampo
            // 
            this.ClientSize = new System.Drawing.Size(1091, 276);
            this.Controls.Add(this.ewTxtCuentaRellenarCon);
            this.Controls.Add(this.ewTxtArticuloRellenarCon);
            this.Controls.Add(this.ewComboCuentaEmpezarPor);
            this.Controls.Add(this.ewComboArticuloEmpezarPor);
            this.Controls.Add(this.ewNumCuentaAPartirPosicion);
            this.Controls.Add(this.ewNumArticuloAPartirPosicion);
            this.Controls.Add(this.ewLblEmpezandoPor);
            this.Controls.Add(this.ewLblApartir2);
            this.Controls.Add(this.ewLblApartir1);
            this.Controls.Add(this.ewLblRellenarCon);
            this.Controls.Add(this.ewNumCuentaAnchoMinimo);
            this.Controls.Add(this.ewNumArticuloAnchoMinimo);
            this.Controls.Add(this.ewlblAnchoMinimo);
            this.Controls.Add(this.ewNumCuentaAnchoMaximo);
            this.Controls.Add(this.ewNumArticuloAnchoMaximo);
            this.Controls.Add(this.ewlblAnchoMaximo);
            this.Controls.Add(this.ewNumCuentaAnchoStandar);
            this.Controls.Add(this.ewNumArticuloAnchoStandar);
            this.Controls.Add(this.ewlblAnchoStandar);
            this.Controls.Add(this.ewNumCuentaAnchoActual);
            this.Controls.Add(this.ewNumArticuloAnchoActual);
            this.Controls.Add(this.ewNumCuentaAnchoNuevo);
            this.Controls.Add(this.ewNumArticuloAnchoNuevo);
            this.Controls.Add(this.ewChkCopiaSeg);
            this.Controls.Add(this.txtEstadoProceso);
            this.Controls.Add(this.ewlblAnchoNuevo);
            this.Controls.Add(this.ewlblAnchoActual);
            this.Controls.Add(this.ewlabelCampoCuenta);
            this.Controls.Add(this.ewlabelCampoArticulo);
            this.Name = "frmEjemCambioAnchoCampo";
            this.Text = "Ejemplo cambio anchura de campos configurables en anchura de Sage50";
            this.Controls.SetChildIndex(this.btSalir1, 0);
            this.Controls.SetChildIndex(this.btDocCancelar1, 0);
            this.Controls.SetChildIndex(this.btDocAceptar1, 0);
            this.Controls.SetChildIndex(this.ewlabelCampoArticulo, 0);
            this.Controls.SetChildIndex(this.ewlabelCampoCuenta, 0);
            this.Controls.SetChildIndex(this.ewlblAnchoActual, 0);
            this.Controls.SetChildIndex(this.ewlblAnchoNuevo, 0);
            this.Controls.SetChildIndex(this.txtEstadoProceso, 0);
            this.Controls.SetChildIndex(this.ewChkCopiaSeg, 0);
            this.Controls.SetChildIndex(this.ewNumArticuloAnchoNuevo, 0);
            this.Controls.SetChildIndex(this.ewNumCuentaAnchoNuevo, 0);
            this.Controls.SetChildIndex(this.ewNumArticuloAnchoActual, 0);
            this.Controls.SetChildIndex(this.ewNumCuentaAnchoActual, 0);
            this.Controls.SetChildIndex(this.ewlblAnchoStandar, 0);
            this.Controls.SetChildIndex(this.ewNumArticuloAnchoStandar, 0);
            this.Controls.SetChildIndex(this.ewNumCuentaAnchoStandar, 0);
            this.Controls.SetChildIndex(this.ewlblAnchoMaximo, 0);
            this.Controls.SetChildIndex(this.ewNumArticuloAnchoMaximo, 0);
            this.Controls.SetChildIndex(this.ewNumCuentaAnchoMaximo, 0);
            this.Controls.SetChildIndex(this.ewlblAnchoMinimo, 0);
            this.Controls.SetChildIndex(this.ewNumArticuloAnchoMinimo, 0);
            this.Controls.SetChildIndex(this.ewNumCuentaAnchoMinimo, 0);
            this.Controls.SetChildIndex(this.ewLblRellenarCon, 0);
            this.Controls.SetChildIndex(this.ewLblApartir1, 0);
            this.Controls.SetChildIndex(this.ewLblApartir2, 0);
            this.Controls.SetChildIndex(this.ewLblEmpezandoPor, 0);
            this.Controls.SetChildIndex(this.ewNumArticuloAPartirPosicion, 0);
            this.Controls.SetChildIndex(this.ewNumCuentaAPartirPosicion, 0);
            this.Controls.SetChildIndex(this.ewComboArticuloEmpezarPor, 0);
            this.Controls.SetChildIndex(this.ewComboCuentaEmpezarPor, 0);
            this.Controls.SetChildIndex(this.ewTxtArticuloRellenarCon, 0);
            this.Controls.SetChildIndex(this.ewTxtCuentaRellenarCon, 0);
            ((System.ComponentModel.ISupportInitialize)(this._oErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAnchoNuevo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAnchoNuevo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAnchoActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAnchoActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAnchoStandar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAnchoStandar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAnchoMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAnchoMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAnchoMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAnchoMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumCuentaAPartirPosicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewNumArticuloAPartirPosicion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ewlabel ewlabelCampoArticulo;
        private ewlabel ewlabelCampoCuenta;
        private ewlabel ewlblAnchoActual;
        private ewlabel ewlblAnchoNuevo;
        private ewtextbox txtEstadoProceso;
        private ewcheckbox ewChkCopiaSeg;
        private ewnumericupdown ewNumArticuloAnchoNuevo;
        private ewnumericupdown ewNumCuentaAnchoNuevo;
        private ewnumericupdown ewNumCuentaAnchoActual;
        private ewnumericupdown ewNumArticuloAnchoActual;
        private ewnumericupdown ewNumCuentaAnchoStandar;
        private ewnumericupdown ewNumArticuloAnchoStandar;
        private ewlabel ewlblAnchoStandar;
        private ewnumericupdown ewNumCuentaAnchoMinimo;
        private ewnumericupdown ewNumArticuloAnchoMinimo;
        private ewlabel ewlblAnchoMinimo;
        private ewnumericupdown ewNumCuentaAnchoMaximo;
        private ewnumericupdown ewNumArticuloAnchoMaximo;
        private ewlabel ewlblAnchoMaximo;
        private ewlabel ewLblRellenarCon;
        private ewlabel ewLblApartir1;
        private ewlabel ewLblApartir2;
        private ewlabel ewLblEmpezandoPor;
        private ewnumericupdown ewNumCuentaAPartirPosicion;
        private ewnumericupdown ewNumArticuloAPartirPosicion;
        private ewcombobox ewComboArticuloEmpezarPor;
        private ewcombobox ewComboCuentaEmpezarPor;
        private System.Windows.Forms.TextBox ewTxtArticuloRellenarCon;
        private System.Windows.Forms.TextBox ewTxtCuentaRellenarCon;
    }
}
