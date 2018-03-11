using System;
using System.Linq;
using Forum.App.Controllers.Contracts;
using Forum.App.Services;
using Forum.App.UserInterface;
using Forum.App.UserInterface.Contracts;
using Forum.App.UserInterface.Input;
using Forum.App.UserInterface.ViewModels;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;

        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        private TextArea TextArea { get; set; }
        public ReplyViewModel Reply { get; private set; }
        private PostViewModel postView;

        public bool Error { get; private set; }

        public AddReplyController()
        {
            this.ResetReply();
        }

        private enum Command
        {
            Write, Post, Back
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Write:
                    this.TextArea.Write();
                    this.Reply.Content = this.TextArea.Lines.ToArray();
                    return MenuState.AddReply;

                case Command.Post:
                    bool validReply = PostService.TrySaveReply(this.Reply, this.postView.PostId);
                    if (!validReply)
                    {
                        this.Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.ReplyAdded;
                case Command.Back:
                    return MenuState.Back;
            }

            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            this.Reply.Author = userName;
            return new AddReplyView(this.postView, this.Reply, this.TextArea, this.Error);
        }

        public void ResetReply()
        {
            this.Error = false;
            this.Reply = new ReplyViewModel();
            int contentLen = this.postView?.Content.Count ?? 0;
            this.TextArea = new TextArea(centerLeft - 18, centerTop + contentLen - 6, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }

        public void SetPostId(int postId)
        {
            this.postView = PostService.GetPostViewModel(postId);
            this.ResetReply();
        }
    }
}