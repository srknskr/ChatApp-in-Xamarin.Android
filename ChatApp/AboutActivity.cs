﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ChatApp
{
    [Activity(Label = "AboutActivity")]
    public class AboutActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.About);
            FindViewById<Button>(Resource.Id.learnMoreButton).Click += OnLearnMoreClick;
        }

        private void OnLearnMoreClick(object sender, EventArgs e)
        {
            var intent = new Intent();

            intent.SetAction(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse("http://srknskr.github.io"));

            StartActivity(intent);
        }
    }
}