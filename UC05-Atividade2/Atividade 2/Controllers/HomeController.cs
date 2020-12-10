using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atividade_2.Models;

namespace Atividade_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Agendamento()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agendamento(PreAgendamento preagend)
        {
            Dados.PedidoAtual(preagend);
            List<PreAgendamento> listaPreAgendamento = Dados.Listar();
            ViewBag.nome = preagend.nome;
            ViewBag.telefone = preagend.telefone;
            ViewBag.data = preagend.data;
            ViewBag.animal = preagend.necessidade;
            return View("Registrado");
        }

        public IActionResult Serviços()
        {
            return View();
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
