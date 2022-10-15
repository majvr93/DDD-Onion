using Newtonsoft.Json;

namespace BookingMsApiV2.Services
{
    public static class CastUtil
    {
        public static T2 Cast<T1, T2>(T1 target1)
        {
            var serialized = JsonConvert.SerializeObject(target1);
            return JsonConvert.DeserializeObject<T2>(serialized);
        }
    }
}
