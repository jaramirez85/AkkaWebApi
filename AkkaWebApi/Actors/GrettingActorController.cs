using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Akka.Actor;
using AkkaWebApi.Messages;
using AkkaWebApi.Actors;

namespace AkkaWebApi.Actors
{
    public class GrettingActorController : ReceiveActor
    {
        private IDictionary<string, IActorRef> _actorRefs;

        public GrettingActorController()
        {
            _actorRefs = new Dictionary<string, IActorRef>();
            Receive<GrettingMessage>(m =>
            {
                var greeting = m.Name;
                IActorRef child;
                if (!_actorRefs.TryGetValue(greeting, out child))
                {
                    child = Context.ActorOf(GrettingActor.Props(greeting), greeting);
                    _actorRefs[greeting] = child;
                }
                child.Tell(greeting, Sender);
            });
        }
    }
}