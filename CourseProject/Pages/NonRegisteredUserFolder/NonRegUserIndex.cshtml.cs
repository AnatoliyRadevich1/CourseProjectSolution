using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CourseProject.Pages.NonRegisteredUserFolder
{
    public class NonRegUserIndexModel : PageModel
    {
        public List<NonRegisteredUserInfo> listNonRegisteredUsers = new List<NonRegisteredUserInfo>();
        public void OnGet()
        {
            try
            {
				string connecetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\Desktop\ITransition\CourseProject\CourseProjectSolution\DataBase\SampleDatabaseWalkthrough\CourseDB.mdf;Integrated Security=True";
				using (SqlConnection connection = new SqlConnection(connecetionString))
				{
					connection.Open();
					string sql = "SELECT * FROM fulltable";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								NonRegisteredUserInfo nonRegisteredUserInfo = new NonRegisteredUserInfo();

								nonRegisteredUserInfo.User_name_of_review = reader.GetString(7);
								nonRegisteredUserInfo.User_dark_theme = reader.GetBoolean(17);
								nonRegisteredUserInfo.User_language_selection = reader.GetString(18);

								listNonRegisteredUsers.Add(nonRegisteredUserInfo);
							}
						}
					}
				}
			}
            catch (Exception ex)
            {
                 Console.WriteLine("Необработанное исключение " + ex.ToString());
            }
        }
    }
    public class NonRegisteredUserInfo
    {
		readonly string _username = "Гость";
		public string Username { get {return _username; } }
		public string User_name_of_review { get; set; }
		public bool User_group_of_review_for_films { get;}
		public bool User_group_of_review_for_books { get;}
		public bool User_group_of_review_for_games { get;}
		public string User_review_text { get;}
		public string User_icon_address { get;}
		public byte User_marks { get;}
		public byte AnyUser_rate { get;}
		public decimal Average_rate { get;}
		public bool User_dark_theme { get; set; }
		public string User_language_selection { get; set; }
	}
}
