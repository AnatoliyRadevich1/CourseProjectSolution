using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CourseProject.Pages.RegisteredUserFolder
{
    public class IndexRegUserModel : PageModel
    {
		public List<RegisteredUserInfo> listRegisteredUsers= new List<RegisteredUserInfo>();
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
								RegisteredUserInfo registeredUserInfo = new RegisteredUserInfo();
								
								registeredUserInfo.Username = reader.GetString(1);
								registeredUserInfo.User_name_of_review = reader.GetString(7);
								registeredUserInfo.User_group_of_review_for_films = reader.GetBoolean(8);
								registeredUserInfo.User_group_of_review_for_books = reader.GetBoolean(9);
								registeredUserInfo.User_group_of_review_for_games = reader.GetBoolean(10);
								registeredUserInfo.User_review_text = reader.GetString(12);
								registeredUserInfo.User_icon_address = reader.GetString(13);
								registeredUserInfo.User_marks = reader.GetByte(14);
								registeredUserInfo.AnyUser_rate = reader.GetByte(15);
								registeredUserInfo.Average_rate = reader.GetDecimal(16);
								registeredUserInfo.User_dark_theme = reader.GetBoolean(17);
								registeredUserInfo.User_language_selection = reader.GetString(18);

								listRegisteredUsers.Add(registeredUserInfo);
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
    public class RegisteredUserInfo
    {
		public string Username { get; set; }
		public string User_name_of_review { get; set; }
		public bool User_group_of_review_for_films { get; set; }
		public bool User_group_of_review_for_books { get; set; }
		public bool User_group_of_review_for_games { get; set; }
		public string User_review_text { get; set; }
		public string User_icon_address { get; set; }
		public byte User_marks { get; set; }
		public byte AnyUser_rate { get; set; }
		public decimal Average_rate { get; set; }
		public bool User_dark_theme { get; set; }
		public string User_language_selection { get; set; }
	}
}
