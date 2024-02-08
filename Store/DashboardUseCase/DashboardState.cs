using Fluxor;
using ImgPOC.Models;

namespace ImgPOC.Store.DashboardUseCase
{
    [FeatureState]
    public class DashboardState
    {
        public bool IsLoading { get; }
        public PhotoPage? PhotoPage { get; }

        private DashboardState() { }
        public DashboardState(bool isLoading, PhotoPage photoPage)
        {
            IsLoading = isLoading;
            PhotoPage = photoPage ?? new PhotoPage();
        }
    }
}
