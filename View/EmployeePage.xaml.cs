using Mod2Exer1.ViewModel;

namespace Mod2Exer1.View;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
        BindingContext = new EmployeeViewModel();
    }
}