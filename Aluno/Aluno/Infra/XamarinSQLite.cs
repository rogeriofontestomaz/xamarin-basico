using Aluno.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aluno.infra
{
    public class XamarinSQLite
    {
        SQLiteAsyncConnection db;
        public XamarinSQLite(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Pessoa>().Wait();
        }

        //Insert and Update new record
        public Task<int> SaveItemAsync(Pessoa pessoa)
        {
            if (pessoa.Id != 0)
            {
                return db.UpdateAsync(pessoa);
            }
            else
            {
                return db.InsertAsync(pessoa);
            }
        }

        //Delete
        public Task<int> DeleteItemAsync(Pessoa pessoa)
        {
            return db.DeleteAsync(pessoa);
        }

        //Read All Items
        public Task<List<Pessoa>> GetItemsAsync()
        {
            return db.Table<Pessoa>().ToListAsync();
        }


        //Read Item
        public Task<Pessoa> GetItemAsync(int id)
        {
            return db.Table<Pessoa>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}
