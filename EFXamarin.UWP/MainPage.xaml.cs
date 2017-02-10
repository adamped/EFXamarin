// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

using System.IO;

namespace EFXamarin.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "exrin.db");

            LoadApplication(new EFXamarin.App(dbPath));
        }
    }
}
