using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysPractice
{
    internal class Program
    {
        static string[,] courses = new string[,]
        {
            {"C10", "Math", "40", "0", "" },
            {"C11", "Eng", "40", "0", "" },
            {"C12", "Isl", "40", "0", "" },
            {"C13", "PST", "40", "0", "" },
            {"C14", "Urdu", "40", "0", "" }
        };

        static string[][] students = new string[][]
        {
            new string[] {"S10", "Bilal", ""},
            new string[] {"S101", "ALI", ""},
            new string[] {"S12", "Babar", ""},
            new string[] {"S13", "Umar", ""},
            new string[] {"S14", "Ayesha", ""},
        };
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Enroll Stydents \n2 View Course information\n3. View Enrolled Students for Course\n4. View Enrolled Courses for Stdents\n5. Exit");
                Console.WriteLine("Enter Your Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        EnrollStudent();
                        break;

                    case 2:
                        DisplayCourses();
                        break;
                    case 3:
                        Console.WriteLine("ENter Course ID: ");
                        string courseID = Console.ReadLine();
                        DisplayEnrolledStudentsInCourses(courseID);
                        break;
                    case 4:
                        Console.WriteLine("ENter Student ID: ");
                        string studentID = Console.ReadLine();
                        DisplayEnrolledCoursesByStudents(studentID);
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        static void EnrollStudent()
        {
            Console.WriteLine("ENter Course ID: ");
            string courseID = Console.ReadLine();
            Console.WriteLine("ENter Student ID: ");
            string studentID = Console.ReadLine();

            int courseIndex = -1;
            int studentIndex = -1;

            for (int i = 0; i < courses.GetLength(0); i++)
            {
                if (courses[i, 0] == courseID)
                {
                    courseIndex = i;
                    break;
                }
            }
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i][0] == studentID)
                {
                    studentIndex = i;
                    break;
                }
            }
            if (courseIndex != -1 && studentIndex != -1)
            {
                int currentEnrollment = int.Parse(courses[courseIndex, 3]);
                int maxEnrollment = int.Parse(courses[courseIndex, 2]);

                if (currentEnrollment < maxEnrollment)
                {
                    string[] enrolledStudents = courses[courseIndex, 4].Split(',');
                    if (!enrolledStudents.Contains(studentID))
                    {
                        if (courses[courseIndex, 4] == "")
                        {
                            courses[courseIndex, 4] = studentID;
                        }
                        else
                        {
                            courses[courseIndex, 4] = courses[courseIndex, 4] + "," + studentID;
                        }

                        courses[courseIndex, 3] = (currentEnrollment + 1).ToString();

                        if (students[studentIndex][2] == "")
                        {
                            students[studentIndex][2] = courseID;
                        }
                        else
                        {
                            students[studentIndex][2] += "," + courseID;
                        }

                        Console.WriteLine("Student Enrolled Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Student Already majood Hai");
                    }

                }
                else
                {
                    Console.WriteLine("Cours is Already Fulled");
                }

            }
            else
            {
                Console.WriteLine("Invalid Course or Student ID");
            }
        }

        static void DisplayCourses()
        {
            Console.WriteLine("Course ID\tCourse Name\tCurrent Enrollment\tMaximum Enrollment\tAll Enrolled Students");

            for (int i = 0; i < courses.GetLength(0); i++)
            {

                //Console.WriteLine(courses[i, 0] + "\t" + courses[i, 1] + "\t" + courses[i, 3] + "\t" + courses[i, 2] + "\t" + courses[i, 4]);
                Console.WriteLine($"{courses[i, 0]} \t{courses[i, 1]} \t {courses[i, 3]} \t {courses[i, 2]} \t {courses[i, 4]}");

            }
        }
        static void DisplayEnrolledStudentsInCourses(string courseID)
        {
            Console.WriteLine("Enrolled Students for COurse " + courseID);

            for (int j = 0; j < courses.GetLength(0); j++)
            {
                if (courses[j, 0] == courseID)
                {
                    string[] enrolledStudents = courses[j, 4].Split(',');
                    //for (int k=0; k<enrolledStudents.Length; k++)
                    //{
                    //    string studentID = enrolledStudents[k];

                    //    for (int m=0; m<students.Length; m++)
                    //    {
                    //        string[] student = students[m];

                    //        if (student[0]==studentID)
                    //        {
                    //            Console.WriteLine(student[0] + "\t" + student[1]);
                    //            break;
                    //        }
                    //    }
                    //}

                    foreach (var StudentID in enrolledStudents)
                    {
                        foreach (var student in students)
                        {
                            if (student[0] == StudentID)
                            {
                                Console.WriteLine(student[0] + "\t" + student[1]);
                                break;

                            }
                        }
                    }
                }
            }
        }

        static void DisplayEnrolledCoursesByStudents(string studentId)
        {
            Console.WriteLine("Enrolled Courses for Student " + studentId);
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i][0] == studentId)
                {
                    string[] enrolledCourses = students[i][2].Split(',');
                    foreach (var course in enrolledCourses)
                    {
                        for (int j = 0; j < courses.GetLength(0); j++)
                        {
                            if (courses[j, 0] == course)
                            {
                                Console.WriteLine(courses[j, 0] + "\t" + courses[j, 1]);
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }

    }
}
