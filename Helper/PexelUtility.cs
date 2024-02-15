using PexelsDotNetSDK.Api;
using PexelsDotNetSDK.Models;

namespace ImgPOC.Helper
{
    public class PexelUtility
    {
        private static PexelsClient pexelsClient => new("ZwNU752Jpkha5PUt7hoML2RizWJucQxusGa8YXj4RIAWyJ7kPA9qTZi5");

        public static async Task<PhotoPage> SearchImages(int page = 1, int pageSize = 100)
        {
            _ = new PhotoPage();
            PhotoPage? response;
            try
            {
                response = await pexelsClient.SearchPhotosAsync("Nature", page: page, pageSize: pageSize);
            }
            catch (Exception)
            {
                throw;
            }

            return response;
        }
    }
}
