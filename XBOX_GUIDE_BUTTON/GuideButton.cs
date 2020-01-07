using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace GuideButton
{
    [CLSCompliant(false)]
    public class XboxGuideButton
    {
        [DllImport("xinput1_3.dll", EntryPoint = "#100", CharSet = CharSet.Unicode)]
        static extern int gamepadGuide(int playerIndex, out XINPUT_Guide struc);

        public struct XINPUT_Guide
        {
            public uint eventCount;
            public ushort wButtons;
            public byte bLeftTrigger;
            public byte bRightTrigger;
            public short sThumbLX;
            public short sThumbLY;
            public short sThumbRX;
            public short sThumbRY;
        }
        public static int guide(int playerIndex, out XINPUT_Guide struc)
        {
            return gamepadGuide(playerIndex, out struc);
        }

        public static bool GuideButton = false;
        private static XINPUT_Guide xgs;

        static void GuideButtonPress()
        {
            while (true)
            {
                Thread.Sleep(500);
                int stat;
                bool value;
                for (int i = 0; i < 4; i++)
                {
                    stat = guide(0, out xgs);
                    if (stat != 0)
                    {
                        continue;
                    }
                    value = ((xgs.wButtons & 0x0400) != 0);
                    if (value)
                    {
                        try
                        {
                            Thread.Sleep(1000);
                            int stat2;
                            bool value2;
                            for (int i2 = 0; i2 < 4; i2++)
                            {
                                stat2 = guide(0, out xgs);
                                if (stat2 != 0)
                                {
                                    continue;
                                }
                                value2 = ((xgs.wButtons & 0x0400) != 0);
                                if (value2)
                                {
                                    if (!GuideButton)
                                    {
                                        GuideButton = true;

                                        // Need XNA Framework
                                        SetVibration(PlayerIndex.One, 0.2f, 0.2f);
                                        Thread.Sleep(300);
                                        SetVibration(PlayerIndex.One, 0f, 0f);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
    }
}