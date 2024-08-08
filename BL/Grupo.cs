using BL.Interfaces;
using DL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;

namespace BL
{
    public class Grupo : IGrupo
    {
        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {

                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();


                var query = "GrupoGetAll";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;

                DataTable tableGrupo = new DataTable();


                DataSet ds = new DataSet();

                ds.Tables.Add(tableGrupo);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(tableGrupo);

                if (tableGrupo.Rows.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach (DataRow fila in tableGrupo.Rows)
                    {
                        ML.Grupo grupo = new ML.Grupo();

                        grupo.IdGrupo = int.Parse(fila[0].ToString());
                        grupo.Nombre = fila[1].ToString();
                        grupo.Turno = fila[2].ToString();
                        grupo.Generacion = fila[3].ToString();
                        grupo.Carrera = new ML.Carrera();
                        grupo.Carrera.IdCarrera = int.Parse(fila[4].ToString());
                        grupo.Carrera.Nombre = fila[5].ToString();

                        result.Objects.Add(grupo);
                    }
                    result.Correct = true;
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            finally
            {
                Conexion.GetInstancia().CloseConnection();
            }

            return result;

        }
        public ML.Result Delete(ML.Grupo grupo)
        {
            ML.Result result = new ML.Result();

            try
            {

                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();


                var query = "GrupoDelete";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdGrupo", grupo.IdGrupo);


                int RowAffected = command.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            finally
            {
                Conexion.GetInstancia().CloseConnection();
            }

            return result;


        }

        public ML.Result GetById(int idGrupo)
        {
            ML.Result result = new ML.Result();

            try
            {

                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();


                var query = "GrupoGetById";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdGrupo", idGrupo);

                DataTable tableGrupo = new DataTable();


                DataSet ds = new DataSet();

                ds.Tables.Add(tableGrupo);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(tableGrupo);

                if (tableGrupo.Rows.Count > 0)
                {
                    var fila = tableGrupo.Rows[0];

                    ML.Grupo grupo = new ML.Grupo();

                    grupo.IdGrupo = int.Parse(fila[0].ToString());
                    grupo.Nombre = fila[1].ToString();
                    grupo.Turno = fila[2].ToString();
                    grupo.Generacion = fila[3].ToString();
                    grupo.Carrera = new ML.Carrera();
                    grupo.Carrera.IdCarrera = int.Parse(fila[4].ToString());
                    grupo.Carrera.Nombre = fila[5].ToString();
                    result.Object = grupo;
                    result.Correct = true;
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            finally
            {
                Conexion.GetInstancia().CloseConnection();
            }

            return result;


        }


    }
}
