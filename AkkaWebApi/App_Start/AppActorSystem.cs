using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Akka.Actor;
using AkkaWebApi.Actors;

namespace AkkaWebApi.App_Start
{
    public static class AppActorSystem
    {
        public static ActorSystem ActorSystem;
        public static void Create()
        {
            ActorSystem = ActorSystem.Create("AppActorSystem");
            ActorReferences.GrettingActorController = ActorSystem.ActorOf<GrettingActorController>("GrettingActorController");
        }

        public static void Terminate()
        {
            ActorSystem.Terminate();
        }
        public static class ActorReferences
        {
            public static IActorRef GrettingActorController { get; set; }
        }
    }
}