using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace XTECDigitalAPI.Models
{
    public class ProfessorDBAccessProvider
    {
        public static string MongoConnection = "mongodb+srv://SMZ19:SMZ19@xtecdigitalcluster.conak.mongodb.net/XTECDigitalDB?retryWrites=true&w=majority";
        public static string MongoDatabase = "XTECDigitalDB";
        private readonly IMongoCollection<Professor> _professor;

        public ProfessorDBAccessProvider()
        {
            var client = new MongoClient(MongoConnection);
            var database = client.GetDatabase(MongoDatabase);
            _professor = database.GetCollection<Professor>("Professors");

        }

        public List<Professor> Get() =>
            _professor.Find<Professor>(student => true).ToList();

        public Professor Create(Professor professor)
        {
            _professor.InsertOne(professor);
            return professor;
        }
    }
}