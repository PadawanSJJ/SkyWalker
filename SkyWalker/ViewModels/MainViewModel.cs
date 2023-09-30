using CommunityToolkit.Mvvm.ComponentModel;
using SkyWalker_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWalker_WPF.ViewModels
{
    public partial class MainViewModel:ObservableObject
    {
        [ObservableProperty]
        private Uri avatar = new Uri("D:\\Code\\C#\\SkyWalker-WPF\\SkyWalker-WPF\\Assets\\avatar.webp");
        [ObservableProperty]
        private ObservableCollection<NavigatorItem> navigatorItems = new()
        {
            new(){Key="message",Icon="MessageOutline" },
            new(){Key="friend",Icon="AccountOutline" },
            new(){Key="family",Icon="HomeHeart"},
            new(){Key="group",Icon="AccountGroupOutline"},
            new(){Key="work",Icon="BriefcaseOutline"},
        };
    }
}
