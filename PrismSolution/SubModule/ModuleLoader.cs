using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SubModule.Views;

namespace SubModule
{
    public class ModuleLoader : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(SubViewB));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {}
    }
}
