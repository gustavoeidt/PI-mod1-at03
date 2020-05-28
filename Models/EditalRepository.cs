using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace at03.Models
{
    public class EditalRepository : Repository
    {
        public void Cadastra (Edital e, Usuario u)
        {
            conexao.Open();

            string sql = "INSERT INTO editais (orgao, banca, cargo, remuneracao, vagas, link_edital, usuario_id) VALUES (@orgao, @banca, @cargo, @remuneracao, @vagas, @link_edital, @usuario_id)";

            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@orgao", e.orgao);
            comando.Parameters.AddWithValue("@banca", e.banca);
            comando.Parameters.AddWithValue("@cargo", e.cargo);
            comando.Parameters.AddWithValue("@remuneracao", e.remuneracao);
            comando.Parameters.AddWithValue("@vagas", e.vagas);
            comando.Parameters.AddWithValue("@link_edital", e.link_edital);
            comando.Parameters.AddWithValue("@usuario_id", u.id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void Atualiza (Edital e, Usuario u)
        {
            conexao.Open();

            string sql = "UPDATE editais SET orgao = @orgao , banca = @banca, cargo = @cargo, remuneracao = @remuneracao, vagas = @vagas, link_edital = @link_edital, usuario_id = @usuario_id WHERE id = @id";

            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@orgao", e.orgao);
            comando.Parameters.AddWithValue("@banca", e.banca);
            comando.Parameters.AddWithValue("@cargo", e.cargo);
            comando.Parameters.AddWithValue("@remuneracao", e.remuneracao);
            comando.Parameters.AddWithValue("@vagas", e.vagas);
            comando.Parameters.AddWithValue("@link_edital", e.link_edital);
            comando.Parameters.AddWithValue("@id", e.id);
            comando.Parameters.AddWithValue("@usuario_id", u.id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public List<Edital> Lista()
        {
            conexao.Open();
            
            string sql = "SELECT * FROM editais ORDER BY editais.orgao DESC";
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            
            MySqlDataReader reader = comando.ExecuteReader();
            List<Edital> lista = new List<Edital>();

            while(reader.Read())
            {

                Edital edital = new Edital();
                edital.id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("orgao")))
                    edital.orgao = reader.GetString("orgao");
                
                if (!reader.IsDBNull(reader.GetOrdinal("banca")))
                    edital.banca = reader.GetString("banca");

                if (!reader.IsDBNull(reader.GetOrdinal("cargo")))
                    edital.cargo = reader.GetString("cargo");

                if (!reader.IsDBNull(reader.GetOrdinal("remuneracao")))
                    edital.remuneracao = reader.GetDouble("remuneracao");

                if (!reader.IsDBNull(reader.GetOrdinal("vagas")))
                    edital.vagas = reader.GetInt32("vagas");

                lista.Add(edital);
            }

            conexao.Close();

            return lista;
        }

        public Edital Lista(int id)
        {
            conexao.Open();
            
            string sql = "SELECT * FROM editais WHERE pacotes.id = " + id;
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            MySqlDataReader reader = comando.ExecuteReader();

            reader.Read();
            
                Edital edital = new Edital();
                edital.id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("orgao")))
                    edital.orgao = reader.GetString("orgao");
                
                if (!reader.IsDBNull(reader.GetOrdinal("banca")))
                    edital.banca = reader.GetString("banca");

                if (!reader.IsDBNull(reader.GetOrdinal("cargo")))
                    edital.cargo = reader.GetString("cargo");

                if (!reader.IsDBNull(reader.GetOrdinal("remuneracao")))
                    edital.remuneracao = reader.GetDouble("remuneracao");

                if (!reader.IsDBNull(reader.GetOrdinal("vagas")))
                    edital.vagas = reader.GetInt32("vagas");


            conexao.Close();

            return edital;
        }

        public void Apaga(int id)
        {
            conexao.Open();
            
            string sql = "DELETE FROM editais WHERE id = " + id;
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
}