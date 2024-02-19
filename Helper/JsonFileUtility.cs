using System.Text.Json.Serialization;
using System.Text.Json;

namespace ImgPOC.Helper
{
    public static class JsonFileUtility
    {
        private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
        
        public static void Write(object obj, string fileName)
        {
            try
            {
                var options = new JsonSerializerOptions(_options)
                {
                    WriteIndented = true
                };
                var jsonString = JsonSerializer.Serialize(obj, options);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                throw;
            }            
        }
    }
}
