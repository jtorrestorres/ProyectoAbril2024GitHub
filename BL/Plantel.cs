using BL.Interfaces;
using DL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plantel : ICatalogo
    {
        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {

                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();


                var query = "PlantelGetAll";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;

                DataTable tablePlantel = new DataTable();


                DataSet ds = new DataSet();

                ds.Tables.Add(tablePlantel);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(tablePlantel);

                if (tablePlantel.Rows.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach (DataRow fila in tablePlantel.Rows)
                    {
                        ML.Carrera carrera = new ML.Carrera();

                        carrera.IdCarrera = int.Parse(fila[0].ToString());
                        carrera.Nombre = fila[1].ToString();

                        result.Objects.Add(carrera);
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

        public ML.Result Delete(ML.Carrera carrera)
        {
            ML.Result result = new ML.Result();

            try
            {

                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();


                var query = "CatalogoDelete";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPlantel", carrera.IdCarrera);

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

        public ML.Result GetById(int idCarrerra)
        {
            ML.Result result = new ML.Result();

            try
            {
                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();


                var query = "PlantelGetById";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPlantel", idCarrerra);

                DataTable tablePlantel = new DataTable();


                DataSet ds = new DataSet();

                ds.Tables.Add(tablePlantel);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(tablePlantel);

                if (tablePlantel.Rows.Count > 0)
                {
                    var fila = tablePlantel.Rows[0];

                    ML.Carrera carrera = new ML.Carrera();

                    carrera.IdCarrera = int.Parse(fila[0].ToString());
                    carrera.Nombre = fila[1].ToString();

                    result.Object = carrera;
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

        public ML.Result Add(ML.Carrera catalogo)
        {
            ML.Result result = new ML.Result();

            try
            {

                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();


                var query = "PlantelAdd";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", catalogo.Nombre);

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

        public ML.Result Update(ML.Carrera catalogo)
        {
            ML.Result result = new ML.Result();

            try
            {

                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();


                var query = "PlantelUpdate";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPlantel", catalogo.IdCarrera);
                command.Parameters.AddWithValue("@Nombre", catalogo.Nombre);

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
    }
}
