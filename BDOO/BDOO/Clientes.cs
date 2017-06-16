using BDOO.DAO;
using BDOO.Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BDOO
{
    public partial class Clientes : Form {

        private ClienteDAO clienteDao;

        private EnderecoDAO enderecoDao;

        public Clientes() {
            clienteDao = new ClienteDAO();
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

            InitializeData();
            LimpaCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e) {
            LimpaCampos();
        }

        private void btnDeletar_Click(object sender, EventArgs e) {
            if (DeleteEndereco(((BindingSource)this.dgvClientes.DataSource).Current as Cliente)) {
                LimpaCampos();
            }
        }

        private void dgvClientes_Click(object sender, EventArgs e) {
            SetDataToForm(((BindingSource)this.dgvClientes.DataSource).Current as Cliente);
        }

        private bool DeleteEndereco(Cliente cliente) {
            try {
                clienteDao.Clientes.Attach(cliente);
                clienteDao.Clientes.Local.Remove(cliente);
                clienteDao.SaveChanges();
                InitializeData();
                return true;
            } catch {
                return false;
            }
        }

        private void SetDataToForm(Cliente cliente) {
            this.txbID.Text = cliente.Id.ToString();
            this.txbNome.Text = cliente.Nome;
            this.dtpDataNascimento.Value = cliente.DataNascimento == DateTime.MinValue ? DateTime.Now : cliente.DataNascimento;
            this.cbxEndereco.SelectedValue = cliente.Endereco == null ? Guid.Empty : cliente.Endereco.Id;
            this.txbTelefone.Text = cliente.Telefone;
        }

        private void LimpaCampos() {
            this.txbID.Text = string.Empty;
            this.txbNome.Text = string.Empty;
            this.dtpDataNascimento.Value = DateTime.Now;
            this.cbxEndereco.SelectedIndex = -1;
            this.txbTelefone.Text = string.Empty;
        }

        private void InitializeData() {
            BindingSource source_cliente = new BindingSource();
            source_cliente.DataSource = clienteDao.Clientes.ToList();
            this.dgvClientes.DataSource = source_cliente;

            BindingSource source_endereco = new BindingSource();
            source_endereco.DataSource = enderecoDao.Enderecos.ToList();
            cbxEndereco.DataSource = source_endereco;
            cbxEndereco.ValueMember = "Id";
            cbxEndereco.DisplayMember = "Logradouro";
        }

        private bool InsereEndereco() {
            try {
                Cliente cliente = new Cliente();
                cliente.Id = Guid.NewGuid();
                cliente.Nome = txbNome.Text;
                cliente.DataNascimento = dtpDataNascimento.Value;
                cliente.EnderecoID = (cbxEndereco.SelectedValue as Endereco).Id;
                cliente.Telefone = txbTelefone.Text;

                clienteDao.Clientes.Add(cliente);
                clienteDao.SaveChanges();
                return true;
            } catch (Exception e){
                return false;
            }
        }

        private bool UpdateEndereco() {
            try {
                Cliente cliente_encontrado = clienteDao.Clientes.Find(new Guid(txbID.Text));
                clienteDao.Clientes.Attach(cliente_encontrado);

                cliente_encontrado.Nome = txbNome.Text;
                cliente_encontrado.DataNascimento = dtpDataNascimento.Value;
                cliente_encontrado.EnderecoID = (cbxEndereco.SelectedValue as Endereco).Id;
                cliente_encontrado.Telefone = txbTelefone.Text;

                var entry = clienteDao.Entry(cliente_encontrado);
                clienteDao.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

    }
}
