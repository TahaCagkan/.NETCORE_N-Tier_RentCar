using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        //mesaj ve doğru olduğu zaman
        public SuccessResult(string message):base(true,message)
        {
                
        }
        //sadece doğru oldğu zaman
        public SuccessResult() : base(true)
        {

        }
    }
}
