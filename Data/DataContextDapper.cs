
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HellowWorld.Data{

public class DataContextDapper{

  private readonly string?  _connectionString;
    private readonly IConfiguration _configuration;
public DataContextDapper( IConfiguration configuration){

      _configuration = configuration;
      _connectionString = configuration.GetConnectionString("DefaultConnection");

}

  public IEnumerable<T> LoadData<T>(string sql){

      IDbConnection dbConnection = new SqlConnection(_connectionString);

      return dbConnection.Query<T>(sql);
  }


public T LoadDataSingle<T>(string sql){

    IDbConnection dbConnection = new SqlConnection(_connectionString);

      return dbConnection.QuerySingle<T>(sql);
}

public bool ExecuteSql(string sql){

 IDbConnection dbConnection = new SqlConnection(_connectionString);
      return (dbConnection.Execute(sql) > 0); 
}

public int ExecuteSqlInt(string sql){

 IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.Execute(sql); 
}





}

}