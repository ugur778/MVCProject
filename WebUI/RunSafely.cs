using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI
{
    public static class ObjectExtentions
    {
        /// <summary>
        /// Tüm projede try catch yerine bu kullanılarak tüm exception tek merkezden yönetilir.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <param name="errorAction"></param>
        public static void RunSafely(this object obj, Action action, Action<Exception> errorAction = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                while (innerException != null && innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                //lOG eKLE

                if (errorAction != null)
                {
                    errorAction(ex);
                }
            }
        }
    }
}