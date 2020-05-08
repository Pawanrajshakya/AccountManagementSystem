using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

        public static void AddPaginationHeader(this HttpResponse response, int currentPage, int pageSize, int totalCount, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, pageSize, totalCount, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
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