using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //data ve mesaj ver
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        //sadece data ver
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //sadece mesaj ver
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        //istersen hiç birşey verme
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
