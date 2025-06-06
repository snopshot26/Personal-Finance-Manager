using System.Threading.Tasks;

namespace Personal_Finance_Manager.Service
{
    public interface INavigationAware
    {
        Task OnNavigatedToAsync(object? parameter);
    }
}
