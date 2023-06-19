using System;
using System.Collections.Generic;
using System.Text;
//colocar para que la clase use los componentes modelos
using System.ComponentModel;
using Xamarin.Forms;
using Heroes.Views;
using Heroes.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Heroes.ViewModels
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {

        //Ruta de guardado de serializacion
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Usuarios.bin");






        //Metodo Construtor del ViewModelMainPage
        public ViewModelMainPage()
        {

            

            try
            {
                // Abrir y leer el archivo
                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formatter = new BinaryFormatter();
                u = (Usuarios)formatter.Deserialize(memory);
                memory.Close();
            }
            catch (FileNotFoundException)
            {
                // El archivo no existe, se crea una nueva lista vacía
                u = new Usuarios();
            }

           

            navegarCrearUsuario = new Command(async () =>
            {
                //vse está llamando al constructor predeterminado de la clase para crear un nuevo objeto de esa clase.
                ////Luego, se asigna este nuevo objeto a la variable pagina, lo que permite acceder y manipular el objeto 
                ///posteriormente en el código.
                var pagina = new ViewCreacionUsuario();


                //Secuencia de comando que recibe "pagina" para navegar con un pushasync al view de creacion de usuarios
                await Application.Current.MainPage.Navigation.PushAsync(pagina);

            });

            autenticar = new Command(() =>
            {

                if (u.autenticacion(this.Usuario, this.Password) == true) 
                {

                    var pagina = new ViewMenuHeroes();

                    Application.Current.MainPage.Navigation.PushAsync(pagina);

                }
                else 
                {

                    resultado = "Error en la autenticacion";
                
                }







            });


        }

        Usuarios u;

        public Usuarios U
        {
            get => u;

            set
            {
                u = value;
                OnPropertyChanged(nameof(U));
            }
        }


        string resultado;

        public string Resultado
        {
            get => resultado;

            set
            {
                resultado = value;
                OnPropertyChanged(nameof(Resultado));
            }
        }

        //variable Privada usuario
        string usuario;

        //Varible publica Usuario que recibira los datos y dalar valor a la variable privada usuario
        public string Usuario
        {
            get => usuario;

            set { 
                usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }

        //variable privada password
        string password;

        //Varible publica Password que recibira los datos y dalar valor a la variable privada password
        public string Password
        {
            get => password;

            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        //nuevo comando para navegar a la pagina de crear usuario
        public Command navegarCrearUsuario { get;}
        public Command autenticar { get; }


        //Void Privado para hacer el PropertyChanged?.Invoke de las variables en la clase
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //Implementacion de Interfaz de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
