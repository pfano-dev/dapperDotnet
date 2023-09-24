using System;
using System.Data;
using Dapper;
using HellowWorld.Data;
using HellowWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HellowWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json")
            .Build();

            DataContextDapper dataContextDapper = new DataContextDapper(configuration);
            DataContextEF dataContextEF = new DataContextEF(configuration);

            string sqlCommand = "SELECT GETDATE()";

            DateTime dateTime = dataContextDapper.LoadDataSingle<DateTime>(sqlCommand);
          

            Computer myComputer = new Computer(){

                Users="samsung",
                Cpu  = 9 ,
                Ram = 16,
                VideoCard  = "HH55",
                HasLan = true

            };

            dataContextEF.Add(myComputer);
            dataContextEF.SaveChanges();
            
            // string sqlInsert = @"INSERT INTO TutorialAppSchema.Computer (Users, Cpu, Ram, HasLan, VideoCard) " +
            //                   "VALUES ( '"+ myComputer.Users +"','"
            //                             + myComputer.Cpu +"','"
            //                             + myComputer.Ram +"','"
            //                             + myComputer.HasLan +"', '"
            //                             + myComputer.VidioCard +"')";


            // string selectQuery = @"SELECT * FROM TutorialAppSchema.Computer";

            // bool res = dataContextDapper.ExecuteSql(sqlInsert);

            // int result = dataContextDapper.ExecuteSqlInt(sqlInsert);

            // IEnumerable<Computer> computers = dataContextDapper.LoadData<Computer>(selectQuery);

            //     foreach(Computer single in computers ){
            //     Console.WriteLine(single.Ram);
            //     }




            IEnumerable<Computer>? computers = dataContextEF.Computer?.ToList<Computer>();

            if (computers != null)
            {
                foreach (Computer single in computers)
                {
                    Console.WriteLine(single.Users);
                }

            }



            Console.WriteLine(dateTime);
            // Console.WriteLine(res);
            // Console.WriteLine(result);




        }
        


        
    }
}