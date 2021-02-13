using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        //mesaj ve doğru olduğu zaman
        public ErrorResult(string message) : base(false, message)
        {

        }
        //sadece doğru oldğu zaman
        public ErrorResult() : base(false)
        {

        }
    }
}
