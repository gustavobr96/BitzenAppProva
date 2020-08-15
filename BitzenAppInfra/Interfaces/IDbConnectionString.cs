using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppInfra.Interfaces
{
    public interface IDbConnectionString : IDisposable
    {
       NpgsqlConnection Connection();
    }
}
