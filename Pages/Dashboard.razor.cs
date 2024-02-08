using Fluxor;
using ImgPOC.Helper;
using ImgPOC.Models;
using ImgPOC.SharedComponent;
using ImgPOC.Store.DashboardUseCase;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace ImgPOC.Pages
{
    public partial class Dashboard
    {
        [Inject]
        private IState<DashboardState>? DashboardState { get; set; }

        private PhotoPage? Data = new PhotoPage();

        [Inject]
        private IDispatcher? Dispatcher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
            Dispatcher?.Dispatch(new DashboardAction());
            //var Data = await PexelUtility.SearchImages();
            //if (Data is not null)
            //{
            //    var photoPage = new PhotoPage
            //    {
            //        next_page = Data.nextPage,
            //        page = Data.page,
            //        per_page = Data.perPage,
            //        total_results = Data.totalResults,
            //    };
            //    try
            //    {
            //        foreach (var item in Data.photos)
            //        {
            //            var source = JsonSerializer.Serialize(item.source);
            //            photoPage.photos.Add(new Photo
            //            {
            //                alt = item.alt,
            //                photographer = item.photographer,
            //                url = item.url,
            //                src = !string.IsNullOrEmpty(source) ? JsonSerializer.Deserialize<Src>(source) : new Src()
            //            }); ;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
        }

        async Task OpenDialogFromService(string url, int id, string name)
        {
            var result = await MatDialogService.OpenAsync(typeof(Dialog), new MatDialogOptions()
            {
                Attributes = new Dictionary<string, object>()
                {
                    {"Id", id},{ "ImgSource", url }, { "Name", name}
                },
                SurfaceStyle = "min-width: 600px; max-width: 700px;"
            });
        }
    }
}
