using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace AndroidApp.ViewModels
{
    public class AppShellViewModel:BaseViewModel
    {
        public ICommand LogOutCommand {get => new Command(async () => await LogOut()) ; }

        public async Task LogOut()
        {
            await Shell.Current.DisplayAlert("todo", "you ve been signed out!", "Ok");
        }
    }
}