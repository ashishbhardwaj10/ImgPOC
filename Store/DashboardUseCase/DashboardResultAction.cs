using ImgPOC.Models;

namespace ImgPOC.Store.DashboardUseCase
{
    public class DashboardResultAction(PhotoPage photoPage)
    {
        public PhotoPage PhotoPage { get; } = photoPage;
    }
}
