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
        EncryptAndDecryptService encrypAnddecrypS = new EncryptAndDecryptService();

        public ProfessorDBAccessProvider()
        {
            var client = new MongoClient(MongoConnection);
            var database = client.GetDatabase(MongoDatabase);
            _professor = database.GetCollection<Professor>("Professors");

        }

        public List<Professor> Get() =>
            _professor.Find<Professor>(professor => true).ToList();

        public Professor Create(Professor professor)
        {
            professor.password = encrypAnddecrypS.encrypts(professor.password);
            _professor.InsertOne(professor);
            return professor;
        }
        public bool verifyCredentials(LogInAndOutMessage msg)
        {

            msg.password = encrypAnddecrypS.encrypts(msg.password);
            bool query = _professor.AsQueryable<Professor>().Any(p => p._id == msg.id && p.password == msg.password);
            return query;

        }
    }
}