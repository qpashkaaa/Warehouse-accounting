using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Warehouse_accounting.Model;
using Warehouse_accounting.Model.DbModels;
using Warehouse_accounting.Tools;
using Warehouse_accounting.View;

namespace Warehouse_accounting.ViewModel
{
    public class AuthorizationModalWindowViewModel
    {
        private IWindowService _windowService;
        private void OnOpenMainWindow()
        {
            _windowService.OpenMainWindow();
        }

        public AuthorizationModalWindowViewModel(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public string Login { get; set; }
        private string password;
        public string Password {
            get { return password; }
            set { password = Encryption.AES_encrypt(value); } 
        }

        public ICommand bAuthorizationModalWindow_Click
        {
            get
            {
                return new RelayCommand(() => CheckAuthorizationData());
            }
        }

        private void CheckAuthorizationData()
        {
            if (AuthorizationDataWorker.CheckAuthorizationDatas(Login, Password) == true)
            {
                OnOpenMainWindow();
            }
            else
            {
                // Обводка элементов красным цветом
                MessageBox.Show("Не найдено!");
            }

        }
    }
}
