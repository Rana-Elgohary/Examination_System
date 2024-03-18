Examination System Project

Description:
This project is an Examination System developed using the Model-View-Controller (MVC) architectural pattern. It allows users to manage courses, exams, instructors, students, and their interactions within the system. The system facilitates generating various reports related to student information, grades, courses, instructors, and exam details.

Features:
Course Management: Allows CRUD (Create, Read, Update, Delete) operations for courses.
Exam Management: Provides functionalities to create and manage exams associated with courses.
Instructor Management: Enables adding, updating, and deleting instructors along with their assigned courses.
Student Management: Supports managing student information and their enrolled courses.
Reporting: Includes various reports such as student information by track, grades in all courses for a student, course details for instructors, and topics data for specific courses.
Exam Details: Displays questions and choices for a particular exam and student answers for those questions.
Homepage: Displays courses for a student and instructor details.

Technologies Used:
C#
ASP.NET Core MVC
Entity Framework Core (EF Core) for data access
Microsoft SQL Server for database management

Installation:
Clone the repository to your local machine.
Open the solution file in Visual Studio.
Restore the necessary NuGet packages.
Configure the database connection string in the appsettings.json file.
Run Entity Framework migrations to create the database schema and seed initial data.
Build and run the application.

Usage:
Upon running the application, navigate through different views using the provided links in the UI.
Perform CRUD operations for courses, exams, instructors, and students.
Generate reports by accessing the respective functionalities provided in the AdminController.
View course details and instructor information on the homepage.

Credits:
Developed by [Rana El-Gohary,
Salma Ali,
Sara Mahmoud,
Menna Usama,
Maya Refaye]

Email: [r.elgohary2000@gmail.com,
salma.ali67815@gmail.com,
sarahh.mahmood2001@gmail.com,
mennausama1682@gmail.com,
Mayarefaey34@gmail.com]

GitHub: [Rana-Elgohary,
salma197457,
sarra5,
MennaOsama162,
MayaaRefaey]

Note:
Make sure to configure the database connection string and run migrations before using the application.
For any issues or feature requests, please open an issue on GitHub.
