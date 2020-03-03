using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace ChatApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static List<People> PeopleList = new List<People>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            PeopleList.Add(new People("Apple", 1));
            PeopleList.Add(new People("Milk", 2));
            PeopleList.Add(new People("Bread", 3));
            PeopleList.Add(new People("Banana", 4));
            PeopleList.Add(new People("Pineapple", 5));

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var lv = FindViewById<ListView>(Resource.Id.listView);


            lv.Adapter = new ArrayAdapter<People>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, MainActivity.PeopleList);
            lv.ItemClick += OnItemClick;


            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
        

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            StartActivity(typeof(AboutActivity));
            
        }
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
        void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(DetailsActivity));

            intent.PutExtra("ItemPosition", e.Position); // e.Position is the position in the list of the item the use touched

            StartActivity(intent);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == 100 && resultCode == Result.Ok)
            {
                string name = data.GetStringExtra("ItemName");
                int count = data.GetIntExtra("ItemCount", 0);

                MainActivity.PeopleList.Add(new People(name, count));
            }
        }
    }
}

