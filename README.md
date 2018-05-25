# api-project
Sikka Software assignment

## requirements
* <code>ASP.NET Core 2.x</code>
* <code>MySQL 8.0.x</code>

## instructions
* create database, tables and populate them:
  <code>mysql -u root -p < apiproject.sql</code>
  Note: Please ensure that there is no user named 'ODBC' and no database named 'apiproject' on the MySQL server.

* build the project: <br>
  navigate to the folder containing the solution file and then enter the command <code>dotnet build</code>

* run the server: <br>
  navigate to the folder APIProject and then enter the command <code>dotnet run --launch-profile APIProject</code>

* the server can be accessed at [http://localhost:52222/](http://localhost:52222/)

## api
* <code>/patients?\{key}=\{value}</code>: Retreives a JSON array of patients based on the options provided <br>
  **Options:**
  
  | Key | Value |
  | ---------------- | ----- |
  | patientId | integer value denoting the patient's id |
  | firstName | string value denoting the patient's first name |
  | lastName | string value denoting the patient's last name |
  | city | string value denoting the patient's city |
  | state | string value denoting the patient's state |
  | zip | string value denoting the patient's zip code |
  | nextVisitDate | 'MM/dd/yyyy' value denoting the patient's next visit date |
  | startDate | 'MM/dd/yyyy' value denoting the start date of next visits to filter from Note: ignored when nextVisitDate is provided |
  | endDate | 'MM/dd/yyyy' value denoting the end date of next visits to filter until Note: ignored when nextVisitDate is provided |
  | practiceId | integer value denoting the practice's id |

* <code>/practices?\{key}=\{value}</code>: Retreives a JSON array of practices based on the options provided <br>
  **Options:**
  
  | Key | Value |
  | ---------------- | ----- |
  | practiceId | integer value denoting the practice's id |
  | practiceName | string value denoting the practice's name |
  | speciality | string value denoting the practice's speciality |
  | city | string value denoting the practice's city |
  | state | string value denoting the practice's state |
  | zip | string value denoting the practice's zip code |

* <code>/appointments?\{key}=\{value}</code>: Retreives a JSON array of appointments based on the options provided <br>
  **Options:**
  
  | Key | Value |
  | ---------------- | ----- |
  | patientId | integer value denoting the patient's id |
  | practiceId | integer value denoting the practice's id |
  | appointmentDate | 'MM/dd/yyyy' value denoting the patient's appointment date with the practice |
  | startDate | 'MM/dd/yyyy' value denoting the start date of appointment dates to filter from Note: ignored when appointmentDate is provided |
  | endDate | 'MM/dd/yyyy' value denoting the end date of appointment dates to filter until Note: ignored when appointmentDate is provided |
  | appointmentTime | 'HH:mm' (24 hour format) value denoting the patient's appointment time of the day with the practice |
  | startTime | 'HH:mm' (24 hour format) value denoting the start time of appointment in a day to filter from Note: ignored when appointmentTime is provided |
  | endTime | 'HH:mm' (24 hour format) value denoting the end date of appointment in a day to filter until Note: ignored when appointmentTime is provided |
