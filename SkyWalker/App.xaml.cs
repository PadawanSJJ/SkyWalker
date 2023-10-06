using Prism.Ioc;
using Prism.Unity;
using SkyWalker_WPF.ViewModels;
using SkyWalker_WPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SkyWalker_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : PrismApplication
    {
        public static string token;
        protected override Window CreateShell()
        {
            var loginWindow=Container.Resolve<LoginWindow>();
            var result=loginWindow.ShowDialog();
            if (result.Value)
            {
                return Container.Resolve<MainWindow>();
            }
            else
            {
                App.Current.Shutdown();
                return null;
            }       
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainViewModel>();
            containerRegistry.RegisterForNavigation<FamilyView, FamilyViewModel>();
            containerRegistry.RegisterForNavigation<FriendView, FriendViewModel>();
            containerRegistry.RegisterForNavigation<GroupView, GroupViewModel>();
            containerRegistry.RegisterForNavigation<MessageView, MessageViewModel>();
            containerRegistry.RegisterForNavigation<WorkView, WorkViewModel>();
        }
    }
}
