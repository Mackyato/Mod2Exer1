using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod2Exer1.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Mod2Exer1.ViewModel
{
    public class EmployeeViewModel
    {
        private Employee _employee;

        private string _fullname;

        public EmployeeViewModel()
        {
            //Initializing a sample student model. Coordination with Model
            _employee = new Employee
            {
                FirstName = "Mark",
                LastName = "Anthony",
                Position = "Manager",
                Department = "CCS",
                IsActive = true
            };

            //UI THREAD MANAGEMENT
            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());


            Employees = new ObservableCollection<Employee>
            {
                new Employee {FirstName = "Jane", LastName = "Smith", Position = "Dean", Department = "CCS"},
                new Employee {FirstName = "James", LastName = "Bond", Position = "Program Chair", Department = "BMMA"},
                new Employee {FirstName = "Alice", LastName = "Guo", Position = "Vice Dean", Department = "BSCS"}
            };
        }

        //setting collection in public
        public ObservableCollection<Employee> Employees { get; set; }

        //Two-Way DATA BINDING
        public string FullName
        {
            get => _fullname;
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        //UI THREAD MANAGEMENT
        public ICommand LoadEmployeeDataCommand { get; }

        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000); //I/0 operation

            FullName = $"{_employee.FirstName} {_employee.LastName} {_employee.Position} {_employee.Department}"; ///Data Conversion
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
