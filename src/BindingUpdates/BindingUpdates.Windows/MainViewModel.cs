using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Prism.StoreApps;

namespace BindingUpdates
{
    internal class MainViewModel : BindableBase
    {
        private int _counter = 0;

        public MainViewModel()
        {
            Text1 = "Text 1";
            Text2 = "Text 2";
            Text3 = "Text 3";

            TextChangedCommand = new RelayCommand<TextChangedEventArgs>(OnTextChanged);
        }

        private string _text1;
        public string Text1
        {
            get { return _text1; }
            set
            {
                SetProperty(ref _text1, value);
                Log("Text 1 updated: " + value);
            }
        }
        private string _text2;
        public string Text2
        {
            get { return _text2; }
            set
            {
                SetProperty(ref _text2, value);
                Log("Text 2 updated: " + value);
            }
        }
        private string _text3;
        public string Text3
        {
            get { return _text3; }
            set
            {
                SetProperty(ref _text3, value);
                Log("Text 3 updated: " + value);
            }
        }

        public RelayCommand<TextChangedEventArgs> TextChangedCommand { get; private set; }

        private void Log(string txt)
        {
            Debug.WriteLine(txt);
        }

        private void OnTextChanged(TextChangedEventArgs args)
        {
            _counter++;
            if (_counter == 3)
            {
                Text1 = "Reset text"; // only works once while editing
                _counter = 0;
            }
        }
    }
}
