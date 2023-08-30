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
    public partial class Login : Form{
        public int xClick = 0, yClick = 0;
        int c = 0;
        string tipo = "";
        public Login(){
            InitializeComponent();
        }
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e){
            if (e.KeyChar == (char)Keys.Enter){
                acceder();
            }else { }
        }
        private void entrar_Click(object sender, EventArgs e){
            acceder();
        }
        public void acceder(){
            MySqlConnection connStr = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
            connStr.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection con = new MySqlConnection();
            cmd.Connection = connStr;
            cmd.CommandText = "SELECT contraseña FROM user WHERE contraseña = '" + txtContraseña.Text + "' AND Usuario ='" + comboBox1.Text + "'";
            MySqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read()){
                connStr.Close();
                Cons();
            }else{
                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                c++;
                if (c == 3){
                    MessageBox.Show("Limite de Intentos excedido\nLa contraseña se cambiará y se enviará por correo al administrador\nPor favor pongase en contacto con él", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    NuC();
                    inhab();                    
                    c = 0;
                    Environment.Exit(0);
                }
                txtContraseña.Focus();
            }
        }
        private void NuC(){
            string n = "!#$12345%&/()=?¡\'+*{}[]-aABbCcKkLlMmNnOoPpQqRrSsDdEeFfGgHhIiJj06789TtUuVvWwXxYyZz_.;:,<>";
            Random r = new Random();
            int a = r.Next(0, n.Length);
            string cadena = n.Substring(a, 10);
            string nu = cadena;
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection connStr = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c");
            try{
                connStr.Open();
                string consul = "UPDATE user SET contraseña ='" + nu + "' WHERE Usuario = '" +comboBox1.Text+"'";
                cmd = new MySqlCommand(consul, connStr);
                cmd.ExecuteNonQuery();
                connStr.Close();
                #region EnviarContraseña
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                //msg.To.Add("servicio_medico@itesa.edu.mx");//Para quien
                msg.To.Add("15030371@itesa.edu.mx");//Para quien
                msg.Subject = "Nueva contraseña del Sistema de enfermeria";//Asunto
                msg.SubjectEncoding = System.Text.Encoding.UTF8;

                msg.Body = nu;//msj
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.From = new System.Net.Mail.MailAddress("amedicaitesa@gmail.com");//Quien lo envia

                System.Net.Mail.SmtpClient cl = new System.Net.Mail.SmtpClient();
                cl.Credentials = new System.Net.NetworkCredential("amedicaitesa@gmail.com", "amedicaitesa1234"); //usuario y contraseña

                cl.Port = 587;
                cl.EnableSsl = true;

                cl.Host = "smtp.gmail.com"; //Dominio

                try{
                    cl.Send(msg);
                    MessageBox.Show("Se envio la nueva contraseña al administrador por correo electronico");
                }catch (Exception ex){
                    MessageBox.Show("Error al enviar" + ex);
                }
                #endregion
            }catch (Exception ex){
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void inhab(){
            txtContraseña.Enabled = false;
            entrar.Enabled = false;
        }
        public void llenC(){
            using (MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=h_c")){
                string query = "SELECT id, Usuario from user";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "Usuario";
                comboBox1.DataSource = dt;

            }
        }
        public void Cons(){            
            String connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h_c";
            using (MySqlConnection con = new MySqlConnection(connString)){
                using (MySqlCommand cmd = new MySqlCommand("SELECT Tipo FROM user WHERE contraseña = '" + txtContraseña.Text + "' AND Usuario ='" + comboBox1.Text + "'")){
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    tipo = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            this.Hide();
            Principal pr = new Principal();
            pr.label1.Text = tipo;
            pr.Show();
        }
        private void Login_Load(object sender, EventArgs e){
            llenC();
            comboBox1.SelectedIndex = 0;
        }
        private void iconMin_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void iconCerrar_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea cerrar la aplicación ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else { }
        }
        private void label8_MouseMove(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
    }
}