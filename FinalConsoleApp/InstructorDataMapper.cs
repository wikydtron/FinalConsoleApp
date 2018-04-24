using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FinalConsoleApp
{
    public class InstructorDataMapper : IDataMapper<Instructor>
    {
        private string path;

        public InstructorDataMapper()
        {
            path = AppDomain.CurrentDomain.BaseDirectory + "Instructors.txt";
        }

        private List<Instructor> GetInstructors()
        {
            List<Instructor> instructors = new List<Instructor>();

            // Read from Instructors.txt
            if (File.Exists(path))
            {
                var sr = new StreamReader(path);
                string line;

                // for as long as there are lines to read, we are going to loop
                while ((line = sr.ReadLine()) != null)
                {
                    var elems = line.Split(','); // create array from Comma Seperated Values file
                    var instructor = new Instructor
                    {
                        ID = Int16.Parse(elems[0]),
                        FirstName = elems[1],
                        LastName = elems[2],
                        Address = elems[3],
                        City = elems[4],
                        Province = elems[5],
                        PostalCode = elems[6],
                        Phone = elems[7],
                        Email = elems[8],
                        HireDate = DateTime.Parse(elems[9])
                    };
                    // Add each new student (one for each line in Students.txt) to the list
                    instructors.Add(instructor);
                }
            }
            return instructors;
        }

        public List<Instructor> Find(string LastName)
        {
            throw new NotImplementedException();
        }

        public List<Instructor> Select()
        {
            return GetInstructors();
        }
    }
}