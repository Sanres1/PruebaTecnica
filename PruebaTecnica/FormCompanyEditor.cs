using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.models;


namespace PruebaTecnica
{
    public partial class FormCompanyEditor : Form
    {
        //instanciamos los objetos para poder trabajar con ellos
        Empresa modelo = new Empresa();
        DatabaseContext db = new DatabaseContext();
        string estado;
        int IDEmpresa;
        //creamos el contructor del formulario
        public FormCompanyEditor(string estado,int IdEmpresa)
        {
            InitializeComponent();
            this.estado = estado;
            this.IDEmpresa = IdEmpresa;

        }
        //metodo con el cual el formulario nos hace saber si estamos editando o agregando un registro
        void estados()
        {
            if (estado.Equals("Agregar"))
            {
                lblEstado.Text = "Se encuentra Agregando un elemento";
            }
            else 
            {
                lblEstado.Text = "Se encuentra Editando un elemento";
            }

        }

        private void FormCompanyEditor_Load(object sender, EventArgs e)
        {
            estados();
        }
        private void limpiar()
        {
            txtCiudad.Text = "";
            txtCodigo.Text = "";
            txtDepartamento.Text = "";
            txtDireccion.Text = "";
            txtName.Text = "";
            txtPais.Text = "";
            txtTelefono.Text = "";

        }

        //funcionalidad del boton guardar, esta agrega o edita un elemento con base a si el formulario se encuentra en estado de agregar o editar

        private void button1_Click(object sender, EventArgs e)
        {

            if (estado.Equals("Agregar")){
                modelo.Nombre = txtName.Text;
                modelo.Telefono = txtTelefono.Text;
                modelo.Dirección = txtDireccion.Text;
                modelo.Departamento = txtDepartamento.Text;
                modelo.Pais = txtPais.Text;
                modelo.Ciudad = txtCiudad.Text;
                if (!txtCodigo.Text.Equals(""))
                {
                    modelo.Codigo = Int32.Parse(txtCodigo.Text);
                }
                modelo.FechaCreación = DateTime.Now;
                modelo.FechaModificación = DateTime.Now;
                db.Empresas.Add(modelo);
                int a = db.SaveChanges();

                if (a > 0)
                {
                    MessageBox.Show("Insertado");
                    limpiar();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error");
                    limpiar();
                    this.Close();
                }
            }
            else if (estado.Equals("Editar"))
            {
                modelo = db.Empresas.Where(x => x.EmpresaID == IDEmpresa).FirstOrDefault();
                modelo.Nombre = txtName.Text;
                if (!txtCodigo.Text.Equals(""))
                {
                    modelo.Codigo = Int32.Parse(txtCodigo.Text);
                    
                }
                modelo.Telefono = txtTelefono.Text;
                modelo.Dirección = txtDireccion.Text;
                modelo.Departamento = txtDepartamento.Text;
                modelo.Pais = txtPais.Text;
                modelo.Ciudad = txtCiudad.Text;
                modelo.FechaModificación= DateTime.Now;

                db.Entry(modelo).State = EntityState.Modified;
                int a= db.SaveChanges();
                if (a > 0)
                {
                    MessageBox.Show("Actualizado");
                    limpiar();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error");
                    limpiar();
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
