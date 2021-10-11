using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BNG.Controllers
{
    public class YakController : ApiController
    {
        [Route("yak-shop/stock/{T}")]
        public HttpResponseMessage Get([FromUri]int T )
        {
            YakInfo yakInfo = new YakInfo();
            return Request.CreateResponse(HttpStatusCode.OK, yakInfo.YakStock(T), Configuration.Formatters.JsonFormatter);
        }


        [Route("yak-shop/order/{T}")]
        public HttpResponseMessage Post([FromUri]int T, [FromBody] YakOrder yakOrder)
        {
            YakInfo yakInfo = new YakInfo();
            var JOrder = yakInfo.InitOrder(T, yakOrder.order);
            HttpStatusCode status = HttpStatusCode.Created;

            if (JOrder.Property("milk") is null && JOrder.Property("skins") is null)
            {
                status = HttpStatusCode.NotFound;
            }
            else if (JOrder.Property("skins") is null || JOrder.Property("milk") is null) {
                status = HttpStatusCode.PartialContent;
            }

            return Request.CreateResponse(status, JOrder, Configuration.Formatters.JsonFormatter);
        }

    }
}
