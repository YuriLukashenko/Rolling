using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolling.Extensions
{
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T obj) where T : class
        {
            // And below is using Newtonsoft as Int64 is not converted to long but as JsonAttribute
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var cloned = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            return cloned ?? throw new Exception($"{obj.GetType().Name} is not clonable.");
        }
    }
}
