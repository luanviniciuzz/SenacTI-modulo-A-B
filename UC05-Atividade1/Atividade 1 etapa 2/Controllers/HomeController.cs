using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atividade_1_etapa_2.Models;

namespace Atividade_1_etapa_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Etiqueta()
        {
            Pedido pedido = new Pedido();
            pedido.descricao = "Agua";
            pedido.valor_unitario = 2.00M;
            pedido.quantidade = 1;
            return View(pedido);
        }
        public IActionResult ItemPedido()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ItemPedido(Pedido pedido)
        {
            Dados.PedidoAtual(pedido);
            return View("Registrado");
        }
        public IActionResult Listagem()
        {
            List<Pedido> pedidos = Dados.Listar();
            return View(pedidos);

        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
