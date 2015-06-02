namespace Jsinh.BoogerWpf.Test.ViewModel
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;

    public class MainViewModel : ViewModelBase
    {
        private RelayCommand changeValueCommand;
        private bool someBoolProperty;

        public RelayCommand ChangeValueCommand
        {
            get
            {
                return this.changeValueCommand ?? (this.changeValueCommand = new RelayCommand(() =>
                {
                    this.SomeBoolProperty = !this.SomeBoolProperty;
                }));
            }
        }

        public bool SomeBoolProperty
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