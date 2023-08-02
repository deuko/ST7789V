using System.Device.Spi;

namespace ST7789V
{
    public class Display
    {
        private int _width;
        private int _height;
        private bool _isInitialized;
        private ColorMode _colorMode;
        private SpiDevice _device;

        public Display(int width = 240, int height = 320)
        {
            _width = width;
            _height = height;
            _isInitialized = false;
        }

        public void Initialize(ColorMode color = ColorMode.Mode565, RotationMode rotation = RotationMode.Rot0, bool mirrored = false, bool invertedColors = true, bool reset = true)
        {
            _device = SpiDevice.Create(new SpiConnectionSettings(0));

            _colorMode = color;

            SetColorMode(_colorMode);

            _isInitialized = true;
        }

        public void TurnOn()
        {
            SendCommand(Command.SLPOUT);
            SendCommand(Command.DISPON);
        }

        public void TurnOff()
        {
            SendCommand(Command.DISPOFF);
            SendCommand(Command.SLPIN);
        }

        private void SendCommand(Command command)
        {
            var commandBytes = Convert.ToByte(command.ID, 16);
            _device.WriteByte(commandBytes);
        }

        public void SendCommand(Command command, int data)
        {
            var commandBytes = Convert.ToByte(command.ID, 16);
            var dataBytes = Convert.ToByte(data);

            _device.WriteByte(commandBytes);
            _device.WriteByte(dataBytes);
            var x = 2;
        }

        private void SetColorMode(ColorMode colorMode)
        {
            int commandBytes = 0;
            switch (colorMode)
            {
                case ColorMode.Mode444:
                commandBytes = Convert.ToByte("0x03", 16);
                break;
                case ColorMode.Mode565:
                commandBytes = Convert.ToByte("0x05", 16);
                break;
                case ColorMode.Mode666:
                commandBytes = Convert.ToByte("0x06", 16);
                break;
            }

            SendCommand(Command.COLMOD, commandBytes);
        }

        private void WriteRgb((byte, byte, byte)[] rgb)
        {
            var commandBytes = Convert.ToByte(Command.RAMWR.ID, 16);
            var bytes = new byte[rgb.Length*3];

            for (int i = 0; i < rgb.Length; i++)
            {
                bytes[i] = rgb[i].Item1;
                bytes[i+1] = rgb[i].Item2;
                bytes[i+2] = rgb[i].Item3;
            }

            // https://github.com/dotnet/iot/issues/997
            var dataBytes = new Span<byte>(bytes);

            _device.WriteByte(commandBytes);
            _device.Write(dataBytes);
        }

        public void SetRedScreen()
        {
            var rgb = new (byte, byte, byte)[320*240];
            for (int i = 0; i < rgb.Length; i++)
            {
                rgb[i] = (30, 0, 0);
            }

            WriteRgb(rgb);
        }

        public void SendRawCommand()
        {

        }
    }
}