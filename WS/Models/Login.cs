using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WS.Models
{
    [Table("Usuarios", Schema = "dbo")]
    public class Login
    {
        [Key]
        public string NM_Login { get; set; }
        public string Cliente { get; set; }
        public string NomeBanco { get; set; }
        public string NM_Funcionalidade { get; set; }
    }
}
