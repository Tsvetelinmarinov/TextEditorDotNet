// TextEditor

using CommonLibrary.Attributes;

namespace TextEditor
{
    /// <summary>
    ///  The entry point of the application.
    /// </summary>
    [Author("Tsvetelin Marinov")]
    [Usage("Simple text editor for every-day usage")]
    internal class Starter
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EditorUI());
        }
    }
}
