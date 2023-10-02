using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Webshop_Borok.Models;
using System.Web.Script.Services;

namespace Webshop_Borok.IServices
{
    [ServiceContract]
    public interface IBorokService
    {
            [OperationContract]
            List<Borok> BorokLista_CS();
            [OperationContract]

            [WebInvoke(Method = "GET",
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json,
              BodyStyle = WebMessageBodyStyle.WrappedRequest,
              UriTemplate = "/BorokLista/")]
            List<Borok> BorokLista_Web();

            [OperationContract]

            string BorHozzaAdas_CS(Borok borok);

            [OperationContract]

            [WebInvoke(Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest,
                UriTemplate = "/BorHozzaAdas/")]

            string BorhozzaAdas_Web(Borok borok);
            [OperationContract]

            string BorModosit_CS(Borok borok);
            [OperationContract]

            [WebInvoke(Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest,
                UriTemplate = "/BorHozzaAdas/")]

            string BorModosit_WEB(Borok borok);
            [OperationContract]
            string BorTorol_CS(int id);
            [OperationContract]

            [WebInvoke(Method = "DELETE",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest,
                UriTemplate = "/BorTorol?id={id}")]

            string BorTorol_WEB(int id);
        }
    }

