namespace CasoWow.AppVisual
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lstColaPrioritaria = new ListBox();
            lstColaRegular = new ListBox();
            lstHistorial = new ListBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtNombre = new TextBox();
            txtAsignatura = new TextBox();
            radPrioritaria = new RadioButton();
            radRegular = new RadioButton();
            btnRegistrar = new Button();
            btnAtender = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(8, 91);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre             :";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(8, 120);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 1;
            label2.Text = "Asignatura          : ";
            label2.TextAlign = ContentAlignment.TopCenter;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(8, 151);
            label3.Name = "label3";
            label3.Size = new Size(106, 29);
            label3.TabIndex = 2;
            label3.Text = "Tipo de Solicitud:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstColaPrioritaria
            // 
            lstColaPrioritaria.FormattingEnabled = true;
            lstColaPrioritaria.ItemHeight = 15;
            lstColaPrioritaria.Items.AddRange(new object[] { "..." });
            lstColaPrioritaria.Location = new Point(22, 230);
            lstColaPrioritaria.Name = "lstColaPrioritaria";
            lstColaPrioritaria.Size = new Size(238, 94);
            lstColaPrioritaria.TabIndex = 3;
            lstColaPrioritaria.SelectedIndexChanged += lstColaPrioritaria_SelectedIndexChanged;
            // 
            // lstColaRegular
            // 
            lstColaRegular.FormattingEnabled = true;
            lstColaRegular.ItemHeight = 15;
            lstColaRegular.Items.AddRange(new object[] { "..." });
            lstColaRegular.Location = new Point(22, 352);
            lstColaRegular.Name = "lstColaRegular";
            lstColaRegular.Size = new Size(238, 94);
            lstColaRegular.TabIndex = 4;
            // 
            // lstHistorial
            // 
            lstHistorial.FormattingEnabled = true;
            lstHistorial.ItemHeight = 15;
            lstHistorial.Items.AddRange(new object[] { "..." });
            lstHistorial.Location = new Point(397, 90);
            lstHistorial.Name = "lstHistorial";
            lstHistorial.Size = new Size(254, 364);
            lstHistorial.TabIndex = 5;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(22, 212);
            label4.Name = "label4";
            label4.Size = new Size(238, 15);
            label4.TabIndex = 6;
            label4.Text = "Cola Prioritaria";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(21, 334);
            label5.Name = "label5";
            label5.Size = new Size(239, 15);
            label5.TabIndex = 7;
            label5.Text = "Cola Regular";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(397, 67);
            label6.Name = "label6";
            label6.Size = new Size(254, 17);
            label6.TabIndex = 8;
            label6.Text = "Historial de Atendidos";
            label6.TextAlign = ContentAlignment.TopCenter;
            label6.Click += label6_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 88);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(140, 23);
            txtNombre.TabIndex = 9;
            // 
            // txtAsignatura
            // 
            txtAsignatura.Location = new Point(120, 117);
            txtAsignatura.Name = "txtAsignatura";
            txtAsignatura.Size = new Size(140, 23);
            txtAsignatura.TabIndex = 10;
            // 
            // radPrioritaria
            // 
            radPrioritaria.AutoSize = true;
            radPrioritaria.BackColor = Color.Transparent;
            radPrioritaria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            radPrioritaria.Location = new Point(120, 148);
            radPrioritaria.Name = "radPrioritaria";
            radPrioritaria.Size = new Size(80, 19);
            radPrioritaria.TabIndex = 11;
            radPrioritaria.TabStop = true;
            radPrioritaria.Text = "Prioritaria";
            radPrioritaria.UseVisualStyleBackColor = false;
            // 
            // radRegular
            // 
            radRegular.AutoSize = true;
            radRegular.BackColor = Color.Transparent;
            radRegular.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            radRegular.Location = new Point(120, 171);
            radRegular.Name = "radRegular";
            radRegular.Size = new Size(68, 19);
            radRegular.TabIndex = 12;
            radRegular.TabStop = true;
            radRegular.Text = "Regular";
            radRegular.UseVisualStyleBackColor = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(148, 0, 255);
            btnRegistrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = SystemColors.ButtonHighlight;
            btnRegistrar.Location = new Point(266, 81);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(104, 109);
            btnRegistrar.TabIndex = 13;
            btnRegistrar.Text = "Registrar Estudiante";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnAtender
            // 
            btnAtender.BackColor = Color.FromArgb(148, 0, 255);
            btnAtender.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAtender.ForeColor = SystemColors.ButtonHighlight;
            btnAtender.Location = new Point(266, 224);
            btnAtender.Name = "btnAtender";
            btnAtender.Size = new Size(104, 234);
            btnAtender.TabIndex = 14;
            btnAtender.Text = "Atender Siguiente";
            btnAtender.UseVisualStyleBackColor = false;
            btnAtender.Click += btnAtender_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(54, 63);
            label7.Name = "label7";
            label7.Size = new Size(167, 21);
            label7.TabIndex = 15;
            label7.Text = "Datos del Estudiante";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Sans Serif Collection", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(51, -7);
            label8.Name = "label8";
            label8.Size = new Size(667, 82);
            label8.TabIndex = 16;
            label8.Text = "SISTEMA DE CONTROL DE ATENCIONES";
            label8.TextAlign = ContentAlignment.TopCenter;
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 190);
            label9.Name = "label9";
            label9.Size = new Size(337, 15);
            label9.TabIndex = 17;
            label9.Text = "__________________________________________________________________";
            label9.Click += label9_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 63);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 184, 24);
            ClientSize = new Size(673, 464);
            Controls.Add(pictureBox1);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(btnAtender);
            Controls.Add(btnRegistrar);
            Controls.Add(radRegular);
            Controls.Add(radPrioritaria);
            Controls.Add(txtAsignatura);
            Controls.Add(txtNombre);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lstHistorial);
            Controls.Add(lstColaRegular);
            Controls.Add(lstColaPrioritaria);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label8);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox lstColaPrioritaria;
        private ListBox lstColaRegular;
        private ListBox lstHistorial;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtNombre;
        private TextBox txtAsignatura;
        private RadioButton radPrioritaria;
        private RadioButton radRegular;
        private Button btnRegistrar;
        private Button btnAtender;
        private Label label7;
        private Label label8;
        private Label label9;
        private PictureBox pictureBox1;
    }
}