﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Boletim.Context.cs
{
    public class BoletimContext
    {
        SqlConnection con = new SqlConnection();

        public BoletimContext()
        {
            con.ConnectionString = @"Data Source=DESKTOP-TSI8JUU\SQLEXPRESS;Initial Catalog=boletim;Integrated Security=True";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}