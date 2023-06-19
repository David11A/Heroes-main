using Heroes.Models;
using Heroes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Heroes.ViewModels
{
    [Serializable]
    public class VMHeroeModelo : INotifyPropertyChanged
    {

        //Ruta de guardado de serializacion
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Heroes_Modelos.bin");

        public ObservableCollection<Heroe_Modelo> listaHM { get; set; } = new ObservableCollection<Heroe_Modelo>();
        public ObservableCollection<PequeñosHeroes> ListaPH { get; set; } = new ObservableCollection<PequeñosHeroes>();

        public ObservableCollection<string> ListaAtaques { get; set; } = new ObservableCollection<string>();
        
        public ObservableCollection<string> ListaPoderes { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> ListaAtaquesPH { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListaPoderesPH { get; set; } = new ObservableCollection<string>();

        

        /* ------------------------------------------- Metodo Constructor ---------------------------------------*/

        //Metodo Constructor
        //el constructor "VMHeroeModelo" toma un objeto de tipo "Heroe_Modelo"
        //como parámetro y lo utiliza para inicializar el objeto creado a partir de la clase "VMHeroeModelo
        public VMHeroeModelo()
        {
            CrearHM = new Command(() => {

                int dañoHM = 0;
                foreach (string ataque in ListaAtaques)
                {

                   dañoHM = dañoHM + 70;


                }


                Heroe_Modelo HM = new Heroe_Modelo()
                {
                    Nombre = this.nombreHM,
                    IdentidadSecreta = this.idSecretaHM,
                    ColorPreferido = this.colorPreferidoHM,
                    TipoHeroe = "Modelo",
                    Daño = dañoHM

                };

                ListaAtaques.Add(ataque);
                ListaPoderes.Add(Poder);
                HM.listPoderes = this.ListaPoderes;
                HM.listAtaques = this.ListaAtaques;
                HM.ListaPequeñosHeroes = ListaPH;
                listaHM.Add(HM);
                


                //Rutina de Serializacion
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream memory = new MemoryStream();
                formatter.Serialize(memory, listaHM);
                byte[] SerializedData = memory.ToArray();
                memory.Close();
                File.WriteAllBytes(ruta, SerializedData);



                var pagina = new ViewSeleccion_Heroes_Modelo();

                Application.Current.MainPage.Navigation.PushAsync(pagina);



            });

            //posible comando para ingresar poderes en un heroe modelo
            CrearAtaques = new Command(async () =>
            {
                for (int i = 0; i < CantidadAtaques; i++)
                {
                    string ataque = await Application.Current.MainPage.DisplayPromptAsync("Crear Ataque", "Ingrese el nombre del ataque " + i, "Aceptar", "Cancelar", placeholder: "Ataque " + "\n");
                    if (!string.IsNullOrWhiteSpace(ataque))
                    {
                        this.ListaAtaques.Add(ataque);
                    }
                }
            });

            CrearPoderes = new Command(async () =>
            {
                for (int i = 0; i < CantidadPoderes; i++)
                {
                    string poder = await Application.Current.MainPage.DisplayPromptAsync("Crear Poder", "Ingrese el nombre del poder " + i, "Aceptar", "Cancelar", placeholder: "Poder " + "\n");
                    if (!string.IsNullOrWhiteSpace(poder))
                    {
                        this.ListaPoderes.Add(poder);
                    }
                }
            });

            CrearPequenoHeroe = new Command(async () => await CrearPequenoHeroeAsync());






        }

        /* ------------------------------------------- Fin Metodo Constructor ---------------------------------------*/




        private async Task CrearPequenoHeroeAsync()
        {
            for (int i = 0; i < CantidadPequeñosHeroes; i++)
            {
                var ataques = await Application.Current.MainPage.DisplayPromptAsync("Crear Ataques", $"Ingrese la cantidad de ataques para el Pequeño Héroe {i + 1}", "Aceptar", "Cancelar", keyboard: Keyboard.Numeric);
                if (!string.IsNullOrEmpty(ataques) && int.TryParse(ataques, out int cantidadAtaques))
                {

                    for (int j = 0; j < cantidadAtaques; j++)
                    {
                        string AtaquesPH = await Application.Current.MainPage.DisplayPromptAsync("Crear Ataque", $"Ingrese el nombre del ataque {j + 1} para el Pequeño Héroe {i + 1}", "Aceptar", "Cancelar");
                        if (!string.IsNullOrWhiteSpace(AtaquesPH))
                            this.ListaAtaquesPH.Add(AtaquesPH);
                    }

                    var poderes = await Application.Current.MainPage.DisplayPromptAsync("Crear Poderes", $"Ingrese la cantidad de poderes para el Pequeño Héroe {i + 1}", "Aceptar", "Cancelar", keyboard: Keyboard.Numeric);
                    if (!string.IsNullOrEmpty(poderes) && int.TryParse(poderes, out int cantidadPoderes))
                    {
                        
                        for (int j = 0; j < cantidadPoderes; j++)
                        {
                            string poder = await Application.Current.MainPage.DisplayPromptAsync("Crear Poder", $"Ingrese el nombre del poder {j + 1} para el Pequeño Héroe {i + 1}", "Aceptar", "Cancelar");
                            if (!string.IsNullOrWhiteSpace(poder))
                                ListaPoderesPH.Add(poder);
                        }

                        var nombre = await Application.Current.MainPage.DisplayPromptAsync("Crear Pequeño Héroe", $"Ingrese el nombre para el Pequeño Héroe {i + 1}", "Aceptar", "Cancelar");
                        if (!string.IsNullOrWhiteSpace(nombre))
                        {
                            var identidadSecreta = await Application.Current.MainPage.DisplayPromptAsync("Crear Pequeño Héroe", $"Ingrese la identidad secreta para el Pequeño Héroe {i + 1}", "Aceptar", "Cancelar");
                            if (!string.IsNullOrWhiteSpace(identidadSecreta))
                            {
                                var nivel = await Application.Current.MainPage.DisplayPromptAsync("Crear Pequeño Héroe", $"Ingrese el nivel para el Pequeño Héroe {i + 1}", "Aceptar", "Cancelar");
                                if (!string.IsNullOrWhiteSpace(nivel) && int.TryParse(nivel, out int nivelInt))
                                {
                                    var colorPreferido = await Application.Current.MainPage.DisplayPromptAsync("Crear Pequeño Héroe", $"Ingrese el color preferido para el Pequeño Héroe {i + 1}", "Aceptar", "Cancelar");
                                    if (!string.IsNullOrWhiteSpace(colorPreferido))
                                    {
                                        var personasRescatadas = await Application.Current.MainPage.DisplayPromptAsync("Crear Pequeño Héroe", $"Ingrese la cantidad de personas rescatadas para el Pequeño Héroe {i + 1}", "Aceptar", "Cancelar", keyboard: Keyboard.Numeric);
                                        if (!string.IsNullOrEmpty(personasRescatadas) && int.TryParse(personasRescatadas, out int cantidadPersonasRescatadas))
                                        {

                                            int dañoPH = 0;
                                            foreach (string ataquesPH in ListaAtaquesPH)
                                            {

                                                dañoPH = dañoPH + 50;


                                            }
                                            PequeñosHeroes pequenoHeroe = new PequeñosHeroes
                                            {
                                                Nombre = nombre,
                                                IdentidadSecreta = identidadSecreta,
                                                Nivel = nivelInt,
                                                PersonasRescatadas = cantidadPersonasRescatadas,
                                                TipoHeroe = "Pequeño",
                                                ColorPreferido = colorPreferido,
                                                Daño= dañoPH
                                            };
                                            pequenoHeroe.listAtaques = this.ListaAtaquesPH;
                                            pequenoHeroe.listPoderes = this.ListaPoderesPH;

                                            ListaPH.Add(pequenoHeroe);
                                        }
                                    }
                                   
                                }
                            }
                        }
                    }
                }
            }
        }


        /* ------------------------------------------- Variables  ---------------------------------------*/







        int cantidadPequeñosHeroes;
        public int CantidadPequeñosHeroes {

            get => cantidadPequeñosHeroes;
            set
            {
                cantidadPequeñosHeroes = value;
                OnPropertyChanged(nameof(CantidadPequeñosHeroes));
            }
        }



        string poder;
        public string Poder
        {
            get => poder;
            set
            {
                poder = value;
                OnPropertyChanged(nameof(Poder));
            }
        }





        string ataque;
        public string Ataque
        {
            get => ataque;
            set
            {
                ataque = value;
                OnPropertyChanged(nameof(Ataque));
            }
        }





        int cantidadAtaques;
        int cantidadPoderes;

        public int CantidadAtaques
        {
            get => cantidadAtaques;
            set
            {
                cantidadAtaques = value;
                OnPropertyChanged(nameof(CantidadAtaques));
            }
        }

        public int CantidadPoderes
        {
            get => cantidadPoderes;
            set
            {
                cantidadPoderes = value;
                OnPropertyChanged(nameof(CantidadPoderes));
            }
        }





        //variable Privada usuario
        string HMnombre;

        //Varible publica Usuario que recibira los datos y dalar valor a la variable privada usuario
        public string hMnombre
        {
            get => HMnombre;

            set
            {
                HMnombre = value;
                OnPropertyChanged(nameof(hMnombre));
            }
        }



        //Variable Privada del nombre del Heroe
        string poderHM;

        //Variable Publica del nombre del Heroe
        public string PoderHM
        {
            get => poderHM;

            set
            {
                poderHM = value;
                OnPropertyChanged(nameof(PoderHM));
            }

        }


        //Variable Privada del nombre del Heroe
        string nombreHM;

        //Variable Publica del nombre del Heroe
        public string NombreHM
        {
            get => nombreHM;

            set
            {
                nombreHM = value;
                OnPropertyChanged(nameof(NombreHM));
            }

        }

        //Variable Privada Identidad Secreta del Heroe Modelo
        string idSecretaHM;
        //variable publica
        public string IdSecretaHM
        {
            get => idSecretaHM;

            set
            {
                idSecretaHM = value;
                OnPropertyChanged(nameof(IdSecretaHM));
            }

        }

        //variable del color preferido del Heroe Modelo
        string colorPreferidoHM;
        //variable publica
        public string ColorPreferidoHM
        {
            get => colorPreferidoHM;

            set
            {
                colorPreferidoHM = value;
                OnPropertyChanged(nameof(ColorPreferidoHM));
            }

        }



        /* ------------------------------------------- Fin Variables ---------------------------------------*/




        /* ------------------------------------------- Comandos ---------------------------------------*/

        public Command CrearPoderes { get; set; }

        public Command CrearAtaques { get; set; }

        //comando crear heroe
        public Command CrearHM { get; set; }

        //comando get poderes

        public Command CrearPequenoHeroe { get; set; }


        /* ------------------------------------------- Fin Comandos---------------------------------------*/



        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;

    }
}
