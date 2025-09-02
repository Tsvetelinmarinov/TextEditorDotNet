// Text editor

using TextEditor.ColorTables;
using CommonLibrary.Attributes;

namespace TextEditor.Renderers
{
    /// <summary>
    ///  Renderer for the dark mode. Renders menus background.
    /// </summary>
    [Usage("Used by the menu bar as renderer for the dark mode")]
    internal class DarkModeRenderer : ToolStripProfessionalRenderer
    {
        /// <summary>
        ///  Creates new renderer for the menu bar.
        ///  Used by the dark theme.
        /// </summary>
        public DarkModeRenderer() : base(new DarkModeColorTable()) { }
    }
}
