using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class Empresa
    { 

        private ArrayList empleados = new ArrayList(0);
        private ArrayList obras = new ArrayList(0);

        public Empleado buscarEmpleado(uint leg)
        {
            foreach (Empleado aux in this.empleados)
            {
                if(aux.getLegajo() == leg)
                {
                    return aux;
                }
            }
            return null;
        }

        public bool agregarObrero(uint leg, string nom, string ape, string oficio, string exp)
        {
            Empleado emp = buscarEmpleado(leg);

            if (emp == null)
            {
                this.empleados.Add(new Obrero(leg, nom, ape, oficio, exp));
                return true;
            }

            return false;
        }

        public bool agregarProfesional(uint leg, string nom, string ape, string titulo, ulong matricula, string consejoDeEmision, float porce)
        {

            Empleado emp = buscarEmpleado(leg);

            if (emp == null)
            {
                this.empleados.Add(new Profesional(leg, nom, ape, titulo, matricula, consejoDeEmision, porce));
                return true;
            }

            return false;

        }

        public void ordenarEmpleados()
        {
            this.empleados.Sort();
        }

        public string mostrarEmpleados()
        {

            string datos = "";
            foreach(Empleado aux in this.empleados)
            {
                datos += aux.ToString();
            }

            return datos;
        }

        public Obra buscarObra(string cod)
        {
            foreach(Obra aux in this.obras)
            {
                if(aux.getCodigo() == cod)
                {
                    return aux;

                }
            }

            return null;
        }
        public bool agregarObra(Obra ob)
        {
            if(this.buscarObra(ob.getCodigo()) == null)
            {
                this.obras.Add(ob);
                return true;
            }

            return false;
        }

        public bool verificarObreroEnObra(uint leg)
        {
            foreach(Obra aux in this.obras)
            {
                if(aux.buscarObrero(leg) != null)
                {
                    return false;
                }
            }

            return true;
        }


        public bool designarProfesional(string cod , Profesional pro)
        {
            foreach(Obra aux in this.obras)
            {
                if( aux.getCodigo() == cod)
                {
                    //Busco el supervisor a retirar de la obra, para cambiarle el valor de si esta en una obra o no
                    Profesional supervisorViejo = (Profesional)this.buscarEmpleado(aux.getSupervisor().getLegajo());
                    supervisorViejo.setEnObra(false);
                    //elimino el objeto 
                    this.empleados.Remove(this.buscarEmpleado(aux.getSupervisor().getLegajo()));
                    //y lo vuelvo a agregar
                    this.empleados.Add(supervisorViejo);

                    //ahora al nuevo supervisor seteo que esta en una obra y lo agrego a la obra.
                    pro.setEnObra(true);
                    aux.setSupervisor(pro);

                    return true;
                }
            }

            return false;
        }
        public string mostrarObras()
        {
            string datos = "";
            foreach(Obra aux in this.obras)
            {
                datos += aux.ToString();
            }

            return datos;
        }


        public bool eliminarProfesional(uint leg)
        {
            Profesional aEliminar = (Profesional)this.buscarEmpleado(leg);

            if(aEliminar != null)
            {
                foreach(Obra aux in this.obras)
                {
                    if(aux.getSupervisor().getLegajo() == leg)
                    {
                        return false;
                    }
                }
            }

            this.empleados.Remove(aEliminar); return true;
        }

    }
}
