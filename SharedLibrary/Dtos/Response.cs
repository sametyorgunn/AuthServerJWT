using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class Response<T>where T : class
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool isSuccessfull { get;private set; }
        public ErrorDto Error { get;private set; }

        public static Response<T> Success(T data,int statusCode)
        {
          return new Response<T> { Data = data, StatusCode = statusCode,isSuccessfull=true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode,isSuccessfull = true };
        }

        public static Response<T> Fail(ErrorDto Error,int statusCode)
        {
            return new Response<T> { Error = Error, StatusCode = statusCode,isSuccessfull=false };
        }

        public static Response<T> Fail(string ErrorMessage,int statusCode,bool isShow)
        {
            var ErrorDto = new ErrorDto(ErrorMessage, isShow);
            return new Response<T> { Error = ErrorDto, StatusCode = statusCode,isSuccessfull=false };
        }
    }
}
