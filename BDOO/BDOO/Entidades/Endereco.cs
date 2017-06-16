using System;

namespace BDOO.Entidades {
    public class Endereco {
        public Guid Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public Endereco() { }

        public Endereco(Guid id, string cEP, string logradouro, string numero, string bairro, string cidade, string estado, string pais) {
            Id = id;
            CEP = cEP;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public override string ToString() {
            return CEP + " - " + Logradouro + ", " + Numero;
        }
    }
}
