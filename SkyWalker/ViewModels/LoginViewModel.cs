using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SkyWalker.Models;
using SkyWalker_WPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SkyWalker_WPF.ViewModels
{
    public partial class LoginViewModel:ObservableObject
    {
        private HttpClient httpClient=new();


        private  Window _window;

        [ObservableProperty]
        private int index=0;

        [ObservableProperty]
        private bool openPane;

        [ObservableProperty]
        private string userInfo;

        [ObservableProperty]
        private List<string> users = new();

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string phoneNo;

        [ObservableProperty]
        private string name;

        [RelayCommand]
        private void Index0()=>Index = 0;

        [RelayCommand]
        private void Index1() => Index = 1;

        [RelayCommand]
        private void Loaded(Window window)
        {
            _window = window;
        }

        [RelayCommand]
        private async Task SignIn(PasswordBox passwordBox)
        {
            var form = new List<KeyValuePair<string, string>>();
            form.Add(new("email", UserInfo));
            form.Add(new("password", passwordBox.Password));
            var res=await httpClient.PostAsync("http://localhost:5104/api/Login/SignIn", new FormUrlEncodedContent(form));
            var content = await res.Content.ReadAsStringAsync();
            if (res.StatusCode!=HttpStatusCode.OK)
            {
                MessageBox.Show(content);
                return;
            }
            else
            {
                App.token = content;
            }           
        }

        [RelayCommand]
        private async Task SignUp(PasswordBox passwordBox)
        {
            CitizenRegistrationModel model = new()
            {
                Email = Email,
                PhoneNo = PhoneNo,
                Name = Name,
                Password=passwordBox.Password
            };
            StringContent stringContent=new(JsonSerializer.Serialize(model),Encoding.UTF8,"application/json");
            var res = await httpClient.PostAsync("http://localhost:5104/api/Login/SignUp", stringContent);
        }
        [RelayCommand]
        private void ShowPane()
        {
            OpenPane = true;
        }

    }
}
