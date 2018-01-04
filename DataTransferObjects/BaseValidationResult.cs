using System.Linq;
using System.Reflection;

namespace UstSoft.DataTransferObjects
{
    public class BaseValidationResult
    {
        public virtual bool Success
        {
            get
            {
                return !GetType().GetProperties().Any(o => o.Name != nameof(Success) &&
                    o.PropertyType == typeof(bool) && (bool)o.GetValue(this, null));
            }
        }
    }
}
