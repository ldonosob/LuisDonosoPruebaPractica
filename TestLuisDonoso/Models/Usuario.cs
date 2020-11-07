using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestLuisDonoso.Models
{
    public class Usuario
    {
        [Key, Column("username"),DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
        public Usuario()
        {
                
        }
    }
}