namespace Locadora_de_Jogos
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnJogo = new System.Windows.Forms.Button();
            this.btnLocacao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(140, 58);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(586, 128);
            this.btnCliente.TabIndex = 0;
            this.btnCliente.Text = "Clientes";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnJogo
            // 
            this.btnJogo.Location = new System.Drawing.Point(140, 228);
            this.btnJogo.Name = "btnJogo";
            this.btnJogo.Size = new System.Drawing.Size(586, 128);
            this.btnJogo.TabIndex = 1;
            this.btnJogo.Text = "Jogos";
            this.btnJogo.UseVisualStyleBackColor = true;
            this.btnJogo.Click += new System.EventHandler(this.btnJogo_Click);
            // 
            // btnLocacao
            // 
            this.btnLocacao.Location = new System.Drawing.Point(140, 402);
            this.btnLocacao.Name = "btnLocacao";
            this.btnLocacao.Size = new System.Drawing.Size(586, 128);
            this.btnLocacao.TabIndex = 2;
            this.btnLocacao.Text = "Locacoes";
            this.btnLocacao.UseVisualStyleBackColor = true;
            this.btnLocacao.Click += new System.EventHandler(this.btnLocacao_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 608);
            this.Controls.Add(this.btnLocacao);
            this.Controls.Add(this.btnJogo);
            this.Controls.Add(this.btnCliente);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnJogo;
        private System.Windows.Forms.Button btnLocacao;
    }
}