using System.Collections.Generic;
using System.Windows.Controls;
using DattingLab.Application.Services;
using DattingLab.Domain.Entities;

namespace DattingLab.UI.Views
{
    public partial class GirlsPage : Page
    {
        private readonly GirlProfileGenerator _generator;
        private readonly MatchService _matchService;

        public GirlsPage(GirlProfileGenerator generator, MatchService matchService)
        {
            _generator = generator;
            _matchService = matchService;
            InitializeComponent();
            LoadGirls();
        }

        private async void LoadGirls()
        {
            IEnumerable<GirlProfile> girls = await _generator.GetRandomGirlsAsync(5);
            GirlsList.ItemsSource = girls;
        }

        private async void OnLike(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;
            var profile = button?.Tag as GirlProfile;
            if (profile != null)
            {
                await _generator.LikeAsync(profile);
                bool matched = await _matchService.TryMatchAsync(profile);
                if (matched)
                {
                    NavigationService?.Navigate(new ChatPage(profile));
                }
            }
        }

        private async void OnDislike(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;
            var profile = button?.Tag as GirlProfile;
            if (profile != null)
            {
                await _generator.DislikeAsync(profile);
            }
        }
    }
}
