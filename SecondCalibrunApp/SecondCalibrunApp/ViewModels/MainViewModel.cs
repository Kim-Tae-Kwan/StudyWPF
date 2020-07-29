using Caliburn.Micro;
using MySql.Data.MySqlClient;
using SecondCalibrunApp.Helper;
using SecondCalibrunApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCalibrunApp.ViewModels
{
    public class MainViewModel : Conductor<object>, IHaveDisplayName
    {
        public override string DisplayName { get; set; }

        public MainViewModel()
        {
            DisplayName = "Second Caliburn App";
            //FirstName = "TaeKwan";

            People = new BindableCollection<PersonModel>();
            //People.Add(new PersonModel { LastName = "Gates", FirstName = "Bill" });
            //People.Add(new PersonModel { LastName = "Jobs", FirstName = "Steve" });
            //People.Add(new PersonModel { LastName = "Musk", FirstName = "Ellen" });
            InitComboBox();

        } //생성자

        private void InitComboBox()
        {
            //데이터 베이스 연결
            using(MySqlConnection conn = new MySqlConnection(Commons.STRCONNSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.SELECTPEOPLEQUERY, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    var temp = new PersonModel 
                    { 
                        FirstName = reader["FirstName"].ToString(), 
                        LastName = reader["lastname"].ToString() 
                    };
                    People.Add(temp);

                }
            }
        }

        private string firstName;
        public string FirstName 
        {
            get => firstName;
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        private string lastName;
        public string LastName
        {
            get =>lastName;
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        public string FullName
        {
            get => $"{LastName} {FirstName}";
        }



        // 콤보박스 사람 리스트
        public BindableCollection<PersonModel> People { get; set; }

        PersonModel selectedPerson;

        public PersonModel SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                this.LastName = selectedPerson.LastName;
                this.FirstName = selectedPerson.FirstName;
                NotifyOfPropertyChange(() => SelectedPerson);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        public void ClearName()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
        }

        public bool CanClearName
        {
            get => !(string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName));
            
        }

        public void LoadPageOne()
        {   //UserControl FirstChildView
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {   //UserControl SecondChildView
            ActivateItem(new SecondChildViewModel());
        }
    }
}
