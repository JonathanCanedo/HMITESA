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
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }
        public void Barra(){
            progressBar1.Increment(1);
            lbl3.Text = progressBar1.Value.ToString() + " %";
            if (progressBar1.Value == progressBar1.Maximum){
                timer1.Stop();
                this.Hide();
                Login log = new Login();
                log.Show();
            }
        }
        private void timer1_Tick(object sender, EventArgs e){
            Barra();
        }
        private void Form1_Load(object sender, EventArgs e){
            lbl3.BackColor = Color.Transparent;
            timer1.Start();
        }
    }
}