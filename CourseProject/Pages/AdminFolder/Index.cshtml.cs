using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient; //для использования класса SqlConnection

namespace CourseProject.Pages.AdminFolder
{
    public class IndexModel : PageModel
    {
        public List<AdminInfo> myAdminInfo = new List<AdminInfo>();
        public void OnGet()
        {
            try
            {
				//адрес взят из свойсва базы данных CourseDB.mdf (обозреватель серверов->CourseDB.mdf->Свойства->Ячейка правее Строки подключения)
				string conectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\Desktop\ITransition\CourseProject\CourseProjectSolution\DataBase\SampleDatabaseWalkthrough\CourseDB.mdf;Integrated Security=True";
				using (SqlConnection connection = new SqlConnection(conectionString))
				{ 
					connection.Open();
					string sql = "SELECT * FROM fulltable";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								AdminInfo adminInfo = new AdminInfo();
								adminInfo.Id = reader.GetInt32(0);
								adminInfo.Username = reader.GetString(1);
								adminInfo.Userpass = reader.GetString(2);
								adminInfo.User_social_network_VK_acceess = reader.GetString(3);
								adminInfo.User_social_network_FB_acceess = reader.GetString(4);
								adminInfo.User_social_network_TG_acceess = reader.GetString(5);
								adminInfo.User_page_address = reader.GetString(6);
								adminInfo.User_name_of_review = reader.GetString(7);
								adminInfo.User_group_of_review_for_films = reader.GetBoolean(8);
								adminInfo.User_group_of_review_for_books = reader.GetBoolean(9);
								adminInfo.User_group_of_review_for_games = reader.GetBoolean(10);
								adminInfo.User_tag  = reader.GetString(11);
								adminInfo.User_review_text = reader.GetString(12);
								adminInfo.User_icon_address  = reader.GetString(13);
								adminInfo.User_marks = reader.GetByte(14);
								adminInfo.AnyUser_rate = reader.GetByte(15);
								adminInfo.Average_rate = reader.GetDecimal(16);
								adminInfo.User_dark_theme  = reader.GetBoolean(17);
								adminInfo.User_language_selection  = reader.GetString(18);
								adminInfo.User_is_blocked = reader.GetBoolean(19);
								adminInfo.User_is_deleted = reader.GetBoolean(20);
								adminInfo.User_pdf_file_address  = reader.GetString(21);

								myAdminInfo.Add(adminInfo);
							}
						}
					}
				}
            }
            catch (Exception ex)
            {
                Console.WriteLine("Необработанное исключение "+ex.ToString());
            }
        }
    }
    public class AdminInfo
    {
		public int Id { get; set; }
		public string Username { get; set; }
		public string Userpass { get; set; }
		public string User_social_network_VK_acceess { get; set; }
		public string User_social_network_FB_acceess { get; set; }
		public string User_social_network_TG_acceess { get; set; }
		public string User_page_address { get; set; }
		public string User_name_of_review { get; set; }
		public bool User_group_of_review_for_films { get; set; }
		public bool User_group_of_review_for_books { get; set; }
		public bool User_group_of_review_for_games { get; set; }
		public string User_tag { get; set; }
		public string User_review_text { get; set; }
		public string User_icon_address { get; set; }
		public byte User_marks { get; set; }
		public byte AnyUser_rate { get; set; }
		public decimal Average_rate { get; set; }
		public bool User_dark_theme { get; set; }
		public string User_language_selection { get; set; }
		public bool User_is_blocked { get; set; }
		public bool User_is_deleted { get; set; }
		public string User_pdf_file_address { get; set; }

	}
}
