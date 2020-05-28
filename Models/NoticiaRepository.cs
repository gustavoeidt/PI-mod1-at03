using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace at03.Models
{
    public class NoticiaRepository : Repository
    {
        public void Cadastra (Noticia n, Usuario u)
        {
            conexao.Open();

            string sql = "INSERT INTO noticias (titulo, texto, data, usuario_id) VALUES (@titulo, @texto, @data, @usuario_id)";

            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@titulo", n.titulo);
            comando.Parameters.AddWithValue("@texto", n.texto);
            comando.Parameters.AddWithValue("@data", n.data);
            comando.Parameters.AddWithValue("@usuario_id", u.id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void Atualiza (Noticia n, Usuario u)
        {
            conexao.Open();

            string sql = "UPDATE noticias SET titulo = @titulo , texto = @texto, data = @data, usuario_id = @usuario_id WHERE id = @id";

            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@titulo", n.titulo);
            comando.Parameters.AddWithValue("@texto", n.texto);
            comando.Parameters.AddWithValue("@data", n.data);
            comando.Parameters.AddWithValue("@id", n.id);
            comando.Parameters.AddWithValue("@usuario_id", u.id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public List<Noticia> Lista()
        {
            conexao.Open();
            
            string sql = "SELECT * ,usuarios.nome AS autor FROM noticias LEFT JOIN usuarios USING (id) ORDER BY noticias.data DESC";
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            
            MySqlDataReader reader = comando.ExecuteReader();
            List<Noticia> lista = new List<Noticia>();

            while(reader.Read())
            {

                Noticia noticia = new Noticia();
                noticia.id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("titulo")))
                    noticia.titulo = reader.GetString("titulo");
                
                if (!reader.IsDBNull(reader.GetOrdinal("texto")))
                    noticia.texto = reader.GetString("texto");

                if (!reader.IsDBNull(reader.GetOrdinal("data")))
                    noticia.data = reader.GetDateTime("data");

                if (!reader.IsDBNull(reader.GetOrdinal("usuario_id")))
                    noticia.usuario_id = reader.GetInt32("usuario_id");

                if (!reader.IsDBNull(reader.GetOrdinal("autor")))
                    noticia.autor = reader.GetString("autor");

                lista.Add(noticia);
            }

            conexao.Close();

            return lista;
        }

        public Noticia Lista(int id)
        {
            conexao.Open();
            
            string sql = "SELECT * ,usuarios.nome AS autor FROM noticias LEFT JOIN usuarios USING (id) WHERE pacotes.id = " + id;
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            MySqlDataReader reader = comando.ExecuteReader();

            reader.Read();
            
                Noticia noticia = new Noticia();
                noticia.id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("titulo")))
                    noticia.titulo = reader.GetString("titulo");
                
                if (!reader.IsDBNull(reader.GetOrdinal("texto")))
                    noticia.texto = reader.GetString("texto");

                if (!reader.IsDBNull(reader.GetOrdinal("data")))
                    noticia.data = reader.GetDateTime("data");

                if (!reader.IsDBNull(reader.GetOrdinal("usuario_id")))
                    noticia.usuario_id = reader.GetInt32("usuario_id");

                if (!reader.IsDBNull(reader.GetOrdinal("autor")))
                    noticia.autor = reader.GetString("autor");


            conexao.Close();

            return noticia;
        }

        public void Apaga(int id)
        {
            conexao.Open();
            
            string sql = "DELETE FROM noticias WHERE id = " + id;
            MySqlCommand comando = new MySqlCommand(sql,conexao);
            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
}