using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyUsefulStuff
{
    public class ResponseLogger
    {
        private readonly RequestDelegate _next_middleware;
        public ResponseLogger(RequestDelegate next)
        {
            this._next_middleware = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Stream originalBody = context.Response.Body;
            context.Response.Body = new MemoryStream();
            await _next_middleware.Invoke(context);
            var resultStream = context.Response.Body;

            context.Response.Body = originalBody;
            await resultStream.CopyToAsync(context.Response.Body);

            
        }
    }
}
