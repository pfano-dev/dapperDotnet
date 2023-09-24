
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace HellowWorld.Data{

public class DataContextDapper{

  private  string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;trustservercertificate=true;Trusted_Connection=True;";


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