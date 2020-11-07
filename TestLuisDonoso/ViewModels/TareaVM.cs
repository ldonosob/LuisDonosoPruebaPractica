using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestLuisDonoso.ViewModels
{
    public class TareaVM
    {
        public int IDTarea { get; set; }
        public string NombreTarea { get; set; }
        public string EstadoTarea { get; set; }
        public int EstadoTareaID { get; set; }

        public string DescripcionTarea { get; set; }
        public string Usuario { get; set; }


        public TareaVM()
        {

        }
    }
}