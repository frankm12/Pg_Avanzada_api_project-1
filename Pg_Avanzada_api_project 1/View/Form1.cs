using Pg_Avanzada_api_project_1.Presenter;
using Pg_Avanzada_api_project_1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pg_Avanzada_api_project_1
{
    public partial class Form1 : Form , IViewFormulario_Principal
    {
        private Presenter_crypto_general _presenter;

        public Form1()
        {
            InitializeComponent();
            _presenter = new Presenter_crypto_general(this);
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Símbolo",
                HeaderText = "Símbolo",
                Width = 80
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Precio",
                HeaderText = "Precio (USD)",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2"
                }
            });
        }

        // Implementación de ICryptoView
        public event EventHandler OnDatosRequeridos;

        public void MostrarDatos(object datos)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object>(MostrarDatos), datos);
                return;
            }
            dataGridView1.DataSource = datos;
        }

        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_conseguir_to_Click(object sender, EventArgs e)
        {
            OnDatosRequeridos?.Invoke(this, EventArgs.Empty);
        }
    }
}
