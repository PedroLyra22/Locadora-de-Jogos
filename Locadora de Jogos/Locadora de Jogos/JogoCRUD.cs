using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Locadora_de_Jogos
{
    internal class JogoCRUD
    {
        public void AdicionarJogo(string titulo, string genero, string plataforma, int anoLancamento, decimal precoDiaria)
        {
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "INSERT INTO Jogos (titulo, genero, plataforma, ano_lancamento, preco_diaria) VALUES (@titulo, @genero, @plataforma, @ano_lancamento, @preco_diaria)";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@plataforma", plataforma);
                cmd.Parameters.AddWithValue("@ano_lancamento", anoLancamento);
                cmd.Parameters.AddWithValue("@preco_diaria", precoDiaria);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Jogo> ListarJogos()
        {
            List<Jogo> jogos = new List<Jogo>();
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "SELECT * FROM Jogos";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Jogo jogo = new Jogo
                        {
                            Id = reader.GetInt32("id"),
                            Titulo = reader.GetString("titulo"),
                            Genero = reader.GetString("genero"),
                            Plataforma = reader.GetString("plataforma"),
                            AnoLancamento = reader.GetInt32("ano_lancamento"),
                            PrecoDiaria = reader.GetDecimal("preco_diaria")
                        };
                        jogos.Add(jogo);
                    }
                }
                conn.Close();
            }

            return jogos;
        }

        public void AtualizarJogo(int id, string titulo, string genero, string plataforma, int anoLancamento, decimal precoDiaria)
        {
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "UPDATE Jogos SET titulo=@titulo, genero=@genero, plataforma=@plataforma, ano_lancamento=@ano_lancamento, preco_diaria=@preco_diaria WHERE id=@id";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@plataforma", plataforma);
                cmd.Parameters.AddWithValue("@ano_lancamento", anoLancamento);
                cmd.Parameters.AddWithValue("@preco_diaria", precoDiaria);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ExcluirJogo(int id)
        {
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "DELETE FROM Jogos WHERE id=@id";

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
