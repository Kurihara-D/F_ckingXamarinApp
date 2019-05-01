using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace Todo
{
    public class TodoAPI
    {
        public List<TodoEntitiy> taskList;

        public string API_URL = "<some api url>";

        public async Task<List<TodoEntitiy>> AsyncGetWebAPIData()
        {
            taskList = new List<TodoEntitiy>();

            HttpClient httpClient = new HttpClient();

            Task<string> stringAsync = httpClient.GetStringAsync(API_URL);
            string result = await stringAsync;

            taskList = JsonConvert.DeserializeObject<List<TodoEntitiy>>(result);

            return taskList;
        }
    }

    public class TodoEntitiy
    {
        public string id { get; set; }
        public string body { get; set; }

    }
}
