using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BichoDenunciaService.Estrutura
{
    public class Retorno
    {
        public int? id { get; set; }
        public int? id_denuncia { get; set; }
        public string entidade { get; set; }
        public string descricao { get; set; }
        public string data { get; set; }
    }
}