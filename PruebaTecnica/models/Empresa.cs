using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.models
{
    class Empresa
    {

        //Creamos la clase Empresa la cual se convetira en la tabla en la base de datos
        // en ella tenemos un autoincrementable y 2 atributos requeridos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpresaID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Codigo { get; set; }
        public string Dirección { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Pais { get; set; }
        public DateTime FechaCreación { get; set; }
        public DateTime FechaModificación { get; set; }

    }
}
