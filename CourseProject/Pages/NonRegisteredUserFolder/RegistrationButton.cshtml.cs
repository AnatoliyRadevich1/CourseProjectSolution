using System;
using CourseProject.Pages.AdminFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseProject.Pages.NonRegisteredUserFolder
{
    public class RegistrationButtonModel : PageModel 
    {
        public string errorMessageRegistration = "Должен быть введён логин и пароль";
        public string successMessageRegistration = "Вы зарегистрированы";
        
        public AdminInfo nonRegisteredUser = new AdminInfo();
        public void OnGet()
        {
        }
        public void OnPost()
        {
            nonRegisteredUser.Username = Request.Form["Имя"];
            nonRegisteredUser.Userpass = Request.Form["Пароль"];

            if (nonRegisteredUser.Username == "" || nonRegisteredUser.Userpass=="")
            {
                Console.WriteLine(errorMessageRegistration);
                return;
            }

        }
    }

}
