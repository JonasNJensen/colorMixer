using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace colorMixer.ViewModel
{
    public partial class colorMixerViewModel : ObservableObject
    {
        public colorMixerViewModel()
        {
            red = 0;
            green = 0;
            blue = 0;
            hexColorCode = "000000";
            regtangleColor = "#" + Red.ToString("X2") + Green.ToString("X2") + Blue.ToString("X2");
        }



        [ObservableProperty]
        private int red;



        [ObservableProperty]
        private int green;



        [ObservableProperty]
        private int blue;

        [ObservableProperty]
        private string regtangleColor;

        [ObservableProperty]
        private string hexColorCode;


        partial void OnRedChanged(int value)
        {
            CalculateHex();
        }

        partial void OnGreenChanged(int value)
        {
            CalculateHex();
        }

        partial void OnBlueChanged(int value)
        {
            CalculateHex();
        }

        
        public void CalculateHex()
        {
            HexColorCode = Red.ToString("X2") + Green.ToString("X2") + Blue.ToString("X2");
            changeRegtangleColor();
        }

        [RelayCommand(CanExecute = nameof(validHexCode))]
        public void changeRegtangleColor()
        {
            RegtangleColor = "#" + HexColorCode;
        }

        

        public bool validHexCode()
        {
            if (HexColorCode.Length != 6)
            {
                return false;
            }
            foreach (char c in HexColorCode)
            {
                bool is_hex_char = (c >= '0' && c <= '9') ||
                                   (c >= 'a' && c <= 'f') ||
                                   (c >= 'A' && c <= 'F');
                if(!is_hex_char) 
                {
                    return false;
                }
            }
            return true;
        }
    }
}
