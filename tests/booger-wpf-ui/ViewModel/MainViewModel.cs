namespace Jsinh.BoogerWpf.Test.ViewModel
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.SomeBoolProperty = "This is JUST a test.";
        }

        ////private RelayCommand changeValueCommand;
        private string someBoolProperty;

        ////public RelayCommand ChangeValueCommand
        ////{
        ////    get
        ////    {
        ////        return this.changeValueCommand ?? (this.changeValueCommand = new RelayCommand(() =>
        ////        {
        ////            this.SomeBoolProperty = !this.SomeBoolProperty;
        ////        }));
        ////    }
        ////}

        public string SomeBoolProperty
        {
            get
            {
                return this.someBoolProperty;
            }

            set
            {
                this.someBoolProperty = value;
                this.RaisePropertyChanged(() => this.SomeBoolProperty);
            }
        }
    }
}