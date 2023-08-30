using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace HMITESA {
    public partial class Serv : Form {
        public int xClick = 0, yClick = 0;
        string genero = "", tabaquismo = "", alcoholismo = "", drog = "", Trauma = "", Quirur = "", Hosp = "", Trans = "", Al = "", Enfer = "";
        public Serv(){
            InitializeComponent();
        }
        #region radios
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
        private void radioButton15_CheckedChanged(object sender, EventArgs e){
            txtTra.Enabled = false;
            txtTra.Text = "N/A";
            radioButton4.Focus();
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            txtHosp.Enabled = true;
            txtHosp.Text = "";
            txtHosp.Focus();
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            txtHosp.Enabled = false;
            txtHosp.Text = "N/A";
            radioButton11.Focus();
        }
        private void radioButton11_CheckedChanged(object sender, EventArgs e){
            txtTrans.Enabled = true;
            txtTrans.Text = "";
            txtTrans.Focus();
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            txtTrans.Enabled = false;
            txtTrans.Text = "N/A";
            radioButton12.Focus();
        }
        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            radioButton14.Focus();
        }
        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            txtEnf.Text = "";
            txtTrat.Text = "";
            groupBox15.Enabled = true;
            txtEnf.Focus();
        }
        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            txtEnf.Text = "N/A";
            txtTrat.Text = "N/A";
            groupBox15.Enabled = false;
        }
        private void pictureBox12_Click(object sender, EventArgs e){
            nuevo();
            panel1.Visible = false;
            cero();
            pictureBox26.Visible = true;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e){
            txtTra.Enabled = true;
            txtTra.Text = "";
            txtTra.Focus();
        }
        #endregion
        private void label8_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
        private void iconMin_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void iconCerrar_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea regresar a la pantalla de Servicio Médico ?\nGuarde cambios o perderá sus avances.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                this.Hide();
                Principal pr = new Principal();
                pr.label1.Text = this.label11.Text;
                pr.Show();
            }else { }
        }
        private void pictureBox7_Click(object sender, EventArgs e){
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            pictureBox7.Visible = false;
            pictureBox26.Visible = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e){
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            pictureBox7.Visible = true;
            pictureBox26.Visible = false;
        }
        private void pictureBox11_Click(object sender, EventArgs e){
            if (textBox1.Text != ""){
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar el registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes){
                    try{
                        MySqlCommand cmd;
                        MySqlConnection Con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
                        string consul = "DELETE FROM datos WHERE Matricula='" + textBox1.Text + "'";
                        cmd = new MySqlCommand(consul, Con);
                        Con.Open();
                        cmd.ExecuteNonQuery();
                        Con.Close();
                        MessageBox.Show("Se eliminó con exito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }catch (Exception){
                        MessageBox.Show("Error", "La matricula ingresada no existe");
                    }
                }else { }
            }else{
                MessageBox.Show("Debe ingresar una matricula para poder eliminar el registro");
                textBox1.Focus();
            }
        } // Cambiar cadena de conexion
        private void button1_Click(object sender, EventArgs e){
            if (!Existe(textBox1.Text)) {
                MessageBox.Show("La matrícula no existe\nIngrese una matrícula distinta ó Registrela en un historial", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox1.Focus();
            }else{
                llenar();
                hab();
            }
            
        }
        private void pictureBox13_Click(object sender, EventArgs e){
            nuevo();
            textBox1.Focus();
        }
        private void pictureBox15_Click(object sender, EventArgs e){
            val();
            if (!Existe(textBox1.Text)){
                try{
                    MySqlCommand cmd;
                    MySqlConnection Con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
                    DialogResult respuesta = MessageBox.Show("¿Desea guardar el registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes){
                        string consul = "INSERT INTO datos (NombrePaciente,Edad,Sexo,NSS,FechaNacimiento,Tabaquismo,CantCigarros,Alcoholismo,Drogadiccion,traumaticos,CualTraumat,Quirurgico,Hospitalizaciones,DetalleHospital,transfuciones,DetalleTransf,Alergicos,Enfermedad,DetalleEnfermed,tratamiento,Menarca,CicloMenst,IVSA,NPS,MPF,DoCaCu,Gestas,Partos,Cesareas,Abortos,peso,Talla,GrupoSang,ImpDiag,Matricula,PE,Lugaryfecha,NombreMedico)values(@NombrePaciente,@Edad,@Sexo,@NSS,@FechaNacimiento,@Tabaquismo,@CantCigarros,@Alcoholismo,@Drogadiccion,@traumaticos,@CualTraumat,@Quirurgico,@Hospitalizaciones,@DetalleHospital,@transfuciones,@DetalleTransf,@Alergicos,@Enfermedad,@DetalleEnfermed,@tratamiento,@Menarca,@CicloMenst,@IVSA,@NPS,@MPF,@DoCaCu,@Gestas,@Partos,@Cesareas,@Abortos,@peso,@Talla,@GrupoSang,@ImpDiag,@Matricula,@PE,@Lugaryfecha,@NombreMedico)";
                        cmd = new MySqlCommand(consul, Con);
                        #region Datos                        
                        cmd.Parameters.AddWithValue("@NombrePaciente", txtNP.Text);//1
                        cmd.Parameters.AddWithValue("@Edad", txtE.Text);
                        cmd.Parameters.AddWithValue("@Sexo", genero);
                        cmd.Parameters.AddWithValue("@NSS", txtNSS.Text);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", cal.Text);
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
                        cmd.Parameters.AddWithValue("@ImpDiag", txtImD.Text);//4
                        cmd.Parameters.AddWithValue("@Matricula", textBox1.Text);
                        cmd.Parameters.AddWithValue("@PE", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@Lugaryfecha", txtLyF.Text);//5
                        cmd.Parameters.AddWithValue("@NombreMedico", txtNM.Text);
                        #endregion
                        Con.Open();
                        cmd.ExecuteNonQuery();
                        Con.Close();
                        MessageBox.Show("Se guardó con exito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else { }
                }catch (Exception ex){
                    MessageBox.Show("Error: " + ex.Message);
                }
            }else{
                try{
                    MySqlCommand cmd;
                    MySqlConnection Con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
                    DialogResult respuesta = MessageBox.Show("¿Desea actualizar el registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes){
                        string consul = "UPDATE datos SET NombrePaciente=@NombrePaciente,Edad=@Edad,Sexo=@Sexo,NSS=@NSS,FechaNacimiento=@FechaNacimiento,Tabaquismo=@Tabaquismo,CantCigarros=@CantCigarros,Alcoholismo=@Alcoholismo,Drogadiccion=@Drogadiccion,traumaticos=@traumaticos,CualTraumat=@CualTraumat,Quirurgico=@Quirurgico,Hospitalizaciones=@Hospitalizaciones,DetalleHospital=@DetalleHospital,transfuciones=@transfuciones,DetalleTransf=@DetalleTransf,Alergicos=@Alergicos,Enfermedad=@Enfermedad,DetalleEnfermed=@DetalleEnfermed,tratamiento=@tratamiento,Menarca=@Menarca,CicloMenst=@CicloMenst,IVSA=@IVSA,NPS=@NPS,MPF=@MPF,DoCaCu=@DoCaCu,Gestas=@Gestas,Partos=@Partos,Cesareas=@Cesareas,Abortos=@Abortos,peso=@peso,Talla=@Talla,GrupoSang=@GrupoSang,ImpDiag=@ImpDiag,Matricula=@Matricula,PE=@PE,Lugaryfecha=@Lugaryfecha,NombreMedico=@NombreMedico WHERE Matricula = '" + textBox1.Text + "'";
                        cmd = new MySqlCommand(consul, Con);
                        #region Datos
                        cmd.Parameters.AddWithValue("@NombrePaciente", txtNP.Text);//1
                        cmd.Parameters.AddWithValue("@Edad", txtE.Text);
                        cmd.Parameters.AddWithValue("@Sexo", genero);
                        cmd.Parameters.AddWithValue("@NSS", txtNSS.Text);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", cal.Text);
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
                        cmd.Parameters.AddWithValue("@ImpDiag", txtImD.Text);//4
                        cmd.Parameters.AddWithValue("@Matricula", textBox1.Text);
                        cmd.Parameters.AddWithValue("@PE", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@Lugaryfecha", txtLyF.Text);//5
                        cmd.Parameters.AddWithValue("@NombreMedico", txtNM.Text);
                        #endregion
                        Con.Open();
                        cmd.ExecuteNonQuery();
                        Con.Close();
                        MessageBox.Show("Se actualizó con exito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else { }
                }catch (Exception ex){
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        } // Cambiar cadena
        private void pictureBox14_Click(object sender, EventArgs e){
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            this.BackColor = Color.White;
            foreach (Control c in this.Controls)
            {
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
            foreach (Control c in this.Controls)
            {
                if (c is Panel) { c.BackColor = Panel.DefaultBackColor; }
                if (c is Button) { c.Visible = true; }
            }
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.PrintPage += (a, b) => { b.Graphics.DrawImage(Img, 50, 50); };
            printDocument1.Print();
            pictureBox10.Visible = true;
            pictureBox11.Visible = true;
            pictureBox12.Visible = true;
            pictureBox13.Visible = true;
            pictureBox14.Visible = true;
            pictureBox15.Visible = true;
        }
        private void pictureBox10_Click(object sender, EventArgs e){
            lblPara.Visible = true;
            txtPara.Visible = true;
        }
        #region keypress
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsDigit(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
        private void txtCantC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtGe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtPa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtCe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtAb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtPara_KeyPress(object sender, KeyPressEventArgs e){
            #region enviar
            if (e.KeyChar == (char)Keys.Enter){
                val();
                string a = ("Nombre del paciente: " + txtNP.Text + "Edad: " + txtE.Text + " años  Sexo: " + genero +"\nNo. Seguro Social"+ txtNSS.Text+"Fecha de nacimiento: " + cal.Text + "\nAntecedentes personales no patológicos\nTabaquismo: " + tabaquismo + " Cantidad de cigarros al día: " + txtCantC.Text + "\nAlcoholismo: " + alcoholismo + "\nDrogadicción: " + drog + "\nAntecedentes personales patológicos\nTraumaticos: " + Trauma + " Detalles: " + txtTra.Text + "\nQuirúrgicos: " + Quirur + "\nHospitalizaciones previas: " + Hosp + " detalles: " + txtHosp.Text + "\nTransfusionales: " + Trans + " detalles: " + txtTrans.Text + "\nAlérgicos: " + Al + "\nEnfermedad que padece: " + Enfer + " detalles: " + txtEnf.Text + " Tratamiento actual: " + txtTrat.Text + "\nAntecedentes gineco-obstétricos\nMenarca: " + txtM.Text + " NPS: " + txtNPS.Text + " Gestas: " + txtGe.Text + "\nCiclo menstrual: " + txtCiclo.Text + " MPF: " + txtMPF.Text + " Partos: " + txtPa.Text + "\nIVSA: " + txtIVSA.Text + " DoCaCu: " + txtDo.Text + " Cesáreas: " + txtCe.Text + "\nAbortos: " + txtAb.Text + "\nDatos antropométricos y signos vitales\nPeso: " + txtPeso.Text + " Grupo sanguíneo: " + txtGS.Text + "\nTalla: " + txtTalla.Text + "\nImpresión Diagnóstica\n" + txtImD.Text + "Matrícula: " + textBox1.Text + "  Programa Educativo: " + comboBox2.Text + "\nLugar y fecha: " + txtLyF.Text + " Nombre del médico: " + txtNM.Text);
                DialogResult res = MessageBox.Show("¿ Realmente desea enviar el correo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes){
                    //Desde aquí
                    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                    msg.To.Add(txtPara.Text);//Para quien
                    msg.Subject = "Historial medico del alumno: " + txtNP.Text;//Asunto
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;

                    msg.Body = a;//msj
                    msg.BodyEncoding = System.Text.Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    msg.From = new System.Net.Mail.MailAddress("servicio_medico@itesa.edu.mx");//Quien lo envia

                    System.Net.Mail.SmtpClient cl = new System.Net.Mail.SmtpClient();
                    cl.Credentials = new System.Net.NetworkCredential("servicio_medico@itesa.edu.mx", "ITESANELYDA123"); //usuario y contraseña

                    cl.Port = 587;
                    cl.EnableSsl = true;

                    cl.Host = "smtp.gmail.com"; //Dominio

                    try{
                        cl.Send(msg);
                        MessageBox.Show("Mensaje enviado");
                        txtPara.Text = "";
                        lblPara.Visible = false;
                        txtPara.Visible = false;
                    }catch (Exception ex){
                        MessageBox.Show("Error al enviar" + ex);
                    }
                }else { }
            }else { }
            #endregion
        }
        #endregion
        private void pictureBox2_Click(object sender, EventArgs e){
            groupBox7.Visible = true;
            pictureBox6.Visible = false;
            pictureBox8.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            comboBox1.SelectedIndex = 0;
            pictureBox26.Visible = false;
        }
        private void pictureBox3_Click(object sender, EventArgs e){
            panel1.Visible = false;
            panel4.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            pictureBox26.Visible = false;
        } // Tras
        private void pictureBox18_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea guardar la incapacidad ?\nYa no podrá editar datos despúes de guardarlos", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                if (textBox3.Text == ""){
                    MessageBox.Show("Debe ingresar el correo electronico a quien le enviará la incapacidad del alumno", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                }if (textBox11.Text == "" || textBox9.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == ""){
                    MessageBox.Show("No debe dejar campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else{
                    textBox6.Text = textBox8.Text;
                    try{
                        MySqlCommand cmd;
                        MySqlConnection Con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
                        string consul = "INSERT INTO incapacidad (destino,area,alumno,matricula,diagnostico,indic,medico,fecha)values(@destino,@area,@alumno,@matricula,@diagnostico,@indic,@medico,@fecha)";
                        cmd = new MySqlCommand(consul, Con);
                        #region Datos
                        cmd.Parameters.AddWithValue("@destino", textBox11.Text);
                        cmd.Parameters.AddWithValue("@area", comboBox1.Text);//PrE 3
                        cmd.Parameters.AddWithValue("@alumno", textBox9.Text);//Nom 1
                        cmd.Parameters.AddWithValue("@matricula", textBox4.Text);//Mat 2
                        cmd.Parameters.AddWithValue("@diagnostico", textBox5.Text);//Diagn 4
                        cmd.Parameters.AddWithValue("@indic", textBox7.Text);
                        cmd.Parameters.AddWithValue("@medico", textBox8.Text);
                        cmd.Parameters.AddWithValue("@fecha", lblFecha.Text);//Fech 5
                        #endregion
                        Con.Open();
                        cmd.ExecuteNonQuery();
                        Con.Close();
                    }catch (Exception ex){
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }else { }
        } // cambiar cadena de conexion
        private void pictureBox16_Click(object sender, EventArgs e){
            Limpiar();
            groupBox7.Visible = false;
            pictureBox6.Visible = true;
            pictureBox8.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            pictureBox26.Visible = true;
        }        
        private void pictureBox17_Click(object sender, EventArgs e){
            Limpiar();
        }
        private void pictureBox19_Click(object sender, EventArgs e){//textbox10 por cmbCarreras
            if (textBox3.Text != ""){
                DialogResult res = MessageBox.Show("¿ Realmente desea enviar el correo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes){
                    string a = (textBox11.Text + " " + label14.Text + " " + comboBox1.Text + " " + label73.Text + " " + label71.Text + " " + textBox9.Text + " " + label16.Text + " " + textBox4.Text + " " + label15.Text + " " + textBox5.Text + " " + label52.Text + " " + textBox7.Text + " " + label70.Text + " " + label69.Text + " " + label68.Text + " " + textBox6.Text + " " + label67.Text);
                    //Desde aquí
                    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                    msg.To.Add(textBox3.Text);//Para quien
                    msg.Subject = "Incapacidad";//Asunto
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;

                    msg.Body = a;//msj
                    msg.BodyEncoding = System.Text.Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    msg.From = new System.Net.Mail.MailAddress("servicio_medico@itesa.edu.mx");//Quien lo envia

                    System.Net.Mail.SmtpClient cl = new System.Net.Mail.SmtpClient();
                    cl.Credentials = new System.Net.NetworkCredential("servicio_medico@itesa.edu.mx", "ITESANELYDA123"); //usuario y contraseña

                    cl.Port = 587;
                    cl.EnableSsl = true;

                    cl.Host = "smtp.gmail.com"; //Dominio

                    try{
                        cl.Send(msg);
                        MessageBox.Show("Ok");
                        Limpiar();
                    }catch (Exception ex){
                        MessageBox.Show("Error al enviar" + ex);
                    }
                }else { }
            }else{
                MessageBox.Show("Debe ingresar una dirección de correo al cual enviarlo ");
                txtPara.Focus();
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e){
            panel1.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            button1.Visible = false;
            pictureBox11.Visible = false;
            pictureBox1.Visible = false;
            label1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            comboBox2.SelectedIndex = 0;
            pictureBox26.Visible = false;
        }
        private void pictureBox5_Click(object sender, EventArgs e){
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            Inh();
            panel1.Visible = true;
            button1.Visible = true;
            pictureBox11.Visible = true;
            pictureBox1.Visible = false;
            label1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            comboBox2.SelectedIndex = 0;
            pictureBox26.Visible = false;
        }
        private void pictureBox22_Click(object sender, EventArgs e){
            Li();
            pictureBox7.Visible = false;
            panel1.Visible = false;
            panel4.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox8.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            pictureBox26.Visible = true;
        } // Reg
        private void pictureBox23_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea guardar la incapacidad ?\nYa no podrá editar datos despúes de guardarlos", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                if (txtN.Text == "" || txtMat.Text == "" || txtMo.Text == "" || txtRet.Text == ""){
                    MessageBox.Show("No debe dejar campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else{
                    try{
                        MySqlCommand cmd;
                        MySqlConnection Con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
                        string consul = "INSERT INTO tras (Fecha,Nombre,xMatricula,Motivo,Retiro)values(@Fecha,@Nombre,@Matricula,@Motivo,@Retiro)";
                        cmd = new MySqlCommand(consul, Con);
                        #region Datos
                        cmd.Parameters.AddWithValue("@Fecha", label74.Text);
                        cmd.Parameters.AddWithValue("@Nombre", txtN.Text);
                        cmd.Parameters.AddWithValue("@Matricula", txtMat.Text);
                        cmd.Parameters.AddWithValue("@Motivo", txtMo.Text);
                        cmd.Parameters.AddWithValue("@Retiro", txtRet.Text);
                        #endregion
                        Con.Open();
                        cmd.ExecuteNonQuery();
                        Con.Close();
                        MessageBox.Show("Se guardó con exito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }catch (Exception ex){
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        } // Cambiar cadena de conexion
        private void pictureBox24_Click(object sender, EventArgs e){
            if (txtN.Text == "" || txtMat.Text == "" || txtMo.Text == "" || txtRet.Text == ""){
                MessageBox.Show("No debe dejar campos vacios");
            }else{
                if (textBox12.Text != ""){
                    string a = "Fecha: " + lblFecha.Text + "  Nombre: " + txtN.Text + "\nMatrícula: " + txtMat.Text + "Motivo de consulta: " + txtMo.Text + " Amerita retiro: " + txtRet.Text;
                    DialogResult res = MessageBox.Show("¿ Realmente desea enviar el correo ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes){
                        //Desde aquí
                        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                        msg.To.Add(textBox12.Text);//Para quien
                        msg.Subject = "Traslado";//Asunto
                        msg.SubjectEncoding = System.Text.Encoding.UTF8;

                        msg.Body = a;//msj
                        msg.BodyEncoding = System.Text.Encoding.UTF8;
                        msg.IsBodyHtml = true;
                        msg.From = new System.Net.Mail.MailAddress("servicio_medico@itesa.edu.mx");//Quien lo envia

                        System.Net.Mail.SmtpClient cl = new System.Net.Mail.SmtpClient();
                        cl.Credentials = new System.Net.NetworkCredential("servicio_medico@itesa.edu.mx", "ITESANELYDA123"); //usuario y contraseña

                        cl.Port = 587;
                        cl.EnableSsl = true;

                        cl.Host = "smtp.gmail.com"; //Dominio

                        try{
                            cl.Send(msg);
                            MessageBox.Show("Mensaje enviado");
                        }catch (Exception ex){
                            MessageBox.Show("Error al enviar" + ex);
                        }
                    }else { }
                }else{
                    MessageBox.Show("Debe ingresar una dirección de correo al cual enviarlo ");
                    txtPara.Focus();
                }
            }
        }
        private void pictureBox25_Click(object sender, EventArgs e){
            pictureBox6.Visible = false;
            pictureBox8.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            pictureBox25.Visible = false;
            this.BackColor = Color.White;
            foreach (Control c in this.Controls)
            {
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
            foreach (Control c in this.Controls)
            {
                if (c is Panel) { c.BackColor = Panel.DefaultBackColor; }
                if (c is Button) { c.Visible = true; }
            }
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.PrintPage += (a, b) => { b.Graphics.DrawImage(Img, 50, 50); };
            printDocument1.Print();
            pictureBox6.Visible = true;
            pictureBox8.Visible = true;
            pictureBox22.Visible = true;
            pictureBox23.Visible = true;
            pictureBox24.Visible = true;
            pictureBox25.Visible = true;
        }
        private void txtMat_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void pictureBox26_Click(object sender, EventArgs e){
            this.Hide();
            Principal pr = new Principal();
            pr.label1.Text = this.label11.Text;
            pr.Show();
        }
        private void Serv_Load(object sender, EventArgs e){
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            pictureBox26.Visible = true;
            txtLyF.Text = DateTime.Today.ToString("dd MMMM yyyy");
            label74.Text = DateTime.Today.ToString("dd MMMM yyyy");
            panel1.Visible = false;
            nuevo();
            textBox1.Focus();
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 500;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.pictureBox11, "Eliminar Registro");
            toolTip1.SetToolTip(this.pictureBox14, "Imprimir");
            toolTip1.SetToolTip(this.pictureBox15, "Guardar");
            toolTip1.SetToolTip(this.pictureBox13, "Limpiar Formulario");
            toolTip1.SetToolTip(this.pictureBox12, "Regresar");
            toolTip1.SetToolTip(this.pictureBox10, "Enviar por correo");
            toolTip1.SetToolTip(this.pictureBox4, "Nuevo Historial");
            toolTip1.SetToolTip(this.pictureBox5, "Editar Historial");
            toolTip1.SetToolTip(this.pictureBox16, "Regresar");
            toolTip1.SetToolTip(this.pictureBox19, "Enviar por correo");
            toolTip1.SetToolTip(this.pictureBox18, "Guardar registro");
            toolTip1.SetToolTip(this.pictureBox17, "Limpiar formulario");
            toolTip1.SetToolTip(this.pictureBox22, "Regresar");
            toolTip1.SetToolTip(this.pictureBox24, "Enviar por correo");
            toolTip1.SetToolTip(this.pictureBox23, "Guardar registro");
            toolTip1.SetToolTip(this.pictureBox25, "Imprimir");
            toolTip1.SetToolTip(this.pictureBox26, "Regresar a la pantalla principal");
            toolTip1.SetToolTip(this.pictureBox7, "Regresar a los servicios");
            groupBox7.Visible = false;
            panel4.Visible = false;
        }
        public void cero(){
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            panel1.Visible = false;
        }
        public void val(){
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
            }else if (textBox1.Text == "" || comboBox2.Text == "" || txtNP.Text == "" || txtE.Text == "" || txtCantC.Text == "" || txtTra.Text == "" || txtHosp.Text == "" || txtTrans.Text == "" || txtEnf.Text == "" || txtTrat.Text == "" || txtM.Text == "" || txtNPS.Text == "" || txtGe.Text == "" || txtCiclo.Text == "" || txtMPF.Text == "" || txtPa.Text == "" || txtIVSA.Text == "" || txtDo.Text == "" || txtCe.Text == "" || txtAb.Text == "" || txtPeso.Text == "" || txtTalla.Text == "" || txtGS.Text == "" || txtImD.Text == "" || txtLyF.Text == "" || txtNM.Text == ""){
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
            }
        }
        public void nuevo(){
            textBox1.Text = "";
            txtNSS.Text = "";
            comboBox2.SelectedIndex = 0;
            txtNP.Text = "";
            txtE.Text = "";
            radioButton1.Checked = true;
            radioButton2.Checked = false;
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
            lblPara.Visible = false;
            txtPara.Visible = false;
            txtLyF.Text= DateTime.Today.ToString("dd MMMM yyyy");
        }
        public void Inh(){
            comboBox2.Enabled = false;
            txtNP.Enabled = false;
            txtE.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            cal.Enabled = false;
            radioButton6.Enabled = false;
            radioButton7.Enabled = false;
            txtCantC.Enabled = false;
            radioButton19.Enabled = false;
            radioButton27.Enabled = false;
            radioButton30.Enabled = false;
            radioButton34.Enabled = false;
            radioButton37.Enabled = false;
            radioButton40.Enabled = false;
            radioButton3.Enabled = false;
            radioButton15.Enabled = false;
            radioButton4.Enabled = false;
            radioButton16.Enabled = false;
            radioButton5.Enabled = false;
            radioButton9.Enabled = false;
            radioButton11.Enabled = false;
            radioButton10.Enabled = false;
            radioButton12.Enabled = false;
            radioButton13.Enabled = false;
            radioButton14.Enabled = false;
            radioButton17.Enabled = false;
            txtTra.Enabled = false;
            txtHosp.Enabled = false;
            txtTrans.Enabled = false;
            txtEnf.Enabled = false;
            txtTrat.Enabled = false;
            txtM.Enabled = false;
            txtDo.Enabled = false;
            txtCiclo.Enabled = false;
            txtGe.Enabled = false;
            txtIVSA.Enabled = false;
            txtPa.Enabled = false;
            txtNPS.Enabled = false;
            txtCe.Enabled = false;
            txtMPF.Enabled = false;
            txtAb.Enabled = false;
            txtPeso.Enabled = false;
            txtTalla.Enabled = false;
            txtGS.Enabled = false;
            txtImD.Enabled = false;
            txtNM.Enabled = false;
        }
        public void hab()
        {
            comboBox2.Enabled = true;
            txtNP.Enabled = true;
            txtE.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            cal.Enabled = true;
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;
            txtCantC.Enabled = true;
            radioButton19.Enabled = true;
            radioButton27.Enabled = true;
            radioButton30.Enabled = true;
            radioButton34.Enabled = true;
            radioButton37.Enabled = true;
            radioButton40.Enabled = true;
            radioButton3.Enabled = true;
            radioButton15.Enabled = true;
            radioButton4.Enabled = true;
            radioButton16.Enabled = true;
            radioButton5.Enabled = true;
            radioButton9.Enabled = true;
            radioButton11.Enabled = true;
            radioButton10.Enabled = true;
            radioButton12.Enabled = true;
            radioButton13.Enabled = true;
            radioButton14.Enabled = true;
            radioButton17.Enabled = true;
            txtTra.Enabled = true;
            txtHosp.Enabled = true;
            txtTrans.Enabled = true;
            txtEnf.Enabled = true;
            txtTrat.Enabled = true;
            txtM.Enabled = true;
            txtDo.Enabled = true;
            txtCiclo.Enabled = true;
            txtGe.Enabled = true;
            txtIVSA.Enabled = true;
            txtPa.Enabled = true;
            txtNPS.Enabled = true;
            txtCe.Enabled = true;
            txtMPF.Enabled = true;
            txtAb.Enabled = true;
            txtPeso.Enabled = true;
            txtTalla.Enabled = true;
            txtGS.Enabled = true;
            txtImD.Enabled = true;
            txtNM.Enabled = true;
        }
        public void llenar(){
            MySqlConnection connStr = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
            MySqlCommand cmd = new MySqlCommand("SELECT NombrePaciente,Edad,Sexo,NSS,FechaNacimiento,Tabaquismo,CantCigarros,Alcoholismo,Drogadiccion,traumaticos,CualTraumat,Quirurgico,Hospitalizaciones,DetalleHospital,transfuciones,DetalleTransf,Alergicos,Enfermedad,DetalleEnfermed,tratamiento,Menarca,CicloMenst,IVSA,NPS,MPF,DoCaCu,Gestas,Partos,Cesareas,Abortos,peso,Talla,GrupoSang,ImpDiag,Matricula,PE,Lugaryfecha,NombreMedico FROM datos WHERE matricula ='" + textBox1.Text + "'", connStr);
            connStr.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows){
                while (dr.Read()){
                    txtNP.Text = dr.GetString(0);
                    txtE.Text = dr.GetString(1);
                    genero = dr.GetString(2);
                    #region genero
                    if (genero == "Masculino"){
                        radioButton1.Checked = true;
                    }else {
                        radioButton2.Checked = true;
                    }
                    #endregion                    
                    txtNSS.Text = dr.GetString(3);
                    cal.Text = dr.GetString(4);
                    tabaquismo = dr.GetString(5);
                    #region tabaquismo
                    if (tabaquismo == "Sí"){
                        radioButton6.Checked = true;
                    }else{
                        radioButton7.Checked = true;
                    }
                    #endregion
                    txtCantC.Text = dr.GetString(6);
                    alcoholismo = dr.GetString(7);
                    #region alcoholismo
                    if (alcoholismo == "Sí"){
                        radioButton19.Checked = true;
                    }else if (alcoholismo == "No"){
                        radioButton27.Checked = true;
                    }else{
                        radioButton30.Checked = true;
                    }
                    #endregion                    
                    drog = dr.GetString(8);
                    #region Drogas
                    if (drog == "Sí"){
                        radioButton34.Checked = true;
                    }else if (drog == "No"){
                        radioButton37.Checked = true;
                    }else {
                        radioButton40.Checked = true;
                    }
                    #endregion                    
                    Trauma = dr.GetString(9);
                    #region Traumatico
                    if (Trauma == "Sí"){
                        radioButton3.Checked = true;
                    }else{
                        radioButton15.Checked = true;
                    }
                    #endregion                    
                    txtTra.Text = dr.GetString(10);
                    Quirur = dr.GetString(11);
                    #region Quirurgicos
                    if (Quirur == "Sí"){                        
                        radioButton4.Checked = true;
                    }else{
                        radioButton16.Checked = true;
                    }
                    #endregion
                    Hosp = dr.GetString(12);
                    #region Hospitalizaciones
                    if (Hosp == "Sí"){
                        radioButton5.Checked = true;
                    }else{
                        radioButton9.Checked = true;
                    }
                    #endregion
                    txtHosp.Text = dr.GetString(13);
                    Trans = dr.GetString(14);
                    #region Transfuciones
                    if (Trans == "Sí"){
                        radioButton11.Checked = true;
                    }else{
                        radioButton10.Checked = true;
                    }
                    #endregion
                    txtTrans.Text = dr.GetString(15);
                    Al = dr.GetString(16);
                    #region Alergias
                    if (Al == "Sí"){
                        radioButton12.Checked = true;
                    }else{
                        radioButton13.Checked = true;
                    }
                    #endregion
                    Enfer = dr.GetString(17);
                    #region Enfermedad
                    if (Enfer == "Sí"){
                        radioButton14.Checked = true;
                    }else{
                        radioButton17.Checked = true;
                    }
                    #endregion
                    txtEnf.Text = dr.GetString(18);
                    txtTrat.Text = dr.GetString(19);
                    txtM.Text = dr.GetString(20);
                    txtCiclo.Text = dr.GetString(21);
                    txtIVSA.Text = dr.GetString(22);
                    txtNPS.Text = dr.GetString(23);
                    txtMPF.Text = dr.GetString(24);
                    txtDo.Text = dr.GetString(25);
                    txtGe.Text = dr.GetString(26);
                    txtPa.Text = dr.GetString(27);
                    txtCe.Text = dr.GetString(28);
                    txtAb.Text = dr.GetString(29);
                    txtPeso.Text = dr.GetString(30);
                    txtTalla.Text = dr.GetString(31);
                    txtGS.Text = dr.GetString(32);
                    txtImD.Text = dr.GetString(33);
                    textBox1.Text = dr.GetString(34);
                    comboBox2.Text = dr.GetString(35);
                    txtLyF.Text = dr.GetString(36);
                    txtNM.Text = dr.GetString(37);
                }
            }
            connStr.Close();
        } // cambiar cadena
        public static bool Existe(string Matricula){
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
            string query = "SELECT COUNT(*) FROM datos WHERE Matricula=@Matricula";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("Matricula", Matricula);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0){
                return false;
            }else{
                return true;
            }
        } // cambiar cadena
        public void Limpiar(){
            textBox3.Text = "";
            comboBox1.SelectedIndex = 0;
            textBox9.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox11.Text = "";
        }
        public void Li(){
            textBox12.Text = "";
            txtN.Text = "";
            txtMat.Text = "";
            txtMo.Text = "";
            txtRet.Text = "";
        }
    }
}