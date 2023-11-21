using System;
using System.Collections;
using Newtonsoft.Json;
using Util;

namespace Lib.DTO
{
	public class ResponseDTO<TResponse>
	{
       
        public bool IsSuccess { get; set; } = false;

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public TResponse Data { get; set; }

    }
}

