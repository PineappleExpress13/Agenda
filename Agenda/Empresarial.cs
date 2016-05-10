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
    class Empresarial:Persona
    {
        /// <summary>
        /// Guarda el nombre de la empresa del contacto.
        /// </summary>
        private string empresa;
        /// <summary>
        /// Guarda el cargo del contacto en la empresa.
        /// </summary>
        private string cargo;
        /// <summary>
        /// Guarda el telefono de la empresa.
        /// </summary>
        private string phone;

        /// <summary>
        /// Inicializa una nueva instancia de contacto empresarial con los datos introducidos.
        /// </summary>
        public Empresarial()
        {
            nombre = "default";
            apellidos = "default";
            tlfno = "default";
            fnac = new DateTime();
            empresa = "default";
            cargo = "default";
            phone = "default";
            empre = true;
        }
        /// <summary>
        /// Inicializa una nueva instancia de contacto empresarial con los datos introducidos.
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellidos">Apellidos</param>
        /// <param name="telefono">Telefono</param>
        /// <param name="fnac">fecha de nacimiento</param>
        /// <param name="empresa">Nombre de empresa</param>
        /// <param name="cargo">Cargo en la empresa</param>
        /// <param name="phone">Telefono de la empresa</param>
        public Empresarial(string nombre, string apellidos, string telefono, DateTime fnac,string empresa,string cargo,string iphone)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            tlfno = telefono;
            this.fnac = fnac;
            this.empresa = empresa;
            this.cargo = cargo;
            this.phone = iphone;
            empre = true;
        }

        /// <summary>
        /// Devuelve el contacto en texto.
        /// </summary>
        /// <returns>Resumen</returns>
        public override string ToString()
        {
            return nombre + " " + apellidos + "\t" + tlfno + "\t " + fnac.ToShortDateString()+"\t"+empresa+"\t"+cargo+"\t"+phone; 

        }
        /// <summary>
        /// Devuelve el nombre de la empresa del contacto.
        /// </summary>
        public string Empresa
        {
            get { return this.empresa; }
            set { empresa = value; }
        }
        /// <summary>
        /// Devuelve el cargo en la empresa del contacto.
        /// </summary>
        public string Cargo
        {
            get { return this.cargo; }
            set { cargo = value; }
        }
        /// <summary>
        /// Devuelve el numero de la empresa del contacto.
        /// </summary>
        public string Phone
        {
            get { return this.phone; }
            set { phone = value; }
        }
    }
}
