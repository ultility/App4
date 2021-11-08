using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace App4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        FirebaseClient firebase = new FirebaseClient("https://xamarinfirebase-xxxxx.firebaseio.com/");
        TextView txtId;
        TextView txtName;
        ListView lv;
        PersonAdapter Adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public async Task<List<Person>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Name = item.Object.Name,
                  PersonId  = item.Object.PersonId
              }).ToList();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await FirebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            Toast.MakeText(this, "person added successfully", ToastLength.Long).Show();
            var allPersons = await FirebaseHelper.GetAllPersons();
            Adapter.objects = allPersons;
        }
    }

}