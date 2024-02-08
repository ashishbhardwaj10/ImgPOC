using MatBlazor;
using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;

namespace ImgPOC.SharedComponent
{    public partial class Dialog
    {
        [Parameter]
        public int Id { get; set; } = 1;
        [Parameter]
        public string ImgSource { get; set; } = "";
        [Parameter]
        public string Name { get; set; } = "";
        [CascadingParameter]
        public MatDialogReference? DialogReference { get; set; }

        private void CloseDialog()
        {
            
            //document.querySelector("body.mdc-dialog-scroll-lock")?.classList.remove("mdc-dialog-scroll-lock");
            DialogReference?.Close("Test");
        }
    }
}
