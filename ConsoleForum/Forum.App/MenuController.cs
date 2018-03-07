namespace Forum.App
{
    using Controllers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UserInterface;
    using UserInterface.Contracts;

    internal class MenuController
    {
        private const int DEFAULT_INDEX = 0;

        private IController[] controllers;
        private Stack<int> controllerHistory;
        private int currentOptionIndex;
        private ForumViewEngine forumViewer;

        public MenuController(IEnumerable<IController> controllers, ForumViewEngine forumViewer)
        {
            this.controllers = controllers.ToArray();
            this.forumViewer = forumViewer;

            this.InitializeControllerHistory();

            this.currentOptionIndex = DEFAULT_INDEX;
        }

        private string Username { get; set; }
        private IView CurrentView { get; set; }

        private MenuState State => (MenuState)this.controllerHistory.Peek();
        private int CurrentControllerIndex => this.controllerHistory.Peek();
        private IController CurrentController => this.controllers[this.controllerHistory.Peek()];
        internal ILabel CurrentLabel => this.CurrentView.Buttons[this.currentOptionIndex];

        private void InitializeControllerHistory()
        {
            if (this.controllerHistory != null)
            {
                throw new InvalidOperationException($"{nameof(this.controllerHistory)} already initialized!");
            }
            int mainControllerIndex = 0;
            this.controllerHistory = new Stack<int>();
            this.controllerHistory.Push(mainControllerIndex);
            this.RenderCurrentView();
        }

        internal void PreviousOption()
        {
            this.currentOptionIndex--;

            if (this.currentOptionIndex < 0)
            {
                this.currentOptionIndex += this.CurrentView.Buttons.Length;
            }

            if (this.CurrentLabel.IsHidden)
            {
                this.PreviousOption();
            }
        }

        internal void NextOption()
        {
            this.currentOptionIndex++;

            int totalOptions = this.CurrentView.Buttons.Length;

            if (this.currentOptionIndex >= totalOptions)
            {
                this.currentOptionIndex -= totalOptions;
            }

            if (this.CurrentLabel.IsHidden)
            {
                this.NextOption();
            }
        }

        internal void Back()
        {
            if (this.State == MenuState.Categories || this.State == MenuState.OpenCategory)
            {
                IPaginationController currentController = (IPaginationController)this.CurrentController;
                currentController.CurrentPage = 0;
            }

            if (this.controllerHistory.Count > 1)
            {
                this.controllerHistory.Pop();
                this.currentOptionIndex = DEFAULT_INDEX;
            }

            this.RenderCurrentView();
        }

        internal void ExecuteCommand()
        {
            MenuState newState = this.CurrentController.ExecuteCommand(this.currentOptionIndex);
            switch (newState)
            {
                case MenuState.PostAdded:
                    this.AddPost();
                    break;

                case MenuState.OpenCategory:
                    this.OpenCategory();
                    break;

                case MenuState.ViewPost:
                    this.ViewPost();
                    break;

                case MenuState.SuccessfulLogIn:
                    this.SuccessfulLogin();
                    break;

                case MenuState.LoggedOut:
                    this.LogOut();
                    break;

                case MenuState.Back:
                    this.Back();
                    break;

                case MenuState.Error:
                case MenuState.Rerender:
                    this.RenderCurrentView();
                    break;

                case MenuState.AddReplyToPost:
                    this.RedirectToAddReply();
                    break;

                case MenuState.ReplyAdded:
                    this.AddReply();
                    break;

                default:
                    this.RedirectToMenu(newState);
                    break;
            }
        }

        private void AddReply()
        {
            throw new NotImplementedException();
        }

        private void RedirectToAddReply()
        {
            throw new NotImplementedException();
        }

        private void LogOut()
        {
            throw new NotImplementedException();
        }

        private void SuccessfulLogin()
        {
            throw new NotImplementedException();
        }

        private void ViewPost()
        {
            throw new NotImplementedException();
        }

        private void OpenCategory()
        {
            throw new NotImplementedException();
        }

        private void AddPost()
        {
            throw new NotImplementedException();
        }

        private void RenderCurrentView()
        {
            this.CurrentView = this.CurrentController.GetView(this.Username);
            this.currentOptionIndex = DEFAULT_INDEX;
            this.forumViewer.RenderView(this.CurrentView);
        }

        private bool RedirectToMenu(MenuState newState)
        {
            throw new NotImplementedException();
        }

        private void LogInUser()
        {
            throw new NotImplementedException();
        }

        private void LogOutUser()
        {
            throw new NotImplementedException();
        }
    }
}