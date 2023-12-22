using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Lab16.Models;
using Lab16.Services;

namespace Lab16.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private readonly ApiService _apiService = new ApiService();
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        public async void LoadUsers()
        {
            var users = await _apiService.GetUsersAsync();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public void ClearUsers()
        {
            Users.Clear();
        }

    }
}
