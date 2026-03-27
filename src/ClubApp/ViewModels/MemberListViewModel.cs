using System.Windows.Input;

namespace ClubApp.ViewModels
{
    public class MemberListViewModel
    {
        public ICommand OpenAddCommand { get; set; }
        public ICommand OpenEditCommand { get; set; }
        // Usage of DI for services
    }
}