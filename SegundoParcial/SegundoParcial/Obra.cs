using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class Obra
    {
        private string codigo;
        private string direccion;
        private Profesional supervisor;
        private ArrayList obreros = new ArrayList(0);

        public Obra(string codigo, string direccion, Profesional supervisor)
        {
            this.codigo = codigo;
            this.direccion = direccion;
            this.supervisor = supervisor;
            supervisor.setEnObra(true);
        }

        public string getCodigo() {  return codigo; }

        public string getDireccion() {  return direccion; }

        public Profesional getSupervisor() { return supervisor; }

        public void setSupervisor(Profesional pro) { this.supervisor = pro; } 

        public Obrero buscarObrero(uint leg)
        {
            foreach(Obrero aux in this.obreros)
            {
                if(aux.getLegajo() == leg)
                {
                    return aux;
                }
            }

            return null;
        }

        public bool agregarObrero(Obrero ob)
        {
            if(this.buscarObrero(ob.getLegajo()) == null)
            {
                this.obreros.Add(ob);
                return true;
            }

            return false;
        }


        public override string ToString()
        {
            string datos = "";
            datos += "Codigo de obra: " + this.codigo + "\n";
            datos += "Direccion de obra: " + this.direccion + "\n";
            datos += "Supervisor de la obra: \n" + supervisor.ToString() + "\n";
            datos += "Obreros asigandos a la obra:";
            foreach(Obrero aux in this.obreros)
            {
                datos += aux.ToString();
            }

            return datos;

        }
    }
}
