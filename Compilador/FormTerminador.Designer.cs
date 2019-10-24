namespace Compilador
{
    partial class FormTerminador
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPontoVirgula = new System.Windows.Forms.Button();
            this.btnOutro = new System.Windows.Forms.Button();
            this.txtOutro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Opções de Terminadores:";
            // 
            // btnPontoVirgula
            // 
            this.btnPontoVirgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPontoVirgula.Location = new System.Drawing.Point(131, 37);
            this.btnPontoVirgula.Name = "btnPontoVirgula";
            this.btnPontoVirgula.Size = new System.Drawing.Size(90, 23);
            this.btnPontoVirgula.TabIndex = 1;
            this.btnPontoVirgula.Text = "Ponto e vírgula";
            this.btnPontoVirgula.UseVisualStyleBackColor = true;
            this.btnPontoVirgula.Click += new System.EventHandler(this.PontoVirgula_Click);
            // 
            // btnOutro
            // 
            this.btnOutro.Location = new System.Drawing.Point(132, 66);
            this.btnOutro.Name = "btnOutro";
            this.btnOutro.Size = new System.Drawing.Size(89, 23);
            this.btnOutro.TabIndex = 3;
            this.btnOutro.Text = "Confirmar";
            this.btnOutro.UseVisualStyleBackColor = true;
            this.btnOutro.Click += new System.EventHandler(this.btnOutro_Click);
            // 
            // txtOutro
            // 
            this.txtOutro.Location = new System.Drawing.Point(57, 68);
            this.txtOutro.Name = "txtOutro";
            this.txtOutro.Size = new System.Drawing.Size(69, 20);
            this.txtOutro.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Outro:";
            // 
            // FormTerminador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 97);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOutro);
            this.Controls.Add(this.btnOutro);
            this.Controls.Add(this.btnPontoVirgula);
            this.Controls.Add(this.label1);
            this.Name = "FormTerminador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPontoVirgula;
        private System.Windows.Forms.Button btnOutro;
        private System.Windows.Forms.TextBox txtOutro;
        private System.Windows.Forms.Label label2;
    }
}