using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace Todo
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public List<TodoEntitiy> taskList;

        public bool isBusy { get; set; }

        public MainPage()
        {
            InitializeComponent();

            fetchTasks(new TodoAPI());
        }
        async void fetchTasks(TodoAPI api)
        {
            try
            {
                this.isBusy = true;
                taskList = await api.AsyncGetWebAPIData();

                var items = new List<String>();
                foreach (TodoEntitiy value in taskList)
                {
                    items.Add(value.body);
                }
                this.BindingContext = taskList;
            }
            catch (System.Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "OK");
            }
            finally
            {
                this.isBusy = false;
            }
        }
    }
}
