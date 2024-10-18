using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
	class MainWindowMVVM : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;
		protected void onPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		private string username;

		public string Username
		{
			get { return username; }
			set 
			{
				username = value;
				onPropertyChanged(nameof(Username));
			}
		}

		private string password;

		public string Password
		{
			get { return password; }
			set 
			{
				password = value;
				onPropertyChanged(nameof(Password));
			
			}
		}


	}
}
