// TextEditor

using TextEditor.Functionality;

namespace TextEditor.UserInterface
{
    /// <summary>
    /// The Graphical User Interface of the application.
    /// </summary>
    internal class EditorUI : Form
    {
        // Тhe text box
        private TextBox? _textBox;

        // The menu bar
        private MenuStrip? _menuBar;

        // File Menu
        private ToolStripMenuItem? _fileMenu;

        // Options Menu
        private ToolStripMenuItem? _optionsMenu;

        // About Menu
        private ToolStripMenuItem? _aboutMenu;

        // New File Menu
        private ToolStripMenuItem? _newFile;

        // New Window Menu
        private ToolStripMenuItem? _newWind;

        // Open Menu
        private ToolStripMenuItem? _open;

        // Save Menu
        private ToolStripMenuItem? _save;

        // Restart Menu
        private ToolStripMenuItem? _restart;

        // Exit Menu
        private ToolStripMenuItem? _exit;

        // Font and color Menu
        private ToolStripMenuItem? _fontAndColor;

        // Appearance Menu
        private ToolStripMenuItem? _appearance;

        // Theme menu
        private ToolStripMenuItem? _themes;

        // The classic theme Menu
        private ToolStripMenuItem? _classicTheme;

        // The dark theme Menu
        private ToolStripMenuItem? _darkTheme;

        // Manual Configuration Menu
        private ToolStripMenuItem? _manualConfig;

        // Help menu
        private ToolStripMenuItem? _contact;

        // Facebook Menu
        private ToolStripMenuItem? _fb;

        // GitHub Menu
        private ToolStripMenuItem? _git;



        // Creates new editor.
        internal EditorUI()
        {
            Text = "TextEditor";
            Size = new(1400, 800);
            Icon = Properties.Resources.appIcon;
            BackColor = ProfessionalColors.SeparatorLight;
            StartPosition = FormStartPosition.CenterScreen;
            Visible = true;
            MaximizeBox = true;
            MinimumSize = Size;
            MaximumSize = new(1920, 1080);

            CreateEditor();
            CreateMenu();
        }


        // Creates the text area of the editor
        private void CreateEditor()
        {
            _textBox = new()
            {
                Size = new(1383, 711),
                Location = new(0, 50),
                Multiline = true,
                Font = new("Cascadia Code", 14),
                BackColor = Color.GhostWhite,
                ScrollBars = ScrollBars.Both,
                BorderStyle = BorderStyle.None,
                WordWrap = false,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };

            Controls.Add(_textBox);
        }

