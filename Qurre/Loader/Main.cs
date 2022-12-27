using Loader.Features;
using System;

namespace Loader
{
    /// <summary>
    /// Entry point
    /// </summary>
    public class Main
    {
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
            }
            catch (Exception ex)
            {
                Log.ErrorFatal($"Umm, loading failed. Exception: {ex}");
            }
        }
    }
}
