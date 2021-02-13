using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //IResult implemantasyonu
    public interface IDataResult<T>:IResult
    {
        //herşey olabilir döndürülcek veri
        T Data { get; }
    }
}
