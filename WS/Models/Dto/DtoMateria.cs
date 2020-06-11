using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS.Models.Dto
{
    public class DtoMateria
    {
        public Int32 matId { get; set; }
        public String titulo { get; set; }
        public String subtitulo { get; set; }
        public String midia { get; set; }
        public DateTime data { get; set; }
        public String veiculo { get; set; }
        public String programa { get; set; }
        public String urlMateria { get; set; }
        public String urlFile { get; set; }
    }
}
