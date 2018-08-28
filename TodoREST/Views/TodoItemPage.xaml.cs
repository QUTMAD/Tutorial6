using System;
using Xamarin.Forms;

namespace TodoREST
{
	public partial class TodoItemPage : ContentPage
	{
		public TodoItemPage (bool isNew = false)
		{
			InitializeComponent ();
		}

        async void OnSaveUpdateActivated(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;

            if (todoItem.Text == null)
            {
                await DisplayAlert("Alert", "Task name cannot be empty!", "OK");
            }
            else if (todoItem.Text.Trim() == "")
            {
                await DisplayAlert("Alert", "Task name cannot be empty!", "OK");
            }
            else
            {
                if (todoItem.Id == "0") //save mode
                {
                    await App.TodoManager.SaveTaskAsync(todoItem);
                }
                else //update mode
                {
                    await App.TodoManager.UpdateTaskAsync(todoItem);
                }
                await Navigation.PopAsync();

                // when you're done, disable the following line!
                await DisplayAlert("Alert", "Do yourself in the class! Check resources and take tutor's help!", "OK");
            }
        }

		async void OnDeleteActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.TodoManager.DeleteTaskAsync (todoItem);
			await Navigation.PopAsync ();

            // when you're done, disable the following line!
            await DisplayAlert("Alert", "Do yourself in the class! Check resources and take tutor's help!", "OK");
        }

		void OnCancelActivated (object sender, EventArgs e)
		{
			Navigation.PopAsync ();
		}

		void OnSpeakActivated (object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			App.Speech.Speak (todoItem.Text + " " + todoItem.Text);
		}
	}
}
