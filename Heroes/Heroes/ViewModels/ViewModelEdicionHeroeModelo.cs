using Heroes.Models;
using System;
using Heroes.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Heroes.ViewModels
{
    public class ViewModelEdicionHeroeModelo:INotifyPropertyChanged
    {


        public ViewModelEdicionHeroeModelo(Heroe_Modelo ObjetoSeleccionado)
        { 
        
        
        
        
        
        
        
        }

        public Heroe_Modelo ObjetoSeleccionado { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
