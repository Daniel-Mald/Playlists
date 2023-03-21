using Microsoft.EntityFrameworkCore;
using ProyectoListasdeReproduccion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoListasdeReproduccion.Catalogos
{
    public  class ListasCatalogo
    {
        ListasdereproduccionContext contenedor = new ListasdereproduccionContext();
        public IEnumerable<Listas> GetListas()
        {
            return contenedor.Listas.Include(x=>x.Canciones).OrderBy(x=>x.Nombre);
        }
        public void Create(Listas l)
        {
            contenedor.Database.ExecuteSqlRaw($"call spAgregarLista ('{l.Nombre}', '{l.Descripcion}','{l.Creador}')");
            contenedor.SaveChanges();
        }
        public void Delete(Listas l)
        {
            contenedor.Database.ExecuteSqlRaw($"call spEliminarLista ({l.Id})");
            contenedor.SaveChanges();
        }
        public Listas? GetLista(int id)
        {
            Listas? s = contenedor.Listas.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                return s;
            }
            else
            {
                return null;
            }

        }
        public bool validar(Listas l, out List<string> errores)
        {
            errores = new List<string>();
            if (string.IsNullOrWhiteSpace(l.Descripcion))
                errores.Add("No has agregado una descripcion");
            if (string.IsNullOrWhiteSpace(l.Nombre))
                errores.Add("Falta agregar un nombre");
            if(string.IsNullOrWhiteSpace(l.Creador))
                errores.Add($"Debes escribir un creador");

            if(errores.Count() == 0)
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
