using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{    /*********************************
 Autor: Josue Piña Rodriguez
 Fecha creación: 6/05/2016
 Última modificación: 10/05/2016
 Versión: 1.0
***********************************/
    class Agenda
    {//atributos

        /// <summary>
        /// Array que guarda los contactos de la agenda.
        /// </summary>
        private Persona[] Contactos;
        /// <summary>
        /// Guarda el numero total de contactos almacenados.
        /// </summary>
        private int nelem;
        /// <summary>
        /// Señala que elemento esta seleccionado en el momento.
        /// </summary>
        private int cursor;
        /// <summary>
        /// Guarda el nombre de la agenda.
        /// </summary>
        private string Nombre;
        /// <summary>
        /// Guarda el numero máximo de contactos posibles.
        /// </summary>
        private int max;



        ///metodos

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="tam_max"></param>
        public Agenda(string nombre, int tam_max)
        {
            this.Nombre = nombre;
            this.max = tam_max;
            Contactos = new Persona[max];
            this.nelem = 0;
            this.cursor = 0;
        }
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Agenda()
        {
            this.Nombre = "default";
            this.max = 100;
            this.nelem = 0;
            Contactos = new Persona[max];
            this.cursor = 0;
        }

        /// <summary>
        /// Devuelve el numero de elementos que contiene
        /// </summary>
        /// <returns></returns>
        public int Lenght
        {
            get { return nelem; }
        }

        /// <summary>
        /// Devuelve el numnero de elementos máximo que puede contener la lista
        /// </summary>
        /// <returns></returns>
        public int Size
        {
            get { return max; }
        }

        /// <summary>
        /// Inserta una persona en la agenda.
        /// </summary>
        /// <param name="item"></param>
        public void Inserta(Persona item)
        {
            Contactos[nelem] = item;
            nelem++;
        }
        /// <summary>
        /// Indica si la agenda esta llena.
        /// </summary>
        /// <returns></returns>
        public bool EstaLlena()
        {
            if (nelem == max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Indica si la agenda esta vacia.
        /// </summary>
        /// <returns></returns>
        public bool EstaVacia()
        {
            if (nelem == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Borra una persona de la agenda
        /// </summary>
        /// <param name="pos"></param>
        public void Borra(int pos)
        {
            Contactos[pos].AsignaDatos(null, null, null, DateTime.Now);
            nelem -= 1;
        }
        /// <summary>
        /// Devuelve el contacto seleccionado.
        /// </summary>
        public int Cursor
        {
            get { return cursor; }
            set { cursor = value; }
        }
        /// <summary>
        /// Devuelve el nombre del contacto seleccionado con el cursor.
        /// </summary>
        public string PNombre
        {
            get { return Contactos[cursor].Nombre; }
            set { Contactos[cursor].Nombre = value; }
        }
        /// <summary>
        /// Devuelve el apellido del contacto seleccionado con el cursor.
        /// </summary>
        public string PApellidos
        {
            get { return Contactos[cursor].Apellidos; }
            set { Contactos[cursor].Apellidos = value; }
        }
        /// <summary>
        /// Devuelve el telefono del contacto seleccionado con el cursor.
        /// </summary>
        public string PTelefono
        {
            get { return Contactos[cursor].Telefono; }
            set { Contactos[cursor].Telefono = value; }
        }
        /// <summary>
        /// Devuelve la fecha de nacimiento del contacto seleccionado con el cursor.
        /// </summary>
        public DateTime PFecha
        {
            get { return Contactos[cursor].FechaNac; }
            set { Contactos[cursor].FechaNac = value; }
        }
        /// <summary>
        /// Devuelve true si el contacto es empresarial.
        /// </summary>
        public bool Empre
        {
            get { return Contactos[cursor].Empr; }
           
        }
        /// <summary>
        /// Devuelve el nombre de la emrpesa del contacto seleccionado.
        /// </summary>
        /// <returns></returns>
        public string Empresa()
        {
            Empresarial e1 = (Empresarial)Contactos[cursor];
            return e1.Empresa;

        }
        /// <summary>
        /// Modifica el nombre de la empresa de un contacto.
        /// </summary>
        /// <param name="nueva"></param>
        public void Empresa(string nueva)
        {
            Empresarial e1 = (Empresarial)Contactos[cursor];
            e1.Empresa = nueva;

        }
        /// <summary>
        /// Devuelve el cargo en la empresa del contacto seleccionado
        /// </summary>
        /// <returns></returns>
        public string Cargo()
        {
            Empresarial e1 = (Empresarial)Contactos[cursor];
            return e1.Cargo;

        }
        /// <summary>
        /// Modifica el cargo de un contacto.
        /// </summary>
        /// <param name="nuevo"></param>
        public void Cargo(string nuevo)
        {
            Empresarial e1 = (Empresarial)Contactos[cursor];
            e1.Cargo = nuevo;
        }
        /// <summary>
        /// Devuelve el telefono de la empresa del contacto seleccionado con el cursor.
        /// </summary>
        /// <returns></returns>
        public string Phone()
        {
            Empresarial e1 = (Empresarial)Contactos[cursor];
            return e1.Phone;

        }
        /// <summary>
        /// Modifica el telefono de la empresa de un contacto.
        /// </summary>
        /// <param name="nuevo"></param>
        public void Phone(string nuevo)
        {
            Empresarial e1 = (Empresarial)Contactos[cursor];
            e1.Phone = nuevo;
        }
        /// <summary>
        /// Devuelve los elementos guardados en la agenda.
        /// </summary>
        public int Nelem
        {
            get { return nelem; }
        }
        /// <summary>
        /// Devuelve el tamaño restante de la agenda.
        /// </summary>
        public int Espacio
        {
            get { return max-nelem; }
        }

        public string Resumen(int pos)
        {
            if (Contactos[pos].Empr == false)
            {
               return  Contactos[pos].ToString();
            }
            else
            {
                Empresarial e1 = (Empresarial)Contactos[pos];
                return e1.ToString();
            }
        }

        public string Archivo()
        {
            if (Contactos[cursor].Empr == false)
            {
                return Contactos[cursor].Resumen();
            }
            else
            {
                Empresarial e1 = (Empresarial)Contactos[cursor];
                return e1.Resumen();
            }
        }
        /// <summary>
        /// Devuelve el nombre de la agenda.
        /// </summary>
        public string nombre
        {
            get { return this.Nombre; }
        }
    }
}
