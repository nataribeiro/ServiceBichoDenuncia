using BichoDenunciaService.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BichoDenunciaService.Estrutura;

namespace BichoDenunciaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BichoDenuncia" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BichoDenuncia.svc or BichoDenuncia.svc.cs at the Solution Explorer and start debugging.
    public class BichoDenuncia : IBichoDenuncia
    {      
        public Denuncia CarregaDenuncia(string id)
        {
            int iId;
            if (!int.TryParse(id, out iId))
                return null;

            webserviceEntities model = new webserviceEntities();
            var query = model.denuncia
                .Select(x => new { x.id, x.titulo, x.descricao, x.situacao, x.data, x.categoria_animal, x.tipo_animal, x.endereco, x.endereco_latitude, x.endereco_longitude, x.denunciante_email, x.denunciante_telefone, x.id_dispositivo, x.hashtag, x.midia, x.retorno })
                .Where(x => x.id == iId);

            var queryDenuncia = from item in query.AsEnumerable()
                                                  select new Denuncia
                                                  {
                                                      id = item.id,
                                                      titulo = item.titulo,
                                                      descricao = item.descricao,
                                                      situacao = item.situacao,
                                                      data = item.data.ToString(),
                                                      categoria_animal = item.categoria_animal,
                                                      tipo_animal = item.tipo_animal,
                                                      endereco = item.endereco,
                                                      endereco_latitude = item.endereco_latitude,
                                                      endereco_longitude = item.endereco_longitude,
                                                      denunciante_email = item.denunciante_email,
                                                      denunciante_telefone = item.denunciante_telefone,
                                                      id_dispositivo = item.id_dispositivo,
                                                      hashtag = ConvertToHashtag(item.hashtag),
                                                      midia = ConvertToMidia(item.midia),
                                                      retorno = ConvertToRetorno(item.retorno)
                                                  };

            List<Denuncia> list = queryDenuncia.ToList();

            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        private List<Retorno> ConvertToRetorno(ICollection<retorno> daoRetorno)
        {
            List<Retorno> retornos = new List<Retorno>();
            foreach(retorno r in daoRetorno)
            {
                Retorno retorno = new Retorno();
                retorno.id = r.id;
                retorno.id_denuncia = r.id_denuncia;
                retorno.data = r.data.ToString();
                retorno.entidade = r.entidade;
                retorno.descricao = r.descricao;
                retornos.Add(retorno);
            }
            return retornos;
        }
        private List<Midia> ConvertToMidia(ICollection<midia> daoMidia)
        {
            List<Midia> midias = new List<Midia>();
            foreach(midia m in daoMidia)
            {
                Midia midia = new Midia();
                midia.id = m.id;
                midia.id_denuncia = m.id_denuncia;
                midia.sequencia = m.sequencia;
                midia.tipo_midia = m.tipo_midia;
                try { midia.arquivo = Convert.ToBase64String(m.arquivo); }
                catch { }
                midias.Add(midia);
            }
            return midias;
        }
        private List<Hashtag> ConvertToHashtag(ICollection<hashtag> daoHashtag)
        {
            List<Hashtag> lHashtags = new List<Hashtag>();
            foreach(hashtag h in daoHashtag)
            {
                Hashtag hash = new Hashtag();
                hash.id = h.id;
                hash.id_denuncia = h.id_denuncia;
                hash.hashtag = h.hashtag1;
                lHashtags.Add(hash);
            }
            return lHashtags;
        }

        public List<Denuncia> CarregaDenunciasUsuario(string id)
        {
            webserviceEntities model = new webserviceEntities();
            var query = model.denuncia
                .Select(x => new { x.id, x.titulo, x.descricao, x.situacao, x.data, x.categoria_animal, x.tipo_animal, x.endereco, x.endereco_latitude, x.endereco_longitude, x.denunciante_email, x.denunciante_telefone, x.id_dispositivo, x.hashtag, x.midia, x.retorno })
                .Where(x => x.id_dispositivo == id);

            var queryDenuncia = from item in query.AsEnumerable()
                                select new Denuncia
                                {
                                    id = item.id,
                                    titulo = item.titulo,
                                    descricao = item.descricao,
                                    situacao = item.situacao,
                                    data = item.data.ToString(),
                                    categoria_animal = item.categoria_animal,
                                    tipo_animal = item.tipo_animal,
                                    endereco = item.endereco,
                                    endereco_latitude = item.endereco_latitude,
                                    endereco_longitude = item.endereco_longitude,
                                    denunciante_email = item.denunciante_email,
                                    denunciante_telefone = item.denunciante_telefone,
                                    id_dispositivo = item.id_dispositivo,
                                    hashtag = ConvertToHashtag(item.hashtag),
                                    midia = ConvertToMidia(item.midia),
                                    retorno = ConvertToRetorno(item.retorno)
                                };

            List<Denuncia> list = queryDenuncia.ToList();

            return list;
        }      

        public ResultadoOperacao EnviarDenuncia(Denuncia denuncia)
        {
            try
            {
                denuncia daoDenuncia = new AppCode.denuncia();
                if (denuncia.id != null)
                    daoDenuncia.id = Convert.ToInt32(denuncia.id);
                daoDenuncia.titulo = denuncia.titulo;
                daoDenuncia.descricao = denuncia.descricao;
                daoDenuncia.situacao = denuncia.situacao;
                try { daoDenuncia.data = Convert.ToDateTime(denuncia.data); }
                catch { }
                daoDenuncia.categoria_animal = denuncia.categoria_animal;
                daoDenuncia.tipo_animal = denuncia.tipo_animal;
                daoDenuncia.endereco = denuncia.endereco;
                daoDenuncia.endereco_latitude = denuncia.endereco_latitude;
                daoDenuncia.endereco_longitude = denuncia.endereco_longitude;
                daoDenuncia.denunciante_email = denuncia.denunciante_email;
                daoDenuncia.denunciante_telefone = denuncia.denunciante_telefone;
                daoDenuncia.id_dispositivo = denuncia.id_dispositivo;

                if (denuncia.hashtag != null)
                {
                    List<hashtag> hashtags = new List<hashtag>();
                    foreach (Hashtag h in denuncia.hashtag)
                    {
                        hashtag hash = new hashtag();
                        if (h.id != null)
                            hash.id = Convert.ToInt32(h.id);
                        hash.id_denuncia = h.id_denuncia;
                        hash.hashtag1 = h.hashtag;

                        hashtags.Add(hash);
                    }
                    daoDenuncia.hashtag = hashtags;
                }
                if (denuncia.midia != null)
                {
                    List<midia> midias = new List<midia>();
                    foreach (Midia m in denuncia.midia)
                    {
                        midia midia = new midia();
                        if (m.id != null)
                            midia.id = Convert.ToInt32(m.id);
                        midia.id_denuncia = m.id_denuncia;
                        midia.sequencia = m.sequencia;
                        midia.tipo_midia = m.tipo_midia;
                        try { midia.arquivo = Convert.FromBase64String(m.arquivo); }
                        catch { }
                        midias.Add(midia);
                    }
                    daoDenuncia.midia = midias;
                }
                if (denuncia.retorno != null)
                {
                    List<retorno> retornos = new List<retorno>();
                    foreach (Retorno r in denuncia.retorno)
                    {
                        retorno retorno = new retorno();
                        if (r.id != null)
                            retorno.id = Convert.ToInt32(r.id);
                        retorno.id_denuncia = r.id_denuncia;
                        try { retorno.data = Convert.ToDateTime(r.data); }
                        catch { }
                        retorno.descricao = r.descricao;
                        retorno.entidade = r.entidade;
                        retornos.Add(retorno);
                    }
                    daoDenuncia.retorno = retornos;
                }

                webserviceEntities model = new webserviceEntities();
                denuncia addedDenuncia = model.denuncia.Add(daoDenuncia);
                model.SaveChanges();

                ResultadoOperacao resultado = new ResultadoOperacao();
                if (addedDenuncia != null)
                {
                    resultado.bSucesso = true;
                    resultado.iCodigo = addedDenuncia.id;
                }
                else
                    resultado.bSucesso = false;

                return resultado;
            }
            catch
            {
                ResultadoOperacao resultado = new ResultadoOperacao();                
                resultado.bSucesso = false;

                return resultado;
            }
        }
    }

}
