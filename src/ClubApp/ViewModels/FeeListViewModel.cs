using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ClubApp.Models;
using ClubApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ClubApp.ViewModels
{
    public class FeeListViewModel : ObservableObject
    {
        private readonly IFeeService _service;
        public ObservableCollection<Fee> FeeItems { get; } = new ObservableCollection<Fee>();

        private Fee? _selected;
        public Fee? SelectedFee { get => _selected; set => SetProperty(ref _selected, value); }

        public IRelayCommand AddCommand { get; }
        public IRelayCommand EditCommand { get; }
        public IRelayCommand DeleteCommand { get; }
        public IRelayCommand RefreshCommand { get; }

        public FeeListViewModel(IFeeService service) 
        {
            _service = service;
            AddCommand = new RelayCommand(OnAdd);
            EditCommand = new RelayCommand(OnEdit, () => SelectedFee != null);
            DeleteCommand = new RelayCommand(async () => await OnDeleteAsync(), () => SelectedFee != null);
            RefreshCommand = new RelayCommand(async () => await LoadAsync());
        }

        public async Task LoadAsync()
        {
            FeeItems.Clear();
            var list = await _service.GetAllAsync();
            foreach (var f in list) FeeItems.Add(f);
        }

        private void OnAdd()
        {
            var vm = new FeeEditViewModel(new Fee());
            var dlg = new Views.FeeEditDialog { DataContext = vm };
            vm.RequestClose += () => { if (vm.DialogResult) _ = LoadAsync(); dlg.Close(); };
            dlg.ShowDialog();
        }

        private void OnEdit()
        {
            if (SelectedFee == null) return;
            var copy = new Fee {
                Id = SelectedFee.Id,
                Code = SelectedFee.Code,
                Name = SelectedFee.Name,
                Amount = SelectedFee.Amount,
                Description = SelectedFee.Description,
                IsActive = SelectedFee.IsActive
            };
            var vm = new FeeEditViewModel(copy);
            var dlg = new Views.FeeEditDialog { DataContext = vm };
            vm.RequestClose += async () => { if (vm.DialogResult) { await _service.UpdateAsync(vm.Fee); await LoadAsync(); } dlg.Close(); };
            dlg.ShowDialog();
        }

        private async Task OnDeleteAsync()
        {
            if (SelectedFee == null) return;
            await _service.DeleteAsync(SelectedFee);
            await LoadAsync();
        }
    }
}