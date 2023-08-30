using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMITESA
{
    public partial class Receta : Form {
        public int xClick = 0, yClick = 0;
        public Receta() {
            InitializeComponent();
        }
        private void Receta_Load(object sender, EventArgs e) {
            lblFecha.Text = DateTime.Today.ToString("dd MMMM yyyy");
        }
        private void pictureBox2_Click(object sender, EventArgs e){
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;

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
            foreach (Control c in this.Controls)
            {
                if (c is Panel) { c.BackColor = Panel.DefaultBackColor; }
                if (c is Button) { c.Visible = true; }
            }
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.PrintPage += (a, b) => { b.Graphics.DrawImage(Img, 50, 50); };
            printDocument1.Print();

            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
        }
        private void pictureBox3_Click(object sender, EventArgs e) {
            this.Hide();
            Principal pr = new Principal();
            pr.label1.Text = this.label11.Text;
            pr.Show();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            if (char.IsDigit(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsLetter(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
        private void iconCerrar_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea cerrar la aplicación ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                Environment.Exit(0);
            }else { }
        }
        private void iconMin_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void label8_MouseMove_1(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left){
                xClick = e.X; yClick = e.Y;
            }else{
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsLetter(e.KeyChar)){
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else{
                e.Handled = true;
            }
        }
    }
}