using Aluno.infra;
using Aluno.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Aluno.dao
{
    public class PessoaDAO
    {
        static XamarinSQLite db;
        public PessoaDAO()
        {

        }
        
        public static XamarinSQLite SqliteDb
        {
            get
            {
                if (db == null)
                {
                    db = new XamarinSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pessoa.db3"));
                }
            
                return db;
            }
        }


        public async void Add(Pessoa pessoa)
        {
            if (pessoa != null)
            {
                //Add New Person
                await SqliteDb.SaveItemAsync(pessoa);
            }
        }

        public async Task<Pessoa> ReadPessoa(Pessoa pessoa)
        {
            if (pessoa != null)
            {
                //Get Person
               return await SqliteDb.GetItemAsync(pessoa.Id);
            }

            return null;
        }

        public async Task<List<Pessoa>> ReadPessoas()
        {
            //Get Person
            return await SqliteDb.GetItemsAsync();
        }
        
        private async void UpdatePessoa(Pessoa pessoa)
        {
            if (pessoa != null)
            {
                //Add New Person
                await SqliteDb.SaveItemAsync(pessoa);
            }
        }

        private async Task<List<Pessoa>> DeletePessoa(Pessoa pessoa)
        {
            if (pessoa != null)
            {
                //Get Person
                var pessoaResult = await SqliteDb.GetItemAsync(pessoa.Id);
                if (pessoaResult != null)
                {
                    //Delete Person
                    await SqliteDb.DeleteItemAsync(pessoaResult);
                    //Get All Persons
                    var personList = await SqliteDb.GetItemsAsync();
                    if (personList != null)
                    {
                      return personList;
                    }
                }
            }

            return null;
        }
    }
}
