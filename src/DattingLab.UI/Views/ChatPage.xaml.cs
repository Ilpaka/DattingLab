using System;
using System.Windows.Controls;
using DattingLab.Application.Services;
using DattingLab.Domain.Entities;

namespace DattingLab.UI.Views
{
    public partial class ChatPage : Page
    {
        private readonly ChatService _chatService;
        private readonly GirlProfile _girl;
        private readonly Guid _chatId = Guid.NewGuid();

        public ChatPage(GirlProfile girl)
        {
            _girl = girl;
            _chatService = (App.Current as App)!.Services.GetService(typeof(ChatService)) as ChatService!;
            InitializeComponent();
            LoadMessages();
            SendButton.Click += OnSend;
        }

        private async void LoadMessages()
        {
            var messages = await _chatService.GetChatAsync(_chatId);
            MessagesList.ItemsSource = messages;
        }

        private async void OnSend(object sender, System.Windows.RoutedEventArgs e)
        {
            string text = MessageBox.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Clear();
                var reply = await _chatService.SendUserMessageAsync(_chatId, text);
                MessagesList.Items.Add(reply);
            }
        }
    }
}
