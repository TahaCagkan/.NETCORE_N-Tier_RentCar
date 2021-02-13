using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //DataResult result tır.
    public class DataResult<T> : Result, IDataResult<T>
    {
        //data,işlem sonucu ve mesaj
        public DataResult(T data,bool success, string message):base(success,message)
        {
            Data = data;
        }
        //sadece succes bilgisi için
        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }

        public T Data{get;}
    }
}
