using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuranTafseerWPFDemo
{
    public partial class MainWindow : Window
    {
        QuranTafseer.Client client = new QuranTafseer.Client();
        int _CurrentTafsserId;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comTafseer.ItemsSource = await client.GetAvailableTafseersListAsync();
            comTafseer.SelectedIndex = 0;
            lbSuraList.ItemsSource = await client.GetSuraListAsync();
        }

        private async void lbSuraList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbSuraList.SelectedItem == null) return;

            int SuraNumbr = (lbSuraList.SelectedItem as QuranTafseer.Sura).Index;
            List<QuranTafseer.Verse> verses = new List<QuranTafseer.Verse>();


            int i = 0;
            try //TODO: Use QuranAsyncReader class insted
            {
                while (true)
                {
                    i++;
                    QuranTafseer.Verse v = await client.GetVerseDetails(SuraNumbr, i);
                    verses.Add(v);
                }
            }
            catch { }

            lbAyahList.ItemsSource = verses;
        }

        private void comTafseer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comTafseer.SelectedItem == null) return;

            _CurrentTafsserId = (comTafseer.SelectedItem as QuranTafseer.Tafseer).Id;

            if (tbTafseer.Text.Trim() != "") this.lbAyahList_SelectionChanged(null, null);
        }

        private async void lbAyahList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbAyahList.SelectedItem == null) return;

            tbTafseer.Text = (await client.GetVerseTafseerAsync(_CurrentTafsserId, (lbSuraList.SelectedItem as QuranTafseer.Sura).Index, (lbAyahList.SelectedItem as QuranTafseer.Verse).AyahNumber)).Text;
        }
    }
}
