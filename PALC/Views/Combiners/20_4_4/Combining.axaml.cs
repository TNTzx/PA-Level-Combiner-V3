using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;

using PALC.ViewModels.Combiners._20_4_4;
using PALC.Views.Templates;
using static PALC.ViewModels.Combiners._20_4_4.CombiningVM;

namespace PALC.Views.Combiners._20_4_4;

public partial class Combining : Window
{
    public CombiningVM vm;

    public Combining(CombiningVM vm)
    {
        InitializeComponent();
        this.vm = vm;
        DataContext = vm;

        vm.Finished += OnFinished;
        vm.CombineError += CombineError;
    }

    public Combining() : this(new CombiningVM()) { }


    public async void OnLoad(object? sender, RoutedEventArgs e) => await vm.Combine();


    private async Task OnFinished(object? sender, FinishedArgs e)
    {
        await MessageBoxManager.GetMessageBoxStandard(
            "Finished combining!",
            "Finished!",
            icon: MsBox.Avalonia.Enums.Icon.Success
        ).ShowWindowDialogAsync(this);
    }

    private async Task CombineError(object? sender, CombineErrorArgs e)
    {
        await MessageBoxTools.CreateErrorMsgBox(e.message, e.ex).ShowWindowDialogAsync(this);
    }


    private RelayCommand? _onFinishClickCommand;
    public RelayCommand OnFinishClickCommand => _onFinishClickCommand ??= new RelayCommand(OnFinishClick);
    private void OnFinishClick()
        => Close();
}
