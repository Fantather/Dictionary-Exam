namespace Dictionary_Exam
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Позволяем WinForms передавать необработанные исключения в ThreadException
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Перехват исключений из UI-потока (обработчики событий, диалоги и т.д.)
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show($"Произошла ошибка: {e.Exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            ApplicationConfiguration.Initialize();
            Application.Run(new Menu());
        }
    }
}