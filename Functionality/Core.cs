// TextEditor

using System.Diagnostics;
using System.Drawing.Text;
using TextEditor.Renderers;
using CommonLibrary.Attributes;
using CommonLibrary.Exceptions;
using TextEditor.UserInterface;

namespace TextEditor.Functionality
{
    /// <summary>
    ///  Provides functionality.
    /// </summary>
    [Usage("Provides functionality for all the components of the editor")]
    internal class Core
    {
        // Creates new empty file in the text box.
        internal static void CreateNewFile(TextBox textBox)
        {
            // indicates if i miss the command that creates the text box while i write
            // the code.
            if (textBox == null)
            {
                throw new Error("The text box does not exist.");
            }

            bool hasContent = textBox.Text != null && textBox.Text != string.Empty;

            if (hasContent)
            {
                DialogResult result = MessageBox.Show(
                    "Unsaved data will be lost!  Do you want to continue ?",
                    "Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    textBox.Text = string.Empty;
                }
            }
            else
            {
                textBox.Text = string.Empty;
            }
        }

        // Creates new window
        internal static void CreateNewWind(TextBox box)
        {
            if (box.Text != null && box.Text != string.Empty)
            {

                if (MessageBox.Show(
                    "Unsaved data will be lost!  Do you want to continue ?",
                    "Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.Yes)
                {
                    _ = new EditorUI();
                }

            }
            else
            {
                _ = new EditorUI();
            }
        }

        // Opens external file in the editor
        internal static void OpenExtern(TextBox box)
        {
            bool hasContent = box.Text != null && box.Text != string.Empty;
            string extensionFilters =
                @"All files| *.*|" +
                 "Text file|*.txt|" +
                 "C# file|*.cs|" +
                 "Java file|*.java|" +
                 "C++ file|*.cpp|" +
                 "C file|*.c|" +
                 "Python file|*.py";

            if (hasContent)
            {
                DialogResult result = MessageBox.Show(
                    "Unsaved data will be lost !  Do you want to continue ?",
                    "Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    using OpenFileDialog fileChooser = new();

                    fileChooser.Filter = extensionFilters;
                    fileChooser.DefaultExt = "txt";

                    DialogResult fileDialogResult = fileChooser.ShowDialog();

                    string filePath = fileChooser.FileName;
                    string fileContent = string.Empty;

                    if (fileDialogResult == DialogResult.OK)
                    {
                        fileContent = File.ReadAllText(filePath);
                    }
                    else
                    {
                        fileContent = box.Text!;
                    }

                    box.Text = fileContent;
                }
            }
            else
            {
                using OpenFileDialog filePicker = new();

                filePicker.DefaultExt = "txt";
                filePicker.Filter = extensionFilters;

                DialogResult fileResult = filePicker.ShowDialog();

                string filePath = filePicker.FileName;
                string fileText = string.Empty;

                if (fileResult == DialogResult.OK)
                {
                    fileText = File.ReadAllText(filePath);
                }

                box.Text = fileText;
            }
        }

        // Save the text in the editor in a local file
        internal static void ExportDataToLocalFile(TextBox box)
        {
            bool hasNotText = box.Text == null || box.Text == string.Empty;
            string fileExtensions =
                "All files| *.*|" +
                 "Text file|*.txt|" +
                 "C# file|*.cs|" +
                 "Java file|*.java|" +
                 "C++ file|*.cpp|" +
                 "C file|*.c|" +
                 "Python file|*.py";

            if (hasNotText)
            {
                _ = MessageBox.Show(
                    "There is nothing to be saved!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
            else
            {
                using SaveFileDialog fileExporter = new();

                fileExporter.DefaultExt = "txt";
                fileExporter.Filter = fileExtensions;

                DialogResult result = fileExporter.ShowDialog();
                
                string filePath = fileExporter.FileName;
                string data = box.Text!;

                if (result == DialogResult.OK)
                {
                    File.WriteAllText(filePath, data);
                }
                else
                {
                    MessageBox.Show(
                        "No file path and file name specified.",
                        "Message",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }                
        }

        // Restarts the application
        internal static void Reboot(TextBox box)
        {
            bool hasContent = box.Text != null && box.Text != string.Empty;

            if (hasContent)
            {
                DialogResult userChoose = MessageBox.Show(
                    "Unsaved data will be lost!  Do you want to continue ?",
                    "Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (userChoose == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
            else
            {
                Application.Restart();
            }
        }

        // Closes the application
        internal static void Terminate(TextBox box)
        {
            if (box.Text != null && box.Text != string.Empty)
            {
                if (
                    MessageBox.Show(
                        "Unsaved data will be lost!  Do you want to continue ?",
                        "Message",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    ) 
                    == DialogResult.Yes
                )
                {
                    Application.Exit();
                    Environment.Exit(0);
                }
            }
            else
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }

        // Opens font settings window
        internal static void OpenFontProperties(TextBox box)
        {
            Form propWind = new()
            {
                Text = "Font settings",
                Size = new(700, 200),
                BackColor = Color.GhostWhite,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                Icon = Properties.Resources.fontWindIcon,
                Visible = true
            };
            propWind.MinimumSize = propWind.Size;
            propWind.MaximumSize = propWind.Size;

            Label topBorder = new()
            {
                BackColor = ProfessionalColors.SeparatorDark,
                Bounds = new(20, 25, 645, 1)
            };

            Label fontName = new()
            {
                Text = "Font",
                Font = new("Seoge UI", 11, FontStyle.Regular),
                Size = new(50, 20),
                Location = new(20, 50)
            };

            // All available fonts in the system as objects (The string representation of their names).
            object[] localFonts = [.. new InstalledFontCollection().Families.Select(family => family.Name)];

            ComboBox fontBox = new()
            {
                Size = new(280, 20),
                Location = new(70, 48),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new("Seoge UI", 11)
            };
            fontBox.SelectedIndexChanged += (sender, eventArgs) => ChangeFont(box, fontBox); 
            fontBox.Items.AddRange(localFonts);

            Label fontColor = new()
            {
                Text = "Color",
                Font = fontName.Font,
                Size = new(45, 20),
                Location = new(380, 50),
            };

            Button colorPicker = new()
            {
                Text = "Choose",
                Font = new("Seoge UI", 10),
                Size = new(230, 30),
                Location = new(430, 46)
            };
            colorPicker.Click += (sender, EventArgs) => ChangeForeground(box);

            Label leftBorder = new()
            {
                BackColor = ProfessionalColors.SeparatorDark,
                Bounds = new(20, 109, 140, 1)
            };

            Label fontSize = new()
            {
                Text = "Size",
                Font = fontName.Font,
                Size = new(50, 20),
                Location = new(170, 100)
            };

            NumericUpDown sizeSpinner = new()
            {
                Minimum = 0,
                Maximum = 50,
                Size = new(50, 25),
                Location = new(220, 100),
                Value = (decimal)box.Font.Size,
            };
            sizeSpinner.ValueChanged += (sender, eventArgs) => ChangeFontSize(box, sizeSpinner);

            Label fontStyle = new()
            {
                Text = "Style",
                Font = fontName.Font,
                Size = new(50, 20),
                Location = new(300, 100)
            };

            object[] fontStyles = ["Regular", "Bold", "Italic", "Bold - Italic"];

            ComboBox styleBox = new()
            {
                Size = new(150, 20),
                Location = new(350, 98),
                Font = new("Seoge UI", 11),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            styleBox.Items.AddRange(fontStyles);
            styleBox.SelectedIndexChanged += (sender, eventArgs) => ChangeFontStyle(box, styleBox);

            Label rigthBorder = new()
            {
                BackColor = ProfessionalColors.SeparatorDark,
                Bounds = new(520, 109, 140, 1)
            };

#pragma warning disable IDE0300
            propWind.Controls.AddRange(
                new Control[]
                {
                    fontName, fontBox, fontColor,
                    colorPicker, fontSize, sizeSpinner,
                    fontStyle, styleBox, topBorder,
                    leftBorder, rigthBorder
                }
            );
#pragma warning restore IDE0300
        }

        // Opens Manual configuration window that allows the user to create own theme.
        internal static void OpenManualConfiguration(Form mainWindow, TextBox box, MenuStrip menuBar)
        {
            Form settingsWindow = new()
            {
                Text = "Manual Configuration",
                Size = new(400, 330),
                Icon = Properties.Resources.manualConfigIcon,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                Visible = true,
                BackColor = Color.GhostWhite,
            };
            settingsWindow.MinimumSize = settingsWindow.Size;
            settingsWindow.MaximumSize = settingsWindow.Size;

            PictureBox infoIcon = new()
            {
                Size = new(18, 18),
                Location = new(10, 20),
                Image = Properties.Resources.info,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            new ToolTip().SetToolTip(infoIcon, "Create you own theme, by setting the editor colors manual.");

            Label foreground = new()
            {
                Text = "Foreground",
                Font = new Font("Seoge UI", 11),
                Size = new(90, 20),
                Location = new(20, 60)
            };

            Button foreButton = new()
            {
                Text = "Choose",
                Font = new("Cascadia Code", 10, FontStyle.Regular),
                Size = new(100, 30),
                Location = new(110, 56)
            };
            foreButton.Click += (sender, eventArgs) => ChangeForeground(box);

            Label editorBackground = new()
            {
                Text = "Editor background",
                Font = foreground.Font,
                Size = new(130, 20),
                Location = new(20, 120)
            };

            Button editorBackgroundButton = new()
            {
                Text = "Choose",
                Font = foreButton.Font,
                Size = new(100, 30),
                Location = new(153, 115)
            };
            editorBackgroundButton.Click += (sender, eventArgs) => ChangeEditorBackground(box);

            Label appBackground = new()
            {
                Text = "Application background",
                Font = foreground.Font,
                Size = new(165, 20),
                Location = new(20, 180)
            };

            Button appBackgroundButton = new()
            {
                Text = "Choose",
                Font = foreButton.Font,
                Size = new(100, 30),
                Location = new(186, 175)
            };
            appBackgroundButton.Click += (sender, eventArgs) => ChangeAppBackground(mainWindow);

            Label menuColor = new()
            {
                Text = "Menu bar color",
                Font = foreground.Font,
                Size = new(110, 20),
                Location = new(20, 240)
            };

            Button menuColorButton = new()
            {
                Text = "Choose",
                Font = foreButton.Font,
                Size = new(100, 30),
                Location = new(130, 235)
            };
            menuColorButton.Click += (sender, eventArgs) => ChangeMenuBarColor(menuBar);

#pragma warning disable IDE0300
            settingsWindow.Controls.AddRange(
                new Control[]
                {
                    infoIcon, foreground, foreButton, editorBackground,
                    editorBackgroundButton, appBackground, appBackgroundButton,
                    menuColor, menuColorButton
                }
            );
#pragma warning restore IDE0300
        }

        // Opens the default browser of the computer and navigates to my Facebook profile.
        internal static void NavigateToFacebook()
        {
            string profileUrl = @"https://www.facebook.com/profile.php?id=100010457925248&locale=bg_BG";

            ProcessStartInfo processArguments = new()
            {
                FileName = profileUrl,
                UseShellExecute = true,
            };

            try
            {
                Process.Start(processArguments);
            }
            catch (Exception)
            {
                throw new Error("Internal error! Can not start the process!");
            }
        }

        // Opens the default browser of the computer and navigates to my GitHub profile.
        internal static void NavigateToGitHub()
        {
            string gitProfile = @"https://github.com/Tsvetelinmarinov";

            ProcessStartInfo arguments = new()
            {
                FileName = gitProfile,
                UseShellExecute = true,
            };

            try
            {
                Process.Start(arguments);
            }
            catch (Exception)
            {
                throw new Error("Internal error! Can not start the process!");
            }
        }

        // Sets the classic light theme
        internal static void SetLightTheme(Form window, MenuStrip menuBar, TextBox box, ToolStripMenuItem[] menus)
        {
            window.BackColor = ProfessionalColors.SeparatorLight;

            menuBar.BackColor = Color.FromArgb(100, 250, 230, 250);
            menuBar.ForeColor = Color.Black;
            menuBar.Renderer = null;

            foreach (ToolStripMenuItem menu in menus)
            {
                menu.BackColor = Color.White;
                menu.ForeColor = Color.Black;
            }

            box.BackColor = Color.GhostWhite;
            box.ForeColor = Color.Black;
            box.BorderStyle = BorderStyle.None;
        }

        // Sets the dark theme
        internal static void SetDarkTheme(Form window, MenuStrip menuBar, TextBox box, ToolStripMenuItem[] menus)
        {
            window.BackColor = Color.FromArgb(28, 28, 28);
            
            menuBar.BackColor = Color.FromArgb(23, 23, 23);
            menuBar.ForeColor = Color.GhostWhite;
            menuBar.Renderer = new DarkModeRenderer();

            foreach (ToolStripMenuItem menu in menus)
            {
                menu.BackColor = Color.FromArgb(27, 27, 27);
                menu.ForeColor = Color.GhostWhite;
            }

            box.BackColor = Color.FromArgb(28, 28, 28);
            box.ForeColor = Color.GhostWhite;
            box.BorderStyle = BorderStyle.FixedSingle;          
        }


        private static void ChangeFont(TextBox box, ComboBox fontBox)
            => box.Font = new(fontBox.SelectedItem!.ToString()!, box.Font.Size);

        private static void ChangeForeground(TextBox box)
        {
            ColorDialog colorChooser = new()
            {
                Color = Color.Black
            };

            DialogResult result = colorChooser.ShowDialog();

            if (result == DialogResult.OK)
            {
                box.ForeColor = colorChooser.Color;
            }
        }

        private static void ChangeFontSize(TextBox box, NumericUpDown spinner)
        {
            int size = (int)spinner.Value;

            box.Font = new(box.Font.Name, size);
        }

        private static void ChangeFontStyle(TextBox box, ComboBox styleBox)
        {
            int currentItemIndex = styleBox.SelectedIndex;

            if (currentItemIndex == 0)
            {
                box.Font = new(box.Font.Name, box.Font.Size, FontStyle.Regular);
            }
            else if (currentItemIndex == 1)
            {
                box.Font = new(box.Font.Name, box.Font.Size, FontStyle.Bold);
            }
            else if (currentItemIndex == 2)
            {
                box.Font = new(box.Font.Name, box.Font.Size, FontStyle.Italic);
            }
            else if (currentItemIndex == 3)
            {
                box.Font = new(box.Font.Name, box.Font.Size, FontStyle.Bold | FontStyle.Italic);
            }
        }

        private static void ChangeEditorBackground(TextBox box)
        {
            ColorDialog colorChooser = new()
            {
                Color = Color.GhostWhite
            };

            DialogResult result = colorChooser.ShowDialog();
            bool isDifferentColor = result == DialogResult.OK && box.BackColor != colorChooser.Color;
            
            if (isDifferentColor)
            {
                box.BackColor = colorChooser.Color;
            }
        }

        private static void ChangeAppBackground(Form mainWind)
        {
            ColorDialog colorPicker = new()
            {
                Color = Color.GhostWhite
            };

            DialogResult result = colorPicker.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (mainWind.BackColor != colorPicker.Color)
                {
                    mainWind.BackColor = colorPicker.Color;
                }
            }
        }

        private static void ChangeMenuBarColor(MenuStrip menu)
        {
            ColorDialog colorChooser = new()
            {
                Color = ProfessionalColors.SeparatorLight
            };

            DialogResult result = colorChooser.ShowDialog();
            bool isDifferent = result == DialogResult.OK && menu.BackColor != colorChooser.Color;

            if (isDifferent)
            {
                menu.BackColor = colorChooser.Color;
            }
        }
    }
}