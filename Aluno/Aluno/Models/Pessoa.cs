using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aluno.models
{
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
