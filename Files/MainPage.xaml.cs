using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace Files
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
			if (!isf.DirectoryExists("users"))
			{
				isf.CreateDirectory("users");				
			}

			userList.Items.Clear();
			string [] userFiles = isf.GetFileNames(@"users\*.user");
			foreach (string userFile in userFiles)
			{
				userList.Items.Add(userFile);
			}
		}

		private void AddUser_Click(object sender, EventArgs e)
		{
			NavigationService.Navigate(new Uri("/AddUser.xaml", UriKind.Relative));
		}

		private void DeleteUser_Click(object sender, EventArgs e)
		{

		}

		private void userList_Tap(object sender, GestureEventArgs e)
		{
			if (e.OriginalSource is TextBlock)
			{
				TextBlock tb = e.OriginalSource as TextBlock;
				NavigationService.Navigate(
					new Uri(
						string.Concat("/DisplayPreferences.xaml?user=", tb.Text), 
						UriKind.Relative));
			}
		}


	}
}