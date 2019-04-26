namespace escritorio_loteria
{
    partial class menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.txtNombUsu = new System.Windows.Forms.TextBox();
            this.btnCrearPtda = new System.Windows.Forms.Button();
            this.btnUnirsePtda = new System.Windows.Forms.Button();
            this.lblNombUsu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNombUsu
            // 
            this.txtNombUsu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombUsu.Location = new System.Drawing.Point(161, 27);
            this.txtNombUsu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombUsu.Name = "txtNombUsu";
            this.txtNombUsu.Size = new System.Drawing.Size(116, 23);
            this.txtNombUsu.TabIndex = 1;
            // 
            // btnCrearPtda
            // 
            this.btnCrearPtda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearPtda.BackgroundImage = global::escritorio_loteria.Properties.Resources.Yellow_lakejpg_320x299;
            this.btnCrearPtda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearPtda.Location = new System.Drawing.Point(11, 54);
            this.btnCrearPtda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCrearPtda.Name = "btnCrearPtda";
            this.btnCrearPtda.Size = new System.Drawing.Size(267, 41);
            this.btnCrearPtda.TabIndex = 2;
            this.btnCrearPtda.Text = "Crear Partida";
            this.btnCrearPtda.UseVisualStyleBackColor = true;
            this.btnCrearPtda.Click += new System.EventHandler(this.btnCrearPtda_Click);
            // 
            // btnUnirsePtda
            // 
            this.btnUnirsePtda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnirsePtda.BackgroundImage = global::escritorio_loteria.Properties.Resources.Yellow_lakejpg_320x299;
            this.btnUnirsePtda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnirsePtda.Location = new System.Drawing.Point(12, 100);
            this.btnUnirsePtda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUnirsePtda.Name = "btnUnirsePtda";
            this.btnUnirsePtda.Size = new System.Drawing.Size(267, 41);
            this.btnUnirsePtda.TabIndex = 3;
            this.btnUnirsePtda.Text = "Unirse a la Partida";
            this.btnUnirsePtda.UseVisualStyleBackColor = true;
            this.btnUnirsePtda.Click += new System.EventHandler(this.btnUnirsePtda_Click);
            // 
            // lblNombUsu
            // 
            this.lblNombUsu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombUsu.AutoSize = true;
            this.lblNombUsu.BackColor = System.Drawing.Color.Transparent;
            this.lblNombUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombUsu.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNombUsu.Location = new System.Drawing.Point(9, 27);
            this.lblNombUsu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombUsu.Name = "lblNombUsu";
            this.lblNombUsu.Size = new System.Drawing.Size(152, 17);
            this.lblNombUsu.TabIndex = 4;
            this.lblNombUsu.Text = "Nombre del Usuario";
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(287, 407);
            this.Controls.Add(this.lblNombUsu);
            this.Controls.Add(this.btnUnirsePtda);
            this.Controls.Add(this.btnCrearPtda);
            this.Controls.Add(this.txtNombUsu);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNombUsu;
        private System.Windows.Forms.Button btnCrearPtda;
        private System.Windows.Forms.Button btnUnirsePtda;
        private System.Windows.Forms.Label lblNombUsu;
    }
}

