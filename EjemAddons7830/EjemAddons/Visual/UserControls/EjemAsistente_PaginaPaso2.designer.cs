namespace sage.addons.EjemAddons.Visual.UserControls
{
    partial class EjemAsistente_PaginaPaso2
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
            this.ewlabel1 = new sage.ew.objetos.ewlabel();
            this.ewLabelTitulo = new sage.ew.objetos.ewlabel();
            this.ewlabel2 = new sage.ew.objetos.ewlabel();
            this.ewlabel3 = new sage.ew.objetos.ewlabel();
            this.SuspendLayout();
            // 
            // ewlabel1
            // 
            this.ewlabel1._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewlabel1._PropiedadesDeEstilos._AplicarEstilos = false;
            this.ewlabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ewlabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewlabel1.Location = new System.Drawing.Point(3, 49);
            this.ewlabel1.Name = "ewlabel1";
            this.ewlabel1.Size = new System.Drawing.Size(733, 44);
            this.ewlabel1.TabIndex = 4;
            this.ewlabel1.Text = "Descripción de las tareas a realizar en el paso 2 del asistente.";
            // 
            // ewLabelTitulo
            // 
            this.ewLabelTitulo._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewLabelTitulo.AutoSize = true;
            this.ewLabelTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewLabelTitulo.Location = new System.Drawing.Point(3, 10);
            this.ewLabelTitulo.Name = "ewLabelTitulo";
            this.ewLabelTitulo.Size = new System.Drawing.Size(331, 25);
            this.ewLabelTitulo.TabIndex = 3;
            this.ewLabelTitulo.Text = "Paso 2 para la importación de datos";
            // 
            // ewlabel2
            // 
            this.ewlabel2._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewlabel2._PropiedadesDeEstilos._AplicarEstilos = false;
            this.ewlabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ewlabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewlabel2.Location = new System.Drawing.Point(3, 198);
            this.ewlabel2.Name = "ewlabel2";
            this.ewlabel2.Size = new System.Drawing.Size(733, 44);
            this.ewlabel2.TabIndex = 5;
            this.ewlabel2.Text = "Todos los mensajes de texto que aparecen en esta página forman parte del usercont" +
    "rol de la página Paso 2, elimine los controles que no considere necesarios y agr" +
    "egue sus propios controles.";
            this.ewlabel2.Click += new System.EventHandler(this.ewlabel2_Click);
            // 
            // ewlabel3
            // 
            this.ewlabel3._Localizacion = sage.ew.interficies.LocalizacionOpcion.Bottom;
            this.ewlabel3._PropiedadesDeEstilos._AplicarEstilos = false;
            this.ewlabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ewlabel3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ewlabel3.Location = new System.Drawing.Point(3, 116);
            this.ewlabel3.Name = "ewlabel3";
            this.ewlabel3.Size = new System.Drawing.Size(733, 44);
            this.ewlabel3.TabIndex = 7;
            this.ewlabel3.Text = "Página Paso 2";
            // 
            // EjemAsistente_PaginaPaso2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ewlabel3);
            this.Controls.Add(this.ewlabel2);
            this.Controls.Add(this.ewlabel1);
            this.Controls.Add(this.ewLabelTitulo);
            this.Name = "EjemAsistente_PaginaPaso2";
            this.Size = new System.Drawing.Size(757, 544);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ew.objetos.ewlabel ewlabel1;
        private ew.objetos.ewlabel ewLabelTitulo;
        private ew.objetos.ewlabel ewlabel2;
        private ew.objetos.ewlabel ewlabel3;
    }
}
