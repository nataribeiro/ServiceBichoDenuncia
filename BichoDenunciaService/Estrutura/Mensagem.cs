using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BichoDenunciaService.Estrutura
{
    public class Mensagem
    {
        public string data { get; set; }
        public string to { get; set; }
        public Notification notification { get; set; }
    }
}