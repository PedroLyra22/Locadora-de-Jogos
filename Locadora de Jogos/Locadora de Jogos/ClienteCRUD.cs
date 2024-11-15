using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Locadora_de_Jogos
{
    public class ClienteCRUD
    {
        public void AdicionarCliente(string nome, string email, string telefone, DateTime dataNascimento)
        {
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "INSERT INTO Clientes (nome, email, telefone, data_nascimento) VALUES (@nome, @email, @telefone, @data_nascimento)";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@data_nascimento", dataNascimento);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "SELECT * FROM Clientes";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            Id = reader.GetInt32("id"),
                            Nome = reader.GetString("nome"),
                            Email = reader.GetString("email"),
                            Telefone = reader.GetString("telefone"),
                            DataNascimento = reader.GetDateTime("data_nascimento")
                        };
                        clientes.Add(cliente);
                    }
                }
                conn.Close();
            }

            return clientes;
        }

        public void AtualizarCliente(int id, string nome, string email, string telefone, DateTime dataNascimento)
        {
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "UPDATE Clientes SET nome=@nome, email=@email, telefone=@telefone, data_nascimento=@data_nascimento WHERE id=@id";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@data_nascimento", dataNascimento);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ExcluirCliente(int id)
        {
            var conn = DatabaseConnection.GetInstance().GetConnection();
            string query = "DELETE FROM Clientes WHERE id=@id";

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
