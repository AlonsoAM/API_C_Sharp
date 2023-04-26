using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using novaltyAPI.Conexion;
using novaltyAPI.Model;
using System.Data;
using System.Data.SqlClient;

namespace novaltyAPI.Data
{
    public class CargoData
    {
        ConexionDB cn = new ConexionDB();

        // Listar Cargos
        public async Task<MensajeModel<CargoModel>> ListarCargos()
        {
            MensajeModel<CargoModel> mensaje = new MensajeModel<CargoModel>() { lista = new List<CargoModel>() };

            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    using (var cmd = new SqlCommand("custom_client.sp_listarCargos", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await sql.OpenAsync();
                        using (var items = await cmd.ExecuteReaderAsync())
                        {
                            while (await items.ReadAsync())
                            {
                                CargoModel dt = new CargoModel();
                                dt.id = (int)items["id"];
                                dt.cargo = (string)items["cargo"];
                                mensaje.lista.Add(dt);
                            }
                            mensaje.mensajeID = 1;
                            mensaje.mensaje = "Datos cargados exitosamente";
                            mensaje.valorID = 0;
                            mensaje.error = "";
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                mensaje.mensajeID = 0;
                mensaje.mensaje = "Error, no se puedo obtener la data";
                mensaje.valorID = 0;
                mensaje.error = ex.ToString();
            }
            return mensaje;
        }

    }
}