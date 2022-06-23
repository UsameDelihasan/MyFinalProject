using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {

        //operationclaim den gelen hangi yetkileri koyamam? cevabını verir
        AccessToken CreateToken(User user, List<OperationClaim> operationCClaims);
    }
}
