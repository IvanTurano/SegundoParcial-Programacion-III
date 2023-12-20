using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class Interfaz
    {
        static Interfaz()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("************************************************");
            Console.WriteLine("*     Sistema de Gestión de Empresa Reparar   *");
            Console.WriteLine("************************************************");
            Console.WriteLine("\n[A] Establecer un sueldo y un canon.");
            Console.WriteLine("\n[B] Mostrar sueldo y canon.");
            Console.WriteLine("\n[C] Registrar un empleado.");
            Console.WriteLine("\n[D] Mostrar todos los empleados.");
            Console.WriteLine("\n[E] Registrar una obra.");
            Console.WriteLine("\n[F] Modificar el profesional de una obra.");
            Console.WriteLine("\n[G] Asignar un obrero a una obra");
            Console.WriteLine("\n[H] Mostrar todos los empleados de una obra.");
            Console.WriteLine("\n[I] Eliminar un profesional de la empresa.");

            Console.WriteLine("\n[S] Salir de la aplicación.");
            Console.WriteLine("\n**********************************************");
            return Interfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + "es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();

        }
        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
