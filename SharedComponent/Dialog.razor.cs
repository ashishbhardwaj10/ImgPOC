using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace ImgPOC.SharedComponent
{
    public partial class Dialog
    {
        [Inject]
        private IJSRuntime JS { get; set; }
        [Parameter]
        public int Id { get; set; } = 1;
        [Parameter]
        public string ImgSource { get; set; } = "";
        [Parameter]
        public string Name { get; set; } = "";
        [CascadingParameter]
        public MatDialogReference? DialogReference { get; set; }

        private async void CloseDialog()
        {
            DialogReference?.Close("Test");
            await JS.InvokeVoidAsync("RemoveScrollClass");
        }
        public void Dispose()
        {
            // The following prevents derived types that introduce a
            // finalizer from needing to re-implement IDisposable.
            GC.SuppressFinalize(this);
        }
    }
}
