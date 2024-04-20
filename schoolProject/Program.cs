﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;

ApplicationDbContext dbContext = new();
bool app = true;

do
{
    Console.WriteLine("Type [C] to manage your Classes or [S] to manage the Students! [E] to exit");
    string choice = Console.ReadLine() ?? string.Empty;
    switch (choice.ToUpper())
    {
        case "C":
            bool subjectCase = true;
            do
            {
                Console.Write("Type [I] to insert a new Subject [C] to edit existing ones, [D] to delete some courses or [E] to exit: ");
                choice = Console.ReadLine() ?? string.Empty;
                switch (choice.ToUpper())
                {
                    case "I":
                        Subject subj = new();
                        Console.WriteLine("Insert The Subject's Name: ");
                        string subjName = Console.ReadLine() ?? string.Empty;
                        if (double.TryParse(subjName, out double number))
                        {
                            Console.WriteLine($"Invalid Input: {number}");
                            break;
                        }
                        else if (subjName.IsNullOrEmpty())
                        {
                            Console.WriteLine("You Need to type something! Name can't be empty!");
                            break;
                        }
                        else
                        {
                            subj.Name = subjName;
                        }
                        dbContext.Add(subj);
                        dbContext.SaveChanges();
                        break;
                    case "C":
                        bool edit = true;
                        do
                        {
                            Console.WriteLine("Subjects:");
                            List<Subject> subjectsEdit = dbContext.Subjects.ToList();
                            subjectsEdit.ForEach(element => Console.WriteLine($"{element.Id} - {element.Name}"));
                            Console.WriteLine("Type the index of the Subject You want to change! or [E] to exit: ");
                            string idEdit = Console.ReadLine() ?? string.Empty;
                            if (idEdit.ToUpper().Equals("E"))
                            {
                                break;
                            }
                            else if (!int.TryParse(idEdit, out int index))
                            {
                                Console.WriteLine($"Invalid Input: {idEdit}");
                            }
                            else if (int.Parse(idEdit) < 1)
                            {
                                Console.WriteLine("Invalid Input!");
                            }
                            else
                            {
                                int parsedId = int.Parse(idEdit);
                                Subject subjectById = dbContext.Subjects.Find(parsedId);
                                if (subjectById != null)
                                {
                                    Console.WriteLine("Insert the new Name for the Subject: ");
                                    subjectById.Name = Console.ReadLine() ?? string.Empty;
                                    if (!subjectById.Name.Equals(string.Empty))
                                    {
                                        dbContext.Subjects.Update(subjectById);
                                        dbContext.SaveChanges();
                                        Console.WriteLine($"Name Changed to {subjectById.Name}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"No match found for Id: {parsedId}");
                                }
                            }
                        } while (edit);
                        break;
                    case "D":
                        bool delete = true;
                        do
                        {
                            Console.WriteLine("Subjects:");
                            List<Subject> subjectsDelete = dbContext.Subjects.ToList();
                            subjectsDelete.ForEach(element => Console.WriteLine($"{element.Id} {element.Name}"));
                            Console.WriteLine("Type the index of the Subject You want to delete! or [E] to exit: ");
                            string id = Console.ReadLine() ?? string.Empty;
                            if (id.ToUpper().Equals("E"))
                            {
                                break;
                            }
                            else if (!int.TryParse(id, out int index))
                            {
                                Console.WriteLine($"Invalid Input: {id}");
                            }
                            else if (int.Parse(id) < 1)
                            {
                                Console.WriteLine("No Id in Our DB");
                            }
                            else
                            {
                                int parsedId = int.Parse(id);
                                Subject subjectById = dbContext.Subjects.Find(parsedId);
                                if (subjectById != null)
                                {
                                    Console.WriteLine($"{subjectById.Id} {subjectById.Name}");
                                    Console.WriteLine("Are You sure you want to delete this course? (y/n): ");
                                    string confirm = Console.ReadLine() ?? string.Empty;
                                    if (confirm.ToUpper().Equals("Y"))
                                    {
                                        dbContext.Remove(subjectById);
                                        dbContext.SaveChanges();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Remove cancelled!");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"No match found for Id: {parsedId}");
                                }
                            }
                        } while (delete);
                        break;
                    case "E":
                        subjectCase = false;
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            } while (subjectCase);
            break;
        case "S":
            bool studentCase = true;
            do
            {
                Console.Write("Type [I] to insert a new Student [C] to edit existing ones, [D] to delete some students or [E] to exit: ");
                choice = Console.ReadLine() ?? string.Empty;
                switch (choice.ToUpper())
                {
                    case "I":
                        Student stud = new();
                        Console.WriteLine("Insert The Student's First Name: ");
                        string studentName = Console.ReadLine() ?? string.Empty;
                        if (double.TryParse(studentName, out double number))
                        {
                            Console.WriteLine($"Invalid Input: {number}");
                            break;
                        }
                        else if (studentName.IsNullOrEmpty())
                        {
                            Console.WriteLine("You Need to type something! Name can't be empty!");
                            break;
                        }
                        else
                        {
                            stud.FirstName = studentName;
                        }
                        Console.WriteLine("Insert The Student's Last Name: ");
                        studentName = Console.ReadLine() ?? string.Empty;
                        if (double.TryParse(studentName, out number))
                        {
                            Console.WriteLine($"Invalid Input: {number}");
                            break;
                        }
                        else if (studentName.IsNullOrEmpty())
                        {
                            Console.WriteLine("You Need to type something! Name can't be empty!");
                            break;
                        }
                        else
                        {
                            stud.LastName = studentName;
                        }
                        Console.WriteLine("Insert The Student's Class: ");
                        Console.WriteLine("Subjects:");
                        List<Subject> subjectsDelete = dbContext.Subjects.ToList();
                        foreach (Subject subject in subjectsDelete)
                        {
                            Console.WriteLine($"{subject.Id} {subject.Name}");
                        }
                        Console.WriteLine("Type the index of the Subject You want to assign to the Student! or [E] to exit");
                        string id = Console.ReadLine() ?? string.Empty;
                        if (id.ToUpper().Equals("E"))
                        {
                            break;
                        }
                        else if (!int.TryParse(id, out int index))
                        {
                            Console.WriteLine($"Invalid Input: {id}");
                        }
                        else if (int.Parse(id) < 1)
                        {
                            Console.WriteLine("No Id in Our DB");
                        }
                        else
                        {
                            stud.SubjectId = int.Parse(id);
                        }
                        dbContext.Add(stud);
                        dbContext.SaveChanges();
                        break;
                    case "C":
                        bool edit = true;
                        do
                        {
                            Console.WriteLine("Students:");
                            List<Student> studentsEdit = dbContext.Students.ToList();
                            foreach (Student student in studentsEdit)
                            {
                                Subject subject = dbContext.Subjects.Find(student.SubjectId);
                                Console.WriteLine($"{student.Id} {student.FirstName} {student.LastName} - Subject: {subject.Name}");
                                //Console.WriteLine($"{student.Id} {student.FirstName} {student.LastName} - Subject: {student.Subject.Name}");
                            }
                            Console.WriteLine("Type the index of the Student You want to change! or [E] to exit: ");
                            string idEdit = Console.ReadLine() ?? string.Empty;
                            if (idEdit.ToUpper().Equals("E"))
                            {
                                edit = false;
                                break;
                            }
                            else if (!int.TryParse(idEdit, out int index))
                            {
                                Console.WriteLine($"Invalid Input: {idEdit}");
                            }
                            else if (int.Parse(idEdit) < 1)
                            {
                                Console.WriteLine("Invalid Input!");
                            }
                            else
                            {
                                int parsedId = int.Parse(idEdit);
                                Student studentById = dbContext.Students.Find(parsedId);
                                if (studentById != null)
                                {
                                    Console.WriteLine("Insert the student's new First Name: ");
                                    string newName = Console.ReadLine() ?? string.Empty;
                                    if (!newName.IsNullOrEmpty())
                                    {
                                        studentById.FirstName = newName;
                                        Console.WriteLine($"FirstName Changed to {newName}");
                                    }
                                    else if(double.TryParse(newName, out number)){
                                        Console.WriteLine($"Invalid Input: {number}");
                                    }
                                    else
                                    {
                                        studentById.FirstName = studentById.FirstName;
                                    }
                                    Console.WriteLine("Insert the student's new Last Name: ");
                                    newName = Console.ReadLine() ?? string.Empty;
                                    if (!newName.IsNullOrEmpty())
                                    {
                                        studentById.LastName = newName;
                                        Console.WriteLine($"FirstName Changed to {studentById.LastName}");
                                    }
                                    else if(double.TryParse(newName, out number)){
                                        Console.WriteLine($"Invalid Input: {number}");
                                    }
                                    else
                                    {
                                        studentById.LastName = studentById.LastName;
                                    }
                                    Console.WriteLine("Subjects:");
                                    List<Subject> subjectsEdit = dbContext.Subjects.ToList();
                                    subjectsEdit.ForEach(element => Console.WriteLine($"{element.Id} {element.Name}"));
                                    Console.WriteLine("Type the index of the new Subject You want to assign!");
                                    string classId = Console.ReadLine() ?? string.Empty;
                                    if (!int.TryParse(classId, out index))
                                    {
                                        Console.WriteLine($"Invalid Input: {idEdit}");
                                    }
                                    else if (int.Parse(idEdit) < 1)
                                    {
                                        Console.WriteLine("Invalid Input!");
                                    }
                                    else if(classId.IsNullOrEmpty()){
                                        studentById.SubjectId = studentById.SubjectId;
                                    }
                                    else{
                                        int parsedClassId = int.Parse(classId);
                                        Subject subjectById = dbContext.Subjects.Find(parsedClassId);
                                        if (subjectById!= null)
                                        {
                                            studentById.SubjectId = subjectById.Id;
                                            studentById.Subject = subjectById;
                                            Console.WriteLine($"Subject Changed to {studentById.Subject.Name}");
                                        }
                                        else
                                        {
                                            studentById.SubjectId = studentById.SubjectId;
                                        }
                                    }
                                    dbContext.Students.Update(studentById);
                                    dbContext.SaveChanges();
                                }
                                else
                                {
                                    Console.WriteLine($"No match found for Id: {parsedId}");
                                }
                            }
                        } while (edit);
                        break;
                    case "D":
                        bool delete = true;
                        do
                        {
                            Console.WriteLine("Subjects:");
                            List<Student> studentsDelete = dbContext.Students.ToList();
                            studentsDelete.ForEach(element => Console.WriteLine($"{element.Id} {element.FirstName} {element.LastName}"));
                            Console.WriteLine("Type the index of the Subject You want to delete! or [E] to exit: ");
                            id = Console.ReadLine() ?? string.Empty;
                            if (id.ToUpper().Equals("E"))
                            {
                                break;
                            }
                            else if (!int.TryParse(id, out int index))
                            {
                                Console.WriteLine($"Invalid Input: {id}");
                            }
                            else if (int.Parse(id) < 1)
                            {
                                Console.WriteLine("No Id in Our DB");
                            }
                            else
                            {
                                int parsedId = int.Parse(id);
                                Student studentById = dbContext.Students.Find(parsedId);
                                if (studentById != null)
                                {
                                    Console.WriteLine($"{studentById.Id} {studentById.FirstName} {studentById.LastName}");
                                    Console.WriteLine("Are You sure you want to delete this course? (y/n): ");
                                    string confirm = Console.ReadLine() ?? string.Empty;
                                    if (confirm.ToUpper().Equals("Y"))
                                    {
                                        dbContext.Remove(studentById);
                                        dbContext.SaveChanges();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Remove cancelled!");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"No match found for Id: {parsedId}");
                                }
                            }
                        } while (delete);
                        break;
                    case "E":
                        studentCase = false;
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            } while (studentCase);
            break;
        case "E":
            app = false;
            break;
        default:
            Console.WriteLine("Invalid Input!");
            break;
    }
} while (app);