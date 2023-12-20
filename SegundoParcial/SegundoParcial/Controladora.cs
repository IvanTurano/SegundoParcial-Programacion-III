using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.XPath;

namespace Parcial2
{
    class Controladora
    {
        public static void Main()
        {
            char opcion;
            Empresa empresa = new Empresa();
            do
            {
                char.TryParse(Interfaz.DarOpcion().ToUpper(), out opcion);
                float suel,canon,porce;
                string nom, ape, tit, ofi, conEmision,dir,cod,exp;
                char xp,opci;
                uint leg;
                ulong mat;
                switch (opcion)
                {
                    case 'A':
                        suel = float.Parse(Interfaz.PedirDato("Sueldo dado por el sindicato"));
                        Empleado.setSueldo(suel);
                        canon = float.Parse(Interfaz.PedirDato("Canon para el pago por matricula"));
                        Profesional.setCanon(canon);
                        break;

                    case 'B':
                        Interfaz.MostrarInfo("Sueldo: " + Empleado.getSueldo().ToString() + "\n Canon: " + Profesional.getCanon().ToString());
                        break;

                    case 'C':
                        string op = Interfaz.PedirDato("[A] = Registrar un Obrero, [B] = Registrar un profesional").ToUpper();
                        if (op == "A")
                        {
                            leg = uint.Parse(Interfaz.PedirDato("Legajo del empleado"));
                            nom = Interfaz.PedirDato("Nombre del empleado");
                            ape = Interfaz.PedirDato("Apellido del empleado");
                            ofi = Interfaz.PedirDato("Oficio");
                            char.TryParse(Interfaz.PedirDato("[A] = Oficial, [B] = MedioOficial, [C] = Aprendiz").ToUpper(), out xp);
                            switch (xp)
                            {
                                case 'A':
                                    exp = "Oficial";
                                    if (empresa.agregarObrero(leg, nom, ape, ofi, exp))
                                    {
                                        Interfaz.MostrarInfo("Obrero agregado con exito");
                                    }
                                    else
                                    {
                                        Interfaz.MostrarInfo("Ya existe un empleado con ese legajo");
                                    }
                                    break;

                                case 'B':
                                    exp = "MedioOficial";
                                    if (empresa.agregarObrero(leg, nom, ape, ofi, exp))
                                    {
                                        Interfaz.MostrarInfo("Obrero agregado con exito");
                                    }
                                    else
                                    {
                                        Interfaz.MostrarInfo("Ya existe un empleado con ese legajo");
                                    }
                                    break;

                                case 'C':
                                    exp = "Aprendiz";
                                    if (empresa.agregarObrero(leg, nom, ape, ofi, exp))
                                    {
                                        Interfaz.MostrarInfo("Obrero agregado con exito");
                                    }
                                    else
                                    {
                                        Interfaz.MostrarInfo("Ya existe un empleado con ese legajo");
                                    }
                                    break;
                            }
                        }
                        else if (op == "B")
                        {
                            leg = uint.Parse(Interfaz.PedirDato("Legajo del empleado"));
                            nom = Interfaz.PedirDato("Nombre del empleado");
                            ape = Interfaz.PedirDato("Apellido del empleado");
                            tit = Interfaz.PedirDato("Titulo de especialidad");
                            mat = ulong.Parse(Interfaz.PedirDato("Matricula"));
                            conEmision = Interfaz.PedirDato("Consejo de emision del titulo");
                            porce = float.Parse(Interfaz.PedirDato("Porcentaje de aumento"));
                            if (empresa.agregarProfesional(leg, nom, ape, tit, mat, conEmision, porce))
                            {
                                Interfaz.MostrarInfo("Profesional agregado con exito");
                            }
                            else
                            {
                                Interfaz.MostrarInfo("Empleado ya registrado con ese legajo");
                            }

                        }
                        break;

                    case 'D':
                        empresa.ordenarEmpleados();
                        Interfaz.MostrarInfo(empresa.mostrarEmpleados());
                        break;

                    case 'E':
                        cod = Interfaz.PedirDato("Codigo de obra");
                        dir = Interfaz.PedirDato("Direccion de la obra");
                        leg = uint.Parse(Interfaz.PedirDato("Legajo del profesional a supervisar la obra"));
                        if(empresa.buscarEmpleado(leg) is Profesional)
                        {
                            Profesional profe = (Profesional)empresa.buscarEmpleado(leg);

                            if (empresa.buscarObra(cod) == null)
                            {
                                empresa.agregarObra(new Obra(cod, dir, profe));
                                Interfaz.MostrarInfo("Obra registrada con exito");
                            }
                            else
                            {
                                Interfaz.MostrarInfo("Obra ya registrada, cambie el codigo");
                            }
                        }
                        else
                        {
                            Interfaz.MostrarInfo("No existe ese profesional");
                        }
                        break;
                        
                    case 'F':
                        cod = Interfaz.PedirDato("Codigo de obra");
                        leg = uint.Parse(Interfaz.PedirDato("Legajo del profesional"));
                        
                        if (empresa.buscarEmpleado(leg) is Profesional)
                        {
                            Profesional prof = (Profesional)empresa.buscarEmpleado(leg);
                            if (empresa.designarProfesional(cod, prof))
                            {
                                Interfaz.MostrarInfo("Profesional reasignado con exito");
                            }
                            else
                            {
                                Interfaz.MostrarInfo("Obra no encontrada");
                            }     
                        }
                        else
                        {
                            Interfaz.MostrarInfo("No existe ese profesional");
                        }
                        break;
                        
                    case 'G':
                        cod = Interfaz.PedirDato("Codigo de obra");
                        leg = uint.Parse(Interfaz.PedirDato("Legajo del obrero"));
                        if(empresa.buscarObra(cod) != null)
                        {
                            
                            if (empresa.buscarEmpleado(leg) is Obrero)
                            {
                                Obrero ob = (Obrero)empresa.buscarEmpleado(leg);

                                if (empresa.verificarObreroEnObra(leg))
                                {
                                    empresa.buscarObra(cod).agregarObrero(ob);
                                    Interfaz.MostrarInfo("Obrero asignado con exito");
                                }
                                else
                                {
                                    Interfaz.MostrarInfo("Error: El obrero ya fue asignado a una obra");
                                }
  
                            }
                            else
                            {
                                Interfaz.MostrarInfo("No existe ese obrero");
                            }
                        }
                        else
                        {
                            Interfaz.MostrarInfo("Obra no encontrada");
                        }
                        break;
                        
                    case 'H':
                        cod = Interfaz.PedirDato("Codigo de obra");
                        if(empresa.buscarObra(cod) != null)
                        {
                            Interfaz.MostrarInfo(empresa.buscarObra(cod).ToString());
                        }
                        else
                        {
                            Interfaz.MostrarInfo("Obra no encontrada");
                        }
                        break;
                        
                    case 'I':
                        leg = uint.Parse(Interfaz.PedirDato("Legajo del profesional a eliminar"));
                        if (empresa.buscarEmpleado(leg) is Profesional) 
                        {
                            if (empresa.eliminarProfesional(leg))
                            {
                                Interfaz.MostrarInfo("Profesional eliminado de la empresa correctamente");
                            }
                            else
                            {
                                Interfaz.MostrarInfo("Error: Profesional asignado a una obra");
                            }
                        }
                        else
                        {
                            Interfaz.MostrarInfo("Error: Profesional no existente");
                        }
                        break;

                     
                }


            } while (opcion != 'S');

        }
    }
}
