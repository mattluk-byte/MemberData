using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ClubApp.Models;
using System;

namespace ClubApp.ViewModels
{
    public class FeeEditViewModel : ObservableObject
    {
        public Fee Fee { get; }
        public bool DialogResult { get; private set; }
        public event Action? RequestClose;

        public IRelayCommand SaveCommand { get; }
        public IRelayCommand CancelCommand { get; }

        public FeeEditViewModel(Fee fee)
        {
            Fee = fee;
            SaveCommand = new RelayCommand(OnSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private void OnSave()
        {
            DialogResult = true;
            RequestClose?.Invoke();
        }
        private void OnCancel()
        {
            DialogResult = false;
            RequestClose?.Invoke();
        }
    }
}