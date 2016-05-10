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
    class Persona
    {

        //Atributos
        /// <summary>
        /// Guarda el nombre de la persona.
        /// </summary>
        protected string nombre;
        /// <summary>
        /// Guarda el apellido de la persona.
        /// </summary>
        protected string apellidos;
        /// <summary>
        /// Guarda el telefono de la persona.
        /// </summary>
        protected string tlfno;
        /// <summary>
        /// Guarda la fecha de nacimiento de la persona.
        /// </summary>
        protected DateTime fnac;
        /// <summary>
        /// Indica si el contacto es empresarial o no.
        /// </summary>
        protected bool empre;

        //Metodos

        /// <summary>
        /// Inicializa una nueva instancia de persona con los campos por defecto.
        /// </summary>
        public Persona()
        {
            nombre = "";
            apellidos = "";
            tlfno = "";
            fnac = new DateTime();
            empre = false;
        }
        /// <summary>
        /// Inicializa una nueva instancia de persona con los valores introducidos.
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellidos">Apellidos</param>
        /// <param name="telefono">Telefono</param>
        /// <param name="fnac">Fecha de nacimiento</param>
        public Persona(string nombre, string apellidos, string telefono, DateTime fnac)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            tlfno = telefono;
            this.fnac = fnac;
            empre = false;
        }
        /// <summary>
        /// Copia el valor de todos los campos en el objeto
        /// </summary>
        public void AsignaDatos(string nombre, string apellidos, string telefono, DateTime fnac)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            tlfno = telefono;
            this.fnac = fnac;
        }

        /// <summary>
        /// Devuelve el nombre de una persona
        /// </summary>
        /// <returns></returns>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Devuelve el apellido de una persona
        /// </summary>
        /// <returns></returns>
        public string Apellidos
        {

            get { return apellidos; }
            set { apellidos = value; }

        }

        /// <summary>
        /// Devuelve el telefono de una persona
        /// </summary>
        /// <returns></returns>
        public string Telefono
        {
            get { return tlfno; }
            set { tlfno = value; }
        }

        /// <summary>
        /// Devuelve la fecha de nacimiento de una persona
        /// </summary>
        /// <returns></returns>
        public DateTime FechaNac
        {
            get { return fnac; }
            set { fnac = value; }
        }
        /// <summary>
        /// Devuelve true si es empresario y false si no lo es.
        /// </summary>
        public bool Empr
        {
            get { return empre; }
        }
        /// <summary>
        /// Devuelve el contacto en texto.
        /// </summary>
        /// <returns>Resumen</returns>
        public override string ToString()
        {
            return nombre+" "+ apellidos + "\t" + tlfno + "\t" + fnac.ToShortDateString();

        }
    }
}
