using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Akka.Actor;
using AkkaWebApi.Messages;

namespace AkkaWebApi.Actors
{
    public class GrettingActor : ReceiveActor
    {
        private readonly string _name;
        private int _numberOfGreetings;

        public GrettingActor(string name)
        {
            this._name = name;
            Receive<string>(m => Sender.Tell($"You have been greeted {++_numberOfGreetings} times!!", Self));
        }

        public static Props Props(string name)
        {
            return Akka.Actor.Props.Create(() => new GrettingActor(name));
        }
    }
}