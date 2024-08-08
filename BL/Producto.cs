using BL.Interfaces;
using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace BL
{
    public class Producto : IProducto
    {
        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {

                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();

                context.Open();

                var query = "MateriaGetAll";

                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;

                DataTable tableMateria = new DataTable();


                DataSet ds = new DataSet();

                ds.Tables.Add(tableMateria);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(tableMateria);

                if (tableMateria.Rows.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach (DataRow fila in tableMateria.Rows)
                    {
                        //ML.Materia materia = new ML.Materia();
                        
                        //materia.IdMateria = int.Parse(fila[0].ToString());
                        //materia.Nombre = fila[1].ToString();
                        //materia.Descripcion = fila[2].ToString();
                        //materia.Semestre = new ML.Semestre();
                        //materia.Semestre.IdSemestre = byte.Parse(fila[3].ToString());
                        //// materia.Semestre = byte.Parse(fila[3].ToString());
                        //materia.Costo = decimal.Parse(fila[4].ToString());

                        //result.Objects.Add(materia);
                    }
                    result.Correct = true;
                }
                

            }
            catch (Exception ex)
            {
                //dbConnection.Close();
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

        public ML.Result Add()
        {
            throw new NotImplementedException();
        }
    }
}
