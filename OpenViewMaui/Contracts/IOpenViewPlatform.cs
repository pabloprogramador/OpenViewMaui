using System;
namespace OpenViewMaui.Contracts
{
	public interface IOpenViewPlatform
	{
        Task AddAsync(OpenViewPage page);

        Task RemoveAsync(OpenViewPage page);

        public static IViewHandler GetOrCreateHandler<TPageHandler>(VisualElement bindable) where TPageHandler : IViewHandler, new()
        {
            return bindable.Handler ??= new TPageHandler();
        }
    }
}