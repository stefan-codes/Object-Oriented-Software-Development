/* Student.cs
 * This class is used to generate student objects containing different properties.
 * It provides a methods for accessing those properties and returning the mark for the student.
 * 
 * Created by ...
 * properties, comments and methods added 03/10/2017 by Stefan Hristov, 40284739
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Student
    {
        private int _matricNo; //Student's Matriculation Number - int
        private string _firstName; //Student's First Name - string
        private string _lastName; //Student's Last Name - string
        private int _cwMark; //Student's Coursework Mark - int
        private const int _CwMarkMax = 40; //Max possible grade for the coursework
        private int _examMark; //Student's Exam Mark - int
        private const int _ExamMarkMax = 20; //Max possible grade for the exam
        private DateTime _dateOfBirth; //Student's Date of Birth - DateTime object

        /* GetMark returns the mark of a student as a %.
         * It is calculated based on the coursework mark and the exam mark
         * on ratio of 0.5/0.5.*/
        public string GetMark()
        {
            string tempString = "";
            double tempDouble = ((_cwMark*100)/_CwMarkMax)*0.5 + ((_examMark * 100)/_ExamMarkMax)*0.5;
            tempString = Convert.ToInt16(tempDouble).ToString()+"%";

            return tempString;
        }

        //Getter and Setter for _dateOfBirth
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        //Getter and Setter for _cwMark
        public int CwMark
        {
            get { return _cwMark; }
            set { _cwMark = value; }
        }

        //Getter and Setter for _examMark
        public int ExamMark
        {
            get { return _examMark; }
            set { _examMark = value; }
        }

        //Getter and Setter for _lastName
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        //Getter and Setter for _firstName
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        //Getter and Setter for _matricNo
        public int Matric
        {
            get
            {
                return _matricNo;
            }
            set
            {
                _matricNo = value;
            }
        }
    }
}
