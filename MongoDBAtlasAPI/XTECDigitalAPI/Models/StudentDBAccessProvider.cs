using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace XTECDigitalAPI.Models
{
    public class StudentDBAccessProvider
    {
        public static string MongoConnection = "mongodb+srv://SMZ19:SMZ19@xtecdigitalcluster.conak.mongodb.net/XTECDigitalDB?retryWrites=true&w=majority";
        public static string MongoDatabase = "XTECDigitalDB";
        private readonly IMongoCollection<Student> _students;
        EncryptAndDecryptService encrypAnddecrypS = new EncryptAndDecryptService();

        public StudentDBAccessProvider()
        {
            var client = new MongoClient(MongoConnection);
            var database = client.GetDatabase(MongoDatabase);
            _students = database.GetCollection<Student>("Students");
        }
        public List<Student> Get() =>
            _students.Find(student => true).ToList();

        public Student Get(string id) =>
            _students.Find<Student>(student => student._id == id).FirstOrDefault();

        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public void Update(Student student) =>
            _students.ReplaceOne(st => st._id == student._id, student);

        public void Remove(Student student) =>
            _students.DeleteOne(st => st._id == student._id);

        public void Remove(string id) =>
            _students.DeleteOne(student => student._id == id);

        public bool verifyCredentials(LogInAndOutMessage msg) {

            msg.password = encrypAnddecrypS.encrypts(msg.password);
            bool query = _students.AsQueryable<Student>().Any(s => s._id == msg.id && s.password == msg.password);
            return query;

        }
    }





}
