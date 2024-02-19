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
            await base.OnInitializedAsync();
            Dispatcher?.Dispatch(new DashboardAction());
            
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
