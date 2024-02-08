using Fluxor;
using ImgPOC.Helper;
using ImgPOC.Models;
using System.Text.Json;

namespace ImgPOC.Store.DashboardUseCase
{
    public class Effects
    {
        [EffectMethod()]
        public async Task HandleDashboardAction(DashboardAction action, IDispatcher dispatcher)
        {
            //Apit Call
            var Data = await PexelUtility.SearchImages();
            if (Data is not null)
            {
                var photoPage = new PhotoPage
                {
                    next_page = Data.nextPage,
                    page = Data.page,
                    per_page = Data.perPage,
                    total_results = Data.totalResults,
                };
                try
                {
                    foreach (var item in Data.photos)
                    {
                        var source = JsonSerializer.Serialize(item.source);
                        photoPage.photos.Add(new Photo
                        {
                            alt = item.alt,
                            photographer = item.photographer,
                            url = item.url,
                            src = !string.IsNullOrEmpty(source) ? JsonSerializer.Deserialize<Src>(source) : new Src()
                        }); ;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                dispatcher.Dispatch(new DashboardResultAction(photoPage));
            }
        }
    }
}
