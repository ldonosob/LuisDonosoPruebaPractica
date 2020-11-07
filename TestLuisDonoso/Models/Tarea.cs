using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestLuisDonoso.Models
{
    public class Tarea
    {
        [Key, Column("id") DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [ForeignKey("Estado"),Column("estado_id")]
        public short EstadoID { get; set; }

        public virtual Estado Estado { get; set; }

        [DataType(DataType.MultilineText)]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [ForeignKey("Usuario"), Column("usuario_id")]
        public string UsuarioID { get; set; }
        
        public virtual Usuario Usuario { get; set; }


        public Tarea()
        {

        }
    }
}