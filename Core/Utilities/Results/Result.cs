using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        
        public Result(bool success,string message ) : this(success)   //this sınıfın kendisini temsil eder, dolayısıyla bu şekilde tek parametreli ctor çalıştırılabilir
        {
            Message = message;
            //Success = success;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
