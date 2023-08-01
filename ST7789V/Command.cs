namespace ST7789V
{
    public class Command
    {
        public string ID { get; private set; }
        public string Name { get; private set; }
        public int WRX { get; private set; }
        public int RDX { get; private set; }
        public string Desc { get; private set; }

        private Command(string iD, string name, int wRX, int rDX, string desc)
        {
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            WRX = wRX;
            RDX = rDX;
            Desc = desc ?? throw new ArgumentNullException(nameof(desc));
        }

        public static Command SWRESET => new Command("0x01", "SWRESET", 0, 0, "Software Reset");
        public static Command RDDID => new Command("0x04", "RDDID", 0, 4, "Read Display ID");
        public static Command RDDST => new Command("0x05", "RDDST", 0, 5, "Read Display Status");
        public static Command RDDPM => new Command("0x0A", "RDDPM", 0, 2, "Read Display Power Mode");
        public static Command RDDMADCTL => new Command("0x0B", "RDDMADCTL", 0, 2, "Read Display MADCTL");
        public static Command RDDCOLMOD => new Command("0x0C", "RDDCOLMOD", 0, 2, "Read Display Pixel Format");
        public static Command RDDIM => new Command("0x0D", "RDDIM", 0, 2, "Read Display Image Mode");
        public static Command RDDSM => new Command("0x0E", "RDDSM", 0, 2, "Read Display Signal Mode");
        public static Command RDDSDR => new Command("0x0F", "RDDSDR", 0, 2, "Read Display Self-Diagnostic Result");
        public static Command SLPIN => new Command("0x10", "SLPIN", 0, 0, "Sleep in"); // Default
        public static Command SLPOUT => new Command("0x11", "SLPOUT", 0, 0, "Sleep out");
        public static Command PTLON => new Command("0x12", "PTLON", 0, 0, "Partial Display Mode On");  // See 30h
        public static Command NORON => new Command("0x13", "NORON", 0, 0, "Normal Display Mode On");  // Default
        public static Command INVOFF => new Command("0x20", "INVOFF", 0, 0, "Display Inversion Off");  // Default
        public static Command INVON => new Command("0x21", "INVON", 0, 0, "Display Inversion On");
        public static Command GAMSET => new Command("0x26", "GAMSET", 1, 0, "Gamma Set");
        public static Command DISPOFF => new Command("0x28", "DISPOFF", 0, 0, "Display Off");  // Default
        public static Command DISPON => new Command("0x29", "DISPON", 0, 0, "Display On");
        public static Command CASET => new Command("0x2A", "CASET", 4, 0, "Column Address Set");  // uint16 * 2
        public static Command RASET => new Command("0x2B", "RASET", 4, 0, "Row Address Set");  // uint16 * 2
        public static Command RAMWR => new Command("0x2C", "RAMWR", -1, 0, "Memory Write");  // Not cleared on SW/HW reset, resets col/row
        public static Command RAWRD => new Command("0x2E", "RAWRD", 0, -1, "Memory Read");  // Resets col/row registers, fixed 18-bit
        public static Command PTLAR => new Command("0x30", "PTLAR", 4, 0, "Partial Area");  // uint16 * 2
        public static Command VSCRDEF => new Command("0x33", "VSCRDEF", 6, 0, "Vertical Scrolling Definition");  // uint16 * 3
        public static Command TEOFF => new Command("0x34", "TEOFF", 0, 0, "Tearing Effect Line OFF");  // Default
        public static Command TEON => new Command("0x35", "TEON", 1, 0, "Tearing Effect Line On");
        public static Command MADCTL => new Command("0x36", "MADCTL", 1, 0, "Memory Data Access Control");
        public static Command VSCSAD => new Command("0x37", "VSCSAD", 2, 0, "Vertical Scroll Start Address of RAM");
        public static Command IDMOFF => new Command("0x38", "IDMOFF", 0, 0, "Idle Mode OFF");  // Default
        public static Command IDMON => new Command("0x39", "IDMON", 0, 0, "Idle Mode ON");  // Reduced to 8 colors (RGB-111)
        public static Command COLMOD => new Command("0x3A", "COLMOD", 1, 0, "Interface Pixel Format");  // Default 66h (RGB-666)
        public static Command WRMEMC => new Command("0x3C", "WRMEMC", -1, 0, "Write Memory Continue");  // After 2Ch
        public static Command RDMEMC => new Command("0x3E", "RDMEMC", 0, -1, "Read Memory Continue");  // After 2Eh
        public static Command STE => new Command("0x44", "STE", 2, 0, "Set Tear Scanline");
        public static Command GSCAN => new Command("0x45", "GSCAN", 0, 3, "Get Scanline");
        public static Command WRDISBV => new Command("0x51", "WRDISBV", 1, 0, "Write Display Brightness");
        public static Command RDDISBV => new Command("0x52", "RDDISBV", 0, 2, "Read Display Brightness Value");
        public static Command WRCTRLD => new Command("0x53", "WRCTRLD", 1, 0, "Write CTRL Display");
        public static Command RDCTRLD => new Command("0x54", "RDCTRLD", 0, 2, "Read CTRL Value Display");
        public static Command WRCACE => new Command("0x55", "WRCACE", 1, 0, "Write Content Adaptive Brightness Control and Color Enhancement");
        public static Command RDCABC => new Command("0x56", "RDCABC", 0, 2, "Read Content Adaptive Brightness Control");
        public static Command WRCACBCMB => new Command("0x5E", "WRCACBCMB", 1, 0, "Write CABC Minimum Brightness");
        public static Command RDCABCMB => new Command("0x5F", "RDCABCMB", 0, 2, "Read CABC Minimum Brightness");
        public static Command RDABCSDR => new Command("0x68", "RDABCSDR", 0, 2, "Read Automatic Brightness Control Self-Diagnotstic Result");
        public static Command RDID1 => new Command("0xDA", "RDID1", 0, 2, "Read ID1");
        public static Command RDID2 => new Command("0xDB", "RDID2", 0, 2, "Read ID2");
        public static Command RDID3 => new Command("0xDC", "RDID3", 0, 2, "Read ID3");
    }
}
