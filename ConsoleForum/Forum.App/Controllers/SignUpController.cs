using System;
using Forum.App.Controllers.Contracts;
using Forum.App.Services;
using Forum.App.UserInterface;
using Forum.App.UserInterface.Contracts;

namespace Forum.App.Controllers
{

    public class SignUpController : IController, IReadUserInfoController
    {
        private const string DETAILS_ERROR = "Invalid Username or Password!";
        private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public string Username { get; private set; }

        private string Password { get; set; }

        private string ErrorMessage { get; set; }

        private enum Command
        {
            ReadUsername, ReadPassword, SignUp, Back
        }

        private void ResetLogin()
        {
            this.ErrorMessage = string.Empty;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();

                    return MenuState.SignUp;

                case Command.ReadPassword:
                    this.ReadPassword();

                    return MenuState.SignUp;

                case Command.SignUp:
                    SignUpStatus status = UserService.TrySignUpUser(this.Username, this.Password);
                    switch (status)
                    {
                        case SignUpStatus.Success:
                            return MenuState.SuccessfulLogIn;

                        case SignUpStatus.DetailsError:
                            this.ErrorMessage = DETAILS_ERROR;
                            return MenuState.Error;

                        case SignUpStatus.UsernameTakenError:
                            this.ErrorMessage = USERNAME_TAKEN_ERROR;
                            return MenuState.Error;
                    }
                    break;

                case Command.Back:
                    this.ResetLogin();

                    return MenuState.Back;
            }

            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new SignUpView(this.ErrorMessage);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }
    }
}