using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }       
        public IActionResult Index()
        {   
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Models.Usuario login)
        {
            Models.BibliotecaContext uc = new BibliotecaContext();
            Models.Usuario logou = uc.Usuarios.FirstOrDefault(x=> x.LoginUsuario == login.LoginUsuario && x.SenhaUsuario == login.SenhaUsuario);

            if(logou == null)
            {
                ViewData["Mensagem"] = "Usuário ou Senha inválidos";
                return View("Login");
            }
            else{   
                HttpContext.Session.SetString("user", "admin");            
                return RedirectToAction("Index");
            }
        }


            public IActionResult Privacy()
        {
            return View();
        }
        }        
    }

