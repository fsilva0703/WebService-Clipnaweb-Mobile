using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS.Models.Dto
{
    public class DtoFiltro
    {
        public String Assunto { get; set; }
        public Boolean ChkImpresso { get; set; }
        public Boolean ChkTv { get; set; }
        public Boolean ChkRd { get; set; }
        public Boolean ChkOnline { get; set; }
        public Boolean ChkInter { get; set; }
        public Boolean ChkMSocial { get; set; }
        public String Palavra { get; set; }
        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }
        public String NomeBanco { get; set; }
        public String Cliente { get; set; }

    }
}
