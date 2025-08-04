namespace SistemaExamenes
{
    partial class Form4
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdExamen = new System.Windows.Forms.TextBox();
            this.txtAlumno = new System.Windows.Forms.TextBox();
            this.btnCorregirExamen = new System.Windows.Forms.Button();
            this.panelPreguntas = new System.Windows.Forms.Panel();
            this.btnGenerarExamen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresar ID del Examen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre y Apellido:";
            // 
            // txtIdExamen
            // 
            this.txtIdExamen.BackColor = System.Drawing.Color.Azure;
            this.txtIdExamen.Location = new System.Drawing.Point(204, 21);
            this.txtIdExamen.Name = "txtIdExamen";
            this.txtIdExamen.Size = new System.Drawing.Size(149, 22);
            this.txtIdExamen.TabIndex = 2;
            // 
            // txtAlumno
            // 
            this.txtAlumno.BackColor = System.Drawing.Color.Azure;
            this.txtAlumno.Location = new System.Drawing.Point(180, 49);
            this.txtAlumno.Name = "txtAlumno";
            this.txtAlumno.Size = new System.Drawing.Size(173, 22);
            this.txtAlumno.TabIndex = 3;
            // 
            // btnCorregirExamen
            // 
            this.btnCorregirExamen.BackColor = System.Drawing.Color.Azure;
            this.btnCorregirExamen.Location = new System.Drawing.Point(135, 629);
            this.btnCorregirExamen.Name = "btnCorregirExamen";
            this.btnCorregirExamen.Size = new System.Drawing.Size(365, 53);
            this.btnCorregirExamen.TabIndex = 4;
            this.btnCorregirExamen.Text = "Corregir Examen";
            this.btnCorregirExamen.UseVisualStyleBackColor = false;
            this.btnCorregirExamen.Click += new System.EventHandler(this.btnCorregirExamen_Click);
            // 
            // panelPreguntas
            // 
            this.panelPreguntas.AutoScroll = true;
            this.panelPreguntas.BackColor = System.Drawing.Color.MintCream;
            this.panelPreguntas.Location = new System.Drawing.Point(23, 107);
            this.panelPreguntas.Name = "panelPreguntas";
            this.panelPreguntas.Size = new System.Drawing.Size(577, 509);
            this.panelPreguntas.TabIndex = 5;
            // 
            // btnGenerarExamen
            // 
            this.btnGenerarExamen.BackColor = System.Drawing.Color.Azure;
            this.btnGenerarExamen.Location = new System.Drawing.Point(398, 12);
            this.btnGenerarExamen.Name = "btnGenerarExamen";
            this.btnGenerarExamen.Size = new System.Drawing.Size(146, 69);
            this.btnGenerarExamen.TabIndex = 6;
            this.btnGenerarExamen.Text = "Generar Examen";
            this.btnGenerarExamen.UseVisualStyleBackColor = false;
            this.btnGenerarExamen.Click += new System.EventHandler(this.btnGenerarExamen_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 694);
            this.Controls.Add(this.btnGenerarExamen);
            this.Controls.Add(this.panelPreguntas);
            this.Controls.Add(this.btnCorregirExamen);
            this.Controls.Add(this.txtAlumno);
            this.Controls.Add(this.txtIdExamen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form4";
            this.Text = "Examen corregido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdExamen;
        private System.Windows.Forms.TextBox txtAlumno;
        private System.Windows.Forms.Button btnCorregirExamen;
        private System.Windows.Forms.Panel panelPreguntas;
        private System.Windows.Forms.Button btnGenerarExamen;
    }
}