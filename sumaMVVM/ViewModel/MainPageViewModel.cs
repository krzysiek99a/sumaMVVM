using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sumaMVVM.ViewModel
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _a;
        string _b;
        string _dzialanie;
        string _wynik;
        public ICommand Suma {  get; set; }

        public MainPageViewModel()
        {
            A = "0";
            B = "0";
            Suma = new Command(() => { ObliczSume(); });
        }

        public string A { get => _a;
            set { _a = value;
                Wynik = $"{A} + {B}";
                OnPropertyChenged(nameof(A));
            }
        }

        public string B { get => _b;
            set { _b = value;
                Wynik = $"{A} + {B}";
                OnPropertyChenged(nameof(B));
            } }

        public string Dzialanie { get => _dzialanie;
            set { _dzialanie = value;
                OnPropertyChenged(nameof(Dzialanie));
            } }
        public string Wynik { get => _wynik;
            set { _wynik = value;
                OnPropertyChenged(nameof(Wynik));
            }
        }

        void ObliczSume()
        {
            int temp = int.Parse(A) + int.Parse(B);
            Dzialanie= temp.ToString();
        }

        protected void OnPropertyChenged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
