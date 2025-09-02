// TextEditor

namespace TextEditor.ColorTables
{
    /// <summary>
    ///  Provides colors for the menu bar and the menus for the dark theme.
    /// </summary>
    internal class DarkModeColorTable : ProfessionalColorTable
    {
        // The background of the menu item when it is selected (hovered).
        public override Color MenuItemSelected => Color.FromArgb(36, 36, 36);


        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(60, 60, 60);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(60, 60, 60);
        public override Color MenuItemBorder => Color.FromArgb(80, 80, 80);

        public override Color ToolStripDropDownBackground => Color.FromArgb(40, 40, 40);
        public override Color ImageMarginGradientBegin => Color.FromArgb(40, 40, 40);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(40, 40, 40);
        public override Color ImageMarginGradientEnd => Color.FromArgb(40, 40, 40);

        public override Color MenuBorder => Color.FromArgb(80, 80, 80);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(70, 70, 70);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(70, 70, 70);
    }
}