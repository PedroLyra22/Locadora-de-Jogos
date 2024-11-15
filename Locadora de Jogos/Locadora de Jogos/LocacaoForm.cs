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
    public partial class LocacaoForm : Form
    {
        private LocacaoCRUD locacaoCRUD;
        private string ConteudoBarra;
        public LocacaoForm()
        {
            InitializeComponent();
            locacaoCRUD = new LocacaoCRUD();
            CarregarLocacoes();
        }
        private void CarregarLocacoes()
        {
            try
            {
                List<Locacao> locacoes = locacaoCRUD.ListarLocacoes();
                dataGridViewClientes.DataSource = locacoes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar locacoes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string query = ConteudoBarra;
            string[] parametros = query.Split(',');
            locacaoCRUD.AdicionarLocacao(int.Parse(parametros[0]), int.Parse(parametros[1]), DateTime.Parse(parametros[2]), DateTime.Parse(parametros[3]), decimal.Parse(parametros[4]));
            CarregarLocacoes();
            textBox1.Text = "";
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            CarregarLocacoes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string query = ConteudoBarra;
            string[] parametros = query.Split(',');
            locacaoCRUD.AtualizarLocacao(int.Parse(parametros[0]), int.Parse(parametros[1]), int.Parse(parametros[2]), DateTime.Parse(parametros[3]), DateTime.Parse(parametros[4]), decimal.Parse(parametros[5]));
            CarregarLocacoes();
            textBox1.Text = "";
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string query = ConteudoBarra;
            string[] parametros = query.Split(',');
            locacaoCRUD.ExcluirLocacao(int.Parse(parametros[0]));
            CarregarLocacoes();
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox Caixa = (TextBox)sender;
            ConteudoBarra = Caixa.Text;
        }
    }
}
