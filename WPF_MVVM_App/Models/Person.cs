using System;
using WPF_MVVM_App.Helpers;

namespace WPF_MVVM_App.Models
{
    public class Person
    {
        public Person(string firstName, string lastName, string email, DateTime date) //생성자
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Date = date;
        }


        public string FirstName { get; set; } //Table상 필드
        public string LastName { get; set; } //Table상 필드


        string email; //Table상 필드
        public string Email
        {
            //get => email; 람다식
            get { return email; }
            set 
            {
                if (Commons.IsValidEmail(value))
                    email = value;
                else
                    throw new Exception("Invalid Email");
            }
        }



        DateTime date; //Table상 필드
        public DateTime Date
        {
            get { return date; }
            set 
            {
                var result = Commons.CalcAge(value); //나이
                if (result > 150 || result < 0)
                    throw new Exception("Invalid Age");
                else
                    date = value; 
            }
        }

        

        public bool IsBirthDay //추가 속성
        {
            get 
            {
                return DateTime.Now.Month == Date.Month && DateTime.Now.Day == Date.Day;
            }
        }

        public bool IsAdult //추가 속성
        {
            get
            {
                return Commons.CalcAge(Date) > 18;
            }
        }

        public string ChnZodiac
        {
            get
            {
                return Commons.GetChineseZodiac(Date);
            }
        }

        public string CalcZodiac
        {
            get
            {
                return Commons.GetCalcZodiac(Date);
            }
        }
    }
}
