using System;
using System.Data;
using Dapper;
using HellowWorld.Data;
using HellowWorld.Models;
using Microsoft.Data.SqlClient;

namespace HellowWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataContextDapper dataContextDapper = new DataContextDapper();

            string sqlCommand = "SELECT GETDATE()";

            DateTime dateTime = dataContextDapper.LoadDataSingle<DateTime>(sqlCommand);
          

          



            Computer myComputer = new Computer(){

                Users="HP",
                Cpu  = 5 ,
                Ram = 16,
                VidioCard  = "HH55",
                HasLan = true

            };
            
            string sqlInsert = @"INSERT INTO TutorialAppSchema.Computer (Users, Cpu, Ram, HasLan, VideoCard) " +
                              "VALUES ( '"+ myComputer.Users +"','"
                                        + myComputer.Cpu +"','"
                                        + myComputer.Ram +"','"
                                        + myComputer.HasLan +"', '"
                                        + myComputer.VidioCard +"')";


            string selectQuery = @"SELECT * FROM TutorialAppSchema.Computer";

            bool res = dataContextDapper.ExecuteSql(sqlInsert);

            int result = dataContextDapper.ExecuteSqlInt(sqlInsert);

            IEnumerable<Computer> computers = dataContextDapper.LoadData<Computer>(selectQuery);

                foreach(Computer single in computers ){
                Console.WriteLine(single.Ram);
                }



            Console.WriteLine(dateTime);
            Console.WriteLine(res);
            Console.WriteLine(result);




        }
        


        
    }
}