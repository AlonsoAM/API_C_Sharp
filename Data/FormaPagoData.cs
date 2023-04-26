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
    public class FormaPagoData
    {
        ConexionDB cn = new ConexionDB();

        // Listar Bancos
        public async Task<MensajeModel<FormaPagoModel>> ListarFormasPago()
        {
            MensajeModel<FormaPagoModel> mensaje = new MensajeModel<FormaPagoModel>() { lista = new List<FormaPagoModel>() };

            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    using (var cmd = new SqlCommand("custom_client.sp_listarFormasDePago", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await sql.OpenAsync();
                        using (var items = await cmd.ExecuteReaderAsync())
                        {
                            while (await items.ReadAsync())
                            {
                                FormaPagoModel dt = new FormaPagoModel();
                                dt.id = (int)items["id"];
                                dt.forma_pago = (string)items["forma_pago"];
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