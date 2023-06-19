using Heroes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Heroes.ViewModels
{
    [Serializable]
    public class ViewModelCreacionUsuarios : INotifyPropertyChanged
    {

        public ViewModelCreacionUsuarios()
        {

            //Ruta de guardado de serializacion
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Usuarios.bin");


            CrearUsuario = new Command(() =>
            {

                Usuarios u = new Usuarios()
                {

                    password = this.Password,
                    usuario = this.Usuario,

                };


                //Rutina de Serializacion
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream memory = new MemoryStream();
                formatter.Serialize(memory, u);
                byte[] SerializedData = memory.ToArray();
                memory.Close();
                File.WriteAllBytes(ruta, SerializedData);


                //Popasync para regresar a la pantalla anterior
                //Application.Current.MainPage.Navigation.PopAsync();

                var pagina = new MainPage();

                Application.Current.MainPage.Navigation.PushAsync(pagina);




            });

           
        }
        
        
       

        public Command CrearUsuario { get; }



        //variable Privada usuario
        string usuario;

        //Varible publica Usuario que recibira los datos y dalar valor a la variable privada usuario
        public string Usuario
        {
            get => usuario;

            set
            {
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

        //Void Privado para hacer el PropertyChanged?.Invoke de las variables en la clase
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
