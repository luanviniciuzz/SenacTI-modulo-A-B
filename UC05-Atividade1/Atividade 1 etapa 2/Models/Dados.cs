using System;
using System.Collections.Generic;

namespace Atividade_1_etapa_2.Models
{
    public static class Dados
    {
        private static List<Pedido> pedidos = new List<Pedido>();
        public static void PedidoAtual(Pedido pedido)
        {
            pedidos.Add(pedido);
        }
        public static List<Pedido> Listar()
        {
            return pedidos;
        }
    }
}