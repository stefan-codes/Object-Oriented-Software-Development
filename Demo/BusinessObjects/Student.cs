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
        private double _cwMark; //Student's Coursework Mark - int
        private const double _CwMarkMax = 20.0; //Max possible grade for the coursework
        private double _examMark; //Student's Exam Mark - int
        private const double _ExamMarkMax = 40.0; //Max possible grade for the exam
        private DateTime _dateOfBirth; //Student's Date of Birth - DateTime object
        private string _mark;
        /* GetMark returns the mark of a student as a %.
         * It is calculated based on the coursework mark and the exam mark
         * on ratio of 0.5/0.5.*/
        public string GetMark()
        {
            string tempString = "";
            double tempDouble = ((_cwMark*100)/_CwMarkMax)*0.5 + ((_examMark * 100)/_ExamMarkMax)*0.5;
            //Double rounding is neccessary to ensure we get correct rounding aka 1.5 is 2 and not 1.
            tempDouble = Math.Round(tempDouble, 3);
            tempDouble = Math.Round(tempDouble, 2);
            tempString = tempDouble.ToString() +"%";

            return tempString;
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
                if (value < 10001 || value > 50000)
                {
                    throw new ArgumentException("Matriculation number out of bound! (10001 - 50000)");
                }
                _matricNo = value;
            }
        }

        //Getter and Setter for _firstName
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Please enter a name!");
                }
                _firstName = value;
            }
        }

        //Getter and Setter for _lastName
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Please enter a last name!");
                }
                _lastName = value;
            }
        }

        //Getter and Setter for _dateOfBirth
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Please enter a date of birth!");
                }
                _dateOfBirth = value;
            }
        }

        //Getter and Setter for _cwMark
        public double CwMark
        {
            get
            {
                return _cwMark;
            }
            set
            {
                if (value < 0 || value > _CwMarkMax)
                {
                    throw new ArgumentException("Please make sure coursework mark is between 0 and 20!");
                }
                _cwMark = value;
            }
        }

        //Getter and Setter for _examMark
        public double ExamMark
        {
            get
            {
                return _examMark;
            }
            set
            {
                if (value < 0 || value > _ExamMarkMax)
                {
                    throw new ArgumentException("Please make sure exam mark is between 0 and 40!");
                }
                _examMark = value;
            }
        }

        //Getter and Setter for _mark
        public string Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                if (Double.IsNaN(_examMark) || Double.IsNaN(_cwMark))
                {
                    throw new ArgumentException("CW mark or Exam mark is NAN");
                }
                _mark = value;
            }
        }
    }
}
