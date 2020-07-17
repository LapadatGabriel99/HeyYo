using HeyYo.Core.App.Text;
using ReactiveUI;

namespace HeyYo.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                this.RaiseAndSetIfChanged(ref _title, value);
            }
        }

        public MainViewModel()
        {
            Title = TextNormalization.AppTitle;
        }
    }
}
