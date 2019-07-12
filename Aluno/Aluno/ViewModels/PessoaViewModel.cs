using Aluno.dao;
using Aluno.models;
using Aluno.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Aluno.ViewModels
{
    public class PessoaViewModel   
    {

        public ICommand AddItems { get; set; }
        PessoaDAO dao;

        public PessoaViewModel()
        {
            this.Pessoa = new Pessoa();
            dao = new PessoaDAO();

            AddItems = new Command(async () => await add());
        }

        private async Task add()
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = Nome;
            pessoa.Email = Email;
            dao.Add(pessoa);

            await Application.Current.MainPage.Navigation.PushAsync(new PessoaListagemView(), true);
        }

        public Pessoa Pessoa { get; set; }

        public int Id
        {
            get
            {
                return Pessoa.Id;
            }
            set
            {
                Pessoa.Id = value;
            }
        }


        public string Nome
        {
            get
            {
                return Pessoa.Nome;
            }
            set
            {
                Pessoa.Nome = value;
            }
        }

        public string Email
        {
            get
            {
                return Pessoa.Email;
            }

            set
            {
                Pessoa.Email = value;
            }
        }
    }
}
