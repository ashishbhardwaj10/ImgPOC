using Fluxor;

namespace ImgPOC.Store.DashboardUseCase
{
    public static class Reducers
    {
        [ReducerMethod(typeof(DashboardAction))]
        public static DashboardState ReduceDashboardAction(DashboardState state) => new DashboardState(isLoading: true, photoPage: null);

        [ReducerMethod()]
        public static DashboardState ReduceDashboardResultAction(DashboardState state, DashboardResultAction resultAction) => new DashboardState(isLoading: false, photoPage: resultAction.PhotoPage);
    }
}
