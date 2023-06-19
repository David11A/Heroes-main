using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Heroes.Models
{
    [Serializable]
    public class Usuarios
    {
        //variables de la clase Usuarios
        public string usuario;
        public string password;

        //Metodo de autenticacion que recibe las variables u de usuario y p de password, compara
        //las variables recibidas con las variables establecidad en la clase, si son true retorna true
        //de otro modo retorna falso
        public bool autenticacion(string u, string p) 
        {
            if (usuario == u && password == p)
            {
                return true;
            }
            return false;
        }

       


        


    }
}
