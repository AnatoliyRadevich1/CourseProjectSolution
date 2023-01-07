using System;
using CourseProject.Pages.AdminFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseProject.Pages.NonRegisteredUserFolder
{
    public class RegistrationButtonModel : PageModel 
    {
        public string errorMessageRegistration = "������ ���� ����� ����� � ������";
        public string successMessageRegistration = "�� ����������������";
        
        public AdminInfo nonRegisteredUser = new AdminInfo();
        public void OnGet()
        {
        }
        public void OnPost()
        {
            nonRegisteredUser.Username = Request.Form["���"];
            nonRegisteredUser.Userpass = Request.Form["������"];

            if (nonRegisteredUser.Username == "" || nonRegisteredUser.Userpass=="")
            {
                Console.WriteLine(errorMessageRegistration);
                return;
            }

        }
    }

}
