using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BichoDenunciaService.Estrutura
{
    public class Mensagem
    {
        public AndroidData data { get; set; }
        public List<String> registration_ids { get; set; }
    }
}