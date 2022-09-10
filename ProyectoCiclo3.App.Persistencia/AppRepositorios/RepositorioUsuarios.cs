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
              /*  new Encomienda{id=1,descripcion="Camiseta",peso= 100,tipo= "Ropa",presentacion= "Caja"},
                new Encomienda{id=2,descripcion="Disco Duro",peso= 200,tipo= "Electronico",presentacion= "Caja"},
                new Encomienda{id=3,descripcion="Destornilladores",peso= 130,tipo= "Electronico",presentacion= "Caja"}*/
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