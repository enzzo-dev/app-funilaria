using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyShopAI.Domain.Entities
{
    public class Error
    {
        #region Properties
        public Guid IdError { get; private set; }
        public string LogError { get; private set; }
        public string StackTrace { get; private set; }
        public Exception Exception { get; private set; }
        public string ClassName { get; private set; }
        #endregion


        public static Error CreateLog(Exception ex) => new Error(ex);

        protected Error(Exception ex)
        {
            IdError = Guid.NewGuid();
            LogError = ex.Message;
            StackTrace = ex.StackTrace;
            Exception = ex.InnerException;
            ClassName = ex.Source;
        }
    }
}
