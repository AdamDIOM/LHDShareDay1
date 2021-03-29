using System;
using System.Linq;
using Cassandra;

namespace astraconnect
{
    class Program
    {
        static void Main(string[] args)
        {

            var session = Cluster.Builder()
                        .WithCloudSecureConnectionBundle(@"secure-connect-mlhvideos.zip")
                        //or if on linux .WithCloudSecureConnectionBundle(@"/PATH/TO/>>secure-connect-datastax-test.zip")
                        .WithCredentials("<clientid>", "<clientsecret>")
                        .Build()
                        .Connect();
            
            Random randomnum = new Random();

            int random = randomnum.Next(100000,100000000);


            Console.WriteLine("insert url");
            string url = Console.ReadLine();
            Console.WriteLine($"are you sure that {url} is the correct url? (y/n)");

            if(Console.ReadLine().ToLower()[0] == 'y'){
                
                session.Execute($"INSERT INTO videos.videos (id, url) VALUES (${random}, ${url});");

            }


            //Console.WriteLine(rowSet.First().GetValue<string>("key"));

        }
    }
}