using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ClubApp.ViewModels
{
    public class MemberEditViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Properties and commands implementation here
        public ICommand SaveCommand { get; set; }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}