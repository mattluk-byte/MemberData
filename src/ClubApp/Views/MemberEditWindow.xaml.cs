using System.Windows;
using ClubApp.ViewModels;

namespace ClubApp.Views
{
    public partial class MemberEditWindow : Window
    {
        public MemberEditWindow(MemberEditViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}