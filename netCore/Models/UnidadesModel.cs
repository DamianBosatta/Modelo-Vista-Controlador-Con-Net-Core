using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace netCore.Models
{
    public class UnidadesModel
    {
        public int  IDunidades { get; set; }
        [Required(ErrorMessage = " El campo es obligatorio ")]
        public string modelo { get; set; }
        [Required(ErrorMessage = " El campo es obligatorio ")]
        public string marca { get; set; }
        [Required(ErrorMessage = " El campo es obligatorio ")]
        public int? año { get; set; }
        [Required(ErrorMessage = " El campo es obligatorio ")]
        public decimal? kilometros { get; set; }
        [Required(ErrorMessage = " El campo es obligatorio ")]
        public decimal? precio { get; set; }




    }
}
