namespace Linkly
{
    internal static class Program
    {
        /// <summary>
        /// A unique naming (using a GUID) to guarantee uniqueness across all applications on the machine.
        /// </summary>
        private const string MutexName = "Linkly-{8F3B2A1C-4D5E-4F6A-9B7C-1D2E3F4A5B6C}";

        /// <summary>
        /// A Private static Mutex object to control access to the application instance.
        /// </summary>
        private static Mutex _mutex;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;

            // Attempt to create the mutex. 'createdNew' will be true only if
            // this process is the first to create it - false means another
            // instance already owns it.
            _mutex = new Mutex(true, MutexName, out createdNew);

            if (!createdNew)
            {
                // Another instance is already running - exit immediately.
                MessageBox.Show("Linkly is already running!",
                                "Linkly",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return; // Exits Main() before any forms are created.
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ApplicationConfiguration.Initialize();
                Application.Run(new LinklyMainForm());
            }
            finally
            {
                // Release the mutex when the app closes normally.
                _mutex.ReleaseMutex();
                _mutex.Dispose();
            }
        }
    }
}