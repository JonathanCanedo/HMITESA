using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMITESA{
    public partial class HC : Form{
        string genero = "",tabaquismo="",alcoholismo="",drog="",Trauma="",Quirur="",Hosp="",Trans="",Al="",Enfer="";
        public HC(){
            InitializeComponent();
        }
        private void pictureBox4_Click(object sender, EventArgs e){
            this.Dispose();
            Principal pr = new Principal();
            pr.Show();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e){
            txtM.Text = "";
            txtDo.Text = "";
            txtCiclo.Text = "";
            txtGe.Text = "";
            txtIVSA.Text = "";
            txtPa.Text = "";
            txtNPS.Text = "";
            txtCe.Text = "";
            txtMPF.Text = "";
            txtAb.Text = "";
            groupBox13.Enabled = true;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e){
            txtM.Text = "N/A";
            txtDo.Text = "N/A";
            txtCiclo.Text = "N/A";
            txtGe.Text = "N/A";
            txtIVSA.Text = "N/A";
            txtPa.Text = "N/A";
            txtNPS.Text = "N/A";
            txtCe.Text = "N/A";
            txtMPF.Text = "N/A";
            txtAb.Text = "N/A";
            groupBox13.Enabled = false;
        }
        private void pictureBox3_Click(object sender, EventArgs e){
            nuevo();
            textBox1.Focus();
        }
        private void radioButton14_CheckedChanged(object sender, EventArgs e){
            txtEnf.Text = "";
            txtTrat.Text = "";
            groupBox15.Enabled = true;
            txtEnf.Focus();
        }
        private void radioButton17_CheckedChanged(object sender, EventArgs e){            
            txtEnf.Text = "N/A";
            txtTrat.Text = "N/A";
            groupBox15.Enabled = false;
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e){
            label3.Enabled = true;
            txtCantC.Enabled = true;
            txtCantC.Text = "";
            txtCantC.Focus();
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e){
            label3.Enabled = false;
            txtCantC.Enabled = false;
            txtCantC.Text = "N/A";
            radioButton19.Focus();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e){
            txtTra.Enabled = true;
            txtTra.Text = "";
            txtTra.Focus();
        }
        private void radioButton15_CheckedChanged(object sender, EventArgs e){
            txtTra.Enabled = false;
            txtTra.Text = "N/A";
            radioButton4.Focus();
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e){
            txtHosp.Enabled = true;
            txtHosp.Text = "";
            txtHosp.Focus();
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e){
            txtHosp.Enabled = false;
            txtHosp.Text = "N/A";
            radioButton11.Focus();
        }
        private void radioButton11_CheckedChanged(object sender, EventArgs e){
            txtTrans.Enabled = true;
            txtTrans.Text = "";
            txtTrans.Focus();
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e){
            txtTrans.Enabled = false;
            txtTrans.Text = "N/A";
            radioButton12.Focus();
        }
        private void radioButton13_CheckedChanged(object sender, EventArgs e){
            radioButton14.Focus();
        }
        private void HC_Load(object sender, EventArgs e){
            txtLyF.Text = DateTime.Today.ToString("dd MMMM yyyy");
            nuevo();
            textBox1.Focus();
        }
        private void pictureBox5_Click(object sender, EventArgs e){
            this.BackColor = Color.White;
            foreach (Control c in this.Controls){
                if (c is Panel) { c.BackColor = Color.White; }
                if (c is Button) { c.Visible = false; }
            }
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
            Graphics g = this.CreateGraphics();
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            Image Img = (Image)bmp;
            this.BackColor = Color.White;
            foreach (Control c in this.Controls){
                if (c is Panel) { c.BackColor = Panel.DefaultBackColor; }
                if (c is Button) { c.Visible = true; }
            }
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.PrintPage += (a, b) => { b.Graphics.DrawImage(Img, 50, 50); };
            printDocument1.Print();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsDigit(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
        private void txtCantC_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsDigit(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
        private void txtE_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsDigit(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
        private void HC_FormClosing(object sender, FormClosingEventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea cerrar la aplicación ?\nGuarde cambios o perderá sus avances.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                Environment.Exit(0);
            }else {
                switch (e.CloseReason){
                    case CloseReason.UserClosing:
                        e.Cancel = true;
                        break;
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e){
            #region validar
            if (radioButton6.Checked == true && txtCantC.Text == ""){
                MessageBox.Show("Debe ingresar una cantidad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantC.Focus();
            }else if (radioButton3.Checked == true && txtTra.Text == ""){
                MessageBox.Show("Debe ingresar un antecedente traumático", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTra.Focus();
            }else if (radioButton5.Checked == true && txtHosp.Text == ""){
                MessageBox.Show("Debe ingresar una hospitalización previa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHosp.Focus();
            }else if (radioButton11.Checked == true && txtTrans.Text == ""){
                MessageBox.Show("Debe ingresar datos de Transfusión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrans.Focus();
            }else if (radioButton14.Checked == true && txtEnf.Text == "" && txtTrat.Text == "" || radioButton14.Checked == true && txtEnf.Text == "" || radioButton14.Checked == true && txtTrat.Text == ""){
                MessageBox.Show("Debe ingresar datos de Enfermedad y Tratamiento actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrans.Focus();
            }else if (textBox1.Text == "" || textBox2.Text == "" || txtNP.Text == "" || txtE.Text == "" || txtFN.Text == "" || txtCantC.Text == "" || txtTra.Text == "" || txtHosp.Text == "" || txtTrans.Text == "" || txtEnf.Text == "" || txtTrat.Text == "" || txtM.Text == "" || txtNPS.Text == "" || txtGe.Text == "" || txtCiclo.Text == "" || txtMPF.Text == "" || txtPa.Text == "" || txtIVSA.Text == "" || txtDo.Text == "" || txtCe.Text == "" || txtAb.Text == "" || txtPeso.Text == "" || txtTalla.Text == "" || txtGS.Text == "" || txtImD.Text == "" || txtLyF.Text == "" || txtNM.Text == ""){
                MessageBox.Show("No deje campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else{
                if (radioButton1.Checked == true){
                    genero = "Masculino";
                }else if (radioButton2.Checked == true){
                    genero = "Femenino";
                }
                if (radioButton6.Checked == true){
                    tabaquismo = "Sí";
                }else if (radioButton7.Checked == true){
                    tabaquismo = "No";
                }
                if (radioButton19.Checked == true){
                    alcoholismo = "Sí";
                }else if (radioButton27.Checked == true){
                    alcoholismo = "No";
                }else if (radioButton30.Checked == true){
                    alcoholismo = "Ocasional";
                }
                if (radioButton34.Checked == true){
                    drog = "Sí";
                }else if (radioButton37.Checked == true){
                    drog = "No";
                }else if (radioButton40.Checked == true){
                    drog = "Ocasional";
                }
                if (radioButton3.Checked == true){
                    Trauma = "Sí";
                }else if (radioButton15.Checked == true){
                    Trauma = "No";
                }
                if (radioButton4.Checked == true){
                    Quirur = "Sí";
                }else if (radioButton16.Checked == true){
                    Quirur = "No";
                }
                if (radioButton5.Checked == true){
                    Hosp = "Sí";
                }else if (radioButton9.Checked == true){
                    Hosp = "No";
                }
                if (radioButton11.Checked == true){
                    Trans = "Sí";
                }else if (radioButton10.Checked == true){
                    Trans = "No";
                }
                if (radioButton12.Checked == true){
                    Al = "Sí";
                }else if (radioButton13.Checked == true){
                    Al = "No";
                }
                if (radioButton14.Checked == true){
                    Enfer = "Sí";
                }else if (radioButton17.Checked == true){
                    Enfer = "No";
                }
                #endregion
                try{
                    MySqlCommand cmd;
                    MySqlConnection Con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
                    string consul = "INSERT INTO datos(NombrePaciente,Edad,Sexo,FechaNacimiento,Tabaquismo,CantCigarros,Alcoholismo,Drogadiccion,traumaticos,CualTraumat,Quirurgico,Hospitalizaciones,DetalleHospital,transfuciones,DetalleTransf,Alergicos,Enfermedad,DetalleEnfermed,tratamiento,Menarca,CicloMenst,IVSA,NPS,MPF,DoCaCu,Gestas,Partos,Cesareas,Abortos,peso,Talla,GrupoSang,ImpDiag,Lugaryfecha,NombreMedico)values(@NombrePaciente,@Edad,@Sexo,@FechaNacimiento,@Tabaquismo,@CantCigarros,@Alcoholismo,@Drogadiccion,@traumaticos,@CualTraumat,@Quirurgico,@Hospitalizaciones,@DetalleHospital,@transfuciones,@DetalleTransf,@Alergicos,@Enfermedad,@DetalleEnfermed,@tratamiento,@Menarca,@CicloMenst,@IVSA,@NPS,@MPF,@DoCaCu,@Gestas,@Partos,@Cesareas,@Abortos,@peso,@Talla,@GrupoSang,@ImpDiag,@Lugaryfecha,@NombreMedico)";
                    cmd = new MySqlCommand(consul, Con);
                    #region Datos
                    cmd.Parameters.AddWithValue("@NombrePaciente",txtNP.Text);
                    cmd.Parameters.AddWithValue("@Edad", txtE.Text);
                    cmd.Parameters.AddWithValue("@Sexo", genero);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", txtFN.Text);
                    cmd.Parameters.AddWithValue("@Tabaquismo", tabaquismo);
                    cmd.Parameters.AddWithValue("@CantCigarros", txtCantC.Text);
                    cmd.Parameters.AddWithValue("@Alcoholismo", alcoholismo);
                    cmd.Parameters.AddWithValue("@Drogadiccion", drog);
                    cmd.Parameters.AddWithValue("@traumaticos", Trauma);
                    cmd.Parameters.AddWithValue("@CualTraumat", txtTra.Text);
                    cmd.Parameters.AddWithValue("@Quirurgico", Quirur);
                    cmd.Parameters.AddWithValue("@Hospitalizaciones", Hosp);
                    cmd.Parameters.AddWithValue("@DetalleHospital", txtHosp.Text);
                    cmd.Parameters.AddWithValue("@transfuciones", Trans);
                    cmd.Parameters.AddWithValue("@DetalleTransf", txtTrans.Text);
                    cmd.Parameters.AddWithValue("@Alergicos", Al);
                    cmd.Parameters.AddWithValue("@Enfermedad", Enfer);
                    cmd.Parameters.AddWithValue("@DetalleEnfermed", txtEnf.Text);
                    cmd.Parameters.AddWithValue("@tratamiento", txtTrat.Text);                    
                    cmd.Parameters.AddWithValue("@Menarca", txtM.Text);
                    cmd.Parameters.AddWithValue("@CicloMenst", txtCiclo.Text);
                    cmd.Parameters.AddWithValue("@IVSA", txtIVSA.Text);
                    cmd.Parameters.AddWithValue("@NPS", txtNPS.Text);
                    cmd.Parameters.AddWithValue("@MPF", txtMPF.Text);
                    cmd.Parameters.AddWithValue("@DoCaCu", txtDo.Text);
                    cmd.Parameters.AddWithValue("@Gestas", txtGe.Text);
                    cmd.Parameters.AddWithValue("@Partos", txtPa.Text);
                    cmd.Parameters.AddWithValue("@Cesareas", txtCe.Text);
                    cmd.Parameters.AddWithValue("@Abortos", txtAb.Text);
                    cmd.Parameters.AddWithValue("@peso", txtPeso.Text);
                    cmd.Parameters.AddWithValue("@Talla", txtTalla.Text);
                    cmd.Parameters.AddWithValue("@GrupoSang", txtGS.Text);
                    cmd.Parameters.AddWithValue("@ImpDiag", txtImD.Text);
                    cmd.Parameters.AddWithValue("@Lugaryfecha", txtLyF.Text);
                    cmd.Parameters.AddWithValue("@NombreMedico", txtNM.Text);
                    #endregion
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Se guardó con exito","Notificación",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    nuevo();
                    textBox1.Focus();
                }catch (Exception ex){
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void txtGe_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsDigit(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
        private void txtPa_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsDigit(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
        private void txtCe_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsDigit(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
        private void txtAb_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsDigit(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
        public void nuevo(){
            textBox1.Text = "";
            textBox2.Text = "";
            txtNP.Text = "";
            txtE.Text = "";
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            txtFN.Text = "";
            radioButton6.Checked = true;
            radioButton7.Checked = false;
            txtCantC.Text = "";
            radioButton19.Checked = true;
            radioButton27.Checked = false;
            radioButton30.Checked = false;
            radioButton34.Checked = true;
            radioButton37.Checked = false;
            radioButton40.Checked = false;
            radioButton3.Checked = true;
            radioButton15.Checked = false;
            radioButton4.Checked = true;
            radioButton16.Checked = false;
            radioButton5.Checked = true;
            radioButton9.Checked = false;
            radioButton11.Checked = true;
            radioButton10.Checked = false;
            radioButton12.Checked = true;
            radioButton13.Checked = false;
            radioButton14.Checked = true;
            radioButton17.Checked = false;
            txtTra.Text = "";
            txtHosp.Text = "";
            txtTrans.Text = "";
            txtEnf.Text = "";
            txtTrat.Text = "";
            txtM.Text = "N/A";
            txtDo.Text = "N/A";
            txtCiclo.Text = "N/A";
            txtGe.Text = "N/A";
            txtIVSA.Text = "N/A";
            txtPa.Text = "N/A";
            txtNPS.Text = "N/A";
            txtCe.Text = "N/A";
            txtMPF.Text = "N/A";
            txtAb.Text = "N/A";
            txtPeso.Text = "";
            txtTalla.Text = "";
            txtGS.Text = "";
            txtImD.Text = "";
            txtNM.Text = "";
        }
    }
}