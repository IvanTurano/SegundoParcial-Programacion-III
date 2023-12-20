using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class Empleado:IComparable
    {
        private uint legajo;
        private string nombre;
        private string apellido;
        private static float sueldo;

        public Empleado()
        {
            this.legajo = 0;
            this.nombre = "sin asignar";
            this.apellido = "sin asignar";
        }
        public Empleado(uint legajo, string nom, string ape)
        {
            this.legajo = legajo;
            this.nombre = nom;
            this.apellido = ape;
        }

        public void setLegajo(uint legajo) { this.legajo = legajo; }

        public uint getLegajo() { return this.legajo; }

        public void setNombre(string nom) { this.nombre = nom; }

        public string getNombre() { return this.nombre; }

        public void setApellido(string ape) { this.apellido = ape; }

        public string getApellido() { return this.apellido; }

        public static void setSueldo(float suel) { Empleado.sueldo = suel; }

        public static float getSueldo() { return Empleado.sueldo; }

        public override string ToString()
        {
            string datos = "";
            datos += "\n Legajo: " + this.legajo + "\n";
            datos += "\n Nombre: " + this.nombre + "\n";
            datos += "\n Apellido: " + this.apellido + "\n";
            return datos;
        }

        public int CompareTo(object empleado)
        {
            return this.apellido.CompareTo(((Empleado)empleado).getApellido());
        }


    }
}
