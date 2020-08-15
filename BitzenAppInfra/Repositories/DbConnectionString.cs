﻿using BitzenAppInfra.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppInfra.Repositories
{
    public class DbConnectionString : IDbConnectionString
    {
        public NpgsqlConnection Connection()
        {
            return new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=123; Database=");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
