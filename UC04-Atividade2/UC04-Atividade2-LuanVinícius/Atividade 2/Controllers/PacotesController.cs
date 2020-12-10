using System.Collections.Generic;
using Atividade_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_2.Controllers
{
    public class PacotesController : Controller
    {
         public IActionResult Index()
        {   
            if(HttpContext.Session.GetString("tipo") == null)
            return RedirectToAction("Login");         
            pacote pacotes = new pacote();
            List<pacoteRepository> listadepacotes = pacotes.Lista();
            return View(listadepacotes);            
        }        
        public IActionResult Detalhes(int idPacote)
        {        
            pacote pacotes = new pacote();
            List<pacoteRepository> listadepacotes = pacotes.Lista();
            var result = listadepacotes.Find(p=>p.idPacote == idPacote);   
            return View(result); 
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
        public IActionResult CadastrarPacote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarPacote(pacoteRepository p)
        {
            pacote pac = new pacote();
            pac.insercao(p);
            ViewBag.Mensagem = "Pacote Cadastrado com sucesso";
            return View();
        }
        [HttpGet]
        public IActionResult ExcluirPacote(int idPacote)
        {   
            var exc = new pacote().exclusao(idPacote);
            ViewBag.Mensagem= exc + "Pacote excluído";
            
            
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int idPacote)
        {
            pacote pacotes = new pacote();
            List<pacoteRepository> listadepacotes = pacotes.Lista();
            var result = listadepacotes.Find(p=>p.idPacote == idPacote);   
            return View(result);
        }
        [HttpPost]
         public IActionResult Editar(pacoteRepository p)
        {
            pacote pacotes = new pacote();
            pacotes.alterar(p);
              
            return RedirectToAction("Index");
        }
    }
}