using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;


namespace VeritabaniProjesi
{
    public static class ODBConnector
    {
        public const string connectionString = @"User Id=SYSTEM; Password=1234qwer;" +
                                               @"Data Source = defaultDatabase";

        public static void ConfigureODB()
        {
            // This sample demonstrates how to use ODP.NET Core Configuration API

            // Add connect descriptors and net service names entries.
            string defaultDatabaseInfo =
                "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)(SERVER=dedicated)))";
            OracleConfiguration.OracleDataSources.Add("defaultDatabase", defaultDatabaseInfo);
            //OracleConfiguration.OracleDataSources.Add("orcl", "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE(SERVER=dedicated)))");

            // Set default statement cache size to be used by all connections.
            OracleConfiguration.StatementCacheSize = 25;

            // Disable self tuning by default.
            OracleConfiguration.SelfTuning = false;

            // Bind all parameters by name.
            OracleConfiguration.BindByName = true;

            // Set default timeout to 60 seconds.
            OracleConfiguration.CommandTimeout = 60;

            // Set default fetch size as 1 MB.
            OracleConfiguration.FetchSize = 1024 * 1024;

            // Set tracing options
            OracleConfiguration.TraceOption = 1;
            OracleConfiguration.TraceFileLocation = @"D:\traces";
            // Uncomment below to generate trace files
            //OracleConfiguration.TraceLevel = 7;

            // Set network properties
            OracleConfiguration.SendBufferSize = 8192;
            OracleConfiguration.ReceiveBufferSize = 8192;
            OracleConfiguration.DisableOOB = true;

        }

        public static void AddDbContextToOracleDb<TContext>(IServiceCollection services) where TContext:DbContext
        {
            services.AddDbContext<TContext>(options =>
            {
                options.UseOracle(ODBConnector.connectionString);
            });
        }


        public static bool HasUserBanned(string email)
        {
            OracleConnection conntection = new OracleConnection(connectionString);
            conntection.Open();

            OracleCommand cmd = new OracleCommand($"SELECT * FROM BannedUsers WHERE \"Email\" = '{email}'");
            cmd.Connection = conntection;
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                conntection.Close();
                return true;
            }

            conntection.Close();
            return false;
        }
    }
}