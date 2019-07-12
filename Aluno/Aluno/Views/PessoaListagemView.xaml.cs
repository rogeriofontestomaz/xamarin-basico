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
    public partial class PessoaListagemView : ContentPage
    {
        private PessoaListagemViewModel _viewModel;
        public PessoaListagemView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PessoaListagemViewModel();
        }

        protected override void OnAppearing()
        {
            _viewModel.LoadItems.Execute(null);

            base.OnAppearing();
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PessoaView(), true);
        }

        public void listViewPessoas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var pessoa = (Pessoa)e.Item;
           
            DisplayAlert("Agendamento",
            string.Format(
                @"Id {0}
                 Nome: {1}
                 E-mail: {2}",
                pessoa.Id,
                pessoa.Nome,
                pessoa.Email), "OK");
        }

    }
}