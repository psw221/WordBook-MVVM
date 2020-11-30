using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordBook.Classes;

namespace WordBook.ViewModel
{
    public class WordViewModel : Notifier
    {
        public MyICommand MyCommand { get; set; }

        public WordViewModel()
        {
            MyCommand = new MyICommand(OnAddList);
        }

        private string wordString;
        public string WordString
        {
            get { return wordString; }
            set
            {
                wordString = value;
                OnPropertyChanged("WordString");
            }
        }

        private string selectedWord;
        public string SelectedWord
        {
            get { return selectedWord; }
            set
            {
                selectedWord = value;
                OnPropertyChanged("SelectedWord");
            }
        }

        ObservableCollection<string> wordList;

        public ObservableCollection<string> WordList
        {
            get
            {
                if (wordList == null)
                    wordList = new ObservableCollection<string>();

                return wordList;
            }
            set
            {
                wordList = value;
            }
        }

        private void OnAddList()
        {
            if(!string.IsNullOrEmpty(WordString) && !WordList.Contains(WordString)) 
                WordList.Add(WordString);
        }

        private bool CanAddList()
        {
            return SelectedWord != null;
        }
    }
}
