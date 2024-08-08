﻿using BL.Interfaces;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia : IMateria
    {
        public ML.Result GetAllMateria()
        {
            ML.Result result = new ML.Result();
            try
            {
                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();

                //context.Open();

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
                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = int.Parse(fila[0].ToString());
                        materia.Nombre = fila[1].ToString();
                        materia.Descripcion = fila[2].ToString();
                        materia.Costo = decimal.Parse(fila[3].ToString());
                        materia.Creditos = int.Parse(fila[4].ToString());

                        result.Objects.Add(materia);
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

        public ML.Result GetByIdMateria(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();

                var query = "MateriaGetById";
                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdMateria", idMateria);

                DataTable tableMateria = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(tableMateria);

                if (tableMateria.Rows.Count > 0)
                {
                    DataRow row = tableMateria.Rows[0];
                    ML.Materia materia = new ML.Materia();

                    materia.IdMateria = int.Parse(row["IdMateria"].ToString());
                    materia.Nombre = row["Nombre"].ToString();
                    materia.Descripcion = row["Descripcion"].ToString();
                    materia.Costo = decimal.Parse(row["Costo"].ToString());
                    materia.Creditos = int.Parse(row["Creditos"].ToString());

                    result.Object = materia;
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró la materia.";
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

        public ML.Result AddMateria(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();

                var query = "MateriaAdd";
                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Nombre", materia.Nombre);
                command.Parameters.AddWithValue("@Descripcion", materia.Descripcion);
                command.Parameters.AddWithValue("@Costo", materia.Costo);
                command.Parameters.AddWithValue("@Creditos", materia.Creditos);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se pudo insertar la materia.";
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
        public ML.Result UpdateMateria(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();

                //context.Open();
                var query = "UpdateMateria"; 
                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;

               
                command.Parameters.AddWithValue("@IdMateria", materia.IdMateria);
                command.Parameters.AddWithValue("@Nombre", materia.Nombre);
                command.Parameters.AddWithValue("@Descripcion", materia.Descripcion);
                command.Parameters.AddWithValue("@Costo", materia.Costo);
                command.Parameters.AddWithValue("@Creditos", materia.Creditos);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se pudo actualizar la materia.";
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

        public ML.Result DeleteMateria(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                DL.Conexion dbConnection = DL.Conexion.GetInstancia();
                SqlConnection context = dbConnection.GetConnection();

                //context.Open();
                var query = "DeleteMateria"; 
                SqlCommand command = new SqlCommand(query, context);
                command.CommandType = CommandType.StoredProcedure;

                
                command.Parameters.AddWithValue("@IdMateria", idMateria);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se pudo eliminar la materia.";
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
                Conexion.GetInstancia().GetConnection();
            }

            return result;
        }
    }
}
