using PruebaTecnica.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaTecnica
{
    public partial class FormCompanyList : Form
    {
        //instanciamos los objetos para poder trabajar con ellos
        Empresa modelo = new Empresa();
        DatabaseContext db = new DatabaseContext();
        
        
        public FormCompanyList()
        {
            InitializeComponent();
            BindGrid();
            filtrar();
        }

        //metodo para mostrar el contenido la base de datos en el gridview
        #region HELPER

        void BindGrid()
        {
            //dataGridView1.DataSource = db.Empresas.ToList<Empresa>();
            //dataGridView1.Columns.Remove("EmpresaID");


            using(DatabaseContext db =new DatabaseContext())
            {
                var lst = from d in db.Empresas
                          select d;
                dataGridView1.DataSource = lst.ToList();
                //dataGridView1.Columns.Remove("EmpresaID");
                dataGridView1.Columns["EmpresaID"].Visible = false;
            }
            
        }
        #endregion
        //metodo que esta filtrando constantemente el contenido con base a lo que el usuario escriba en el textbox
        private void filtrar()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var lst = from e in db.Empresas
                          where e.Nombre.Contains(txtFiltro.Text)
                          select e;
                dataGridView1.DataSource = lst.ToList();
                
                dataGridView1.Columns["EmpresaID"].Visible = false;
            }
        }

        //funcion del boton Agregar, abre el formulario formCompanyEditor y le hace saber que esta en estado de agregar
        private void button1_Click(object sender, EventArgs e)
        {
            FormCompanyEditor editor = new FormCompanyEditor("Agregar",0);
            editor.ShowDialog();
            BindGrid();
            
        }
        //funcion del boton Agregar, abre el formulario formCompanyEditor y le hace saber que esta en estado de Editar
        //Ademas mapea el objeto seleccionado en el gridview a los textbox del fomulario destino
        private void button2_Click(object sender, EventArgs e)
        {
            FormCompanyEditor editor = new FormCompanyEditor("Editar", Int32.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["EmpresaID"].Value.ToString()));
            editor.txtName.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Nombre"].Value.ToString();
            editor.txtCodigo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Codigo"].Value.ToString();
            editor.txtDireccion.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Dirección"].Value.ToString();
            editor.txtTelefono.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Telefono"].Value.ToString();
            editor.txtCiudad.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Ciudad"].Value.ToString();
            editor.txtDepartamento.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Departamento"].Value.ToString();
            editor.txtPais.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Pais"].Value.ToString();
            editor.ShowDialog();
            BindGrid();
            dataGridView1.Refresh();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_Click(object sender, EventArgs e)
        {
           
        }
        //Funcionalidad del boton eliminar, elimina el registro seleccionado
        private void button3_Click(object sender, EventArgs e)
        {
            db.Empresas.Where(x => x.EmpresaID == Int32.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["EmpresaID"].Value.ToString())).ToList().ForEach(p => db.Empresas.Remove(p));
            int a=db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Elemento Eliminado");
                
            }
            else
            {
                MessageBox.Show("Ocurrio un error");
                
                this.Close();
            }
            BindGrid();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        //aplica la funcion filtrar al textbox
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void FormCompanyList_Load(object sender, EventArgs e)
        {

        }
    }
}
;