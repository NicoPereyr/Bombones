using Bombones.Entidades.Entidades;
using System.Data.SqlClient;
namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioProveedores
    {
        void Agregar(Proveedor proveedor, SqlConnection conn, SqlTransaction? tran = null);
        void Borrar(int proveedorId, SqlConnection conn, SqlTransaction? tran = null);
        void Editar(Proveedor proveedor, SqlConnection conn, SqlTransaction? tran = null);
        bool Existe(Proveedor proveedor, SqlConnection conn, SqlTransaction? tran = null);
        List<Proveedor> GetLista(SqlConnection conn, SqlTransaction? tran = null);
    }
}
