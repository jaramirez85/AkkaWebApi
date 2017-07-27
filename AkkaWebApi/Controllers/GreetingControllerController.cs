using Akka.Actor;
using AkkaWebApi.App_Start;
using AkkaWebApi.Messages;
using System.Threading.Tasks;
using System.Web.Http;

namespace AkkaWebApi.Controllers
{
    public class GreetingController : ApiController
    {
        // GET: api/Greeting
        public async Task<IHttpActionResult> Get(string greeting)
        {
            var result = await AppActorSystem.ActorReferences.GrettingActorController.Ask<string>(new GrettingMessage(greeting));
            return Ok(new { Greeting = result });
        }
    }
}
