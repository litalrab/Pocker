# Pocker

This Web API project provides functionalities for managing tasks, bundles, and user progress. It includes models for tasks, bundles, and user progress, as well as API endpoints for creating, retrieving, updating, and deleting tasks and bundles. Users can also track their progress towards completion for both tasks and bundles.

API Endpoints
Tasks Endpoints

GET /task/GetTasks: Get a list of all tasks.

GET /tasks/{taskId}: Get details of a specific task by ID.

POST /tasks: Create a new task.

DELETE /tasks/{taskId}: Delete a task.

Bundles Endpoints

GET /bundles/bundles: Get a list of all bundles.

GET /bundles/{bundleId}: Get details of a specific bundle by ID.

POST /bundles: Create a new bundle.

DELETE /bundles/{bundleId}: Delete a bundle.


Getting Started

Prerequisites

.NET SDK

Installation

Clone the repository:

bash
Copy code
git clone https://github.com/litalrab/Pocker.git

Navigate to the project directory:

bash
Copy code
cd Pocker

Restore dependencies:

bash
Copy code
dotnet restore
Update the database connection string in app.config

Run the database migrations:

bash
Copy code
dotnet ef database update
Run the application:

bash
Copy code
dotnet run

Usage

Explore the API using tools like Postman or curl. Refer to the API documentation for details on available endpoints and request/response formats.Go to authorization tab choose barrier enter "123"  
