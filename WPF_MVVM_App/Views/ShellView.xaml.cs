using MahApps.Metro.Controls;
using WPF_MVVM_App.ViewModels;

namespace WPF_MVVM_App.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        public ShellView()
        {
            InitializeComponent();
            this.DataContext = new ShellViewModel();
        }
    }
}
