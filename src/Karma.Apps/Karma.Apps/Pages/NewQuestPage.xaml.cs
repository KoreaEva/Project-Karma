﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Karma.Apps.Pages
{
    public partial class NewQuestPage : ContentPage
    {
        public NewQuestPage()
        {
            InitializeComponent();
            DateInfo.Date = DateTime.Today;

        }
    }
}
