using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;



namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void Inserir(Usuario u)
        {
            using(BibliotecaContext uc = new BibliotecaContext())
            {   
                uc.Usuarios.Add(u);                               
                uc.SaveChanges();                                
            }
        }
        public void Atualizar(Usuario u)
        {
            using(BibliotecaContext uc = new BibliotecaContext())
            {
                Usuario Usuario = uc.Usuarios.Find(u.Id);
                Usuario.NomeUsuarioCadastro = u.NomeUsuarioCadastro;
                Usuario.CpfUsuario = u.CpfUsuario;
                Usuario.LoginUsuario = u.LoginUsuario;
                Usuario.SenhaUsuario = u.SenhaUsuario;


                uc.SaveChanges();
            }
        }
        public ICollection<Usuario> ListarTodos(FiltrosUsuario filtroUsuario = null)
        {
            using(BibliotecaContext uc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;
                
                if(filtroUsuario != null)
                {                    
                    switch(filtroUsuario.TipoFiltroUsuario)
                    {
                        case "NomeUsuarioCadastro":
                            query = uc.Usuarios.Where(u => u.NomeUsuarioCadastro.Contains(filtroUsuario.FiltroUsuario));
                        break;

                        case "CpfUsuario":
                            query = uc.Usuarios.Where(u => u.CpfUsuario.Contains(filtroUsuario.FiltroUsuario));
                        break;

                        default:
                            query = uc.Usuarios;
                        break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = uc.Usuarios;
                }
                
                //ordenação padrão
                return query.OrderBy(u => u.NomeUsuarioCadastro).ToList();
            }
        }
        public Usuario ObterPorId(int Id)
        {
            using(BibliotecaContext uc = new BibliotecaContext())
            {
                return uc.Usuarios.Find(Id);
            }
        }        
        public int Excluir(int Id)
        {
            using(BibliotecaContext uc = new BibliotecaContext())
            {
                uc.Usuarios.Remove(uc.Usuarios.Find(Id));
                uc.SaveChanges();
                return Id;
            }
        }
    }
}