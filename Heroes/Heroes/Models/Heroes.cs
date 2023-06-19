using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace Heroes.Models
{
    [Serializable]
    public class Heroes
    {
        //Varibles de Clase Heroe
        public string Nombre { get; set; }
        public string ColorPreferido { get; set; }
        public string Poder { get; set; }
        public string IdentidadSecreta { get; set; }
        public string TipoHeroe { get; set; }
        public int Nivel { get; set; }
        public int PersonasRescatadas { get; set; }

        public double Daño { get; set; }


        //Listas observable collection de poseres y ataques

        public ObservableCollection<string> listAtaques { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> listPoderes { get; set; } = new ObservableCollection<string>();

        


        //Metodo toString Super Clase
        public override string ToString()
        {
            return $" Nombre del Heroe: {Nombre} Color Preferido: {ColorPreferido} Identidad Secreta:{IdentidadSecreta} Tipo de Heroe: {TipoHeroe}";
        }



        //metodo Heredado para Obtener la cantidad de daño segun los ataques del heroe modelo o pequeño
        public virtual void getDaño() { }

        //metodo Heredado para Obtener la cantidad de ataques segun los ataques del heroe modelo o pequeño almacenados en lista de ataques
        public virtual void getAtaques() { }

        //metodo Heredado para Obtener la cantidad de poderes segun los poderes del heroe modelo o pequeño almacenados en lista de poderes
        public virtual void getPoderes() { }


    }
}