        // Creates the menu bar and the menus with theirs sub menus
        private void CreateMenu()
        {
            _menuBar = new()
            {
                Size = new(1400, 35),
                Location = new(0, 0),
                BackColor = Color.FromArgb(100, 240, 220, 230),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };

            #region File Menu

            _fileMenu = new()
            {
                Text = "File",
                Font = new("Verdana", 11)
            };
            _menuBar.Items.Add(_fileMenu);

            _newFile = new()
            {
                Text = "New File",
                Font = new("Verdana", 10),
                Image = Properties.Resources.newFile,
            };
            _newFile.Click += (sender, eventArgs) => Core.CreateNewFile(_textBox!);
            _fileMenu.DropDownItems.Add(_newFile);

            _newWind = new()
            {
                Text = "New Window",
                Font = _newFile.Font,
                Image = Properties.Resources.newWindow,
            };
            _newWind.Click += (sender, eventArgs) => Core.CreateNewWind(_textBox!);
            _fileMenu.DropDownItems.Add(_newWind);

            _open = new()
            { 
                Text = "Open",
                Font = _newFile.Font,
                Image = Properties.Resources.open,
            };
            _open.Click += (sender, eventArgs) => Core.OpenExtern(_textBox!);
            _fileMenu.DropDownItems.Add(_open);

            _save = new()
            {
                Text = "Save",
                Font = _newFile.Font,
                Image = Properties.Resources.save,
            };
            _save.Click += (sender, eventArgs) => Core.ExportDataToLocalFile(_textBox!);
            _fileMenu.DropDownItems.Add(_save);

            _restart = new()
            {
                Text = "Restart",
                Font = _newFile.Font,
                Image = Properties.Resources.restart,
            };
            _restart.Click += (sender, eventArgs) => Core.Reboot(_textBox!);
            _fileMenu.DropDownItems.Add(_restart);

            _exit = new()
            {
                Text = "Exit",
                Font = _newFile.Font,
                Image = Properties.Resources.exit
            };
            _exit.Click += (sender, eventArgs) => Core.Terminate(_textBox!);
            _fileMenu.DropDownItems.Add(_exit);

            #endregion

            #region Options Menu

            _optionsMenu = new()
            {
                Text = "Options",
                Font = _fileMenu.Font
            };
            _menuBar.Items.Add(_optionsMenu);

            _fontAndColor = new()
            {
                Text = "Font and color",
                Font = _newFile.Font,
                Image = Properties.Resources.fontAndColor
            };
            _fontAndColor.Click += (sender, eventArgs) => Core.OpenFontProperties(_textBox!);
            _optionsMenu.DropDownItems.Add(_fontAndColor);

            _appearance = new()
            {
                Text = "Appearance",
                Font = _newFile.Font,
                Image = Properties.Resources.appearance
            };
            _optionsMenu.DropDownItems.Add(_appearance);

            _themes = new()
            {
                Text = "theme",
                Font = _newFile.Font,
                Image = Properties.Resources.themes
            };
            _appearance.DropDownItems.Add(_themes);

            _classicTheme = new()
            {
                Text = "classic",
                Font = _newFile.Font
            };
            _classicTheme.Click += (sender, eventArgs) => Core.SetLightTheme(
                this, 
                _menuBar, 
                _textBox!,
#pragma warning disable IDE0300
                new ToolStripMenuItem[]
                {
                    _fileMenu, _optionsMenu, _aboutMenu!,
                    _newFile, _newWind, _open,
                    _save, _restart, _exit,
                    _fontAndColor, _appearance,
                    _themes, _manualConfig!,
                    _classicTheme, _darkTheme!,
                    _contact!, _fb!, _git!
                }
#pragma warning restore IDE0300
            );
            _themes.DropDownItems.Add(_classicTheme);

            _darkTheme = new()
            {
                Text = "dark",
                Font = _newFile.Font
            };
            _darkTheme.Click += (sender, eventArgs) => Core.SetDarkTheme(
                this, 
                _menuBar,
                _textBox!,
#pragma warning disable IDE0300
                new ToolStripMenuItem[]
                {
                    _fileMenu, _optionsMenu, _aboutMenu!,
                    _newFile, _newWind, _open,
                    _save, _restart, _exit, 
                    _fontAndColor, _appearance,
                    _themes, _manualConfig!,
                    _classicTheme, _darkTheme, 
                    _contact!, _fb!, _git!
                }
#pragma warning restore IDE0300 
            );
            _themes.DropDownItems.Add(_darkTheme);

            _manualConfig = new()
            {
                Text = "Manual Configuration",
                Font = _newFile.Font,
                Image = Properties.Resources.config
            };
            _manualConfig.Click += (sender, eventArgs) => Core.OpenManualConfiguration(this, _textBox!, _menuBar);
            _appearance.DropDownItems.Add(_manualConfig);

            #endregion

            #region About Menu

            _aboutMenu = new()
            {
                Text = "About",
                Font = _fileMenu.Font,
            };
            _menuBar.Items.Add(_aboutMenu);

            _contact = new()
            {
                Text = "Contact me..",
                Font = _newFile.Font,
                Image = Properties.Resources.aboutMenu
            };
            _aboutMenu.DropDownItems.Add(_contact);

            _fb = new()
            {
                Text = "Facebook",
                Font = new Font("Cascadia Code", 10, FontStyle.Regular),
                Image = Properties.Resources.facebook
            };
            _fb.Click += (sender, eventArgs) => Core.NavigateToFacebook();

            _git = new()
            {
                Text = "GitHub",
                Font = _fb.Font,
                Image = Properties.Resources.github
            };
            _git.Click += (sender, eventArgs) => Core.NavigateToGitHub();

            _contact.DropDownItems.AddRange([_fb, _git]);

            #endregion

            Controls.Add(_menuBar);
        }
    }
}