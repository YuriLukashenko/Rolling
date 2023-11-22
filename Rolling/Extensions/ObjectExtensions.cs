namespace Rolling.Extensions
{
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T obj) where T : class
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var cloned = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            return cloned ?? throw new Exception($"{obj.GetType().Name} is not clonable.");
        }
    }
}
