using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BichoDenunciaService.Estrutura
{
    public class Denuncia
    {
        public int? id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string situacao { get; set; }
        public string data { get; set; }
        public string categoria_animal { get; set; }
        public string tipo_animal { get; set; }
        public string endereco { get; set; }
        public double? endereco_latitude { get; set; }
        public double? endereco_longitude { get; set; }
        public string denunciante_email { get; set; }
        public string denunciante_telefone { get; set; }
        public string id_dispositivo { get; set; }
        public List<Hashtag> hashtag { get; set; }
        public List<Midia> midia { get; set; }
        public List<Retorno> retorno { get; set; }

    }
}