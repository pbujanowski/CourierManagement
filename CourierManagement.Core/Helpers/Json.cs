using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CourierManagement.Core.Helpers
{
    public static class Json
    {
        public static async Task<T> ToObjectAsync<T>(string value)
        {
            return await Task.Run<T>(() => JsonConvert.DeserializeObject<T>(value)).ConfigureAwait(false);
        }

        public static async Task<string> StringifyAsync(object value)
        {
            return await Task.Run<string>(() => JsonConvert.SerializeObject(value)).ConfigureAwait(false);
        }
    }
}