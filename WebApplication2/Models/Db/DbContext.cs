﻿using Npgsql;

namespace WebApplication2.Models.Db
{
    public class DbContext
    {

        public NpgsqlConnection connection { get; }
        string connString = "Host=localhost;Username=postgres;Password=123;Database=test";

        public DbContext() {
            connection = new NpgsqlConnection(connString);
            connection.Open();

        }

    }
}
