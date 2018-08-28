using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoREST
{
	public class RestService : IRestService
	{
		HttpClient client;

		public List<TodoItem> Items { get; private set; }

		public RestService ()
		{
            #region forbasicauthentication

			    client = new HttpClient ();
			    client.MaxResponseContentBufferSize = 256000;
            #endregion
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            Items = new List<TodoItem>();
            #region use_RESTAPI_to_get_data
            var uri = new Uri(string.Format(Constants.RestUrl + "tables/TodoItem", string.Empty));
            var request = new HttpRequestMessage();
            request.Headers.Add("ZUMO-API-VERSION", "2.0.0");
            request.RequestUri = uri;
            try
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            #endregion
            return Items;
        }

        public async Task SaveTodoItemAsync(TodoItem item)
        {
            #region use_RESTAPI_to_save_data_in_database
                //write your code here
            #endregion
        }

        public async Task UpdateTodoItemAsync(TodoItem item)
        {
            #region use_RESTAPI_to_update_data_in_database
                //write your code here
            #endregion
        }

        public async Task DeleteTodoItemAsync (string id)
		{
            #region use_RESTAPI_to_delete_data
                //write your code here
            #endregion
        }

        private Task DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}
