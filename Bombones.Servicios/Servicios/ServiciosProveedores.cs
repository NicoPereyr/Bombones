using Bombones.Datos.Interfaces;
using Bombones.Datos.Repositorios;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;
namespace Bombones.Servicios.Servicios
{
    public class ServiciosProveedores:IServiciosProveedores
    {
        private readonly IRepositorioProveedores? _repositorio;
        private readonly string? _cadena;
        public ServiciosProveedores(IRepositorioProveedores? repositorio, string? cadena)
        {
            _repositorio = repositorio ?? throw new ApplicationException("Dependencias no cargadas!!!"); ;
            _cadena = cadena;
        }

        public List<Proveedor> GetLista()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio!.GetLista(conn);

            }
        }
        public bool Existe(Proveedor prov)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio!.Existe(prov, conn);

            }
        }
        public void Borrar(int proveedorId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    _repositorio!.Borrar(proveedorId, conn, tran);

                }
            }
        }
        public void Guardar(Proveedor proveedor)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (proveedor.ProveedorId == 0)
                        {
                            _repositorio!.Agregar(proveedor, conn, tran);
                        }
                        else
                        {
                            _repositorio!.Editar(proveedor, conn, tran);
                        }
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

    }
}

