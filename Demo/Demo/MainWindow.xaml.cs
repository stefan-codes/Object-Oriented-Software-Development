using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Windows.Forms;
using BusinessObjects;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ModuleList store = new ModuleList();

        //constructor
        public MainWindow()
        {
            InitializeComponent();
            findBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
            resetAllBtn.IsEnabled = false;
            listAllBtn.IsEnabled = false;
        }

        //Clicking add button, try to create a student record
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            bool temp = true;
            Student student = new Student();

            //Try to set all student properties, followed by adding the student to store and adding it to the listbox
            try{
                student.FirstName = firstNameTxt.Text;
                student.LastName = lastNameTxt.Text;
                student.DateOfBirth = datePicker.SelectedDate.Value;
                //Console.WriteLine(student.DateOfBirth.Date.ToString("d"));
                student.CwMark = double.Parse(cwGradeTxt.Text);
                temp = false;
                student.ExamMark = double.Parse(examGradeTxt.Text);
                //if we get so far, add it!
                student.Mark = student.GetMark();
                student.Matric = generateMatrNo();
                store.add(student);
                memberList.Items.Add(student.Matric);
                cleanAllFields();
                checkListAllbtn();
                Console.WriteLine("Student was added to store.");

            }
            catch (ArgumentException exep)
            {
                MessageBox.Show(exep.Message);
            }
            catch (InvalidOperationException dateMatr)
            {
                if (temp)
                {
                    MessageBox.Show("Please select a date of birth.");
                } else
                {
                    MessageBox.Show(dateMatr.Message);
                }
            }
            catch (FormatException)
            {
                if (temp)
                {
                    MessageBox.Show("Make sure the coursework grade is of type double or integer.");
                    cwGradeTxt.Text = "";
                } else
                {
                    MessageBox.Show("Make sure the exam grade is of type double or integer.");
                    examGradeTxt.Text = "";
                }          
            }
        }

        //Clicking reset button
        private void resetAllBtn_Click(object sender, RoutedEventArgs e)
        {
            cleanAllFields();
        }

        //Clicking find button, displays the student if they exist
        private void findBtn_Click(object sender, RoutedEventArgs e)
        {
            int tempMatr = 0;
            //Check if the length of the string for matriculation number is 5 digits long
            if (matrNumTxt.Text.Length == 5)
            {
                try
                {
                    tempMatr = Int32.Parse(matrNumTxt.Text);

                    //Does the student exist
                    if (store.matrics.Contains(tempMatr))
                    {
                        displayStudent(tempMatr);                  
                    } else
                    {
                        MessageBox.Show(string.Format("No student was found with {0} as a matriculation number!", tempMatr.ToString()));
                        cleanAllFields();                       
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Matriculation number must be 5 digit integer!");
                    cleanAllFields();
                }
            } else
            {
                MessageBox.Show("Invalid matriculation number size. Please make sure the number is 5 digit integer!");
                cleanAllFields();
            }  
        }

        //Clicking delete button, deletes the student if the exist from store and the listbox
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int tempMatr = 0;
            //Check if the length of the string for matriculation number is 5 digits long
            if (matrNumTxt.Text.Length == 5)
            {
                try
                {
                    tempMatr = Int32.Parse(matrNumTxt.Text);

                    //Does the student exist
                    if (store.matrics.Contains(tempMatr))
                    {
                        //Should the student be deleted
                        if (MessageBox.Show(string.Format("Are you sure you want to delete student with matriculation number {0}",tempMatr), "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            cleanAllFields();
                            store.delete(tempMatr);
                            memberList.Items.Remove(tempMatr);
                            checkListAllbtn();
                            MessageBox.Show(string.Format("Student with matriculation number {0} was deleted.",tempMatr));
                        } else
                        {
                            //not deleted, dont do anything
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("No student was found with {0} as a matriculation number!", tempMatr.ToString()));
                        cleanAllFields();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Matriculation number must be 5 digit integer!");
                    cleanAllFields();
                }
            }
            else
            {
                MessageBox.Show("Invalid matriculation number size. Please make sure the number is 5 digit integer!");
                cleanAllFields();
            }
        }

        //Clicking list all button -------!!!!!!! not done yet -------------------------------------------
        private void listAllBtn_Click(object sender, RoutedEventArgs e)
        {
            //will do later
            ListAllWindow records = new ListAllWindow(store);
            records.Show();
        }

        //FIlls the fields with the infromation for the student with matrnumber
        private void displayStudent(int stdMtr)
        {
            Student student = store.find(stdMtr);
            matrNumTxt.Text = student.Matric.ToString();
            firstNameTxt.Text = student.FirstName;
            lastNameTxt.Text = student.LastName;
            datePicker.SelectedDate = student.DateOfBirth;
            cwGradeTxt.Text = student.CwMark.ToString();
            examGradeTxt.Text = student.ExamMark.ToString();
        }

        //Generates the next avaliable matriculation number, if full it start assigning from the begining
        private int generateMatrNo()
        {
            int temp = 0;
            //Check if the list is empty, is it is give 10000 (it will be incremented) else get the max element
            if (store.matrics.Any())
            {
                temp = store.matrics.Max();
            } else
            {
                temp = 10000;
            }

            //if we get over the max reset the counter
            if (temp >= 50000)
            {
                MessageBox.Show("Ran out of matriculation numbers! You were assigned the first 10001");
                temp = 10001;
               
            } else
            {
                temp++;
            }
            return temp;
        }

        //resets all text fields to empty / default
        private void cleanAllFields()
        {
            matrNumTxt.Text = "";
            firstNameTxt.Text = "";
            lastNameTxt.Text = "";
            datePicker.SelectedDate = null;
            cwGradeTxt.Text = "";
            examGradeTxt.Text = "";
        }

        //Keeps an eye out for the add Button
        private void checkAddBtn()
        {
            addBtn.IsEnabled = (matrNumTxt.Text == "");
        }

        //Keeps an eye out for the find Button
        private void checkFindBtn()
        {
            findBtn.IsEnabled = (matrNumTxt.Text != "");
        }

        //Keeps an eye out for the delete Button
        private void checkDeleteBtn()
        {
            deleteBtn.IsEnabled = (matrNumTxt.Text != "");
        }

        //Keeps an eye out for the reset Button
        private void checkResetBtn()
        {
            resetAllBtn.IsEnabled = (matrNumTxt.Text != "" || firstNameTxt.Text != "" || lastNameTxt.Text != "" || datePicker.SelectedDate != null || cwGradeTxt.Text != "" || examGradeTxt.Text != "");
        }

        //Keeps an eye out for the list all Button
        private void checkListAllbtn()
        {
            listAllBtn.IsEnabled = (store.matrics.Any());
        }

        //Watches matrNumTxt for changes and calls the check functions on the relative buttons
        private void matrNumTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkAddBtn();
            checkFindBtn();
            checkDeleteBtn();
            checkResetBtn();
        }

        //Watches firstNameTxt for changes and calls the check functions on the reset button
        private void firstNameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkResetBtn();
        }

        //Watches lastNameTxt for changes and calls the check functions on the reset button
        private void lastNameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkResetBtn();
        }

        //Watches datePicker for changes and calls the check functions on the reset button
        private void datePciker_DateChanged(object sender, SelectionChangedEventArgs e)
        {
            checkResetBtn();
        }

        //Watches cwGradeTxt for changes and calls the check functions on the reset button
        private void cwGradeTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkResetBtn();
        }

        //Watches examGradeTxt for changes and calls the check functions on the reset button
        private void examGradeTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkResetBtn();
        }

        //Display the student that is selected in the listbox
        private void memberList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                displayStudent(Int32.Parse(memberList.SelectedValue.ToString()));
            }
            catch
            {
                //just in case the deletion of the current index doesnt change the focus
                memberList.SelectedIndex = -1;
            }
        }

        //Make sure when the listbox looses focus the items are deselected so there are no errors if the item is deleted
        private void memberList_LostFocus(object sender, RoutedEventArgs e)
        {
            memberList.SelectedIndex = -1;
        }

        public ModuleList GetStore()
        {
            return this.store;
        }
    }
}
