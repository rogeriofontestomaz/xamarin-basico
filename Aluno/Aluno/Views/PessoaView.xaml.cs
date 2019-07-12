using Aluno.dao;
using Aluno.models;
using Aluno.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aluno.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PessoaView : ContentPage
	{
        public PessoaViewModel ViewModel { get; set; }
        
        public PessoaView()
		{
			InitializeComponent ();
            this.ViewModel = new PessoaViewModel();
            this.BindingContext = this.ViewModel;
        }
        
        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
            string.Format(
             @"Id {0}
             Nome: {1}
             E-mail: {2}",
             ViewModel.Id,
             ViewModel.Nome,
             ViewModel.Email), "OK");
        }
    }

     
}