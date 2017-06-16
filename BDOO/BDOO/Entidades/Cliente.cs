using System;

namespace BDOO.Entidades {
    public class Cliente {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid EnderecoID { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string Telefone { get; set; }

        public Cliente() { }

        public Cliente(Guid id, string nome, DateTime dataNascimento, Endereco endereco, string telefone) {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            EnderecoID = endereco.Id;
            Endereco = endereco;
            Telefone = telefone;
        }
    }
}
