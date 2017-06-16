using BDOO.Entidades;
using System.Data.Entity;

namespace BDOO.DAO
{
    public class EnderecoDAO : DbContext{

        public DbSet<Endereco> Enderecos { get; set; }

        public EnderecoDAO() : base("Server = tcp:bdoo.database.windows.net,1433; Database = BDOO; User ID =bdoo; Password =@senha123456; Trusted_Connection = False; Encrypt = True; PersistSecurityInfo = True") {
        }

    }
}
