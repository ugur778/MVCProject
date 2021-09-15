using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public partial class RoleService
    {
        private KeyValuePair<bool, string> SameNameValidation(string name)
        {
            var count = RoleRepository.GetCountByName(name);
            if (count == 0)
                return new KeyValuePair<bool, string>(true, "İşlem Başarılı");
            return new KeyValuePair<bool, string>(false, "Mükerrer Role");
        }
    }
}
