using System;
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
    public class People
    {

        public People(string name, long count)
        {
            Name = name;
            Count = count;
        }
        public string Name { get; set; }
        public long Count { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}