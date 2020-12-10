using System;
using System.Collections.Generic;

namespace Atividade_1
{
    class ItemPedido
    {
        static void Main(string[] args)
        {
        Console.WriteLine("Cadastre um Produto");

        List<Pedido> listaPedidos = new List<Pedido>();        

        string opcao = "";
        while(opcao != "2")
        {
            Pedido pt = new Pedido();
            Console.WriteLine("Descrição do produto:");            
            pt.descricao=Console.ReadLine();
            Console.WriteLine("O valor unitário do produto:");
            pt.valorUnitario=Console.ReadLine();
            Console.WriteLine("A quantidade de produtos");
            pt.quantidade=Console.ReadLine();
            
            listaPedidos.Add(pt);
            Console.WriteLine("Adcionar mais: (1) Cancelar: (2)");
            opcao = Console.ReadLine();
            
        }

        for(int i = 0; i < listaPedidos.Count; i++)
        {
            string texto = listaPedidos[i].ConvertString();
            Console.WriteLine(texto);
        }
        }
    }
}
