using Prism.Commands;
using Prism.Mvvm;
using System;

namespace TestPrismApp.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string displayName;
        public string DisplayName
        {
            get => displayName;
            set => SetProperty(ref displayName, value);
        }

        // IsEnabled  UpdateText
        private bool isEnabled;
        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                SetProperty(ref isEnabled, value);
                ExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        private string updateText;
        public string UpdateText
        {
            get => updateText;
            set => SetProperty(ref updateText, value);
        }


        //ExecuteCommand
        public DelegateCommand ExecuteCommand { get; set; }

        public MainViewModel()
        {
            DisplayName = "Prism App";
            ExecuteCommand = new DelegateCommand(Execute, CanExecute);
        }

        private void Execute()
        {
            UpdateText = $"Updated : {DateTime.Now}";
        }

        private bool CanExecute()
        {
            return IsEnabled;
        }
    }
}
