using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
//using GalaSoft.MvvmLight.CommandWpf;
using ProyectoListasdeReproduccion.Catalogos;
using ProyectoListasdeReproduccion.Models;
using ProyectoListasdeReproduccion.Views;

namespace ProyectoListasdeReproduccion.ViewModels
{
    public class ListasViewModel : INotifyPropertyChanged
    {
        ListasCatalogo catalogo = new ListasCatalogo();
        CancionCatalogo catalogocancion = new();
        public Accion Operacion { get; set; }
        public Listas? Lista { get; set; } = new Listas();
        public ObservableCollection<Listas> ListaDeListas { get; set; } = new();
        public List<Canciones> ListaCancionesPorLista { get; set; } = new();
        public string Error { get; set; } = "";
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand VerRegistrarListaCommand { get; set; }
        public ICommand RegistrarListaCommand { get; set; }
        public ICommand VerEliminarListaCommand { get; set; }
        public ICommand EliminarListaCommand { get; set; }
        public ICommand VerCancionesDeListaCommand { get; set; }
        public ICommand RegresarCommand { get; set; }

        public ListasViewModel()
        {
            VerCancionesDeListaCommand = new RelayCommand<int>(LlenarListaCancionXLista);
            VerRegistrarListaCommand = new RelayCommand(VerRegistrarLista);
            RegistrarListaCommand = new RelayCommand(RegistrarLista);
            VerEliminarListaCommand = new RelayCommand<int>(VerEliminarLista);
            EliminarListaCommand = new RelayCommand(EliminarLista);
            RegresarCommand = new RelayCommand(Regresar);
            Operacion = Accion.VerListas;
            CargarListas();
        }
        public void OnPropertyChanged(string? o = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(o));
        }
        public void LlenarListaCancionXLista(int id)
        {
            var a = catalogo.GetLista(id);
            Operacion = Accion.VerCancionesDeLista;
            ListaCancionesPorLista.Clear();
            foreach (var item in catalogocancion.GetCancionesXLista(a))
            {
                ListaCancionesPorLista.Add(item);
            }
            OnPropertyChanged();
        }
        public void VerRegistrarLista()
        {
            Lista = new();
            Operacion = Accion.AgregarListas;
            OnPropertyChanged();
        }
        public void RegistrarLista() 
        {
            if(Lista!= null)
            {

                if (catalogo.validar(Lista , out List<string> errores))
                {
                    catalogo.Create(Lista);
                    
                    Regresar();
                }
                else
                {
                    Error = "";
                    
                    foreach (var item in errores)
                    {
                        Error = $"{Error} {item} {Environment.NewLine}";
                    }
                    OnPropertyChanged();
                }
                CargarListas();
            }
            
        }
        public void VerEliminarLista(int id)
        {
            Lista = catalogo.GetLista(id);
            Operacion = Accion.EliminarListas;
            OnPropertyChanged();
        }
        public void EliminarLista()
        {
            if(Lista != null)
            {
                catalogo.Delete(Lista);
                Regresar();
            }
        }
        public void Regresar()
        {
            Operacion = Accion.VerListas;
            OnPropertyChanged();
        } 
        public void CargarListas()
        {
            ListaDeListas.Clear();
            foreach (var item in catalogo.GetListas())
            {
                ListaDeListas.Add(item);
            }
        }
    }
}
