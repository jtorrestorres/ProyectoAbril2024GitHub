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
    public class Carrera :  ICarrera
    {
        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {

                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();


                var query = "CarreraGetAll";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;

                DataTable tableCarrera = new DataTable();


                DataSet ds = new DataSet();

                ds.Tables.Add(tableCarrera);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(tableCarrera);

                if (tableCarrera.Rows.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach (DataRow fila in tableCarrera.Rows)
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


                var query = "CarreraDelete";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdCarrera", carrera.IdCarrera);

                int RowAffected = command.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    result.Correct=true;
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
