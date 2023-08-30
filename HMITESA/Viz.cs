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
using Microsoft.Office.Interop.Excel;


namespace HMITESA {
    public partial class Viz : Form{
        public int xClick = 0, yClick = 0;
        public Viz(){
            InitializeComponent();
        }
        private void btnVer_Click(object sender, EventArgs e){
            if (comboBox1.SelectedIndex==0) {
                dGHis.Visible = true;
                dGInc.Visible = false;
                dGTras.Visible = false;

                ExHis.Visible = true;
                ExInc.Visible = false;
                ExTrans.Visible = false;
                try {
                    string cadenaconexion = @"datasource=127.0.0.1;port=3306;username=root;password=;database=h_c";
                    MySqlConnection con = new MySqlConnection();
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlDataReader dr;
                    con.ConnectionString = cadenaconexion;
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT NombrePaciente,Matricula,PE,ImpDiag,Lugaryfecha FROM datos";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    dGHis.Rows.Clear();
                    dr = cmd.ExecuteReader();
                    while (dr.Read()){
                        int renglon = dGHis.Rows.Add();
                        dGHis.Rows[renglon].Cells["Nombre"].Value = dr.GetString(dr.GetOrdinal("NombrePaciente"));
                        dGHis.Rows[renglon].Cells["Matricula"].Value = dr.GetInt32(dr.GetOrdinal("Matricula")).ToString();
                        dGHis.Rows[renglon].Cells["PE"].Value = dr.GetString(dr.GetOrdinal("PE"));                        
                        dGHis.Rows[renglon].Cells["Diag"].Value = dr.GetString(dr.GetOrdinal("ImpDiag"));
                        dGHis.Rows[renglon].Cells["Fecha"].Value = dr.GetString(dr.GetOrdinal("Lugaryfecha"));
                    }
                    con.Close();
                }catch (Exception ex){
                    MessageBox.Show("Error: " + ex.Message);
                }
            }else if (comboBox1.SelectedIndex == 1){
                dGInc.Visible = true;
                dGTras.Visible = false;
                dGHis.Visible = false;
                
                ExInc.Visible = true;
                ExTrans.Visible = false;
                ExHis.Visible = false;
                try {
                    string cadenaconexion = @"datasource=127.0.0.1;port=3306;username=root;password=;database=h_c";
                    MySqlConnection con = new MySqlConnection();
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlDataReader dr;
                    con.ConnectionString = cadenaconexion;
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT alumno,matricula,area,diagnostico,fecha FROM incapacidad";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    dGInc.Rows.Clear();
                    dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        int renglon1 = dGInc.Rows.Add();
                        dGInc.Rows[renglon1].Cells["Nombr"].Value = dr.GetString(dr.GetOrdinal("alumno"));
                        dGInc.Rows[renglon1].Cells["Matricul"].Value = dr.GetInt32(dr.GetOrdinal("matricula")).ToString();
                        dGInc.Rows[renglon1].Cells["PrE"].Value = dr.GetString(dr.GetOrdinal("area"));
                        dGInc.Rows[renglon1].Cells["Diagn"].Value = dr.GetString(dr.GetOrdinal("diagnostico"));
                        dGInc.Rows[renglon1].Cells["Fech"].Value = dr.GetString(dr.GetOrdinal("fecha"));
                    }
                    con.Close();
                }catch (Exception ex){
                    MessageBox.Show("Error: " + ex.Message);
                }
            } else if (comboBox1.SelectedIndex == 2) {
                dGTras.Visible = true;
                dGInc.Visible = false;
                dGHis.Visible = false;

                ExTrans.Visible = true;
                ExHis.Visible = false;
                ExInc.Visible = false;
                try {
                    string cadenaconexion = @"datasource=127.0.0.1;port=3306;username=root;password=;database=h_c";
                    MySqlConnection con = new MySqlConnection();
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlDataReader dr;
                    con.ConnectionString = cadenaconexion;
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT Fecha,Nombre,Matricula,Motivo,Retiro FROM tras";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    dGTras.Rows.Clear();
                    dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        int renglon1 = dGTras.Rows.Add();
                        dGTras.Rows[renglon1].Cells["F"].Value = dr.GetString(dr.GetOrdinal("Fecha"));
                        dGTras.Rows[renglon1].Cells["N"].Value = dr.GetString(dr.GetOrdinal("Nombre"));
                        dGTras.Rows[renglon1].Cells["M"].Value = dr.GetInt32(dr.GetOrdinal("Matricula")).ToString();
                        dGTras.Rows[renglon1].Cells["Mo"].Value = dr.GetString(dr.GetOrdinal("Motivo"));
                        dGTras.Rows[renglon1].Cells["R"].Value = dr.GetString(dr.GetOrdinal("Retiro"));                        
                    }
                    con.Close();
                } catch (Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void Viz_Load(object sender, EventArgs e){
            comboBox1.SelectedIndex = 0;
            lblFecha.Text = DateTime.Today.ToString("dd MMMM yyyy");
            ExInc.Visible = false;
            ExHis.Visible = false;
            ExTrans.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e){
            this.Hide();
            Principal pr = new Principal();
            pr.label1.Text = this.label1.Text;
            pr.Show();
        }
        private void Viz_FormClosing(object sender, FormClosingEventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea cerrar la aplicación ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                Environment.Exit(0);
            }else{
                switch (e.CloseReason){
                    case CloseReason.UserClosing:
                        e.Cancel = true;
                        break;
                }
            }
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
        private void ExInc_Click(object sender, EventArgs e) {
            exportarExcel(dGInc);            
        }
        private void ExTrans_Click(object sender, EventArgs e) {
            exportarExcel(dGTras);
        }
        private void ExHis_Click(object sender, EventArgs e) {
            exportarExcel(dGHis);
        }
        private void label8_MouseMove(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
        public void exportarExcel(DataGridView tabla) {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;
            foreach (DataGridViewColumn col in tabla.Columns) { // Columnas
                IndiceColumna++;
                //excel.Cells[1, IndiceColumna] = col.Name;
                excel.Cells[1, IndiceColumna] = col.DataPropertyName;
            }
            int IndeceFila = 0;
            foreach (DataGridViewRow row in tabla.Rows) { // Filas
                IndeceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn col in tabla.Columns) {
                    IndiceColumna++;
                    excel.Cells[IndeceFila+1, IndiceColumna] = row.Cells[col.Name].Value;
                    //excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.DataPropertyName].Value;
                }
            }
            excel.Visible = true;
        }
    }
}