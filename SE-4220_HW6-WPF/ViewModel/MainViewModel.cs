using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace HW6.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public BindingList<BitmapImage> Gallery { get; set; }

        public MainViewModel()
        {

            Gallery = new BindingList<BitmapImage>(new[]
            {
                new BitmapImage(new Uri("pack://application:,,,/Images/adventure-calm.jpg")),
                new BitmapImage(new Uri("pack://application:,,,/Images/arch-bridge-clouds.jpg")),
                new BitmapImage(new Uri("pack://application:,,,/Images/beautiful-blur-bright.jpg")),
                new BitmapImage(new Uri("pack://application:,,,/Images/cascade-clouds.jpg")),
                new BitmapImage(new Uri("pack://application:,,,/Images/clouds-cloudy-countryside.jpg")),
                new BitmapImage(new Uri("pack://application:,,,/Images/clouds-country-countryside.jpg")),
                new BitmapImage(new Uri("pack://application:,,,/Images/dawn-dusk-hd-wallpaper.jpg"))
            });
        }

        private string calDate;
        public string CalDate
        {
            set { calDate = value;  }
            get { return calDate;  }
        }

        public string MaxCount
        {
            get { return (Gallery.Count - 1).ToString(); }
        }

        private int imgIndex = 0;
        public int ImgIndex
        {
            get { return imgIndex; }
            set {
                imgIndex = value;
                Console.Out.WriteLine("Image index value: " + ImgIndex);
                OnPropertyChanged(nameof(ImgIndex));
                OnPropertyChanged(nameof(Image));
            }
        }

        public BitmapImage Image
        {
            get { return Gallery.ElementAtOrDefault(ImgIndex); }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

    }
}
