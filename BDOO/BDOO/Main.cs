using BDOO.DAO;
using System;
using System.Windows.Forms;

namespace BDOO
{
    public partial class Main : Form {
        public Main() {
            InitializeComponent();

            ClienteDAO clienteDAO = new ClienteDAO();
            //clienteDAO.Database.Delete();
            //clienteDAO.Database.Create();
        }

        private void btnEnderecos_Click(object sender, EventArgs e)
        {
            Enderecos enderecos = new Enderecos();
            enderecos.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.ShowDialog();
        }
    }
}
