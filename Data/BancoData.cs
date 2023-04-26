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
    public class BancoData
    {
        ConexionDB cn = new ConexionDB();

        // Listar Bancos
        public async Task<MensajeModel<BancoModel>> ListarBancos()
        {
            MensajeModel<BancoModel> mensaje = new MensajeModel<BancoModel>() { lista = new List<BancoModel>() };

            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    using (var cmd = new SqlCommand("custom_client.sp_listarBancos", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await sql.OpenAsync();
                        using (var items = await cmd.ExecuteReaderAsync())
                        {
                            while (await items.ReadAsync())
                            {
                                BancoModel dt = new BancoModel();
                                dt.id = (int)items["id"];
                                dt.banco = (string)items["banco"];
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