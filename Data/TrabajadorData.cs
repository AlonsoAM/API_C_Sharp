using System.Data.Common;
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
    public class TrabajadorData
    {
        ConexionDB cn = new ConexionDB();

        // Listar Trabajadores
        public async Task<MensajeModel<TrabajadorModel>> ListarTrabajadores()
        {
            MensajeModel<TrabajadorModel> mensaje = new MensajeModel<TrabajadorModel>() { lista = new List<TrabajadorModel>() };

            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    using (var cmd = new SqlCommand("custom_client.sp_listTrabajador", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await sql.OpenAsync();
                        using (var items = await cmd.ExecuteReaderAsync())
                        {
                            while (await items.ReadAsync())
                            {
                                TrabajadorModel dt = new TrabajadorModel();
                                dt.id = (int)items["id"];
                                dt.dni = (string)items["dni"];
                                dt.trabajador = (string)items["trabajador"];
                                dt.cargo = (string)items["cargo"];
                                dt.form_pago = (string)items["form_pago"];
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

        // Listar Trabajador por ID
        public async Task<MensajeModel<TrabajadorModel>> VerTrabajador(int id)
        {
            MensajeModel<TrabajadorModel> mensaje = new MensajeModel<TrabajadorModel>() { lista = new List<TrabajadorModel>() };

            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    using (var cmd = new SqlCommand("custom_client.sp_verTrabajadorPorId", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Pid", id);
                        await sql.OpenAsync();
                        using (var items = await cmd.ExecuteReaderAsync())
                        {
                            while (await items.ReadAsync())
                            {
                                TrabajadorModel dt = new TrabajadorModel();
                                dt.id = (int)items["id"];
                                dt.dni = (string)items["dni"];
                                dt.trabajador = (string)items["trabajador"];
                                dt.cargo = (string)items["cargo"];
                                dt.form_pago = (string)items["form_pago"];
                                dt.banco = (string)items["banco"];
                                dt.cuenta = (string)items["cuenta"];
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

        // Listar Trabajador por FormaPago
        public async Task<MensajeModel<TrabajadorModel>> ListarTrabajadorePorFormaDePago(int id_form_pago)
        {
            MensajeModel<TrabajadorModel> mensaje = new MensajeModel<TrabajadorModel>() { lista = new List<TrabajadorModel>() };

            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    using (var cmd = new SqlCommand("custom_client.sp_filtrarTrabajadorPorFormaPago", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PidFormaPago", id_form_pago);
                        await sql.OpenAsync();
                        using (var items = await cmd.ExecuteReaderAsync())
                        {
                            while (await items.ReadAsync())
                            {
                                TrabajadorModel dt = new TrabajadorModel();
                                dt.id = (int)items["id"];
                                dt.dni = (string)items["dni"];
                                dt.trabajador = (string)items["trabajador"];
                                dt.cargo = (string)items["cargo"];
                                dt.form_pago = (string)items["form_pago"];
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

        // Insertar un trabajador
        public async Task<SimpleRespModel> InsertarTrabajador(ParamsInsertarTrabajadorModel parametros)
        {
            SimpleRespModel mensaje = new SimpleRespModel();

            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    using (var cmd = new SqlCommand("custom_client.sp_insertarTrabajador", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Carga de parámetros
                        //dni
                        SqlParameter Ptra_dni = new SqlParameter();
                        Ptra_dni.ParameterName = "@Ptra_dni";
                        Ptra_dni.SqlDbType = SqlDbType.VarChar;
                        Ptra_dni.Size = 8;
                        Ptra_dni.Value = parametros.tra_dni;
                        cmd.Parameters.Add(Ptra_dni);
                        //ape
                        SqlParameter Ptra_ape = new SqlParameter();
                        Ptra_ape.ParameterName = "@Ptra_ape";
                        Ptra_ape.SqlDbType = SqlDbType.VarChar;
                        Ptra_ape.Size = 100;
                        Ptra_ape.Value = parametros.tra_ape;
                        cmd.Parameters.Add(Ptra_ape);
                        //nom
                        SqlParameter Ptra_nom = new SqlParameter();
                        Ptra_nom.ParameterName = "@Ptra_nom";
                        Ptra_nom.SqlDbType = SqlDbType.VarChar;
                        Ptra_dni.Size = 100;
                        Ptra_nom.Value = parametros.tra_nom;
                        cmd.Parameters.Add(Ptra_nom);
                        //id_cat_tra
                        SqlParameter Pid_car_tra = new SqlParameter();
                        Pid_car_tra.ParameterName = "@Pid_car_tra";
                        Pid_car_tra.SqlDbType = SqlDbType.Int;
                        Pid_car_tra.Value = parametros.id_car_tra;
                        cmd.Parameters.Add(Pid_car_tra);
                        //id_form_pago
                        SqlParameter Pid_form_pago = new SqlParameter();
                        Pid_form_pago.ParameterName = "@Pid_form_pago";
                        Pid_form_pago.SqlDbType = SqlDbType.Int;
                        Pid_form_pago.Value = parametros.id_form_pago;
                        cmd.Parameters.Add(Pid_form_pago);
                        //id_banco
                        SqlParameter Pid_banco = new SqlParameter();
                        Pid_banco.ParameterName = "@Pid_ban";
                        Pid_banco.SqlDbType = SqlDbType.Int;
                        Pid_banco.Value = parametros.id_ban;
                        cmd.Parameters.Add(Pid_banco);
                        //num_cue
                        SqlParameter Ptra_num_cue = new SqlParameter();
                        Ptra_num_cue.ParameterName = "@Ptra_num_cue";
                        Ptra_num_cue.SqlDbType = SqlDbType.VarChar;
                        Ptra_num_cue.Size = 100;
                        Ptra_num_cue.Value = parametros.tra_num_cue;
                        cmd.Parameters.Add(Ptra_num_cue);

                        // Parámetros de salida

                        //mensajeID
                        SqlParameter PmensajeID = new SqlParameter();
                        PmensajeID.ParameterName = "@PmensajeID";
                        PmensajeID.SqlDbType = SqlDbType.Int;
                        PmensajeID.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(PmensajeID);
                        //mensaje
                        SqlParameter Pmensaje = new SqlParameter();
                        Pmensaje.ParameterName = "@Pmensaje";
                        Pmensaje.SqlDbType = SqlDbType.VarChar;
                        Pmensaje.Size = 250;
                        Pmensaje.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(Pmensaje);
                        //error
                        SqlParameter Perror = new SqlParameter();
                        Perror.ParameterName = "@Perror";
                        Perror.SqlDbType = SqlDbType.VarChar;
                        Perror.Size = 2500;
                        Perror.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(Perror);
                        //valorID
                        SqlParameter PvalorID = new SqlParameter();
                        PvalorID.ParameterName = "@PvalorID";
                        PvalorID.SqlDbType = SqlDbType.Int;
                        PvalorID.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(PvalorID);

                        // fin carga de parámetros

                        // Abrir conexión y ejecutar SP
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        // Cargar mensaje
                        mensaje.mensajeID = int.Parse(PmensajeID.Value.ToString());
                        mensaje.mensaje = Pmensaje.Value.ToString();
                        mensaje.error = Perror.Value.ToString();
                        mensaje.valorID = int.Parse(PvalorID.Value.ToString());

                    }
                }
            }
            catch (System.Exception ex)
            {
                mensaje.mensajeID = 0;
                mensaje.mensaje = "Error, no se puedo insertar la data";
                mensaje.valorID = 0;
                mensaje.error = ex.ToString();
            }
            return mensaje;
        }

        // Insertar un acrualizar
        public async Task<SimpleRespModel> ActualizarTrabajador(ParamsInsertarTrabajadorModel parametros, int id)
        {
            SimpleRespModel mensaje = new SimpleRespModel();

            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    using (var cmd = new SqlCommand("custom_client.sp_actualizarTrabajador", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Carga de parámetros
                        //id
                        SqlParameter Pid_tra = new SqlParameter();
                        Pid_tra.ParameterName = "@Pid_tra";
                        Pid_tra.SqlDbType = SqlDbType.VarChar;
                        Pid_tra.Value = id;
                        cmd.Parameters.Add(Pid_tra);

                        //dni
                        SqlParameter Ptra_dni = new SqlParameter();
                        Ptra_dni.ParameterName = "@Ptra_dni";
                        Ptra_dni.SqlDbType = SqlDbType.VarChar;
                        Ptra_dni.Size = 8;
                        Ptra_dni.Value = parametros.tra_dni;
                        cmd.Parameters.Add(Ptra_dni);
                        //ape
                        SqlParameter Ptra_ape = new SqlParameter();
                        Ptra_ape.ParameterName = "@Ptra_ape";
                        Ptra_ape.SqlDbType = SqlDbType.VarChar;
                        Ptra_ape.Size = 100;
                        Ptra_ape.Value = parametros.tra_ape;
                        cmd.Parameters.Add(Ptra_ape);
                        //nom
                        SqlParameter Ptra_nom = new SqlParameter();
                        Ptra_nom.ParameterName = "@Ptra_nom";
                        Ptra_nom.SqlDbType = SqlDbType.VarChar;
                        Ptra_dni.Size = 100;
                        Ptra_nom.Value = parametros.tra_nom;
                        cmd.Parameters.Add(Ptra_nom);
                        //id_cat_tra
                        SqlParameter Pid_car_tra = new SqlParameter();
                        Pid_car_tra.ParameterName = "@Pid_car_tra";
                        Pid_car_tra.SqlDbType = SqlDbType.Int;
                        Pid_car_tra.Value = parametros.id_car_tra;
                        cmd.Parameters.Add(Pid_car_tra);
                        //id_form_pago
                        SqlParameter Pid_form_pago = new SqlParameter();
                        Pid_form_pago.ParameterName = "@Pid_form_pago";
                        Pid_form_pago.SqlDbType = SqlDbType.Int;
                        Pid_form_pago.Value = parametros.id_form_pago;
                        cmd.Parameters.Add(Pid_form_pago);
                        //id_banco
                        SqlParameter Pid_banco = new SqlParameter();
                        Pid_banco.ParameterName = "@Pid_ban";
                        Pid_banco.SqlDbType = SqlDbType.Int;
                        Pid_banco.Value = parametros.id_ban;
                        cmd.Parameters.Add(Pid_banco);
                        //num_cue
                        SqlParameter Ptra_num_cue = new SqlParameter();
                        Ptra_num_cue.ParameterName = "@Ptra_num_cue";
                        Ptra_num_cue.SqlDbType = SqlDbType.VarChar;
                        Ptra_num_cue.Size = 100;
                        Ptra_num_cue.Value = parametros.tra_num_cue;
                        cmd.Parameters.Add(Ptra_num_cue);

                        // Parámetros de salida

                        //mensajeID
                        SqlParameter PmensajeID = new SqlParameter();
                        PmensajeID.ParameterName = "@PmensajeID";
                        PmensajeID.SqlDbType = SqlDbType.Int;
                        PmensajeID.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(PmensajeID);
                        //mensaje
                        SqlParameter Pmensaje = new SqlParameter();
                        Pmensaje.ParameterName = "@Pmensaje";
                        Pmensaje.SqlDbType = SqlDbType.VarChar;
                        Pmensaje.Size = 250;
                        Pmensaje.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(Pmensaje);
                        //error
                        SqlParameter Perror = new SqlParameter();
                        Perror.ParameterName = "@Perror";
                        Perror.SqlDbType = SqlDbType.VarChar;
                        Perror.Size = 2500;
                        Perror.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(Perror);
                        //valorID
                        SqlParameter PvalorID = new SqlParameter();
                        PvalorID.ParameterName = "@PvalorID";
                        PvalorID.SqlDbType = SqlDbType.Int;
                        PvalorID.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(PvalorID);

                        // fin carga de parámetros

                        // Abrir conexión y ejecutar SP
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        // Cargar mensaje
                        mensaje.mensajeID = int.Parse(PmensajeID.Value.ToString());
                        mensaje.mensaje = Pmensaje.Value.ToString();
                        mensaje.error = Perror.Value.ToString();
                        mensaje.valorID = int.Parse(PvalorID.Value.ToString());

                    }
                }
            }
            catch (System.Exception ex)
            {
                mensaje.mensajeID = 0;
                mensaje.mensaje = "Error, no se puedo insertar la data";
                mensaje.valorID = 0;
                mensaje.error = ex.ToString();
            }
            return mensaje;
        }
    }
}