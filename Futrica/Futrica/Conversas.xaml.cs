using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Futrica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conversas : ContentPage
    {
        public Conversas()
        {
            InitializeComponent();
        }

        async void OnContatosButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contatos());
        }

        async void OnMensagensButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Mensagens());
        }
    }
}