namespace BDOO
{
    partial class Main
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
            this.btnEnderecos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnderecos
            // 
            this.btnEnderecos.Location = new System.Drawing.Point(12, 36);
            this.btnEnderecos.Name = "btnEnderecos";
            this.btnEnderecos.Size = new System.Drawing.Size(219, 44);
            this.btnEnderecos.TabIndex = 0;
            this.btnEnderecos.Text = "Endereços";
            this.btnEnderecos.UseVisualStyleBackColor = true;
            this.btnEnderecos.Click += new System.EventHandler(this.btnEnderecos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(12, 107);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(219, 44);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 188);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnEnderecos);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BDOO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnderecos;
        private System.Windows.Forms.Button btnClientes;
    }
}

