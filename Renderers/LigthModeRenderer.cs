// TextEditor

using TextEditor.ColorTables;
using CommonLibrary.Attributes;

namespace TextEditor.Renderers
{
    /// <summary>
    ///  Renders the menu bar and the menus for the ligth mode.
    /// </summary>
    [Usage("Used by the menu bar as renderer for the classic ligth theme")]
    internal class LigthModeRenderer : ToolStripProfessionalRenderer
    {
        // Creates new renderer for the menu bar and the menus.
        public LigthModeRenderer() : base(new LigthModeColorTable()) { }
    }
}
