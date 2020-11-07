using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestLuisDonoso.Models
{
    public class Estado
    {
        [Key, Column("id"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ID { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }


        public Estado()
        {

        }
    }
}