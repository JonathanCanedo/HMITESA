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
    public partial class usu : Form {
        public int xClick = 0, yClick = 0;
        public usu(){
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e){
            panel2.Visible = true;
            btnEl.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e){
            if (textBox1.Text == ""){
                MessageBox.Show("Debe ingresar un nombre de usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }else if (textBox2.Text == ""){
                MessageBox.Show("Debe ingresar una contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
            }else{
                if (!Existe(textBox1.Text)){
                    try{
                        MySqlCommand cmd;
                        MySqlConnection Con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
                        DialogResult respuesta = MessageBox.Show("¿Desea guardar el registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (respuesta == DialogResult.Yes){
                            string consul = "INSERT INTO user (Usuario,contraseña,Tipo)values(@Usuario,@contraseña,@Tipo)";
                            cmd = new MySqlCommand(consul, Con);
                            #region Datos
                            cmd.Parameters.AddWithValue("@Usuario", textBox1.Text);
                            cmd.Parameters.AddWithValue("@contraseña", textBox2.Text);
                            cmd.Parameters.AddWithValue("@Tipo", comboBox1.Text);
                            #endregion
                            Con.Open();
                            cmd.ExecuteNonQuery();
                            Con.Close();
                            MessageBox.Show("Se guardó con exito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            button1.Enabled = false;
                            textBox1.Enabled = false;
                            textBox2.Enabled = false;
                            comboBox1.Enabled = false;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            comboBox1.SelectedIndex = 0;
                        }else { }
                    }catch (Exception ex){
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }else{
                    MessageBox.Show("El usuario " + textBox1.Text + " ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e){
            panel1.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }
        private void pictureBox3_Click(object sender, EventArgs e){
            panel2.Visible = true;
            btnEl.Visible = true;
            btnEd.Visible = false;
            btnG.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }
        private void btnG_Click(object sender, EventArgs e){
            if (textBox4.Text == ""){
                MessageBox.Show("Debe ingresar un nombre de usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
            }else if (textBox3.Text == ""){
                MessageBox.Show("Debe ingresar una contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
            }else{
                if (!Existe(textBox4.Text)){
                    MessageBox.Show("El usuario " + textBox1.Text + " no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else{
                    try{
                        MySqlCommand cmd;
                        MySqlConnection Con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
                        DialogResult respuesta = MessageBox.Show("¿Desea actualizar el registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (respuesta == DialogResult.Yes){
                            if (textBox4.Text==""|| textBox3.Text == ""|| textBox2.Text == ""){
                                MessageBox.Show("No debe dejar datos sin llenar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (textBox4.Text == ""){
                                    textBox4.Focus();
                                }else if (textBox3.Text == ""){
                                    textBox3.Focus();
                                }else if (textBox2.Text == ""){
                                    textBox2.Focus();
                                }
                            }else {
                                string consul = "UPDATE user SET Usuario=@Usuario,contraseña=@contraseña,Tipo=@Tipo WHERE Usuario = '" + textBox4.Text + "'";
                                cmd = new MySqlCommand(consul, Con);
                                #region Datos
                                cmd.Parameters.AddWithValue("@Usuario", textBox4.Text);
                                cmd.Parameters.AddWithValue("@contraseña", textBox3.Text);
                                cmd.Parameters.AddWithValue("@Tipo", comboBox2.Text);
                                #endregion
                                Con.Open();
                                cmd.ExecuteNonQuery();
                                Con.Close();
                                MessageBox.Show("Se actualizó con exito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                inh();
                                textBox3.Text = "";
                                textBox4.Text = "";
                                comboBox2.SelectedIndex = 0;
                                textBox4.Enabled = false;
                                btnEd.Enabled = false;
                                btnEl.Enabled = false;
                                btnG.Enabled = false;
                            }
                        }else { }
                    }catch (Exception ex){
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void btnEd_Click(object sender, EventArgs e){
            hab();
        }
        private void btnEl_Click(object sender, EventArgs e){
            if (textBox4.Text != ""){
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar el registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes){
                    try{
                        MySqlCommand cmd;
                        MySqlConnection Con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
                        string consul = "DELETE FROM user WHERE Usuario='" + textBox4.Text + "'";
                        cmd = new MySqlCommand(consul, Con);
                        Con.Open();
                        cmd.ExecuteNonQuery();
                        Con.Close();
                        MessageBox.Show("Se eliminó con exito", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inh();
                        textBox3.Text = "";
                        textBox4.Text = "";
                        comboBox2.SelectedIndex = 0;
                        btnEl.Enabled = false;
                    }catch (Exception ex){
                        MessageBox.Show("El usuario ingresado no existe\n"+ex, "Error");
                    }
                }else{}
            }else{
                MessageBox.Show("Debe ingresar un usuario para poder eliminar el registro");
                textBox4.Focus();
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e){
            this.Hide();
            Principal pr = new Principal();
            pr.label1.Text = this.label11.Text;
            pr.Show();
        }
        private void usu_Load(object sender, EventArgs e){
            panel1.Visible = false;
            panel2.Visible = false;
            label11.Visible = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            inh();
            btnG.Enabled = false;
            btnEl.Enabled = false;
            btnEd.Enabled = false;
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 500;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.pictureBox1, "Crear usuario");
            toolTip1.SetToolTip(this.pictureBox2, "Editar usuario");
            toolTip1.SetToolTip(this.pictureBox3, "Eliminar usuario");
            toolTip1.SetToolTip(this.pictureBox4, "Regresar");
        }
        public static bool Existe(String Usuario){
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
            string query = "SELECT COUNT(*) FROM user WHERE Usuario=@Usuario";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("Usuario", Usuario);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0){
                return false;
            }else{
                return true;
            }
        }
        public void inh(){
            textBox3.Enabled = false;
            comboBox2.Enabled = false;
        }
        public void hab(){
            textBox4.Enabled = true;
            textBox3.Enabled = true;
            comboBox2.Enabled = true;
        }
        public void llenar(){
            MySqlConnection connStr = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
            MySqlCommand cmd = new MySqlCommand("SELECT  Usuario,contraseña,Tipo FROM user WHERE Usuario ='" + textBox4.Text + "'", connStr);
            connStr.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows){
                while (dr.Read()){
                    textBox4.Text = dr.GetString(0);
                    textBox3.Text = dr.GetString(1);
                    comboBox1.Text = dr.GetString(2);
                }
            }
            connStr.Close();
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e){
            if (e.KeyChar == (char)Keys.Enter){
                if (!Existe(textBox4.Text)){
                    MessageBox.Show("El usuario " + textBox1.Text + " no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else{
                    llenar();
                    textBox4.Enabled = false;
                    btnG.Enabled = true;
                    btnEl.Enabled = true;
                    btnEd.Enabled = true;

                }
            }else{}
        }
        private void iconMin_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void iconCerrar_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea cerrar la aplicación ?\nGuarde cambios o perderá sus avances.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                Environment.Exit(0);
            }else{}
        }
        private void label8_MouseMove(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
    }
}