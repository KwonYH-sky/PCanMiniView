using Peak.Can.Basic;
using System.Reflection;

namespace PCanMiniView
{
    internal static class UtilityHelpers
    {

        public static bool IsBlank(string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static Bitrate ToBitrate(int baudRate)
        {
            switch (baudRate)
            {
                case 0:
                    return Bitrate.Pcan1000;
                case 1:
                    return Bitrate.Pcan800;
                case 2:
                    return Bitrate.Pcan500;
                case 3:
                    return Bitrate.Pcan250;
                case 4:
                    return Bitrate.Pcan125;
                case 5:
                    return Bitrate.Pcan47;
                case 6:
                    return Bitrate.Pcan100;
                case 7:
                    return Bitrate.Pcan50;
                case 8:
                    return Bitrate.Pcan20;
                case 9:
                    return Bitrate.Pcan10;
                case 10:
                    return Bitrate.Pcan5;
                case 11:
                    return Bitrate.Pcan83;
                case 12:
                    return Bitrate.Pcan33;
                case 13:
                    return Bitrate.Pcan95;
                default:
                    throw new ArgumentOutOfRangeException(nameof(baudRate));
            }
        }

        public static PcanChannel ToPcanChannel(int channel)
        {
            switch (channel)
            {
                case 0:
                    return PcanChannel.None;
                case 1:
                    return PcanChannel.Pci01;
                case 2:
                    return PcanChannel.Pci02;
                case 3:
                    return PcanChannel.Pci03;
                case 4:
                    return PcanChannel.Pci04;
                case 5:
                    return PcanChannel.Pci05;
                case 6:
                    return PcanChannel.Pci06;
                case 7:
                    return PcanChannel.Pci07;
                case 8:
                    return PcanChannel.Pci08;
                case 9:
                    return PcanChannel.Pci09;
                case 10:
                    return PcanChannel.Pci10;
                case 11:
                    return PcanChannel.Pci11;
                case 12:
                    return PcanChannel.Pci12;
                case 13:
                    return PcanChannel.Pci13;
                case 14:
                    return PcanChannel.Pci14;
                case 15:
                    return PcanChannel.Pci15;
                case 16:
                    return PcanChannel.Pci16;
                case 17:
                    return PcanChannel.Usb01;
                case 18:
                    return PcanChannel.Usb02;
                case 19:
                    return PcanChannel.Usb03;
                case 20:
                    return PcanChannel.Usb04;
                case 21:
                    return PcanChannel.Usb05;
                case 22:
                    return PcanChannel.Usb06;
                case 23:
                    return PcanChannel.Usb07;
                case 24:
                    return PcanChannel.Usb08;
                case 25:
                    return PcanChannel.Usb09;
                case 26:
                    return PcanChannel.Usb10;
                case 27:
                    return PcanChannel.Usb11;
                case 28:
                    return PcanChannel.Usb12;
                case 29:
                    return PcanChannel.Usb13;
                case 30:
                    return PcanChannel.Usb14;
                case 31:
                    return PcanChannel.Usb15;
                case 32:
                    return PcanChannel.Usb16;
                case 33:
                    return PcanChannel.Lan01;
                case 34:
                    return PcanChannel.Lan02;
                case 35:
                    return PcanChannel.Lan03;
                case 36:
                    return PcanChannel.Lan04;
                case 37:
                    return PcanChannel.Lan05;
                case 38:
                    return PcanChannel.Lan06;
                case 39:
                    return PcanChannel.Lan07;
                case 40:
                    return PcanChannel.Lan08;
                case 41:
                    return PcanChannel.Lan09;
                case 42:
                    return PcanChannel.Lan10;
                case 43:
                    return PcanChannel.Lan11;
                case 44:
                    return PcanChannel.Lan12;
                case 45:
                    return PcanChannel.Lan13;
                case 46:
                    return PcanChannel.Lan14;
                case 47:
                    return PcanChannel.Lan15;
                case 48:
                    return PcanChannel.Lan16;
                default:
                    return PcanChannel.None;
            }

        }
    }
}