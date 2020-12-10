using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        
        public IActionResult Cadastro()
        {      
            Autenticacao.CheckLogin(this);      
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {         
            UsuarioService usuarioService = new UsuarioService();                 
            
                if(u.Id == 0)
                {
                    usuarioService.Inserir(u);
                }
                else
                {
                    usuarioService.Atualizar(u);
                }
                return RedirectToAction("Listagem");
                       
        }
        public IActionResult Listagem(string tipoFiltroUsuario, string filtroUsuario)
        {
            Autenticacao.CheckLogin(this);
            FiltrosUsuario objFiltro = null;
            if(!string.IsNullOrEmpty(filtroUsuario))
            {
                objFiltro = new FiltrosUsuario();
                objFiltro.FiltroUsuario = filtroUsuario;
                objFiltro.TipoFiltroUsuario = tipoFiltroUsuario;
            }
            UsuarioService usuarioService = new UsuarioService();
            return View(usuarioService.ListarTodos(objFiltro));
        }
        public IActionResult Edicao(int Id)
        {
            
            UsuarioService us = new UsuarioService();
            Usuario u = us.ObterPorId(Id);
            return View(u);
        }
        [HttpGet]
        public IActionResult ExcluirUsuario(int Id)
        {   
            var exc = new UsuarioService().Excluir(Id);           
            
            
            return RedirectToAction("Listagem");
        }                
    }
}