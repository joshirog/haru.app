using System.Collections.Generic;
using System.Threading.Tasks;

namespace Haru.App.Shared.Services;

public interface INavigationService
{
    Task GoToAsync(string route);
    Task GoToAsync(string route, IDictionary<string, object> parameters);
    Task GoBackAsync();
    // Potentially add other Shell navigation methods as needed
}
