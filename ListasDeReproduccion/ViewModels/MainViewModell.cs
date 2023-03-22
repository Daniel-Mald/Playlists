using GalaSoft.MvvmLight.Command;
using ProyectoListasdeReproduccion.ViewModels;
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

namespace ProyectoListasdeReproduccion.ViewModels
{
    public class MainViewModell : INotifyPropertyChanged
    {
        CancionViewModel CancionVM = new CancionViewModel();
        ListasViewModel ListasVM = new ListasViewModel();
        EstadisticaViewModel EstadisticaVM = new EstadisticaViewModel();
        private object vmactual;

        public event PropertyChangedEventHandler? PropertyChanged;

        public object VMactual
        {
            get { return vmactual; }
            set { vmactual = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null)); ; }
        }
        public ICommand NavegarCancionesCommand { get; set; }
        public ICommand NavegarListasCommand { get; set; }
        public ICommand NavegarEstadisticaCommand { get; set; }
        public MainViewModell()
        {
            NavegarCancionesCommand = new RelayCommand(NavegarCanciones);
            NavegarListasCommand = new RelayCommand(NavegarListas);
            NavegarEstadisticaCommand = new RelayCommand(NavegarEstadistica);
            
            vmactual = ListasVM;

        }
        public void NavegarEstadistica()
        {
            EstadisticaVM = new();
            VMactual = EstadisticaVM;
            OnPropertyChanged();
        }
        public void NavegarCanciones()
        {
            CancionVM = new();
            vmactual = CancionVM;
            OnPropertyChanged();
        }
        public void NavegarListas()
        {

            ListasVM.CargarListas();
            vmactual = ListasVM;
            OnPropertyChanged();
        }

        public void OnPropertyChanged(string? a = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(a));
        }
    }
}
