using MySql.Data.MySqlClient;

namespace Atividade_2.Models
{
    public class Repository
    {
        protected const  string _strConexao = "Database=pacotedeviagens; Data Source = localhost; User Id=root;";

      
        public MySqlConnection conexao = new MySqlConnection (_strConexao);
        
    }
}