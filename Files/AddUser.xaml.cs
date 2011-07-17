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
	public partial class AddUser : PhoneApplicationPage
	{
		public AddUser()
		{
			InitializeComponent();
		}

		private void addUser_Click(object sender, RoutedEventArgs e)
		{
			IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
			string userFilename = string.Concat("users/", newUserName.Text, ".user");
			IsolatedStorageFileStream stream = isf.CreateFile(userFilename);
			
			string contents = string.Concat("user created: ", DateTime.Now.ToLongDateString());
			byte[] contentsToWrite = System.Text.Encoding.UTF8.GetBytes(contents);
			stream.Write(contentsToWrite, 0, contentsToWrite.Length);

			newUserName.Text = "";
			statusMessage.Text = "User added.";
		}
	}
}