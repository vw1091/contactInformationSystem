﻿using System;
using System.Net;

namespace NetWebApp.App_Start.Filter
{
    internal class LogMetadata
    {
        public string RequestMethod { get; internal set; }
        public DateTime RequestTimestamp { get; internal set; }
        public string RequestUri { get; internal set; }
        public string ResponseContentType { get; internal set; }
        public HttpStatusCode ResponseStatusCode { get; internal set; }
        public DateTime ResponseTimestamp { get; internal set; }
    }
}