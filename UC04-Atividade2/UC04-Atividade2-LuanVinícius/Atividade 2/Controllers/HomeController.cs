using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atividade_2.Models;
using Microsoft.AspNetCore.Http;

namespace Atividade_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(usuarioRepository u)
        {
            usuario ur = new usuario();
            ur.insercao(u);
            ViewBag.Mensagem = "Usuario Cadastrado com sucesso";
            return View();
        }
        public IActionResult CadastroColaborador()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult CadastroColaborador(usuarioRepository u)
        {        
                       
            usuario ur = new usuario();
            ur.insercao(u);
            ViewBag.Mensagem = "Colaborador Cadastrado com sucesso";
            return View();
                
        }

        public IActionResult Index()
        {
            return View();
        }      

        public IActionResult Privacy()
        {
            return View();
        }
         public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(usuarioRepository p)
        {
            usuario ur = new usuario();
            usuarioRepository usuarioRepository = ur.Autentica(p);
            if(usuarioRepository != null)
            {
                ViewBag.Mensagem = "Você está logado";
                HttpContext.Session.SetInt32("idUsuario", usuarioRepository.idUsuario);
                HttpContext.Session.SetString("nomeUsuario", usuarioRepository.nomeUsuario);
                HttpContext.Session.SetString("tipo", usuarioRepository.tipo);
                return Redirect("Index");
            }
            else
            {
                ViewBag.Mensagem = "Falha no Login";
                return View();
            }
        }
        public IActionResult Logout()
            {
                HttpContext.Session.Clear();//limpa toda a sessão // NÃO IMPLEMENTADO
                return View();
            }        
        public IActionResult Pacotes()
        {
            if(HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("Login");
            return View();            
        }
        public IActionResult Quem()
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
