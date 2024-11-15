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
    public partial class JogoForm : Form
    {
        private JogoCRUD jogoCRUD;
        private string ConteudoBarra;
        public JogoForm()
        {
            InitializeComponent();
            jogoCRUD = new JogoCRUD();
            CarregarJogos();
        }
        private void CarregarJogos()
        {
            try
            {
                List<Jogo> jogos = jogoCRUD.ListarJogos();
                dataGridViewClientes.DataSource = jogos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar jogos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string query = ConteudoBarra;
            string[] parametros = query.Split(',');
            jogoCRUD.AdicionarJogo(parametros[0], parametros[1], parametros[2], int.Parse(parametros[3]), decimal.Parse(parametros[4]));
            CarregarJogos();
            textBox1.Text = "";
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            CarregarJogos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string query = ConteudoBarra;
            string[] parametros = query.Split(',');
            jogoCRUD.AtualizarJogo(int.Parse(parametros[0]), parametros[1], parametros[2], parametros[3], int.Parse(parametros[4]), decimal.Parse(parametros[5]));
            CarregarJogos();
            textBox1.Text = "";
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string query = ConteudoBarra;
            string[] parametros = query.Split(',');
            jogoCRUD.ExcluirJogo(int.Parse(parametros[0]));
            CarregarJogos();
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox Caixa = (TextBox)sender;
            ConteudoBarra = Caixa.Text;
        }
    }
}
