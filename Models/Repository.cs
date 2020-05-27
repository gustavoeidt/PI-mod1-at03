using MySql.Data.MySqlClient;

namespace at03.Models
{
    public abstract class Repository
    {
        protected const string _strConexao = "Database=infocon;Data Source=localhost;User Id=root;";
        protected MySqlConnection conexao = new MySqlConnection(_strConexao);
    }
}