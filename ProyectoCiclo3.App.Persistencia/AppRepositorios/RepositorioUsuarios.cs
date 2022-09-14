using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuarios
    {
        List<Usuario> usuarios;
 
    public RepositorioUsuarios()
        {
            usuarios= new List<Usuario>()
            {
               new Usuario{id=1,nombre="Alejandra",apellido= "Lievano",direccion= "Cra 8 # 10 - 88",telefono= "3133359123"},
               new Usuario{id=2,nombre="ALexis",apellido= "Lievano",direccion= "Cra 8 # 10 - 88",telefono= "3207941274"},
               new Usuario{id=3,nombre="Anilvia",apellido= "Atehortua",direccion= "Cra 8 # 10 - 88",telefono= "3115952115"}
            };
        }
 
        public IEnumerable<Usuario> GetAll()
        {
            return usuarios;
        }
 
        public Usuario GetWithId(int id)
        {
            return usuarios.SingleOrDefault(e => e.id == id);
        }

        public Usuario Create(Usuario newUsuario)
        {
           if(usuarios.Count > 0){
             newUsuario.id=usuarios.Max(r => r.id) +1; 
            }else{
               newUsuario.id = 1; 
            }
           usuarios.Add(newUsuario);
           return newUsuario;
        }

        public Usuario Update(Usuario newUsuario)
        {
            var usuario = usuarios.SingleOrDefault(e => e.id == newUsuario.id);
            if(usuario != null){
                usuario.nombre = newUsuario.nombre;
                usuario.apellido = newUsuario.apellido;
                usuario.direccion = newUsuario.direccion;
                usuario.telefono = newUsuario.telefono;
            }
        return usuario;
        }

        public Usuario Delete(int id)
        {
            var usuario = usuarios.SingleOrDefault(e => e.id == id);
            usuarios.Remove(usuario);
            return usuario;
        }
    }
}