using BichoDenunciaService.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BichoDenunciaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BichoDenuncia" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BichoDenuncia.svc or BichoDenuncia.svc.cs at the Solution Explorer and start debugging.
    public class BichoDenuncia : IBichoDenuncia
    {
        public void DoWork()
        {
            webserviceEntities model = new webserviceEntities();
            model.denuncia
                .Select(x => new { x.id, x.descricao, x.data })
                .Where(x => x.id == 1)
                .OrderBy(x => x.id)
                .Take(10);

            model.midia
                .Select(x => new { x.id, x.tipo_midia, x.arquivo });
        }
    }
}
