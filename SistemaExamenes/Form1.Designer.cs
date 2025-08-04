namespace SistemaExamenes
{
    partial class Form1
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
            this.btnCorreccion = new System.Windows.Forms.Button();
            this.btnExamen = new System.Windows.Forms.Button();
            this.btnPreguntas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCorreccion
            // 
            this.btnCorreccion.BackColor = System.Drawing.Color.Azure;
            this.btnCorreccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorreccion.Location = new System.Drawing.Point(43, 241);
            this.btnCorreccion.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCorreccion.Name = "btnCorreccion";
            this.btnCorreccion.Size = new System.Drawing.Size(249, 52);
            this.btnCorreccion.TabIndex = 7;
            this.btnCorreccion.Text = "Correccion de examen";
            this.btnCorreccion.UseVisualStyleBackColor = false;
            this.btnCorreccion.Click += new System.EventHandler(this.btnCorreccion_Click);
            // 
            // btnExamen
            // 
            this.btnExamen.BackColor = System.Drawing.Color.Azure;
            this.btnExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExamen.Location = new System.Drawing.Point(43, 169);
            this.btnExamen.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnExamen.Name = "btnExamen";
            this.btnExamen.Size = new System.Drawing.Size(249, 52);
            this.btnExamen.TabIndex = 6;
            this.btnExamen.Text = "Generar Examen";
            this.btnExamen.UseVisualStyleBackColor = false;
            this.btnExamen.Click += new System.EventHandler(this.btnExamen_Click);
            // 
            // btnPreguntas
            // 
            this.btnPreguntas.BackColor = System.Drawing.Color.Azure;
            this.btnPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreguntas.Location = new System.Drawing.Point(43, 96);
            this.btnPreguntas.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnPreguntas.Name = "btnPreguntas";
            this.btnPreguntas.Size = new System.Drawing.Size(249, 52);
            this.btnPreguntas.TabIndex = 5;
            this.btnPreguntas.Text = "Administrar preguntas";
            this.btnPreguntas.UseVisualStyleBackColor = false;
            this.btnPreguntas.Click += new System.EventHandler(this.btnPreguntas_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(65, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Menu de opciones";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 348);
            this.Controls.Add(this.btnCorreccion);
            this.Controls.Add(this.btnExamen);
            this.Controls.Add(this.btnPreguntas);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Menu de opciones";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCorreccion;
        private System.Windows.Forms.Button btnExamen;
        private System.Windows.Forms.Button btnPreguntas;
        private System.Windows.Forms.Label label1;
    }
}

