using BDOO.DAO;
using BDOO.Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BDOO
{
    public partial class Enderecos : Form {

        private EnderecoDAO enderecoDao;

        public Enderecos() {
            enderecoDao = new EnderecoDAO();
            InitializeComponent();
            InitializeData();
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txbID.Text)) {
                InsereEndereco();
            } else {
                UpdateEndereco();
            }

            LimpaCampos();
            InitializeData();
        }

        private void btnNovo_Click(object sender, EventArgs e) {
            LimpaCampos();
        }

        private void btnDeletar_Click(object sender, EventArgs e) {
            if (DeleteEndereco(((BindingSource)this.dgvEnderecos.DataSource).Current as Endereco)) {
                LimpaCampos();
            }
        }

        private void dgvEnderecos_Click(object sender, EventArgs e) {
            SetDataToForm(((BindingSource)this.dgvEnderecos.DataSource).Current as Endereco);
        }

        private void LimpaCampos() {
            this.txbID.Text = string.Empty;
            this.txbCEP.Text = string.Empty;
            this.txbLogradouro.Text = string.Empty;
            this.txbNumero.Text = string.Empty;
            this.txbBairro.Text = string.Empty;
            this.txbEstado.Text = string.Empty;
            this.txbPais.Text = string.Empty;
            this.txbCidade.Text = string.Empty;
        }

        private bool DeleteEndereco(Endereco endereco) {
            try {
                enderecoDao.Enderecos.Attach(endereco);
                enderecoDao.Enderecos.Local.Remove(endereco);
                enderecoDao.SaveChanges();
                InitializeData();
                return true;
            } catch {
                return false;
            }
        }

        private void InitializeData() {
            BindingSource source = new BindingSource();
            source.DataSource = enderecoDao.Enderecos.ToList();
            this.dgvEnderecos.DataSource = source;
        }

        private void SetDataToForm(Endereco endereco) {
            this.txbID.Text = endereco.Id.ToString();
            this.txbCEP.Text = endereco.CEP;
            this.txbLogradouro.Text = endereco.Logradouro;
            this.txbNumero.Text = endereco.Numero;
            this.txbBairro.Text = endereco.Bairro;
            this.txbEstado.Text = endereco.Estado;
            this.txbPais.Text = endereco.Pais;
            this.txbCidade.Text = endereco.Cidade;
        }

        private bool UpdateEndereco() {
            try {
                Endereco endereco_encontrado = enderecoDao.Enderecos.Find(new Guid(txbID.Text));
                enderecoDao.Enderecos.Attach(endereco_encontrado);

                endereco_encontrado.CEP = txbCEP.Text;
                endereco_encontrado.Logradouro = txbLogradouro.Text;
                endereco_encontrado.Numero = txbNumero.Text;
                endereco_encontrado.Bairro = txbBairro.Text;
                endereco_encontrado.Estado = txbEstado.Text;
                endereco_encontrado.Pais = txbPais.Text;
                endereco_encontrado.Cidade = txbCidade.Text;

                var entry = enderecoDao.Entry(endereco_encontrado);
                enderecoDao.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        private bool InsereEndereco() {
            try {
                Endereco endereco = new Endereco(Guid.NewGuid(), txbCEP.Text, txbLogradouro.Text, txbNumero.Text, txbBairro.Text, txbCidade.Text, txbEstado.Text, txbPais.Text);
                enderecoDao.Enderecos.Add(endereco);
                enderecoDao.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }
    }
}
