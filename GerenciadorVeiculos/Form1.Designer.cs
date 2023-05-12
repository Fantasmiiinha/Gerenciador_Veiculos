namespace GerenciadorVeiculos
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInstancia = new System.Windows.Forms.Button();
            this.rtbTeste = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnInstancia
            // 
            this.btnInstancia.Location = new System.Drawing.Point(23, 24);
            this.btnInstancia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInstancia.Name = "btnInstancia";
            this.btnInstancia.Size = new System.Drawing.Size(205, 39);
            this.btnInstancia.TabIndex = 0;
            this.btnInstancia.Text = "Instanciar um de cada";
            this.btnInstancia.UseVisualStyleBackColor = true;
            this.btnInstancia.Click += new System.EventHandler(this.btnInstancia_Click);
            // 
            // rtbTeste
            // 
            this.rtbTeste.Location = new System.Drawing.Point(23, 100);
            this.rtbTeste.Name = "rtbTeste";
            this.rtbTeste.Size = new System.Drawing.Size(205, 169);
            this.rtbTeste.TabIndex = 1;
            this.rtbTeste.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1005);
            this.Controls.Add(this.rtbTeste);
            this.Controls.Add(this.btnInstancia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInstancia;
        private System.Windows.Forms.RichTextBox rtbTeste;
    }
}

