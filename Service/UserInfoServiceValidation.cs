using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public partial class UserInfoService
    {
        private KeyValuePair<bool, string> SameUserNameValidation(string userName)
        {
            var result = new KeyValuePair<bool, string>(true, "Validasyona takılmamıştır.");
            List<UserInfo> userInfoResult = UserInfoRepository.GetByUserName(userName);
            if (userInfoResult.Any())
                result = new KeyValuePair<bool, string>(false, "Aynı Username'den bulunmaktadır.");

            return result;

        }
    }
}
