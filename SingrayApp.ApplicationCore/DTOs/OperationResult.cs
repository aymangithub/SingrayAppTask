using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingrayApp.ApplicationCore.DTOs
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }
        public static OperationResult Succeeded(string message = "Operation Completed Successfully!", object payload = null)
        {
            return new OperationResult
            {
                Success = true,
                Message = message,
                Payload = payload
            };
        }
        public static OperationResult Failure(string message = "Error: Please Try Again!")
        {
            return new OperationResult
            {
                Success = false,
                Message = message
            };
        }
        public static OperationResult Failure(IEnumerable<string> messages)
        {
            StringBuilder sb = new StringBuilder();
            if (messages.Count() > 0)
            {
                sb.AppendLine("Errors :-");
            }
            foreach (var msg in messages)
            {
                sb.AppendLine(msg);
            }

            return new OperationResult
            {
                Success = false,
                Message = sb.ToString()
            };
        }

        public static OperationResult NotFound(string message = "Error: Item Not Found")
        {
            return new OperationResult
            {
                Success = false,
                Message = message
            };
        }

        public static OperationResult Cascading(string message = "Error: Delete Sub Items First!")
        {
            return new OperationResult
            {
                Success = false,
                Message = message
            };
        }

        public static OperationResult Existed(string message = "Error: Item Already Existed")
        {
            return new OperationResult
            {
                Success = false,
                Message = message
            };
        }
    }
}
