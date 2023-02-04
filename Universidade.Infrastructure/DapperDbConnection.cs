using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Universidade.Domain.Interfaces.Repository;
using Universidade.Domain.Settings;

namespace Universidade.Infrastructure
{
    public class DapperDbConnection : IDapperDbConnection
    {
        private readonly AppSetting _appSetting;
        public DapperDbConnection(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }
        public IDbConnection CreateDbConnection()
        {
            var connection = new SqlConnection(_appSetting.SqlServerConnection);
            return connection;
        }
    }
}
