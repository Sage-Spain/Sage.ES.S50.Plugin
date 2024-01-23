namespace sage.addons.EjemAddons.Visual.UserControls
{
    partial class EjemAddonsConfig
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ewtabcontrolConfig = new sage.ew.objetos.ewtabcontrol();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tabPageContadores = new System.Windows.Forms.TabPage();
            this.ewgridContadores = new sage.ew.objetos.ewgrid();
            this.ewtabcontrolConfig.SuspendLayout();
            this.tabPageContadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ewgridContadores)).BeginInit();
            this.SuspendLayout();
            // 
            // ewtabcontrolConfig
            // 
            this.ewtabcontrolConfig._NavegacionTeclasEspeciales = false;
            this.ewtabcontrolConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ewtabcontrolConfig.Controls.Add(this.tabPageGeneral);
            this.ewtabcontrolConfig.Controls.Add(this.tabPageContadores);
            this.ewtabcontrolConfig.Font = new System.Drawing.Font("Arial", 9.5F);
            this.ewtabcontrolConfig.Location = new System.Drawing.Point(0, 0);
            this.ewtabcontrolConfig.Name = "ewtabcontrolConfig";
            this.ewtabcontrolConfig.SelectedIndex = 0;
            this.ewtabcontrolConfig.Size = new System.Drawing.Size(411, 388);
            this.ewtabcontrolConfig.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(403, 359);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            // 
            // tabPageContadores
            // 
            this.tabPageContadores.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageContadores.Controls.Add(this.ewgridContadores);
            this.tabPageContadores.Location = new System.Drawing.Point(4, 25);
            this.tabPageContadores.Name = "tabPageContadores";
            this.tabPageContadores.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContadores.Size = new System.Drawing.Size(403, 368);
            this.tabPageContadores.TabIndex = 1;
            this.tabPageContadores.Text = "Contadores";
            // 
            // ewgridContadores
            // 
            this.ewgridContadores._BackgroundColor = System.Drawing.SystemColors.Window;
            this.ewgridContadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ewgridContadores.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ewgridContadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ewgridContadores.DefaultCellStyle = dataGridViewCellStyle1;
            this.ewgridContadores.EnableHeadersVisualStyles = false;
            this.ewgridContadores.Location = new System.Drawing.Point(6, 6);
            this.ewgridContadores.Name = "ewgridContadores";
            this.ewgridContadores.RowHeadersVisible = false;
            this.ewgridContadores.Size = new System.Drawing.Size(391, 368);
            this.ewgridContadores.TabIndex = 0;
            // 
            // EjemAddonsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ewtabcontrolConfig);
            this.Name = "EjemAddonsConfig";
            this.Size = new System.Drawing.Size(411, 423);
            this.ewtabcontrolConfig.ResumeLayout(false);
            this.tabPageContadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ewgridContadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ew.objetos.ewtabcontrol ewtabcontrolConfig;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageContadores;
        private ew.objetos.ewgrid ewgridContadores;
    }
}
