using ProyectoListasdeReproduccion.Catalogos;
using ProyectoListasdeReproduccion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasDeReproduccion.ViewModels
{
    public class EstadisticaViewModel : INotifyPropertyChanged
    {
        public EstadisticaViewModel()
        {
            ConvertirANumeros();
        }
        CancionCatalogo catalogocancion = new();
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<CancionYDuracion> listadecyd { get; set; } = new();
        public void ConvertirANumeros()
        {
            listadecyd.Clear();
            foreach (var item in catalogocancion.GetCanciones())
            {
                CancionYDuracion a = new()
                {
                    cancion = item,
                    Sec = Convertir(item.Duracion!= null ?item.Duracion: "0:0")
                };
                listadecyd.Add(a);

                
            }
            listadecyd.OrderBy(x => x.Sec);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public int Convertir(string tiempo)
        {
            int segundos = 0;
            string[] a = tiempo.Split(':');
            if(a.Length == 2)
            {
                segundos += int.Parse(a[0]);
                segundos += int.Parse(a[1]);
            }
            return segundos;
        }
        
    }
    public class CancionYDuracion
    {
        public Canciones cancion { get; set; }
        public int Sec { get; set; }
    }
}
