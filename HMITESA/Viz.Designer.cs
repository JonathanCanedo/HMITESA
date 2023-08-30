namespace HMITESA
{
    partial class Viz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viz));
            this.dGHis = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGInc = new System.Windows.Forms.DataGridView();
            this.Nombr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGTras = new System.Windows.Forms.DataGridView();
            this.F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.iconMin = new System.Windows.Forms.PictureBox();
            this.iconCerrar = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ExInc = new System.Windows.Forms.Button();
            this.ExTrans = new System.Windows.Forms.Button();
            this.ExHis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGHis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGInc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGTras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // dGHis
            // 
            this.dGHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGHis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Matricula,
            this.PE,
            this.Diag,
            this.Fecha});
            this.dGHis.Location = new System.Drawing.Point(15, 75);
            this.dGHis.Name = "dGHis";
            this.dGHis.Size = new System.Drawing.Size(629, 263);
            this.dGHis.TabIndex = 0;
            this.dGHis.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Matricula
            // 
            this.Matricula.HeaderText = "Matricula";
            this.Matricula.Name = "Matricula";
            // 
            // PE
            // 
            this.PE.HeaderText = "PE";
            this.PE.Name = "PE";
            // 
            // Diag
            // 
            this.Diag.HeaderText = "Diag";
            this.Diag.Name = "Diag";
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // dGInc
            // 
            this.dGInc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGInc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombr,
            this.Matricul,
            this.PrE,
            this.Diagn,
            this.Fech});
            this.dGInc.Location = new System.Drawing.Point(15, 75);
            this.dGInc.Name = "dGInc";
            this.dGInc.Size = new System.Drawing.Size(629, 263);
            this.dGInc.TabIndex = 0;
            this.dGInc.Visible = false;
            // 
            // Nombr
            // 
            this.Nombr.HeaderText = "Nombre";
            this.Nombr.Name = "Nombr";
            // 
            // Matricul
            // 
            this.Matricul.HeaderText = "Matricula";
            this.Matricul.Name = "Matricul";
            // 
            // PrE
            // 
            this.PrE.HeaderText = "PE";
            this.PrE.Name = "PrE";
            // 
            // Diagn
            // 
            this.Diagn.HeaderText = "Diag";
            this.Diagn.Name = "Diagn";
            // 
            // Fech
            // 
            this.Fech.HeaderText = "Fecha";
            this.Fech.Name = "Fech";
            // 
            // dGTras
            // 
            this.dGTras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGTras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F,
            this.N,
            this.M,
            this.Mo,
            this.R});
            this.dGTras.Location = new System.Drawing.Point(15, 75);
            this.dGTras.Name = "dGTras";
            this.dGTras.Size = new System.Drawing.Size(629, 263);
            this.dGTras.TabIndex = 0;
            this.dGTras.Visible = false;
            // 
            // F
            // 
            this.F.HeaderText = "Fecha";
            this.F.Name = "F";
            // 
            // N
            // 
            this.N.HeaderText = "Nombre";
            this.N.Name = "N";
            // 
            // M
            // 
            this.M.HeaderText = "Matricula";
            this.M.Name = "M";
            // 
            // Mo
            // 
            this.Mo.HeaderText = "Motivo";
            this.Mo.Name = "Mo";
            // 
            // R
            // 
            this.R.HeaderText = "Retiro";
            this.R.Name = "R";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Historial",
            "Incapacidad",
            "Traslado"});
            this.comboBox1.Location = new System.Drawing.Point(283, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(487, 38);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(75, 23);
            this.btnVer.TabIndex = 2;
            this.btnVer.Text = "Visualizar";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(569, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(50, 10);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkCyan;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(5, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 23);
            this.label7.TabIndex = 29;
            this.label7.Text = "Visualizar";
            // 
            // iconMin
            // 
            this.iconMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMin.BackColor = System.Drawing.Color.DarkCyan;
            this.iconMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconMin.Image = global::HMITESA.Properties.Resources.mi;
            this.iconMin.Location = new System.Drawing.Point(607, 5);
            this.iconMin.Name = "iconMin";
            this.iconMin.Size = new System.Drawing.Size(18, 20);
            this.iconMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconMin.TabIndex = 28;
            this.iconMin.TabStop = false;
            this.iconMin.Click += new System.EventHandler(this.iconMin_Click);
            // 
            // iconCerrar
            // 
            this.iconCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconCerrar.BackColor = System.Drawing.Color.DarkCyan;
            this.iconCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconCerrar.Image = global::HMITESA.Properties.Resources.ce;
            this.iconCerrar.Location = new System.Drawing.Point(631, 5);
            this.iconCerrar.Name = "iconCerrar";
            this.iconCerrar.Size = new System.Drawing.Size(18, 20);
            this.iconCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconCerrar.TabIndex = 27;
            this.iconCerrar.TabStop = false;
            this.iconCerrar.Click += new System.EventHandler(this.iconCerrar_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkCyan;
            this.label8.ForeColor = System.Drawing.Color.LightGray;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(656, 31);
            this.label8.TabIndex = 26;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label8_MouseMove);
            // 
            // ExInc
            // 
            this.ExInc.Location = new System.Drawing.Point(202, 40);
            this.ExInc.Name = "ExInc";
            this.ExInc.Size = new System.Drawing.Size(75, 23);
            this.ExInc.TabIndex = 30;
            this.ExInc.Text = "Exportar";
            this.ExInc.UseVisualStyleBackColor = true;
            this.ExInc.Click += new System.EventHandler(this.ExInc_Click);
            // 
            // ExTrans
            // 
            this.ExTrans.Location = new System.Drawing.Point(202, 40);
            this.ExTrans.Name = "ExTrans";
            this.ExTrans.Size = new System.Drawing.Size(75, 23);
            this.ExTrans.TabIndex = 30;
            this.ExTrans.Text = "Exportar";
            this.ExTrans.UseVisualStyleBackColor = true;
            this.ExTrans.Click += new System.EventHandler(this.ExTrans_Click);
            // 
            // ExHis
            // 
            this.ExHis.Location = new System.Drawing.Point(202, 40);
            this.ExHis.Name = "ExHis";
            this.ExHis.Size = new System.Drawing.Size(75, 23);
            this.ExHis.TabIndex = 30;
            this.ExHis.Text = "Exportar";
            this.ExHis.UseVisualStyleBackColor = true;
            this.ExHis.Click += new System.EventHandler(this.ExHis_Click);
            // 
            // Viz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 350);
            this.Controls.Add(this.ExHis);
            this.Controls.Add(this.ExTrans);
            this.Controls.Add(this.ExInc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.iconMin);
            this.Controls.Add(this.iconCerrar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dGTras);
            this.Controls.Add(this.dGHis);
            this.Controls.Add(this.dGInc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Viz";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Viz_FormClosing);
            this.Load += new System.EventHandler(this.Viz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGHis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGInc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGTras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGHis;
        private System.Windows.Forms.DataGridView dGInc;
        private System.Windows.Forms.DataGridView dGTras;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn PE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricul;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diagn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fech;
        private System.Windows.Forms.DataGridViewTextBoxColumn F;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn M;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mo;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox iconMin;
        private System.Windows.Forms.PictureBox iconCerrar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ExInc;
        private System.Windows.Forms.Button ExTrans;
        private System.Windows.Forms.Button ExHis;
    }
}