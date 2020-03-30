using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Helpers;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
		private string _userName;
		private string _password;
		private string _errorMessage;
		private IAPIHelper _apiHelper;

		public LoginViewModel(IAPIHelper apiHelper)
		{
			_apiHelper = apiHelper;
		}

		public string UserName
		{
			get { return _userName; }
			set 
			{ 
				_userName = value;
				NotifyOfPropertyChange(() => UserName);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}

		public string Password
		{
			get { return _password; }
			set 
			{ 
				_password = value;
				NotifyOfPropertyChange(() => Password);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}



		public bool IsErrorVisible
		{
			get => ErrorMessage?.Length > 0;
		}


		public string ErrorMessage
		{
			get { return _errorMessage; }
			set 
			{
				_errorMessage = value;
				NotifyOfPropertyChange(() => ErrorMessage);
				NotifyOfPropertyChange(() => IsErrorVisible);
			}
		}



		public bool CanLogIn
		{
			get => UserName?.Length > 0 && Password?.Length > 0;
		}

		public async Task LogIn()
		{
			try
			{
				var result = await _apiHelper.Authenticate(UserName, Password);
				ErrorMessage = "";
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;	
			}
		}
	}
}
