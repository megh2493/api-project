using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace APIProject.Models
{
    public class DBContext
    {
        public string ConnectionString { get; set; }

        public DBContext(string connectionString) => ConnectionString = connectionString;

        private MySqlConnection GetConnection() => new MySqlConnection(ConnectionString);

        public List<Practices> GetPractices(IQueryCollection query)
        {
            List<Practices> list = new List<Practices>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                StringBuilder sqlQuery = new StringBuilder("SELECT * FROM Practices WHERE 1=1");
                if (!String.IsNullOrEmpty(query["practiceId"]) && query["practiceId"].ToString().All(char.IsDigit))
                {
                    sqlQuery.AppendFormat(" AND PracticeId = {0}", query["practiceId"]);
                }
                if (!String.IsNullOrEmpty(query["practiceName"]))
                {
                    sqlQuery.AppendFormat(" AND PracticeName = '{0}'", query["practiceName"]);
                }
                if (!String.IsNullOrEmpty(query["speciality"]))
                {
                    sqlQuery.AppendFormat(" AND Speciality = '{0}'", query["speciality"]);
                }
                if (!String.IsNullOrEmpty(query["city"]))
                {
                    sqlQuery.AppendFormat(" AND City = '{0}'", query["city"]);
                }
                if (!String.IsNullOrEmpty(query["state"]))
                {
                    sqlQuery.AppendFormat(" AND State = '{0}'", query["state"]);
                }
                if (!String.IsNullOrEmpty(query["zip"]))
                {
                    sqlQuery.AppendFormat(" AND Zip = '{0}'", query["zip"]);
                }

                MySqlCommand cmd = new MySqlCommand(sqlQuery.ToString(), conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Practices()
                        {
                            PracticeId = Convert.ToInt32(reader["PracticeId"]),
                            PracticeName = reader["PracticeName"].ToString(),
                            Speciality = reader["Speciality"].ToString(),
                            LicenseNumber = reader["LicenseNumber"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            State = reader["State"].ToString(),
                            Zip = reader["Zip"].ToString(),
                            Cell = reader["Cell"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public List<Patients> GetPatients(IQueryCollection query)
        {
            List<Patients> list = new List<Patients>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                StringBuilder sqlQuery = new StringBuilder("SELECT * FROM Patients WHERE 1=1");
                if (!String.IsNullOrEmpty(query["patientId"]) && query["patientId"].ToString().All(char.IsDigit))
                {
                    sqlQuery.AppendFormat(" AND PatientId = {0}", query["patientId"]);
                }
                if (!String.IsNullOrEmpty(query["firstName"]))
                {
                    sqlQuery.AppendFormat(" AND FirstName = '{0}'", query["firstName"]);
                }
                if (!String.IsNullOrEmpty(query["lastName"]))
                {
                    sqlQuery.AppendFormat(" AND LastName = '{0}'", query["lastName"]);
                }
                if (!String.IsNullOrEmpty(query["city"]))
                {
                    sqlQuery.AppendFormat(" AND City = '{0}'", query["city"]);
                }
                if (!String.IsNullOrEmpty(query["state"]))
                {
                    sqlQuery.AppendFormat(" AND State = '{0}'", query["state"]);
                }
                if (!String.IsNullOrEmpty(query["zip"]))
                {
                    sqlQuery.AppendFormat(" AND Zip = '{0}'", query["zip"]);
                }
                if (!String.IsNullOrEmpty(query["nextVisitDate"]) &&
                    DateTime.TryParseExact(query["nextVisitDate"], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    sqlQuery.AppendFormat(" AND NextVisitDate = '{0}'", dt.ToString("yyyy-MM-dd"));
                }
                else
                {
                    if (!String.IsNullOrEmpty(query["startDate"]) &&
                    DateTime.TryParseExact(query["startDate"], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        sqlQuery.AppendFormat(" AND NextVisitDate >= '{0}'", dt.ToString("yyyy-MM-dd"));
                    }
                    if (!String.IsNullOrEmpty(query["endDate"]) &&
                    DateTime.TryParseExact(query["endDate"], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        sqlQuery.AppendFormat(" AND NextVisitDate <= '{0}'", dt.ToString("yyyy-MM-dd"));
                    }
                }
                if (!String.IsNullOrEmpty(query["practiceId"]) && query["practiceId"].ToString().All(char.IsDigit))
                {
                    sqlQuery.AppendFormat(" AND PracticeId = {0}", query["practiceId"]);
                }

                MySqlCommand cmd = new MySqlCommand(sqlQuery.ToString(), conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Patients()
                        {
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            BirthDate = ((DateTime)reader["BirthDate"]).ToString("MM/dd/yyyy"),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            State = reader["State"].ToString(),
                            MedicalNotes = reader["MedicalNotes"].ToString(),
                            NextVisitDate = ((DateTime)reader["NextVisitDate"]).ToString("MM/dd/yyyy"),
                            Zip = reader["Zip"].ToString(),
                            Cell = reader["Cell"].ToString(),
                            PracticeId = Convert.ToInt32(reader["PracticeId"])
                        });
                    }
                }
            }
            return list;
        }

        public List<Appointments> GetAppointments(IQueryCollection query)
        {
            List<Appointments> list = new List<Appointments>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                StringBuilder sqlQuery = new StringBuilder("SELECT * FROM Appointments WHERE 1=1");
                if (!String.IsNullOrEmpty(query["patientId"]) && query["patientId"].ToString().All(char.IsDigit))
                {
                    sqlQuery.AppendFormat(" AND PatientId = {0}", query["patientId"]);
                }
                if (!String.IsNullOrEmpty(query["practiceId"]) && query["practiceId"].ToString().All(char.IsDigit))
                {
                    sqlQuery.AppendFormat(" AND PracticeId = {0}", query["practiceId"]);
                }
                if (!String.IsNullOrEmpty(query["appointmentDate"]) && 
                    DateTime.TryParseExact(query["appointmentDate"], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    sqlQuery.AppendFormat(" AND AppointmentDate = '{0}'", dt.ToString("yyyy-MM-dd"));
                }
                else
                {
                    if(!String.IsNullOrEmpty(query["startDate"]) &&
                    DateTime.TryParseExact(query["startDate"], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        sqlQuery.AppendFormat(" AND AppointmentDate >= '{0}'", dt.ToString("yyyy-MM-dd"));
                    }
                    if (!String.IsNullOrEmpty(query["endDate"]) &&
                    DateTime.TryParseExact(query["endDate"], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        sqlQuery.AppendFormat(" AND AppointmentDate <= '{0}'", dt.ToString("yyyy-MM-dd"));
                    }
                }
                if (!String.IsNullOrEmpty(query["appointmentTime"]) &&
                    DateTime.TryParseExact(query["appointmentTime"], "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    sqlQuery.AppendFormat(" AND AppointmentTime = '{0}'", dt.ToString("HH:mm:ss"));
                }
                else
                {
                    if (!String.IsNullOrEmpty(query["startTime"]) &&
                    DateTime.TryParseExact(query["startTime"], "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        sqlQuery.AppendFormat(" AND AppointmentTime >= '{0}'", dt.ToString("yyyy-MM-dd"));
                    }
                    if (!String.IsNullOrEmpty(query["endDate"]) &&
                    DateTime.TryParseExact(query["endTime"], "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        sqlQuery.AppendFormat(" AND AppointmentTime <= '{0}'", dt.ToString("yyyy-MM-dd"));
                    }
                }

                MySqlCommand cmd = new MySqlCommand(sqlQuery.ToString(), conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.WriteLine("{0}, {1}", reader["AppointmentDate"].GetType(), reader["AppointmentTime"].GetType());
                        TimeSpan ts = (TimeSpan) reader["AppointmentTime"];
                        list.Add(new Appointments()
                        {
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            PracticeId = Convert.ToInt32(reader["PracticeId"]),
                            AppointmentDate = ((DateTime) reader["AppointmentDate"]).ToString("MM/dd/yyyy"),
                            AppointmentTime = string.Format("{0:00}:{1:00}", ts.Hours, ts.Minutes),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
