# MongoDBSimpleCRUDwithDotNet8
MongoDB CRUD Operations with ASP.NET Core 8 This project demonstrates a simple CRUD (Create, Read, Update, Delete) application using MongoDB as the database and ASP.NET Core 8 for building the RESTful API. The application is structured to interact with a MongoDB collection and perform basic operations on student records.

# Features
CRUD Operations:
Create new student records.
Retrieve all students or a single student by their unique ID.
Update existing student records.
Delete student records.
MongoDB Integration:
Uses the official MongoDB driver to connect to and interact with the database.
RESTful API:
Endpoints follow RESTful principles for easy interaction and scalability.
ASP.NET Core 8:
Built using the latest version of .NET for modern development practices.


# Technologies Used
ASP.NET Core 8: For building the web API.
MongoDB: NoSQL database for storing and managing student records.
C#: Primary programming language.
MongoDB.Driver: Official MongoDB driver for .NET.

# API Endpoints
Get All Students:
GET /Student
Fetches all student records.

1. Get Single Student by ID:
GET /Student/{id}
Fetches a student record by its unique MongoDB ObjectId.

2. Insert New Student:
POST /Student
Adds a new student record to the database.

3. Update Student Record:
PUT /Student/{id}
Updates an existing student record by its ID.
Request Body Example: Same as above.

4. Delete Student by ID:
DELETE /Student/{id}
Deletes a student record by its unique ID.
