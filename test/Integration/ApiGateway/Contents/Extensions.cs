﻿using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace AwsSignatureVersion4.Integration.ApiGateway.Contents
{
    public static class Extensions
    {
        public static StringContent ToJsonContent(this Type self) =>
            new(
                JsonConvert.SerializeObject(Activator.CreateInstance(self)),
                Encoding.UTF8,
                "application/json");
    }
}
