using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository
    {
        private MVCDataBaseEntities mvcDataBaseEntities;
        public MVCDataBaseEntities Model
        {
            get
            {
                if (mvcDataBaseEntities is null)
                    mvcDataBaseEntities = new MVCDataBaseEntities();
                return mvcDataBaseEntities;
            }
        }


    }
}
