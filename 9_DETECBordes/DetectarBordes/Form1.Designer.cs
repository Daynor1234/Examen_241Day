namespace DetectarBordes
{
    partial class AppDetecBord
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.DecBor = new System.Windows.Forms.Button();
            this.CarIma = new System.Windows.Forms.Button();
            this.ImagOrig = new System.Windows.Forms.PictureBox();
            this.ImagWithoutBord = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ImagOrig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagWithoutBord)).BeginInit();
            this.SuspendLayout();
            // 
            // DecBor
            // 
            this.DecBor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.DecBor.Location = new System.Drawing.Point(551, 116);
            this.DecBor.Name = "DecBor";
            this.DecBor.Size = new System.Drawing.Size(90, 27);
            this.DecBor.TabIndex = 0;
            this.DecBor.Text = "Detectar Borde";
            this.DecBor.UseVisualStyleBackColor = false;
            this.DecBor.Click += new System.EventHandler(this.DecBor_Click);
            // 
            // CarIma
            // 
            this.CarIma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.CarIma.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.CarIma.Location = new System.Drawing.Point(551, 83);
            this.CarIma.Name = "CarIma";
            this.CarIma.Size = new System.Drawing.Size(90, 27);
            this.CarIma.TabIndex = 1;
            this.CarIma.Text = "Cargar Imagen";
            this.CarIma.UseVisualStyleBackColor = false;
            this.CarIma.Click += new System.EventHandler(this.CarIma_Click);
            // 
            // ImagOrig
            // 
            this.ImagOrig.Location = new System.Drawing.Point(12, 53);
            this.ImagOrig.Name = "ImagOrig";
            this.ImagOrig.Size = new System.Drawing.Size(247, 258);
            this.ImagOrig.TabIndex = 2;
            this.ImagOrig.TabStop = false;
            // 
            // ImagWithoutBord
            // 
            this.ImagWithoutBord.Location = new System.Drawing.Point(291, 53);
            this.ImagWithoutBord.Name = "ImagWithoutBord";
            this.ImagWithoutBord.Size = new System.Drawing.Size(254, 258);
            this.ImagWithoutBord.TabIndex = 3;
            this.ImagWithoutBord.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AppDetecBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 335);
            this.Controls.Add(this.ImagWithoutBord);
            this.Controls.Add(this.ImagOrig);
            this.Controls.Add(this.CarIma);
            this.Controls.Add(this.DecBor);
            this.Name = "AppDetecBord";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ImagOrig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagWithoutBord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DecBor;
        private System.Windows.Forms.Button CarIma;
        private System.Windows.Forms.PictureBox ImagOrig;
        private System.Windows.Forms.PictureBox ImagWithoutBord;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

