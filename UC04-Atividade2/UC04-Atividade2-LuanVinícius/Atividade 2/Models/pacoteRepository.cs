using System;

namespace Atividade_2.Models
{
    public class pacoteRepository
    {
        public int idPacote {get; set;}
        public string nomePacote {get; set;}
        public string origem {get; set;}
        public string destino {get; set;}
        public string atrativos {get; set;}
        public DateTime saida {get; set;}
        public DateTime retorno {get; set;}
    }
}