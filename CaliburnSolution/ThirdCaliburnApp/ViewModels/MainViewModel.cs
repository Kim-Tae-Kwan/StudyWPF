using Caliburn.Micro;
using MvvmDialogs;
using MySql.Data.MySqlClient;
using System.Windows;
using ThirdCaliburnApp.Models;

namespace ThirdCaliburnApp.ViewModels
{
    public class MainViewModel : Conductor<object>, IHaveDisplayName
    {

        #region 속성영역
        //모델과 뷰모델 연결

        readonly IWindowManager windowManager; //팝업창
        readonly IDialogService dialogService; //팝업창

        int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;

                NotifyOfPropertyChange(() => Id);
                NotifyOfPropertyChange(() => CanDeleteEmployee);
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
                NotifyOfPropertyChange(() => CanSaveEmployee);
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
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        string deptName;
        public string DeptName
        {
            get => deptName;
            set
            {
                deptName = value;
                NotifyOfPropertyChange(() => DeptName);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        string destination;
        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
                NotifyOfPropertyChange(() => Destination);
                NotifyOfPropertyChange(() => CanSaveEmployee);
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
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;

                if (value != null)
                {
                    Id = value.Id;
                    EmpName = value.EmpName;
                    Salary = value.Salary;
                    DeptName = value.DeptName;
                    Destination = value.Destination;
                }

                NotifyOfPropertyChange(() => SelectedEmployee);
            }
        }
        #endregion


        #region 생성자 영역
        public MainViewModel(IWindowManager windowManager, IDialogService dialogService)
        {
            this.windowManager = windowManager;
            this.dialogService = dialogService;
            GetEmployees();
        }
        #endregion


        public void GetEmployees()
        {
            //데이터베이스 초기화
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
            {
                conn.Open();


                MySqlCommand cmd = new MySqlCommand(EmployeesTbl.SELECT_EMPLOYEE, conn);
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



        public bool CanSaveEmployee //Button 사용 유무
        {
            get => !(string.IsNullOrEmpty(EmpName) ||
                    string.IsNullOrEmpty(DeptName) ||
                    string.IsNullOrEmpty(Destination) ||
                    Salary == 0);
        }

        public void SaveEmployee()
        {
            int resultRow = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (id == 0)//Insert
                    {
                        cmd.CommandText = EmployeesTbl.INSERT_EMPLOYEE;
                    }
                    else //update
                        cmd.CommandText = EmployeesTbl.UPDATE_EMPLOYEE;

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

                    if (id != 0)
                    {
                        MySqlParameter paramid = new MySqlParameter("@id", MySqlDbType.VarChar, 45);
                        paramid.Value = id;
                        cmd.Parameters.Add(paramid);
                    }


                    resultRow = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception e)
            {
                DialogViewModel dialogVM = new DialogViewModel();
                dialogVM.DisplayName = $"{e.Message}";
                bool? success = windowManager.ShowDialog(dialogVM);
            }


            if (resultRow > 0)
            {
                    //MessageBox.Show("저장했습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogViewModel dialogVM = new DialogViewModel();
                    dialogVM.DisplayName = "저장되었습니다.";
                    bool? success = windowManager.ShowDialog(dialogVM);

                    GetEmployees();
                    NewEmployee();
            }
        }




        public void NewEmployee()
        {
            Id = 0;
            EmpName = DeptName = Destination = string.Empty;
            Salary = 0;

        }

        public bool CanDeleteEmployee
        {
            get => !(Id == 0);
        }

        public void DeleteEmployee()
        {
            int resultRow = 0;
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = EmployeesTbl.DELETE_EMPLOYEE;

                MySqlParameter paramid = new MySqlParameter("@id", MySqlDbType.VarChar, 45);
                paramid.Value = id;
                cmd.Parameters.Add(paramid);

                resultRow = cmd.ExecuteNonQuery();

            }

            if (resultRow > 0)
            {
                //MessageBox.Show("삭제했습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogViewModel dialogVM = new DialogViewModel();
                dialogVM.DisplayName = "삭제되었습니다.";
                bool? success = windowManager.ShowDialog(dialogVM);
                GetEmployees();
                NewEmployee();
            }
        }


    }
}
