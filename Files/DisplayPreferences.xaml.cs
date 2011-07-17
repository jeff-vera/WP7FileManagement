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
	public partial class DisplayPreferences : PhoneApplicationPage
	{
		public DisplayPreferences()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			string userFilename;
			if (NavigationContext.QueryString.TryGetValue("user", out userFilename))
			{
				string filePath = string.Concat("users/", userFilename);
				string fileContents = GetFileContents(filePath);
				preferences.Text = string.Concat(
					"preferences for ", 
					userFilename, 
					Environment.NewLine, 
					fileContents);
			}
		}

		private string GetFileContents(string filePath)
		{
			IsolatedStorageFile ifs =
				IsolatedStorageFile.GetUserStoreForApplication();
			IsolatedStorageFileStream stream =
				ifs.OpenFile(filePath, System.IO.FileMode.Open);
			List<byte> contents = new List<byte>();
			int currentByte = -1;
			do
			{
				currentByte = -1;
				currentByte = stream.ReadByte();
				if (currentByte >= 0)
				{
					contents.Add((byte)currentByte);
				}
			} while (currentByte >= 0);

			string convertedContents =System.Text.UTF8Encoding.UTF8.GetString(
				contents.ToArray<byte>(), 
				0, 
				contents.Count);

			return convertedContents;
		}
	}
}