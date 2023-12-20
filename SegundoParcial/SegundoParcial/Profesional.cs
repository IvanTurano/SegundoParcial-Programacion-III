using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class Profesional:Empleado
    {
        private string titulo;
        private ulong matricula;
        private string consejoDeEmision;
        private float porcentaje;
        private static float canon;
        private bool enObra;

        public Profesional(uint leg, string nom, string ape, string titulo, ulong matricula, string consejoDeEmision, float porce) : base(leg, nom, ape)
        {
            this.titulo = titulo;
            this.matricula = matricula;
            this.consejoDeEmision = consejoDeEmision;
            this.porcentaje = porce;
            this.enObra = false;
        }

        public static void setCanon(float can) { Profesional.canon = can; }
        public static float getCanon() { return Profesional.canon; }
        public void setPorcentaje(float por) { this.porcentaje = por; }
        public float getPorcentaje() { return this.porcentaje; }
        public void setEnObra(bool enObra){ this.enObra = enObra;}
        public bool getEnObra() { return this.enObra; }
        public float darSueldo()
        {
            return getSueldo() + (getSueldo() * (this.porcentaje / 100));
        }

        public float sueldoYCanon()
        {
            if (enObra) { return darSueldo() + getCanon(); }

            return darSueldo();
        }

        public override string ToString()
        {
            string datos = base.ToString();
            datos += "\n Titulo: " + this.titulo;
            datos += "\n Matricula: " + this.matricula;
            datos += "\n Consejo de Emision del titulo: " + this.consejoDeEmision;
            datos += "\n Pago por matricula: " + getCanon();
            datos += "\n Sueldo: " + sueldoYCanon();
            return datos;
        }
    }
}
