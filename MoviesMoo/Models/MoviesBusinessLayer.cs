using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MoviesMoo.Models
{
    public class MoviesBusinessLayer
    {
        public void SaveMovies(Movies movies)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["MoviesDBconnectionstring"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spEditeMovies", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //Movies-Id
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = movies.Id;
                cmd.Parameters.Add(paramId);

                //Movies-Name
                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = movies.Name;
                cmd.Parameters.Add(paramName);

                //Movies-Genre
                SqlParameter paramGenre = new SqlParameter();
                paramGenre.ParameterName = "@Genre";
                paramGenre.Value = movies.Genre;
                cmd.Parameters.Add(paramGenre);

                //Movies-ReleasDate
                SqlParameter paramReleasDate = new SqlParameter();
                paramReleasDate.ParameterName = "@ReleasDate";
                paramReleasDate.Value = movies.ReleasDate;
                cmd.Parameters.Add(paramReleasDate);

                //Movies-DateAdd
                SqlParameter paramDateAdd = new SqlParameter();
                paramDateAdd.ParameterName = "@DateAdd";
                paramDateAdd.Value = movies.DateAdd;
                cmd.Parameters.Add(paramDateAdd);

                //Movies-NumberInStock
                SqlParameter paramNumberInStock = new SqlParameter();
                paramNumberInStock.ParameterName = "@NumberInStock";
                paramNumberInStock.Value = movies.NumberInStock;
                cmd.Parameters.Add(paramNumberInStock);

                //Movies-MemberAvalible
                SqlParameter paramMemberAvalible = new SqlParameter();
                paramMemberAvalible.ParameterName = "@MemberAvalible";
                paramMemberAvalible.Value = movies.MemberAvalible;
                cmd.Parameters.Add(paramMemberAvalible);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}