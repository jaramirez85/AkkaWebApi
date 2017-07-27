﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkkaWebApi.Messages
{
    public class GrettingMessage
    {
        public string Name { get; private set; }

        public GrettingMessage(string name)
        {
            Name = name;
        }
    }
}