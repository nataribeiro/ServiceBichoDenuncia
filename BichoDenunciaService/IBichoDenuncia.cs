using BichoDenunciaService.Estrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BichoDenunciaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBichoDenuncia" in both code and config file together.
    [ServiceContract]
    public interface IBichoDenuncia
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Denuncias/Usuario/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<Denuncia> CarregaDenunciasUsuario(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Denuncia/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Denuncia CarregaDenuncia(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Denuncia", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ResultadoOperacao EnviarDenuncia(Denuncia denuncia);
    }
}
