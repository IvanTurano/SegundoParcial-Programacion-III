using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class Obrero:Empleado
    {
        private string oficio;
        private string experiencia;

        public Obrero(uint leg, string nom, string ape, string oficio, string experiencia) : base(leg, nom, ape)
        {
            this.oficio = oficio;
            this.experiencia = experiencia;
        }

        public float darSueldo()
        {
            if(this.experiencia == "MedioOficial")
            {
                return getSueldo() * 0.65f;
            }
            else if (this.experiencia == "Aprendiz")
            {
                return getSueldo() * 0.25f;
            }

            return getSueldo();
        }

        public override string ToString()
        {
            string datos = base.ToString();
            datos += "\n Oficio: " + this.oficio;
            datos += "\n Experiencia: " + this.experiencia.ToString();
            datos += "\n Sueldo: " + this.darSueldo();
            return datos;
        }
    }
}
