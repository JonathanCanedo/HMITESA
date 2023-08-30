using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMITESA{
    public partial class Principal : Form{
        public int xClick = 0, yClick = 0;
        public Principal(){
            InitializeComponent();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea regresar al logueo de la aplicación ?","Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                this.Hide();
                Login lo = new Login();
                lo.label1.Text = this.label1.Text;
                lo.Show();
            } else {}
        }
        private void Principal_FormClosing(object sender, FormClosingEventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea cerrar la aplicación ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                Environment.Exit(0);
            }else {
                
            }
        }
        private void Principal_Load(object sender, EventArgs e){
            if (label1.Text== "Super Usuario"){
                AdminTool.Visible = true;
                ServTool.Visible = true;
                VisTool.Visible = true;
                recetaToolStripMenuItem.Visible = true;
            }else if (label1.Text == "Usuario"){
                AdminTool.Visible = false;
                ServTool.Visible = true;
                VisTool.Visible = true;
                recetaToolStripMenuItem.Visible = true;
            }else if (label1.Text == "Invitado"){
                AdminTool.Visible = false;
                ServTool.Visible = false;
                recetaToolStripMenuItem.Visible = false;
                VisTool.Visible = true;                
            }

        }
        private void AdminTool_Click(object sender, EventArgs e){
            this.Hide();
            usu u = new usu();
            u.label11.Text = this.label1.Text;
            u.Show();
        }
        private void VisTool_Click(object sender, EventArgs e){
            this.Hide();
            Viz vis = new Viz();
            vis.label1.Text = this.label1.Text;
            vis.Show();
        }
        private void iconMin_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void iconCerrar_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea cerrar la aplicación ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                Environment.Exit(0);
            }else { }
        }
        private void ServTool_Click(object sender, EventArgs e){
            this.Hide();
            Serv serv = new Serv();
            serv.label11.Text = this.label1.Text;
            serv.Show();
        }
        private void pictureBox3_Click(object sender, EventArgs e){
            this.Hide();
            Inf inf = new Inf();
            inf.label11.Text = this.label1.Text;
            inf.Show();
        }
        private void recetaToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Hide();
            Receta rec = new Receta(); 
            rec.label11.Text = this.label1.Text;
            rec.Show();
        }
        private void label8_MouseMove(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left) {
                xClick = e.X; yClick = e.Y;
            }else {
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }
        }
    }
}