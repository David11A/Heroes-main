using Heroes.Models;
using Heroes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Text;
using Xamarin.Forms;

namespace Heroes.ViewModels
{
    public class VMMenuHeroe : INotifyPropertyChanged
    {
        //Metodo Constructor
        public VMMenuHeroe() 
        {

            ListaMenu.Add(new MenuHeroes()
            {
                texto="Ver Lista de Heroes",
                imagen = "HeroesDC.png"

            });

            ListaMenu.Add(new MenuHeroes()
            {
                texto = "Crear Heroe Modelo",
                imagen = "Modelos.jpeg"

            });

            ListaMenu.Add(new MenuHeroes()
            {
                texto = "Salir",
                imagen = "exit.jpeg"

            });

            Redireccion = new Command( ()=>
            {
                //Switch segun la opcion seleccionada con el texto de la lista del MenuHeroes
                switch (OpcionSeleccionada.texto)
                {
                    case "Ver Lista de Heroes":
                        var pagina3 = new ViewListaHeroes();
                        Application.Current.MainPage.Navigation.PushAsync(pagina3);

                        break;

                    case "Crear Heroe Modelo":

                        var pagina = new ViewHeroeModelo();
                        Application.Current.MainPage.Navigation.PushAsync( pagina );


                        break;

                    case "Salir":

                        var pagina2 = new MainPage();
                        Application.Current.MainPage.Navigation.PushAsync(pagina2);

                        break;
                }


            });

        }


        MenuHeroes opcionSeleccionada;

        public MenuHeroes OpcionSeleccionada 
        { 
            get => opcionSeleccionada;
            set
            {
                opcionSeleccionada = value;
                OnPropertyChanged(nameof(OpcionSeleccionada));
            }
         
        }

        //Definicion de Comando publico con metodo get
        public Command Redireccion { get; }




        // observable collection de Lista de para menu de Heroes, la coleccion no se puede crear de una super clase
        public ObservableCollection<MenuHeroes> ListaMenu { get; set; } = new ObservableCollection<MenuHeroes>();



        //Void Privado para hacer el PropertyChanged?.Invoke de las variables en la clase
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
