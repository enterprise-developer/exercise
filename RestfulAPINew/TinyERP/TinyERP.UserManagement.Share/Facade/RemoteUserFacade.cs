﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using TinyERP.Common.Configurations;
using TinyERP.Common.Responses;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Share.Facade
{
    public class RemoteUserFacade : IUserFacade
    {
        public int CreateIfNotExist(CreateAuthorDto createAuthor)
        {
            HttpClient http = new HttpClient();
            string url = ConfigurationApp.Instance.UserManagement.EndPoint.Url;
            var json = JsonConvert.SerializeObject(createAuthor);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = http.PostAsync(url, data).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<Response<int>>(result);
            return responseData.Data;
        }
    }
}
