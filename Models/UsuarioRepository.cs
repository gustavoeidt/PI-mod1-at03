using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace at03.Models
{
    public class UsuarioRepository : Repository
    {
        public void Cadastra (Usuario u)
        {
            conexao.Open();

            string sql = "INSERT INTO usuarios (usuario, senha) VALUES (@usuario, @senha)";

            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@usuario", u.usuario);
            comando.Parameters.AddWithValue("@senha", u.senha);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void Atualiza (Usuario u)
        {
            conexao.Open();

            string sql = "UPDATE usuarios SET usuario = @usuario , senha = @senha WHERE id = @id";

            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@usuario", u.usuario);
            comando.Parameters.AddWithValue("@senha", u.senha);
            comando.Parameters.AddWithValue("@id", u.id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public List<Usuario> Lista()
        {
            conexao.Open();
            
            string sql = "SELECT * FROM usuarios ORDER BY nome";
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            
            MySqlDataReader reader = comando.ExecuteReader();
            List<Usuario> lista = new List<Usuario>();

            while(reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("usuario")))
                    usuario.usuario = reader.GetString("usuario");

                if (!reader.IsDBNull(reader.GetOrdinal("senha")))
                    usuario.senha = reader.GetString("senha");

                lista.Add(usuario);
            }

            conexao.Close();

            return lista;
        }

        public Usuario Lista(int id)
        {
            conexao.Open();
            
            string sql = "SELECT * FROM usuarios WHERE id = " + id;
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            MySqlDataReader reader = comando.ExecuteReader();

            reader.Read();
            
                Usuario usuario = new Usuario();
                usuario.id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("usuario")))
                    usuario.usuario = reader.GetString("usuario");

                if (!reader.IsDBNull(reader.GetOrdinal("senha")))
                    usuario.senha = reader.GetString("senha");

            conexao.Close();

            return usuario;
        }

        public void Apaga(int id)
        {
            conexao.Open();
            
            string sql = "DELETE FROM usuarios WHERE id = " + id;
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
}