using GalaSoft.MvvmLight.Command;
using ProyectoListasdeReproduccion.Catalogos;
using ProyectoListasdeReproduccion.Models;
using ProyectoListasdeReproduccion.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProyectoListasdeReproduccion.Views;

namespace ProyectoListasdeReproduccion.ViewModels
{
    public class CancionViewModel:INotifyPropertyChanged
    {
        public CancionCatalogo catalogo = new CancionCatalogo();
       public  ListasCatalogo catalogolista = new();
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Error { get; set; } = "";
        public Listas? ListaID { get; set; }
        public Accion Operacion { get; set; }
        public Canciones? Cancion { get; set; } 
        public ObservableCollection<Canciones> ListaCanciones { get; set; } = new();
        public List<Listas> listalista { get; set; } = new();

        public ICommand VerAgregarCancionCommadn { get; set; }
        public ICommand AgregarCancionCommand { get; set; }
        public ICommand VerEliminarCancionCommand { get; set; }
        public ICommand EliminarCancionCommand { get; set; }
        public ICommand RegresarCommand { get; set; }

        public CancionViewModel()
        {
            VerAgregarCancionCommadn = new RelayCommand(VerAgregarCancion);
            AgregarCancionCommand = new RelayCommand(AgregarCancion);
            VerEliminarCancionCommand = new RelayCommand<int>(VerEliminarCancion);
            EliminarCancionCommand = new RelayCommand(EliminarCancion);
            RegresarCommand = new RelayCommand(Regresar);
            Operacion = Accion.VerCanciones;
            LlenarListaCanciones();
        }
        public void LlenarListaCanciones()
        {
            ListaCanciones.Clear();
            foreach (var item in catalogo.GetCanciones())               
            {
                ListaCanciones.Add(item);
            }
            OnPropertyChanged();
        }
        public void Listalista()
        {
            listalista.Clear();
            foreach (var item in catalogolista.GetListas())
            {
                listalista.Add(item);
            }

        }
        public void LlenarListaPorLista(Listas l)
        {
            ListaCanciones.Clear();
            foreach (var item in catalogo.GetCancionesXLista(l))
            {
                ListaCanciones.Add(item);
            }
            OnPropertyChanged();
        }
        public void VerAgregarCancion()
        {
            Cancion = new();
            Operacion = Accion.AgregarCanciones;
            Listalista();
            OnPropertyChanged();
        }
        public void AgregarCancion()
        {
            if(Cancion != null)
            {
                
                Cancion.ListaId = ListaID.Id;
                if (catalogo.validar(Cancion, out List<string> errores))
                {
                    catalogo.Create(Cancion);
                    LlenarListaCanciones();
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
                
            }
            

        }
        public void VerEliminarCancion(int id)
        {
            Cancion = catalogo.GetCancion(id);
            
            Operacion = Accion.EliminarCanciones;
            OnPropertyChanged();
            
        }
        public void EliminarCancion()
        {
            if(Cancion != null)
            {
                catalogo.Delete(Cancion);
                Regresar();
                LlenarListaCanciones();
            }
            
        }
        public void Regresar()
        {
            Operacion = Accion.VerCanciones;
            OnPropertyChanged();
        }
        public void OnPropertyChanged(string? a = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(a));
        }
    }
}
