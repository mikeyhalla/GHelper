using GHelper;
using System;
using System.IO;
using System.Reflection;
using System.Security.Permissions;

public class GameWatcher
{
    internal static FileSystemWatcher watcher;
    internal static FileSystemWatcher watcher2;
    internal static FileSystemWatcher watcher3;
    static readonly string AssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public static void Watch()
    {
        var USMWPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + "\\Games";
        var AUSMWPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms) + "\\Games";
        var NotesPath = AssemblyDirectory + "\\Notes";

        if (Directory.Exists(USMWPath))
        {
            watcher = new FileSystemWatcher();

            watcher.Path = USMWPath;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = "*.*";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }
        if (Directory.Exists(AUSMWPath))
        {
            watcher2 = new FileSystemWatcher();

            watcher2.Path = AUSMWPath;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher2.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher2.Filter = "*.*";

            // Add event handlers.
            watcher2.Changed += new FileSystemEventHandler(OnChanged);
            watcher2.Created += new FileSystemEventHandler(OnChanged);
            watcher2.Deleted += new FileSystemEventHandler(OnChanged);
            watcher2.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher2.EnableRaisingEvents = true;
        }
        if (Directory.Exists(AUSMWPath))
        {
            watcher3 = new FileSystemWatcher();

            watcher3.Path = NotesPath;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher3.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher3.Filter = "*.*";

            // Add event handlers.
            watcher3.Changed += new FileSystemEventHandler(OnChanged);
            watcher3.Created += new FileSystemEventHandler(OnChanged);
            watcher3.Deleted += new FileSystemEventHandler(OnChanged);
            watcher3.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher3.EnableRaisingEvents = true;
        }
    }

    // Define the event handlers.
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        if (File.Exists(e.FullPath))
        {
            if (!File.GetAttributes(e.FullPath).HasFlag(FileAttributes.Hidden) && !File.GetAttributes(e.FullPath).HasFlag(FileAttributes.System))
            {
                GHelperForm.RestartMenuItem_Click(null, null);
            }
        }
        else if (!File.Exists(e.FullPath))
        {
            GHelperForm.RestartMenuItem_Click(null, null);
        }
    }

    private static void OnRenamed(object source, RenamedEventArgs e)
    {
        GHelperForm.RestartMenuItem_Click(null, null);
    }
}
