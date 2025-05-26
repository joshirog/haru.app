using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haru.App.Shared.Services;

public class NavigationService : INavigationService
{
    public Task GoToAsync(string route) => Shell.Current.GoToAsync(route);

    public Task GoToAsync(string route, IDictionary<string, object> parameters) => Shell.Current.GoToAsync(route, parameters);
    
    public Task GoBackAsync() => Shell.Current.GoBackAsync();
}
