using Aluno.dao;
using Aluno.Helpers;
using Aluno.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Aluno.ViewModels
{
    public class PessoaListagemViewModel : ObservableObject
    {
        public string tag = "AlunoApp";
        public ICommand LoadItems { get; set; }
        PessoaDAO dao;

        private ObservableCollection<Pessoa> _pessoas;
        public ObservableCollection<Pessoa> Pessoas
        {
            get { return _pessoas; }
            set { SetProperty(ref _pessoas, value); }
        }
        
        public PessoaListagemViewModel()
        {

            dao = new PessoaDAO();

            LoadItems = new Command(async () => await load());

        }

        private async Task load()
        {
            var items = await dao.ReadPessoas();
            this.Pessoas = new ObservableCollection<Pessoa>(items);
         
            Log.Warning(tag, "this is an info message" + this.Pessoas);
        }
    }
}
