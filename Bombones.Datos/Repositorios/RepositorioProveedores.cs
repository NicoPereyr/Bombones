using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;
namespace Bombones.Datos.Repositorios
{
    public class RepositorioProveedores: IRepositorioProveedores
    {
        public RepositorioProveedores()
        {
        }

        public void Agregar(Proveedor prov, SqlConnection conn, SqlTransaction? tran = null)
        {
            string insertQuery = @"INSERT INTO Proveedores (NombreProveedor) 
                    VALUES(@NombreProveedor); SELECT CAST(SCOPE_IDENTITY() as int)";

            var primaryKey = conn.QuerySingle<int>(insertQuery, prov, tran);
            if (primaryKey > 0)
            {

                prov.ProveedorId = primaryKey;
                return;
            }

            throw new Exception("No se pudo agregar el proveedor");
        }

        public void Borrar(int provId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string deleteQuery = @"DELETE FROM Proveedores 
                    WHERE ProveedorId=@ProvId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { provId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar el proveedor");
            }
        }

        public void Editar(Proveedor prov, SqlConnection conn, SqlTransaction? tran = null)
        {
            string updateQuery = @"UPDATE Proveedores 
                    SET Descripcion=@NombreProveedor 
                    WHERE ProveedorId=@ProveedorId";

            int registrosAfectados = conn.Execute(updateQuery, prov, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar el proveedor");
            }
        }


        public bool Existe(Proveedor prov, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) FROM Proveedores ";
                string finalQuery = string.Empty;
                string conditional = string.Empty;
                if (prov.ProveedorId == 0)
                {
                    conditional = "WHERE NombreProveedor = @NombreProveedor";
                }
                else
                {
                    conditional = @"WHERE NombreProveedor = @NombreProveedor
                                AND ProveedorId<>@ProveedorId";
                }
                finalQuery = string.Concat(selectQuery, conditional);
                return conn.QuerySingle<int>(finalQuery, prov) > 0;


            }
            catch (Exception)
            {

                throw new Exception("No se pudo comprobar si existe el proveedor");
            }
        }

        public List<Proveedor> GetLista(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT ProveedorId, NombreProveedor FROM 
                        Proveedores ORDER BY NombreProveedor";
            return conn.Query<Proveedor>(selectQuery).ToList();
        }
    }
}

