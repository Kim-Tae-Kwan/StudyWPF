using Caliburn.Micro;
using MySql.Data.MySqlClient;
using Renci.SshNet.Messages.Connection;
using System.Windows;
using ThirdCaliburnApp.Models;

namespace ThirdCaliburnApp.ViewModels
{
    public class MainViewModel : Conductor<object>, IHaveDisplayName
    {
        EmployeesModel employeesModel;


        #region 속성영역
        //모델과 뷰모델 연결
        int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        string empName;
        public string EmpName 
        {
            get => empName;
            set
            {
                empName = value;
                NotifyOfPropertyChange(() => EmpName);
            }
        }

        decimal salary;
        public decimal Salary 
        { 
            get => salary; 
            set 
            { 
                salary = value;
                NotifyOfPropertyChange(() => Salary);
            } 
        }

        string deptName;
        public string DeptName 
        { 
            get=>deptName;
            set
            {
                deptName = value;
                NotifyOfPropertyChange(() => DeptName);
            }
        }

        string destination;
        public string Destination 
        { 
            get=> destination; 
            set
            {
                destination = value;
                NotifyOfPropertyChange(() => Destination);
            }
        }

        //전체 Employees 리스트

        BindableCollection<EmployeesModel> employees;
        public BindableCollection<EmployeesModel> Employees 
        {
            get => employees; 
            set
            {
                employees = value;
                NotifyOfPropertyChange(() => Employees);
            }
        }

        //리스트 중 선택된 하나의 Employee
        EmployeesModel selectedEmployee;
        public EmployeesModel SelectedEmployee
        {
            get=> selectedEmployee;
            set
            {
                selectedEmployee = value;

                Id = value.Id;
                EmpName = value.EmpName;
                Salary = value.Salary;
                DeptName = value.DeptName;
                Destination = value.Destination;

                NotifyOfPropertyChange(() => SelectedEmployee);
            }
        }
        #endregion

        #region 생성자 영역
        public MainViewModel()
        {
            
            GetEmployees();
        }
        #endregion


        public void GetEmployees()
        {
            //데이터베이스 초기화
            using(MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                

                MySqlCommand cmd = new MySqlCommand(EmployeesTbl.SELECT_EMPLOYEE,conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Employees = new BindableCollection<EmployeesModel>();
                while (reader.Read())
                {
                    var temp = new EmployeesModel
                    {
                        Id = (int)reader["id"],
                        EmpName = reader["EmpName"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        DeptName = reader["DeptName"].ToString(),
                        Destination = reader["Destination"].ToString()
                    };
                    Employees.Add(temp);
                }

            }
        }
        public bool CanSaveEmployee
        {
            get
            {
                if ((Id == 0) && (string.IsNullOrEmpty(EmpName)) && (Salary == 0) && (string.IsNullOrEmpty(DeptName))
                    && (string.IsNullOrEmpty(Destination)))
                {
                    return false;
                }
                else
                    return true;
            }
        }

        public void SaveEmployee()
        {
            int resultRow = 0;

            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(EmployeesTbl.UPDATE_EMPLOYEE, conn);
                MySqlParameter paramEmpName = new MySqlParameter("@EmpName", MySqlDbType.VarChar, 45);
                paramEmpName.Value = EmpName;
                cmd.Parameters.Add(paramEmpName);

                MySqlParameter paramSalary = new MySqlParameter("@Salary", MySqlDbType.Decimal);
                paramSalary.Value = Salary;
                cmd.Parameters.Add(paramSalary);

                MySqlParameter paramDeptName = new MySqlParameter("@DeptName", MySqlDbType.VarChar, 45);
                paramDeptName.Value = DeptName;
                cmd.Parameters.Add(paramDeptName);

                MySqlParameter paramDestination = new MySqlParameter("@Destination", MySqlDbType.VarChar, 45);
                paramDestination.Value = Destination; 
                cmd.Parameters.Add(paramDestination);

                MySqlParameter paramid = new MySqlParameter("@id", MySqlDbType.VarChar, 45);
                paramid.Value = id;
                cmd.Parameters.Add(paramid);

                resultRow = cmd.ExecuteNonQuery();


            }

            if(resultRow > 0)
            {
                MessageBox.Show("저장했습니다.");
                GetEmployees();
            }

        }

        public void NewEmployee()
        {
            Id = 0;
            EmpName = DeptName = Destination = string.Empty;
            Salary = 0;
        }



    }
}
