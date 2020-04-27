using System;
using Microsoft.AspNetCore.Http;

namespace API.Helpers
{
    public static class Extension
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculateAge(this DateTime DateToCalculate)
        {
            int age = DateTime.Today.Year - DateToCalculate.Year;
            if (DateToCalculate.AddYears(age) > DateTime.Today)
                age--;
            return age;
        }
    }
}