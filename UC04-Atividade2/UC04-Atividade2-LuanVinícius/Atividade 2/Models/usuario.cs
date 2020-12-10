using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

namespace Atividade_2.Models
{
    public class usuario : Repository
    {
        public void insercao(usuarioRepository p)
        {   
            MySqlConnection conexao = new MySqlConnection (_strConexao);
            conexao.Open();
            string sql = "insert into usuario(nomeUsuario, dtNascimento, login, senha, tipo) values(@nomeUsuario, @dtNascimento, @login, @senha, @tipo);";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@nomeUsuario", p.nomeUsuario);
            comando.Parameters.AddWithValue("@dtNascimento", p.dtNascimento);
            comando.Parameters.AddWithValue("@login", p.login);
            comando.Parameters.AddWithValue("@senha", p.senha);
            comando.Parameters.AddWithValue("@tipo", p.tipo);            
            comando.ExecuteNonQuery();
            conexao.Close();            
        }
    

        public void alterar(usuarioRepository p)
        {
            conexao.Open();
            string sql = "update pacote set nomeUsuario=@nomeUsuario, dtNascimento=@dtNascimento, login=@login, senha=@senha, tipo=@tipo, where idUsuario=@idUsuario";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@idUsuario",p.idUsuario);
            comando.Parameters.AddWithValue("@nomeUsuario", p.nomeUsuario);
            comando.Parameters.AddWithValue("@dtNascimento", p.dtNascimento);
            comando.Parameters.AddWithValue("@login", p.login);
            comando.Parameters.AddWithValue("@senha", p.senha);
            comando.Parameters.AddWithValue("@tipo", p.tipo);            
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void exclusao(usuarioRepository p)
        {
            conexao.Open();
            string sql = "delete from usuario where idUsuario=@idUsuario";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@idUsuario", p.idUsuario);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<usuarioRepository> Lista()
        {
            conexao.Open();
            string sql = "select * from usuario;";
            MySqlCommand comando = new MySqlCommand (sql, conexao);
            MySqlDataReader reader = comando.ExecuteReader();
            List<usuarioRepository> lista = new List<usuarioRepository>();

            while(reader.Read())
            {
                usuarioRepository usr= new usuarioRepository();
                usr.idUsuario=reader.GetInt32("idUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
                    usr.nomeUsuario=reader.GetString("nomeUsuario");
                
                if(!reader.IsDBNull(reader.GetOrdinal("dtNascimento")))
                    usr.dtNascimento=reader.GetDateTime("dtNascimento");
                
                if(!reader.IsDBNull(reader.GetOrdinal("login")))
                    usr.login=reader.GetString("login");
                
                if(!reader.IsDBNull(reader.GetOrdinal("senha")))
                    usr.senha=reader.GetString("senha");
                
                if(!reader.IsDBNull(reader.GetOrdinal("tipo")))
                    usr.tipo=reader.GetString("tipo");             
                            
                lista.Add(usr);                            

            }            
            conexao.Close();
            return lista;
        }
        public usuarioRepository Autentica(usuarioRepository p)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "select * from usuario where login=@login and senha=@senha;";
            MySqlCommand comandoAutentica = new MySqlCommand(sql, conexao);
            comandoAutentica.Parameters.AddWithValue("@login", p.login);
            comandoAutentica.Parameters.AddWithValue("@senha", p.senha);
            MySqlDataReader reader = comandoAutentica.ExecuteReader();
            usuarioRepository ur = null;
            if(reader.Read())
            {
                ur = new usuarioRepository();
                ur.idUsuario = reader.GetInt32("idUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
                    ur.nomeUsuario = reader.GetString("nomeUsuario");
                
                if(!reader.IsDBNull(reader.GetOrdinal("login")))
                    ur.login = reader.GetString("login");
                if(!reader.IsDBNull(reader.GetOrdinal("senha")))
                    ur.senha = reader.GetString("senha");                
                if(!reader.IsDBNull(reader.GetOrdinal("tipo")))
                    ur.tipo = reader.GetString("tipo");
            }
            conexao.Close();
            return ur;
        }
    }
}