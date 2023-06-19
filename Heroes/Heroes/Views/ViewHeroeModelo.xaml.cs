using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Heroes.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewHeroeModelo : ContentPage
	{
		public ViewHeroeModelo ()
		{
			InitializeComponent ();
		}


		//private Async para crear PopUp con entrada de texto
		private async void BotonAlertaTexto (object sender, EventArgs e)
		{

			string texto = await DisplayPromptAsync("A continuacion escriba el nombre de los Poderes", "Poder: ", placeholder: "Poder");



		}
	}
}