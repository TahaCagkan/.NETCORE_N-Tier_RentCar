using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //Kullanıcı ve kullanıcı operasyon bilgilerini token oluşturma
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
