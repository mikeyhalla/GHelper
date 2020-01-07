using IWshRuntimeLibrary;
using System;

namespace GHelper
{
    internal class ShortcutInfo
    {
        internal static bool ShortcutExists(string path)
        {

            try
            {
                WshShell lib = new WshShell();

                IWshShortcut _shortcut;

                _shortcut = (IWshShortcut)lib.CreateShortcut(path);

                if (System.IO.File.Exists(_shortcut.TargetPath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}