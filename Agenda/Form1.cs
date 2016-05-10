using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;


namespace Agenda
{
    /*********************************
 Autor: Josue Piña Rodriguez
 Fecha creación: 6/05/2016
 Última modificación: 10/05/2016
 Versión: 1.0
***********************************/
    public partial class Form1 : Form
    {
        AddSchedule schdule = new AddSchedule();
        SchduleChange schdule2 = new SchduleChange();
        Agenda[] agendas = new Agenda[100];
        int pos;
        int nelem;
        public Form1()
        {
            InitializeComponent();
            pos = 0;
            nelem = 0;
        }
        /// <summary>
        /// Función que actualiza los datos de las box en función del tipo de contacto.
        /// </summary>
        private void MostrarDatos()
        {
            ////Personal
            if (agendas[pos].Empre == false)
            {
                Marcador.Text = (agendas[pos].Cursor + 1) + " de " + (agendas[pos].Lenght);
                nameBox.Text = agendas[pos].PNombre;
                phoneBox.Text = agendas[pos].PTelefono;
                surBox.Text = agendas[pos].PApellidos; ;
                dateBox.Text = agendas[pos].PFecha.ToString();
                GrupoEmp.Visible = false;
                personalButton.Checked = true;
            }
            else
            ////Empresarial
            {
                Marcador.Text = (agendas[pos].Cursor + 1) + " de " + (agendas[pos].Lenght);
                nameBox.Text = agendas[pos].PNombre;
                phoneBox.Text = agendas[pos].PTelefono;
                surBox.Text = agendas[pos].PApellidos; ;
                dateBox.Text = agendas[pos].PFecha.ToString();
                GrupoEmp.Visible = true;
                GrupoEmp.Enabled = true;
                compBox.Text = agendas[pos].Empresa();
                carBox.Text = agendas[pos].Cargo();
                cphoneBox.Text = agendas[pos].Phone();
                companyButton.Checked = true;
            }
        }
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] pruebas;
            string[] aux;
            string p = @"\";
            string[] fecha;
            int[] fecha2 = new int[3];
           if ( openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.FileName = openFileDialog1.FileName;
                ///Hago un split del path usando el separador '\'
                aux = openFileDialog1.FileName.Split(char.Parse(p));
                ///Hago un split del resultado (*.agenda) usando el separador .
                aux = aux[aux.Length - 1].Split('.');
                ////El resultado almacenado en aux[0] es el nombre del archivo sin extensión.
                Agenda a1 = new Agenda(aux[0], 200);
                agendas[pos] = a1;
                pos++;
                schdule2.Lista("Agenda -" + aux[0]);
                ///Abrimos el archivo.
                pruebas = File.ReadAllLines(openFileDialog1.FileName);
                for (int i = 0; i < pruebas.Length; i++)
                {
                    aux = pruebas[i].Split('$');
                    ///Por el formato de los archivos,si da lugar a 4 substrings se trata de una persona.
                    if (aux.Length == 4)
                    {
                        ///Extraemos la fecha.
                        fecha = aux[3].Split('/');
                        fecha2[0] = int.Parse(fecha[0]);
                        fecha2[1] = int.Parse(fecha[1]);
                        fecha2[2] = int.Parse(fecha[2]);
                        DateTime date = new DateTime(fecha2[2], fecha2[1], fecha2[0]);
                        ///Creamos la instancia 
                        Persona p1 = new Persona(aux[0], aux[1], aux[2], date);
                        agendas[pos].Inserta(p1);
                        MostrarDatos();
                    }///Igualmente,si da lugar a 7 substrings se trata de un contacto empresarial.
                    else if (aux.Length == 7)
                    {
                        ///Extraemos la fecha.
                        fecha = aux[3].Split('/');
                        fecha2[0] = int.Parse(fecha[0]);
                        fecha2[1] = int.Parse(fecha[1]);
                        fecha2[2] = int.Parse(fecha[2]);
                        DateTime date = new DateTime(fecha2[2], fecha2[1], fecha2[0]);
                        ///Creamos la instancia 
                        Empresarial p1 = new Empresarial(aux[0], aux[1], aux[2], date, aux[4], aux[5], aux[6]);
                        agendas[pos].Inserta(p1);
                        MostrarDatos();
                    }
                    

                }
                
                //Activamos todo
                Guardar.Enabled = true;
                GrupoTip.Enabled = true;
                nuevoToolStripMenuItem.Enabled = true;
                cambiarDeEstadoToolStripMenuItem.Enabled = true;
                GrupoReg.Enabled = true;
                GrupoMos.Enabled = true;
                GrupoP.Enabled = true;
                button5.Enabled = true;
                primeroToolStripMenuItem.Enabled = true;
                anteriorToolStripMenuItem.Enabled = true;
                siguienteToolStripMenuItem.Enabled = true;
                ultimoToolStripMenuItem.Enabled = true;
                mostrarResumenToolStripMenuItem.Enabled = true;
            }
            
        }
        
        

            
        /// <summary>
        /// Muestra los datos del programador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Josué Piña Rodriguez \n 1º DAW", "Datos Alumno");
        }
        /// <summary>
        /// Establece el cursor en la primera posición de la agenda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void primeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agendas[pos].Cursor = 0;
            MostrarDatos();
        }
        /// <summary>
        /// Establece el cursor en una posición menos de la actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void anteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (agendas[pos].Cursor > 0)
            {
                agendas[pos].Cursor -= 1;
                MostrarDatos();
            }
        }
        /// <summary>
        /// Establece el cursor en una posición mas de la actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void siguienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (agendas[pos].Cursor < agendas[pos].Lenght - 1)
            {
                agendas[pos].Cursor++;
                MostrarDatos();
            }
        }
        /// <summary>
        /// Establece el cursor en la última posicion de la agenda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultimoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agendas[pos].Cursor = agendas[pos].Lenght - 1;
            MostrarDatos();
        }
        /// <summary>
        /// Establece el cursor en la primera posición de la agenda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            agendas[pos].Cursor = 0;
            MostrarDatos();
        }
        /// <summary>
        /// Establece el cursor en una posición menos de la actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (agendas[pos].Cursor > 0)
            {
                agendas[pos].Cursor -= 1;
                MostrarDatos();
            }
        }
        /// <summary>
        /// Establece el cursor en una posición mas de la actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {//todo corregir que cuando abro un archivo con 0 personas crashee el programa,filtro if(nelem==0) y no hacer nada.
            if (agendas[pos].Cursor < agendas[pos].Lenght - 1)
            {
                agendas[pos].Cursor++;
                MostrarDatos();
            }
        }
        /// <summary>
        /// Establece el cursor en la última posicion de la agenda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            agendas[pos].Cursor = agendas[pos].Lenght - 1;
            MostrarDatos();
        }
        /// <summary>
        /// Muestra el contacto del indice de la verBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ver_Click(object sender, EventArgs e)
        {
            bool result;
            int num;
            result = int.TryParse(verBox.Text, out num);
            if (result == false)
            {
               
            }
            else if (result==true && int.Parse(verBox.Text)<= agendas[pos].Nelem)
            {
                agendas[pos].Cursor = int.Parse(verBox.Text) - 1;
                
                MostrarDatos();
            }
            verBox.Clear();
        }
        /// <summary>
        /// Habilita los grupos correspondientes según el tipo de contacto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nuevo_Click(object sender, EventArgs e)
        {
            if (companyButton.Checked == true)
            {
                GrupoP.Enabled = true;
                GrupoEmp.Enabled = true;
                nameBox.Clear();
                surBox.Clear();
                phoneBox.Clear();
                compBox.Clear();
                carBox.Clear();
                cphoneBox.Clear();
            }
            else if(personalButton.Checked==true)
            {
                GrupoP.Enabled = true;
                nameBox.Clear();
                surBox.Clear();
                phoneBox.Clear();
            }
        }
        /// <summary>
        /// Pone visible al grupo de datos empresariales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void companyButton_CheckedChanged(object sender, EventArgs e)
        {
            GrupoEmp.Visible = true;
        }
        /// <summary>
        /// Pone invisible al grupo de datos empresariales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void personalButton_CheckedChanged(object sender, EventArgs e)
        {
            GrupoEmp.Visible = false;
        }
        /// <summary>
        /// Habilita los grupos correspondientes según el tipo de contacto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Boton crear Agenda.Crea una nueva agenda con los parametros introducidos
        /// en el otro formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevaAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///Evita crear una nueva agenda en caso de haber llegado al máximo.
            if (nelem < 100)
            {
                if (schdule.ShowDialog() == DialogResult.OK)
                {
                    Agenda a1 = new Agenda(schdule.Nombre, schdule.Contactos);
                    schdule2.Lista("Agenda - " + a1.nombre);
                    agendas[nelem] = a1;
                    nelem++;
                    Guardar.Enabled = true;
                    GrupoTip.Enabled = true;
                    nuevoToolStripMenuItem.Enabled = true;
                    cambiarDeEstadoToolStripMenuItem.Enabled = true;
                    schdule.Nombre = "";
                    schdule.Contactos =0;
                    
                }
            }
            else
            {
                MessageBox.Show("Se ha alcanzado el número máximo de agendas.");
            }
        }
        /// <summary>
        /// Botón salir del menú. Sale de la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Guarda un nuevo contacto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Guardar_Click(object sender, EventArgs e)
        {
            if (companyButton.Checked == true)
            {
                Empresarial p1 = new Empresarial(nameBox.Text, surBox.Text, phoneBox.Text, dateBox.Value, compBox.Text, carBox.Text, cphoneBox.Text);
                agendas[pos].Inserta(p1);
            }
            else if (personalButton.Checked == true)
            {
                Persona p1 = new Persona(nameBox.Text, surBox.Text, phoneBox.Text, dateBox.Value);
                agendas[pos].Inserta(p1);
            }
            
            ////Activamos todos los controles que tienen sentido despues de guardar el primer contacto.
            GrupoReg.Enabled = true;
            GrupoMos.Enabled = true;
            primeroToolStripMenuItem.Enabled = true;
            anteriorToolStripMenuItem.Enabled = true;
            siguienteToolStripMenuItem.Enabled = true;
            ultimoToolStripMenuItem.Enabled = true;
            mostrarResumenToolStripMenuItem.Enabled = true;
            button5.Enabled = true;
            ////Mostramos los datos.
            MostrarDatos();
        }
        /// <summary>
        /// Cambia de agenda a una de la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cambiarDeEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (schdule2.ShowDialog() == DialogResult.OK)
            {
                pos = schdule2.Index;
                this.Text ="Agenda - " + agendas[pos].nombre;
                ///Controlamos los datos que se van a mostrar de la nueva agenda inmediatamente del cambio en función de si tiene o no contactos ya.
                if (agendas[pos].Nelem == 0)
                {
                    nameBox.Clear();
                    surBox.Clear();
                    phoneBox.Clear();
                    compBox.Clear();
                    carBox.Clear();
                    cphoneBox.Clear();
                    Marcador.Text = "0 de 0";
                    GrupoReg.Enabled = false;
                    GrupoMos.Enabled = false;
                    button5.Enabled = false;
                }
                else
                {
                    agendas[pos].Cursor = 0;
                    MostrarDatos();
                    GrupoReg.Enabled = true;
                    GrupoMos.Enabled = true;
                    button5.Enabled = true;
                    GrupoP.Enabled = true;
                }
                
            }
        }
        /// <summary>
        /// Crea 1 nueva agenda,5 contactos normales y 2 empresariales para probar el programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inicializacionDePruebasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////Activamos todo.
            Guardar.Enabled = true;
            GrupoTip.Enabled = true;
            nuevoToolStripMenuItem.Enabled = true;
            cambiarDeEstadoToolStripMenuItem.Enabled = true;
            GrupoReg.Enabled = true;
            GrupoMos.Enabled = true;
            GrupoP.Enabled = true;
            button5.Enabled = true;
            primeroToolStripMenuItem.Enabled = true;
            anteriorToolStripMenuItem.Enabled = true;
            siguienteToolStripMenuItem.Enabled = true;
            ultimoToolStripMenuItem.Enabled = true;
            mostrarResumenToolStripMenuItem.Enabled = true;
            ////Creamos una agenda.
            Agenda a1 = new Agenda();
            schdule2.Lista("Agenda - PRUEBAS" );
            this.Text = "Agenda - PRUEBAS";
            agendas[pos] = a1;
            nelem++;
            ////Creamos los contactos de prueba.
            Persona p1 = new Persona("Josué", "Piña Rodriguez", "675303038", new DateTime(1993, 06, 22));
            Persona p2 = new Persona("Adrian", "Diaz", "687415123", new DateTime(1994, 12, 01));
            Persona p3 = new Persona("Chicharrito", "Ortiz", "673698745", new DateTime(1984, 11, 22));
            Persona p4 = new Persona("Conor", "Mcgregor", "555999888", new DateTime(1998, 01, 30));
            Persona p5 = new Persona("Cindy", "Crawford", "654789845", new DateTime(1986, 04, 13));
            Empresarial e1 = new Empresarial("Pepe", "Fernandez", "9999999", new DateTime(1854, 06, 22), "Damas", "Director", "66655544");
            Empresarial e2 = new Empresarial("Josedo", "Ortiz", "9999999", new DateTime(1854, 06, 22), "Hipercor", "Gerente", "66655544");
            agendas[pos].Inserta(p1);
            agendas[pos].Inserta(p2);
            agendas[pos].Inserta(p3);
            agendas[pos].Inserta(p4);
            agendas[pos].Inserta(p5);
            agendas[pos].Inserta(e1);
            agendas[pos].Inserta(e2);
            MostrarDatos();


        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrupoP.Enabled = true;
            nameBox.Clear();
            surBox.Clear();
            phoneBox.Clear();
            personalButton.Checked = true;
            
        }

        private void empresarialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrupoP.Enabled = true;
            GrupoEmp.Visible = true;
            GrupoEmp.Enabled = true;
            nameBox.Clear();
            surBox.Clear();
            phoneBox.Clear();
            compBox.Clear();
            carBox.Clear();
            cphoneBox.Clear();
            companyButton.Checked = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ///Empresario
            if (companyButton.Checked == true)
            {
                agendas[pos].PNombre = nameBox.Text;
                agendas[pos].PApellidos = surBox.Text;
                agendas[pos].PTelefono = phoneBox.Text;
                agendas[pos].PFecha = dateBox.Value;
                agendas[pos].Empresa(compBox.Text);
                agendas[pos].Cargo(carBox.Text);
                agendas[pos].Phone(cphoneBox.Text);

            }
            ///Personal
            else if (personalButton.Checked == true)
            {
                agendas[pos].PNombre = nameBox.Text;
                agendas[pos].PApellidos = surBox.Text;
                agendas[pos].PTelefono = phoneBox.Text;
                agendas[pos].PFecha = dateBox.Value;
            }
        }

        private void mostrarResumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resumenBox.Text = "RESUMEN AGENDA. \n ================ \n\n\n";

            for (int i = 0; i < agendas[pos].Nelem; i++)
            {
                resumenBox.AppendText( i+1 +". "+ agendas[pos].Resumen(i) + "\n");
            }

            resumenBox.AppendText("================\n\nTotal entradas almacenadas" + agendas[pos].Nelem + "\nEspacio libre: " + agendas[pos].Espacio + " entradas");
            tabControl1.SelectTab(1);
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ///Genero el array con las lineas ha introducir en el documento
                string[] aux = new string[agendas[pos].Nelem];
                for (int i = 0; i < agendas[pos].Nelem; i++)
                {
                    agendas[pos].Cursor = i;
                    aux[i] = agendas[pos].Archivo();
                }
                File.WriteAllLines(saveFileDialog1.FileName, aux);
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.FileName == ".agenda")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    if (nelem==0)
                    {
                     MessageBox.Show("Cree una agenda antes de guardar.");
                        saveFileDialog1.FileName = ".agenda";
                        
                    }
                    else if(nelem>0 && agendas[pos].Nelem == 0)
                    {
                        File.Create(saveFileDialog1.FileName);
                    }
                    else if (agendas[pos].Nelem>0)
                    {
                        ///Genero el array con las lineas ha introducir en el documento
                        string[] aux = new string[agendas[pos].Nelem];
                        for (int i = 0; i < agendas[pos].Nelem; i++)
                        {
                            agendas[pos].Cursor = i;
                            aux[i] = agendas[pos].Archivo();
                        }
                        File.WriteAllLines(saveFileDialog1.FileName, aux);
                    }
                }
            }
            else
            {
                if (agendas[pos].Nelem == 0)
                {
                    ///Control para que no intente generar un documento vacio y crashee el programa.
                }
                else
                {
                    string[] aux = new string[agendas[pos].Nelem];
                    for (int i = 0; i < agendas[pos].Nelem; i++)
                    {
                        agendas[pos].Cursor = i;
                        aux[i] = agendas[pos].Archivo();
                    }
                    File.WriteAllLines(saveFileDialog1.FileName, aux);
                }
            }
        }
    }
}
