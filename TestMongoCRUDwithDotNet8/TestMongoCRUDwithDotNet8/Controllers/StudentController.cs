using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using TestMongoCRUDwithDotNet8.Models;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMongoCollection<Student> _studentCollection;
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger, IConfiguration configuration)
    {
        _logger = logger;
        var connectionString = configuration["MongoDb:ConnectionString"];
        var databaseName = configuration["MongoDb:DatabaseName"];

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);

        _studentCollection = database.GetCollection<Student>("Students");
    }

    // Get all students
    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        var students = _studentCollection.Find(_ => true).ToList();
        return Ok(students);
    }

    // Get a single student by ID
    [HttpGet("{id:length(24)}", Name = "GetStudentById")]
    public ActionResult<Student> GetSingle(string id)
    {
        var student = _studentCollection.Find(s => s.Id == id).FirstOrDefault();
        if (student == null)
        {
            return NotFound($"Student with ID {id} not found.");
        }

        return Ok(student);
    }

    // Insert a new student
    [HttpPost]
    public ActionResult<Student> Insert([FromBody] Student newStudent)
    {
        _studentCollection.InsertOne(newStudent);
        return CreatedAtRoute("GetStudentById", new { id = newStudent.Id }, newStudent);
    }

    // Update an existing student
    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, [FromBody] Student updatedStudent)
    {
        var existingStudent = _studentCollection.Find(s => s.Id == id).FirstOrDefault();

        if (existingStudent == null)
        {
            return NotFound($"Student with ID {id} not found.");
        }

        _studentCollection.ReplaceOne(s => s.Id == id, updatedStudent);
        return NoContent();
    }

    // Delete a student by ID
    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
        var result = _studentCollection.DeleteOne(s => s.Id == id);

        if (result.DeletedCount == 0)
        {
            return NotFound($"Student with ID {id} not found.");
        }

        return NoContent();
    }
}
