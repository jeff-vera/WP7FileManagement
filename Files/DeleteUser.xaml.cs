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
	public partial class DeleteUser : PhoneApplicationPage
	{
		public DeleteUser()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			LoadUsers();
		}

		private void LoadUsers()
		{
			IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
			usersToDelete.Items.Clear();
			string[] userFiles = isf.GetFileNames(@"users/*.user");
			usersToDelete.ItemsSource = userFiles;
		}

		private void usersToDelete_Tap(object sender, GestureEventArgs e)
		{
			if (e.OriginalSource is TextBlock)
			{
				TextBlock tb = e.OriginalSource as TextBlock;
				IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
				string fullPath = string.Concat("users/", tb.Text);
				isf.DeleteFile(fullPath);
				deleteResult.Text = string.Concat(tb.Text, " deleted.");
				
				LoadUsers();
			}
		}
	}
}