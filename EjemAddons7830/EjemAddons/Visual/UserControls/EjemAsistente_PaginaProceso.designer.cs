namespace sage.addons.EjemAddons.Visual.UserControls
{
    partial class EjemAsistente_PaginaProceso
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ewLabelTitulo = new sage.ew.objetos.ewlabel();
            this.ewProgressBar = new sage.ew.objetos.ewprogressbar();
            this.lblProgreso = new sage.ew.objetos.ewlabel();
            this.txtDetalle = new sage.ew.objetos.ewtextbox();
            this.lblTituloDetalle = new sage.ew.objetos.ewlabel();
            this.lblTitulo = new sage.ew.objetos.ewlabel();
            this.SuspendLayout();
            // 
            // ewLabelTitulo
            // 
            this.ewLabelTitulo._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewLabelTitulo.AutoSize = true;
            this.ewLabelTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewLabelTitulo.Location = new System.Drawing.Point(3, 10);
            this.ewLabelTitulo.Name = "ewLabelTitulo";
            this.ewLabelTitulo.Size = new System.Drawing.Size(368, 25);
            this.ewLabelTitulo.TabIndex = 3;
            this.ewLabelTitulo.Text = "Ejecución proceso importación de datos";
            // 
            // ewProgressBar
            // 
            this.ewProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ewProgressBar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ewProgressBar.Location = new System.Drawing.Point(18, 436);
            this.ewProgressBar.Name = "ewProgressBar";
            this.ewProgressBar.Size = new System.Drawing.Size(631, 23);
            this.ewProgressBar.TabIndex = 9;
            this.ewProgressBar.Visible = false;
            // 
            // lblProgreso
            // 
            this.lblProgreso._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.lblProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgreso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblProgreso.Location = new System.Drawing.Point(16, 415);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(631, 18);
            this.lblProgreso.TabIndex = 8;
            this.lblProgreso.Text = "Progreso";
            this.lblProgreso.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblProgreso.Visible = false;
            // 
            // txtDetalle
            // 
            this.txtDetalle._CanChangeStyle = false;
            this.txtDetalle._DescripcionError = "";
            this.txtDetalle._DescripcionOpcional = null;
            this.txtDetalle._EditMode = false;
            this.txtDetalle._ErrorValidation = false;
            this.txtDetalle._EsOpcionalConfigUser = false;
            this.txtDetalle._NoMostrarTecladoTactil = false;
            this.txtDetalle._PasswordChar = '\0';
            this.txtDetalle._PermitirConfigUser = true;
            this.txtDetalle._PropiedadesDeEstilos._ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.txtDetalle._PropiedadesDeEstilos._ColorBorderError = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(56)))), ((int)(((byte)(79)))));
            this.txtDetalle._PropiedadesDeEstilos._ColorBorderFocus = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.txtDetalle._SoloNumeros = false;
            this.txtDetalle._Tactil_Teclat_Numeric = false;
            this.txtDetalle._Tooltip = "";
            this.txtDetalle._UsuarioPermiteConfigUser = false;
            this.txtDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalle.Location = new System.Drawing.Point(18, 106);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.ReadOnly = true;
            this.txtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalle.Size = new System.Drawing.Size(631, 303);
            this.txtDetalle.TabIndex = 7;
            // 
            // lblTituloDetalle
            // 
            this.lblTituloDetalle._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.lblTituloDetalle.AutoSize = true;
            this.lblTituloDetalle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDetalle.Location = new System.Drawing.Point(14, 84);
            this.lblTituloDetalle.Name = "lblTituloDetalle";
            this.lblTituloDetalle.Size = new System.Drawing.Size(344, 20);
            this.lblTituloDetalle.TabIndex = 6;
            this.lblTituloDetalle.Text = "Pulsa el botón Empezar para iniciar la importación";
            // 
            // lblTitulo
            // 
            this.lblTitulo._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 49);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(191, 25);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Importación de datos";
            // 
            // EjemAsistente_PaginaProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ewProgressBar);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.lblTituloDetalle);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.ewLabelTitulo);
            this.Name = "EjemAsistente_PaginaProceso";
            this.Size = new System.Drawing.Size(757, 544);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ew.objetos.ewlabel ewLabelTitulo;
        private ew.objetos.ewprogressbar ewProgressBar;
        private ew.objetos.ewlabel lblProgreso;
        private ew.objetos.ewtextbox txtDetalle;
        private ew.objetos.ewlabel lblTituloDetalle;
        private ew.objetos.ewlabel lblTitulo;
    }
}
