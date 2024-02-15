using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace ImgPOC.SharedComponent
{
    public partial class Dialog//(IJSRuntime js) : IDisposable
    {
        private readonly IJSRuntime? js;
        [Parameter]
        public int Id { get; set; } = 1;
        [Parameter]
        public string ImgSource { get; set; } = "";
        [Parameter]
        public string Name { get; set; } = "";
        [CascadingParameter]
        public MatDialogReference? DialogReference { get; set; }

        private MatProgressCircle matC;
        private async void CloseDialog()
        {
            DialogReference?.Close("Test");
            await js.InvokeVoidAsync("RemoveScrollClass");
        }
        public void Dispose()
        {
            // The following prevents derived types that introduce a
            // finalizer from needing to re-implement IDisposable.
            GC.SuppressFinalize(this);
        }
    }
}
