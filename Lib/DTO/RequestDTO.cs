using System;
using Lib;
using Util;

namespace Lib.DTO
{
	public class RequestDTO<TRequest> //where T : class
	{
        public string Url { get; set; }

        public ApiType ApiType { get; set; } = ApiType.GET;

        public TRequest Data { get; set; }
    }
}

