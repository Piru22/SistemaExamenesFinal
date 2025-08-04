namespace SistemaExamenes
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.btnGestionarExamen = new System.Windows.Forms.Button();
            this.cmbAsignatura = new System.Windows.Forms.ComboBox();
            this.rtbExamen = new System.Windows.Forms.RichTextBox();
            this.txtUnidades = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUniversidad = new System.Windows.Forms.TextBox();
            this.btnImprimirExamen = new System.Windows.Forms.Button();
            this.lblcarrera = new System.Windows.Forms.Label();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGestionarExamen
            // 
            this.btnGestionarExamen.BackColor = System.Drawing.Color.Azure;
            this.btnGestionarExamen.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.btnGestionarExamen, "btnGestionarExamen");
            this.btnGestionarExamen.Name = "btnGestionarExamen";
            this.btnGestionarExamen.UseVisualStyleBackColor = false;
            this.btnGestionarExamen.Click += new System.EventHandler(this.btnGestionarExamen_Click);
            // 
            // cmbAsignatura
            // 
            this.cmbAsignatura.BackColor = System.Drawing.Color.Azure;
            this.cmbAsignatura.FormattingEnabled = true;
            resources.ApplyResources(this.cmbAsignatura, "cmbAsignatura");
            this.cmbAsignatura.Name = "cmbAsignatura";
            // 
            // rtbExamen
            // 
            this.rtbExamen.BackColor = System.Drawing.Color.MintCream;
            this.rtbExamen.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.rtbExamen, "rtbExamen");
            this.rtbExamen.Name = "rtbExamen";
            // 
            // txtUnidades
            // 
            this.txtUnidades.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.txtUnidades, "txtUnidades");
            this.txtUnidades.Name = "txtUnidades";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarMonthBackground = System.Drawing.Color.Azure;
            resources.ApplyResources(this.dtpFecha, "dtpFecha");
            this.dtpFecha.MaxDate = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtUniversidad
            // 
            this.txtUniversidad.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.txtUniversidad, "txtUniversidad");
            this.txtUniversidad.Name = "txtUniversidad";
            // 
            // btnImprimirExamen
            // 
            this.btnImprimirExamen.BackColor = System.Drawing.Color.Azure;
            this.btnImprimirExamen.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.btnImprimirExamen, "btnImprimirExamen");
            this.btnImprimirExamen.Name = "btnImprimirExamen";
            this.btnImprimirExamen.UseVisualStyleBackColor = false;
            this.btnImprimirExamen.Click += new System.EventHandler(this.btnImprimirExamen_Click);
            // 
            // lblcarrera
            // 
            resources.ApplyResources(this.lblcarrera, "lblcarrera");
            this.lblcarrera.Name = "lblcarrera";
            // 
            // txtCarrera
            // 
            this.txtCarrera.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.txtCarrera, "txtCarrera");
            this.txtCarrera.Name = "txtCarrera";
            // 
            // Form3
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblcarrera);
            this.Controls.Add(this.txtCarrera);
            this.Controls.Add(this.btnImprimirExamen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUniversidad);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUnidades);
            this.Controls.Add(this.rtbExamen);
            this.Controls.Add(this.cmbAsignatura);
            this.Controls.Add(this.btnGestionarExamen);
            this.Name = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGestionarExamen;
        private System.Windows.Forms.ComboBox cmbAsignatura;
        private System.Windows.Forms.RichTextBox rtbExamen;
        private System.Windows.Forms.TextBox txtUnidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUniversidad;
        private System.Windows.Forms.Button btnImprimirExamen;
        private System.Windows.Forms.Label lblcarrera;
        private System.Windows.Forms.TextBox txtCarrera;
    }
}