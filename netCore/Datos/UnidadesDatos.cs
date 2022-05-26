using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netCore.Models;
using System.Data;
using System.Data.SqlClient;

namespace netCore.Datos
{
    public class UnidadesDatos
    {
        public List<UnidadesModel> Listar()
        {
            var oLista = new List<UnidadesModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetcadenaSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("pr_mostrar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new UnidadesModel()
                        {
                            IDunidades = Convert.ToInt32(dr["IDunidades"]),
                            marca = dr["marca"].ToString(),
                            modelo = dr["modelo"].ToString(),
                            año = Convert.ToInt32(dr["año"]),
                            kilometros = Convert.ToDecimal(dr["kilometros"]),
                            precio = Convert.ToDecimal(dr["precio"])


                        });

                    }
                }

            }
            return oLista;
        }

        public bool Crear(UnidadesModel oUnidades)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetcadenaSql()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("pr_Crear", conexion);
                    cmd.Parameters.AddWithValue("marca", oUnidades.marca);
                    cmd.Parameters.AddWithValue("modelo", oUnidades.modelo);
                    cmd.Parameters.AddWithValue("año", oUnidades.año);
                    cmd.Parameters.AddWithValue("kilometros", oUnidades.kilometros);
                    cmd.Parameters.AddWithValue("precio", oUnidades.precio);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch(Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }






            return respuesta;
        }

        public bool Eliminar(int idContacto)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetcadenaSql()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("pr_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IDunidades", idContacto);
      
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }






            return respuesta;
        }






    }

    }

