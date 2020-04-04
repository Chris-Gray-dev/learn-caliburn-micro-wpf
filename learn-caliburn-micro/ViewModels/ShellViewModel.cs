using Caliburn.Micro;
using learn_caliburn_micro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_caliburn_micro.ViewModels
{
    public class ShellViewModel: Conductor<object>
	{


		private string _firstName;
		private string _lastName;

		private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
		private PersonModel _selectedPerson;


		public ShellViewModel()
		{
			People.Add(new PersonModel { FirstName = "Chris", LastName = "Gray" });
			People.Add(new PersonModel { FirstName = "Skank", LastName = "McGank" });
			People.Add(new PersonModel { FirstName = "Jo", LastName = "Jo" });
		}

		public string FirstName
		{
			get 
			{ 
				return _firstName;
			}
			
			set 
			{
				_firstName = value;
				NotifyOfPropertyChange(() => FirstName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string LastName
		{
			get 
			{ 
				return _lastName;
			}
			set 
			{
				_lastName = value;
				NotifyOfPropertyChange(() => LastName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string FullName
		{
			get
			{
				return $"{FirstName} {LastName}";
			}
		}

		public BindableCollection<PersonModel> People
		{
			get { return _people; }
			set { _people = value; }
		}

		public PersonModel SelectedPerson
		{
			get { return _selectedPerson; }
			set 
			{ 
				_selectedPerson = value;
				NotifyOfPropertyChange(()=> SelectedPerson);
			}
		}

		public bool CanClearText(string firstName, string lastName)
		{
			return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
		}
		public void ClearText(string firstName, string lastName)
		{
			FirstName = "";
			LastName = "";
		}


		public void LoadPageOne()
		{
			ActivateItem(new FirstChildViewModel());
		}

		public void LoadPageTwo()
		{
			var windowManager = new WindowManager();
			var login = new FirstChildViewModel();
			windowManager.ShowDialog(login);
		}
	}
}
