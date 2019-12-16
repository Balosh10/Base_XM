
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App_Base_XF.Bases;
using App_Base_XF.Helpers;
using Xamarin.Forms;

namespace App_Base_XF.ViewModel.LoginViewModel
{
    public class LoginViewModel: ModelBase
    {

        #region Propiedades 
        private bool _isPassword;
        public bool IsPassword
        {
            get { return _isPassword; }
            set { SetProperty(ref _isPassword, value, nameof(IsPassword)); }
        }

        private string _placeholderEmail;
        public string PlaceholderEmail
        {
            get { return _placeholderEmail; }
            set { SetProperty(ref _placeholderEmail, value, nameof(PlaceholderEmail)); }
        }

        private Color _placeholderColorEmail;
        public Color PlaceholderColorEmail
        {
            get { return _placeholderColorEmail; }
            set { SetProperty(ref _placeholderColorEmail, value, nameof(PlaceholderColorEmail)); }
        }

        private string _placeholderPassword;
        public string PlaceholderPassword
        {
            get { return _placeholderPassword; }
            set { SetProperty(ref _placeholderPassword, value, nameof(PlaceholderPassword)); }
        }

        private Color _placeholderColorPassword;
        public Color PlaceholderColorPassword
        {
            get { return _placeholderColorPassword; }
            set { SetProperty(ref _placeholderColorPassword, value, nameof(PlaceholderColorPassword)); }
        }
        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set { SetProperty(ref _userPassword, value, nameof(UserPassword)); }
        }
        private string _userEmail;
        public string UserEmail
        {
            get { return _userEmail; }
            set { SetProperty(ref _userEmail, value, nameof(UserEmail)); }
        }

        private string _imageIcon;
        public string ImagenIcon
        {
            get { return _imageIcon; }
            set { SetProperty(ref _imageIcon, value, nameof(ImagenIcon)); }
        }

        private string _icon_user;
        public string Icon_user
        {
            get { return _icon_user; }
            set { SetProperty(ref _icon_user, value, nameof(Icon_user)); }
        }

        private string _icon_password;
        public string Icon_password
        {
            get { return _icon_password; }
            set { SetProperty(ref _icon_password, value, nameof(Icon_password)); }
        }

        private string _icon_password_show_or_hide;
        public string Icon_password_show_or_hide
        {
            get { return _icon_password_show_or_hide; }
            set { SetProperty(ref _icon_password_show_or_hide, value, nameof(Icon_password_show_or_hide)); }
        }

        private bool _icon_password_status;
        public bool Icon_password_status
        {
            get { return _icon_password_status; }
            set { SetProperty(ref _icon_password_status, value, nameof(Icon_password_status)); }
        }

        #endregion

        #region Commandos
        private ICommand _registerUserCommand;
        public ICommand RegisterUserCommand
        {
            get { return _registerUserCommand; }
            set { SetProperty(ref _registerUserCommand, value, nameof(RegisterUserCommand)); }
        }

        private ICommand _recoverPasswordCommand;
        public ICommand RecoverPasswordCommand
        {
            get { return _recoverPasswordCommand; }
            set { SetProperty(ref _recoverPasswordCommand, value, nameof(RecoverPasswordCommand)); }
        }

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get { return _loginCommand; }
            set { SetProperty(ref _loginCommand, value, nameof(LoginCommand)); }
        }

        private ICommand _fingerPrintAuthenticationCommand;
        public ICommand FingerPrintAuthenticationCommand
        {
            get { return _fingerPrintAuthenticationCommand; }
            set { SetProperty(ref _fingerPrintAuthenticationCommand, value, nameof(FingerPrintAuthenticationCommand)); }
        }

        private ICommand _passwordShowOrHideCommand;
        public ICommand PasswordShowOrHideCommand
        {
            get { return _passwordShowOrHideCommand; }
            set { SetProperty(ref _passwordShowOrHideCommand, value, nameof(PasswordShowOrHideCommand)); }
        }

        #endregion

        #region Metodos
        public void PasswordShowOrHide()
        {
            IsPassword = !IsPassword;
            Icon_password_status = !Icon_password_status;
            Icon_password_show_or_hide = Icon_password_status ?
                                         IconConstants.ic_password_show : IconConstants.ic_password_hide;
        }
        public void Login(object args)
        {
        }

        public void RecoverPassword(object args)
        {
        }
        public void RegisterUser(object args)
        {
        }
        #endregion

        #region Contructor
        public LoginViewModel()
        {
            IsPassword = true;
            ImagenIcon = IconConstants.ic_mi_comunidad;
            Icon_user = IconConstants.ic_user;
            Icon_password = IconConstants.ic_password;
            Icon_password_status = false;
            PlaceholderEmail = "Correo electronico...";
            PlaceholderPassword = "Contraseña...";
            PlaceholderColorEmail = Color.FromHex("#bebdc2");
            Icon_password_show_or_hide = IconConstants.ic_password_hide;
            LoginCommand = new Command(async (args) => await LoginAsync(args));
            PasswordShowOrHideCommand = new Command(async () => PasswordShowOrHide());
            RegisterUserCommand = new Command(async (args) => RegisterUser(args));
            RecoverPasswordCommand = new Command(async (args) => RecoverPassword(args));
        }

        private async Task LoginAsync(object args)
        {
            try
            {
                PlaceholderEmail = string.IsNullOrEmpty(UserEmail) ? "Correo electronico requerido...": "Correo electronico...";
                PlaceholderColorEmail = string.IsNullOrEmpty(UserEmail) ? Color.FromHex("#d44a54") : Color.FromHex("#bebdc2");
                PlaceholderPassword = string.IsNullOrEmpty(UserPassword) ? "Contraseña requerido..." : "Contraseña...";
                PlaceholderColorPassword = string.IsNullOrEmpty(UserPassword) ? Color.FromHex("#d44a54") : Color.FromHex("#bebdc2");

                if (string.IsNullOrEmpty(UserEmail) || string.IsNullOrEmpty(UserPassword)) { return; }


            }
            catch (Exception e)
            {

            }
        }
        #endregion
    }

    
}
