using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_de_Jogos
{
    public partial class ClienteForm : Form
    {
        private ClienteCRUD clienteCRUD;
        private string ConteudoBarra;
        public ClienteForm()
        {
            InitializeComponent();
            clienteCRUD = new ClienteCRUD();
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            try
            {
                List<Cliente> clientes = clienteCRUD.ListarClientes();
                dataGridViewClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string query = ConteudoBarra;
            string[] parametros = query.Split(',');
            clienteCRUD.AdicionarCliente(parametros[0], parametros[1], parametros[2], DateTime.Parse(parametros[3]));
            CarregarClientes();
            textBox1.Text = "";
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            CarregarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string query = ConteudoBarra;
            string[] parametros = query.Split(',');
            clienteCRUD.AtualizarCliente(int.Parse(parametros[0]), parametros[1], parametros[2], parametros[3], DateTime.Parse(parametros[4]));
            CarregarClientes();
            textBox1.Text = "";
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string query = ConteudoBarra;
            string[] parametros = query.Split(',');
            clienteCRUD.ExcluirCliente(int.Parse(parametros[0]));
            CarregarClientes();
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox Caixa = (TextBox)sender;
            ConteudoBarra = Caixa.Text;
        }
    }
}
