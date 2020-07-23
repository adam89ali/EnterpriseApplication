using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplication.Application.Common.Entities
{
    public static class Response
    {
        public static Response<T> Ok<T>(string message, bool error, T data = default)
        {
            return new Response<T>(message, data, error);
        }
    }
    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }

        public Response(string message, T data, bool error)
        {
            Message = message;
            Data = data;
            Error = error;
        }
    }
}
