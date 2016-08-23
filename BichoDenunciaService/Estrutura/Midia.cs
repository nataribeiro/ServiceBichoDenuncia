using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BichoDenunciaService.Estrutura
{
    public class Midia
    {
        public int? id { get; set; }
        public int? id_denuncia { get; set; }
        public int? sequencia { get; set; }
        public string tipo_midia { get; set; }
        public string arquivo { get; set; }
    }
}