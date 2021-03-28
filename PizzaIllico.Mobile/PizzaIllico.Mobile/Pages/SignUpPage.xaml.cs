﻿using PizzaIllico.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage 
    {
        public SignInPage()
        {
            BindingContext = new SignUpViewModel();
            InitializeComponent();
        }
    }
}