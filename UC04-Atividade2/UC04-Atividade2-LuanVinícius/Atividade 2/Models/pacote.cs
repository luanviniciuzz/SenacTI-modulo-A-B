using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

namespace Atividade_2.Models
{
    public class pacote : Repository
    {
        public void insercao(pacoteRepository p)
        {
            conexao.Open();
            string sql = "insert into pacote(nomePacote, origem, destino, atrativos, saida, retorno) values (@nome, @origem, @destino, @atrativos, @saida, @retorno);";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@nome", p.nomePacote);
            comando.Parameters.AddWithValue("@origem", p.origem);
            comando.Parameters.AddWithValue("@destino", p.destino);
            comando.Parameters.AddWithValue("@atrativos", p.atrativos);
            comando.Parameters.AddWithValue("@saida", p.saida);
            comando.Parameters.AddWithValue("@retorno", p.retorno);
            comando.ExecuteNonQuery();
            conexao.Close();            
        }
        public void alterar(pacoteRepository p)
        {
            conexao.Open();
            string sql = "update pacote set nomePacote=@nomePacote, origem=@origem, destino=@destino, atrativos=@atrativos, saida=@saida, retorno=@retorno where idPacote=@idPacote";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@idPacote",p.idPacote);
            comando.Parameters.AddWithValue("@nomePacote", p.nomePacote);
            comando.Parameters.AddWithValue("@origem", p.origem);
            comando.Parameters.AddWithValue("@destino", p.destino);
            comando.Parameters.AddWithValue("@atrativos", p.atrativos);
            comando.Parameters.AddWithValue("@saida", p.saida);
            comando.Parameters.AddWithValue("@retorno", p.retorno);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public int exclusao(int idPacote)
        {
            conexao.Open();
            string sql = "delete from pacote where idPacote=@idPacote;";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@idPacote", idPacote);
            int val = comando.ExecuteNonQuery();
            conexao.Close();
            return val;
        }
        public List<pacoteRepository> Lista()
        {
            conexao.Open();
            string sql = "select * from pacote;";
            MySqlCommand comando = new MySqlCommand (sql, conexao);
            MySqlDataReader reader = comando.ExecuteReader();
            List<pacoteRepository> lista = new List<pacoteRepository>();

            while(reader.Read())
            {
                pacoteRepository u = new pacoteRepository();
                u.idPacote=reader.GetInt32("idPacote");                
                if(!reader.IsDBNull(reader.GetOrdinal("nomePacote")))
                    u.nomePacote=reader.GetString("nomePacote");
                
                if(!reader.IsDBNull(reader.GetOrdinal("origem")))
                    u.origem=reader.GetString("origem");
                
                if(!reader.IsDBNull(reader.GetOrdinal("destino")))
                    u.destino=reader.GetString("destino");
                
                if(!reader.IsDBNull(reader.GetOrdinal("atrativos")))
                    u.atrativos=reader.GetString("atrativos");
                
                if(!reader.IsDBNull(reader.GetOrdinal("saida")))
                    u.saida=reader.GetDateTime("saida");
                
                if(!reader.IsDBNull(reader.GetOrdinal("retorno")))
                    u.retorno=reader.GetDateTime("retorno");
                
                lista.Add(u);               

            }
            conexao.Close();
            return lista;
        }
    }
}