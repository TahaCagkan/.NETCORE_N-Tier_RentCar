using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //işlem sonuçlarımız için interface
    public interface IResult
    {
        //başarılı biligilendirme
        bool Succes { get; }
        //Kullanıcıya mesaj döndürme
        string Message { get; }
    }
}
