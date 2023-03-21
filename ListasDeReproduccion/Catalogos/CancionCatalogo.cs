using Microsoft.EntityFrameworkCore;
using ProyectoListasdeReproduccion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoListasdeReproduccion.Catalogos;

namespace ProyectoListasdeReproduccion.Catalogos
{
    public class CancionCatalogo
    {
        ListasdereproduccionContext contenedor = new ListasdereproduccionContext();
        ListasCatalogo lc = new();
        public IEnumerable<Canciones> GetCanciones()
        {
            return contenedor.Canciones.OrderBy(x => x.Titulo);
        }
        public Canciones GetCancion(int id)
        {
            return contenedor.Canciones.FirstOrDefault(x=>x.Id == id);
        }
        public IEnumerable<Canciones> GetCancionesXLista(Listas l)
        {
            return contenedor.Canciones.Where(x=>x.ListaId == l.Id).OrderBy(x=>x.Titulo);
        }
        public void Create(Canciones c)
        {
            contenedor.Database.ExecuteSqlRaw($"call spAgregarCancion ('{c.Titulo}','{c.Artista}','{c.Duracion}','{c.Genero}',{c.ListaId})");
        }
        public void Delete(Canciones c)
        {
            contenedor.Database.ExecuteSqlRaw($"call spEliminarCancion ({c.Id})");
        }
        public bool validar(Canciones c, out List<string> errores)
        {
            errores = new List<string>();
            if (string.IsNullOrWhiteSpace(c.Titulo))
                errores.Add("No has agregado un titulo");
            if (string.IsNullOrWhiteSpace(c.Genero))
                errores.Add("Por favor añade el genero de la cancion");
            if (string.IsNullOrWhiteSpace(c.Artista))
                errores.Add("Debes escribir al artista que la escribio");
            //hacer un metodo para consultar si existe dicha lista
            if (lc.GetLista(c.ListaId) == null)
                errores.Add("No existe esa lista de reproduccion");

            if (errores.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
