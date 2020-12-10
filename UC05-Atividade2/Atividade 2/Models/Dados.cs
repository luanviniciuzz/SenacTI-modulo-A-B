using System.Collections.Generic;

namespace Atividade_2.Models
{
    public static class Dados
    {
        private static List<PreAgendamento> agendamentos = new List<PreAgendamento>();
        public static void PedidoAtual(PreAgendamento a)
        {
            agendamentos.Add(a);
        }
        public static List<PreAgendamento> Listar()
        {
            return agendamentos;
        }
    }
}