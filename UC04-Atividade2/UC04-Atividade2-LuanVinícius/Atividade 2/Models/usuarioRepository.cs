using System;

namespace Atividade_2.Models
{
    public class usuarioRepository
    {
        public int idUsuario {get; set;}
        public string nomeUsuario {get; set;}
        public DateTime dtNascimento {get; set;}
        public string login {get; set;}
        public string senha {get; set;}
        public string tipo {get; set;}
    }
}