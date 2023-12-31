﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.REST.Domain.Entities.EndpointsModel
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        public ResponseModel(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
