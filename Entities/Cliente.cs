using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cliente
    {
        [Key]
        public long Cli_Id { get; set; }
        [MaxLength(50)]
        public string Cli_Email { get; set; }
        public string Cli_Nome { get; set; }
        public DateTime? Cli_DataNascimento { get; set; }
        public bool Cli_Ativo { get; set; }

        public Cliente(long id,string email, string nome, DateTime? data, bool ativo)
        {
            this.Cli_Id = id;
            this.Cli_Nome = nome;
            this.Cli_Email = email;
            this.Cli_DataNascimento = data;
            this.Cli_Ativo = ativo;
        }

        public Cliente(string nome, DateTime? data, bool ativo)
        {
            this.Cli_Nome = nome;
            this.Cli_DataNascimento = data;
            this.Cli_Ativo = ativo;
        }
        public Cliente()
        {

        }

        public Cliente(Cliente cliente)
        {
            this.Cli_Id = cliente.Cli_Id;
            this.Cli_Nome = cliente.Cli_Nome;
            this.Cli_DataNascimento = cliente.Cli_DataNascimento;
            this.Cli_Ativo = cliente.Cli_Ativo;
        }
    }
}
