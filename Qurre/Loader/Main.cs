using Loader.Features;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Loader
{
    /// <summary>
    /// Entry point
    /// </summary>
    public class Main
    {
        private static Type[] GetClasses(string nameSpace)
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(
                type => type.Namespace == nameSpace).ToArray();
        }

        /// <summary>
        /// Entry point itself
        /// </summary>
        public void Start()
        {
            try
            {
                //todo: make a normal loader
#if DEBUG
                Log.Info("[DEBUG] Loading...");
#else
                Log.Info("Loading...");
#endif

                var appdataFolderRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\QurreV2\\";

                if (!Directory.Exists(appdataFolderRoot + "dependencies\\"))
                {
                    Directory.CreateDirectory(appdataFolderRoot + "dependencies\\");
                    Log.Info("Created dependencies folder", ConsoleColor.Yellow);
                }

                Log.Info("Loading dependencies...", ConsoleColor.Yellow);

                foreach (var file in Directory.GetFiles(appdataFolderRoot + "dependencies\\"))
                {
                    if (file.EndsWith(".dll") || file.EndsWith(".dll\\"))
                    {
                        Log.Info($"Loading dependency {file.Remove(0, file.LastIndexOf("\\") + 1)}", ConsoleColor.Magenta);
                        Assembly.LoadFile(file);
                    }
                }

                Log.Info("Loaded dependencies...", ConsoleColor.DarkGreen);

                Log.Info("Loading patches...");
                foreach (var patchCandidate in GetClasses("Loader.Patches"))
                {
                    if (patchCandidate.GetInterface("IPatch") == typeof(Interfaces.IPatch))
                    {
                        Log.Debug($"[SETUP] Setting up patcher {patchCandidate.Name}");
                        //candidate is a patch
                        var obj = Activator.CreateInstance(patchCandidate);
                        patchCandidate.GetMethod("Start").Invoke(obj, null);
                        Log.Debug($"[SETUP] Setted up patcher {patchCandidate.Name}");
                    }
                }
                Log.Info("Patches loaded!", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                Log.ErrorFatal($"Umm, loading failed. Exception: {ex}");
            }
        }
    }
}
