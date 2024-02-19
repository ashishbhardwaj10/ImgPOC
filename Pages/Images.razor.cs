using Blazored.LocalStorage;
using ImgPOC.Helper;
using ImgPOC.Models;
using ImgPOC.Store.DashboardUseCase;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ImgPOC.Pages
{
    public partial class Images
    {
        [Inject]
        private HttpClient _httpClient { get; set; }

        [Inject]
        private IJSRuntime JS { get; set; }

        [Inject]
        private ILocalStorageService _localstorage { get; set; }

        [Inject]
        protected IMatToaster Toaster { get; set; }

        private ImageModel image = new ImageModel();
        public List<ImageModel> tableData;

        public Images()
        {
            tableData = new List<ImageModel>();
            //LoadData();
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            //tableData = await _httpClient.GetFromJsonAsync<List<ImageModel>>("sample-data/imageData.json");
            this.LoadData();
        }

        private async Task Success()
        {
            var message = "Something went wrong!";
            if (image != null)
            {
                if (image.Id > 0)
                {
                    message = $"Updated Successfully with key: {image.Id}";
                }
                else
                {
                    var lenght = await _localstorage.LengthAsync();
                    image.Id = lenght > 0 ? lenght + 1 : 1;
                    message = $"Added Successfully with key: {image.Id}";
                }

                var data = JsonSerializer.Serialize(image);
                await _localstorage.SetItemAsStringAsync(image.Id.ToString(), data);
            }

            LoadData();

            //await JS.InvokeAsync<object>("alert", message);
            Toaster.Add(message, MatToastType.Success, "Done");
            Reset();
        }

        private async void Reset()
        {
            //tableData.Remove(image);
            image.ImageUrl = null;
            image.Photographer = null;
            image.Name = null;
            image.Id = 0;
        }

        public void SelectionChangedEvent(object row)
        {
            this.StateHasChanged();
        }

        public async void LoadData()
        {
            try
            {
                var dataLength = await _localstorage.LengthAsync();
                tableData.Clear();
                if (dataLength > 0)
                {
                    for (int i = 0; i <= dataLength; i++)
                    {
                        var key = $"{i + 1}";
                        if (await _localstorage.ContainKeyAsync(key))
                        {
                            var data = await _localstorage.GetItemAsStringAsync(key);
                            if (data != null)
                            {
                                var model = JsonSerializer.Deserialize<ImageModel>(data);
                                tableData.Add(model);
                            }
                        }
                    }
                }
                else
                {
                    Toaster.Add("Data is not available, Please add new from above form.", MatToastType.Info, "Information");
                }
                this.StateHasChanged();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task Edit(int id)
        {
            var img = tableData.Where(x => x.Id == id).FirstOrDefault();
            image.Id = id;
            image.Name = img.Name;
            image.ImageUrl = img.ImageUrl;
            image.Photographer = img.Photographer;
        }
        private async Task Delete(int id)
        {
            await _localstorage.RemoveItemAsync(id.ToString());
            LoadData();
            //await JS.InvokeAsync<object>("alert", $"Delete Successfully with key: {id}");
            Toaster.Add($"Delete Successfully with key: {id}", MatToastType.Dark, "Delete");
        }
    }
}