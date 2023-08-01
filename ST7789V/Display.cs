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

        public void SendCommand(Command command)
        {
            var commandId = Convert.ToByte(command.ID, 16);
            _device.WriteByte(commandId);
            var x = 2;
        }

        public void SendRawCommand()
        {

        }
    }
}