using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_de_Jogos
{
    internal class LocacaoCRUD
    {
        public void AdicionarLocacao(int idCliente, int idJogo, DateTime dataLocacao, DateTime dataDevolucao, decimal valorTotal)
        {
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "INSERT INTO Locacoes (id_cliente, id_jogo, data_locacao, data_devolucao, valor_total) VALUES (@id_cliente, @id_jogo, @data_locacao, @data_devolucao, @valor_total)";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.Parameters.AddWithValue("@id_jogo", idJogo);
                cmd.Parameters.AddWithValue("@data_locacao", dataLocacao);
                cmd.Parameters.AddWithValue("@data_devolucao", dataDevolucao);
                cmd.Parameters.AddWithValue("@valor_total", valorTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Locacao> ListarLocacoes()
        {
            List<Locacao> locacoes = new List<Locacao>();
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "SELECT * FROM Locacoes";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Locacao locacao = new Locacao
                        {
                            Id = reader.GetInt32("id"),
                            IdCliente = reader.GetInt32("id_cliente"),
                            IdJogo = reader.GetInt32("id_jogo"),
                            DataLocacao = reader.GetDateTime("data_locacao"),
                            DataDevolucao = reader.IsDBNull(reader.GetOrdinal("data_devolucao")) ? (DateTime?)null : reader.GetDateTime("data_devolucao"),
                            ValorTotal = reader.GetDecimal("valor_total")
                        };
                        locacoes.Add(locacao);
                    }
                }
                conn.Close();
            }

            return locacoes;
        }

        public void AtualizarLocacao(int id, int idCliente, int idJogo, DateTime dataLocacao, DateTime? dataDevolucao, decimal valorTotal)
        {
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "UPDATE Locacoes SET id_cliente=@id_cliente, id_jogo=@id_jogo, data_locacao=@data_locacao, data_devolucao=@data_devolucao, valor_total=@valor_total WHERE id=@id";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.Parameters.AddWithValue("@id_jogo", idJogo);
                cmd.Parameters.AddWithValue("@data_locacao", dataLocacao);
                cmd.Parameters.AddWithValue("@data_devolucao", dataDevolucao.HasValue ? dataDevolucao.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@valor_total", valorTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ExcluirLocacao(int id)
        {
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "DELETE FROM Locacoes WHERE id=@id";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
