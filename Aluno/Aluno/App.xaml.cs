﻿using Aluno.infra;
using Aluno.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Aluno
{
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new PessoaView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
