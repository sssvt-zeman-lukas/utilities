using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UtilitiesMain
{
    public class FileExplorer
    {
        enum Attribute
        {
            Folder,
            File,
        }

        enum ActiveWindow
        {
            Explorer,
            Buttons,
            MessagePrompt,
            Settings,
        }

        public enum SelectMode
        {
            OneFile,
            MultipleFiles,
            OneFolder,
            MultipleFolders,
            OneFileFolder,
            MultipleFileFolder,

        }

        public enum ExplorerMode
        {
            OpenOne,
            OpenMultiple,
            SrcEndOne,
            SrcEndMultiple,
            FullOpen,
            FullSelect,
        }

        public enum OptionType
        {
            Folder,
            ParentFolder,
            File,
            Path,
            ChangeDrive,
        }
        
        public enum SavedType
        {
            None,
            Source,
            End,
        }

        public enum OptionState
        {
            Unselected,
            Selected,
            Unselectable,
            FilesUnselected,
            FilesSelected,
            Path,
            SelectableButton,
            UnselectableButton,
            Border,
        }

        public enum ButtonType
        {
            Copy,
            Cut,
            Paste,
            Rename,
            Open,
            Delete,
            NewFolder,
            ConfirmSelection,
            ChangeDrive,
            SwitchMode,
        }

        enum Existence
        {
            InSavedList,
            InOptionsList,
            InFolder,
        }

        private List<string> sourcePaths = new List<string>();
        private List<string> endPaths = new List<string>();
        private List<Option> optionList = new List<Option>();
        private List<Option> savedList = new List<Option>();
        private List<Button> buttons = new List<Button>();
        private ActiveWindow activeWindow = ActiveWindow.Buttons;
        private bool cleanMemory = false;

        private ExplorerMode explorerMode;
        private List<string> allowedExtensions;
        private string activeDirectory;
        private string utilityName;

        public FileExplorer(ExplorerMode explorerMode, List<string> allowedExtensions, string activeDirectory, string utilityName)
        {
            this.allowedExtensions = allowedExtensions;
            this.activeDirectory = activeDirectory;
            this.utilityName = utilityName;
            this.explorerMode = explorerMode;
        }

        public void ExploreFiles()
        {
            bool selected = false;
            int activeSelection = 1;
            int activeButtonSelection = 0;

            GenerateList(activeDirectory);
            GenerateButton();

            while (!selected)
            {
                Console.WriteLine("{0} > FILE EXPLORER", utilityName);
                Console.WriteLine("---");                
                Console.WriteLine();

                RenderExplorer(activeSelection);
                Console.WriteLine();
                RenderButtons(activeButtonSelection);

                var activeSelections = KeyControl(activeSelection, activeButtonSelection);
                activeSelection = activeSelections.Item1;
                activeButtonSelection = activeSelections.Item2;

                if (cleanMemory)
                {
                    ChangeDirectory();
                    activeSelection = 4;
                    GenerateList(activeDirectory);
                    Console.Clear();
                    cleanMemory = false;
                }

                Console.SetCursorPosition(0, 0);
            }
        }

        private void GenerateList(string activeDirectory)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(activeDirectory);

            optionList.Add(new Option(DirInfo.Name, DirInfo.FullName, OptionType.Path, OptionState.Path, SavedType.None, GetAttributes(DirInfo.FullName, Attribute.Folder)));
            
            if (DirInfo.Root.ToString() != DirInfo.FullName)
                optionList.Add(new Option("... " + DirInfo.Parent.Name, DirInfo.Parent.FullName, OptionType.ParentFolder, OptionState.Unselectable, SavedType.None, GetAttributes(DirInfo.Parent.FullName, Attribute.Folder)));

            foreach (DirectoryInfo directory in DirInfo.GetDirectories())
            {
                if (IsAccessible(directory))
                    optionList.Add(new Option(directory.Name, directory.FullName, OptionType.Folder, OptionState.FilesUnselected, SavedType.None, GetAttributes(directory.FullName, Attribute.Folder)));
            }

            foreach (FileInfo file in DirInfo.GetFiles())  
                optionList.Add(new Option(file.Name, file.FullName, OptionType.File, OptionState.Unselected, SavedType.None, GetAttributes(file.FullName, Attribute.File)));

            CheckExistence(Existence.InOptionsList);
            CheckExistence(Existence.InFolder);
        }

        static List<string> GetAttributes(string filePath, Attribute attribute)
        {
            List<string> attributes = new List<string>();
            
            switch (attribute)
            {
                case Attribute.Folder:
                    DirectoryInfo di = new DirectoryInfo(filePath);
                    attributes.Add("");
                    attributes.Add("" + di.CreationTime);
                    attributes.Add("" + di.LastWriteTime);
                    attributes.Add("");
                    break;

                case Attribute.File:
                    FileInfo fi = new FileInfo(filePath);
                    attributes.Add(fi.Extension);
                    attributes.Add("" + fi.CreationTime);
                    attributes.Add("" + fi.LastWriteTime);
                    attributes.Add("" + fi.Length);
                    break;
            }

            return attributes;
        }

        private void GenerateButton()
        {
            buttons.Clear();
            
            switch (explorerMode)
            {
                case ExplorerMode.OpenOne:
                case ExplorerMode.OpenMultiple:
                case ExplorerMode.SrcEndOne:
                    buttons.Add(new Button("CONFIRM", "Confirms your file selection.", ButtonType.ConfirmSelection, OptionState.UnselectableButton));
                    buttons.Add(new Button("CHANGE DRIVE", "Changes the drive (or partition) you are exploring.", ButtonType.ChangeDrive, OptionState.SelectableButton));
                    break;

                case ExplorerMode.SrcEndMultiple:
                    buttons.Add(new Button("CONFIRM", "Confirms your file selection.", ButtonType.ConfirmSelection, OptionState.UnselectableButton));
                    buttons.Add(new Button("CHANGE DRIVE", "Changes the drive (or partition) you are exploring.", ButtonType.ChangeDrive, OptionState.SelectableButton));
                    buttons.Add(new Button("NEW FOLDER", "Creates a new folder in currently opened directory.", ButtonType.NewFolder, OptionState.UnselectableButton));
                    break;

                case ExplorerMode.FullOpen:
                case ExplorerMode.FullSelect:
                    if (explorerMode == ExplorerMode.FullOpen)
                    {
                        buttons.Add(new Button("SELECT MULTIPLE MODE", "Changes the explorer mode. In this mode, you'll be able to select multiple files at once.", ButtonType.SwitchMode, OptionState.SelectableButton));
                        buttons.Add(new Button("OPEN", "Opens your selected file.", ButtonType.Open, OptionState.SelectableButton));
                    }
                    else
                    {
                        buttons.Add(new Button("MODE OPEN", "Changes the explorer mode. In this mode, you'll be able to open files or applications.", ButtonType.SwitchMode, OptionState.SelectableButton));
                    }

                    buttons.Add(new Button("NEW FOLDER", "Creates a new folder in currently opened directory.", ButtonType.NewFolder, OptionState.SelectableButton));
                    buttons.Add(new Button("CHANGE DRIVE", "Changes the drive (or partition) you are exploring.", ButtonType.ChangeDrive, OptionState.SelectableButton));
                    buttons.Add(new Button("CUT", "Withdraws selected files to clipboard, so you are able to move them somewhere else.", ButtonType.Cut, OptionState.SelectableButton));
                    buttons.Add(new Button("COPY", "Copies selected files to clipboard, so you are able to paste them somewhere else.", ButtonType.Copy, OptionState.SelectableButton));
                    buttons.Add(new Button("PASTE", "Pastes files from your clipboard to the current directory.", ButtonType.Paste, OptionState.UnselectableButton));
                    buttons.Add(new Button("RENAME", "Used for renaming selected files.", ButtonType.Rename, OptionState.SelectableButton));
                    buttons.Add(new Button("DELETE", "Deletes selected files.", ButtonType.Delete, OptionState.SelectableButton));
                    break;
            }
        }

        private void CheckExistence(Existence existence)
        {
            switch (existence)
            {
                case Existence.InSavedList:
                    for (int i = 0; i < savedList.Count; i++)
                    {
                        for (int j = 0; j < optionList.Count; j++)
                        {
                            if (savedList[i].filePath.Equals(optionList[j].filePath) && optionList[j].optionState == OptionState.Unselected)
                            {
                                savedList.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;

                case Existence.InOptionsList:
                    for (int i = 0; i < savedList.Count; i++)
                    {
                        for (int j = 0; j < optionList.Count; j++)
                        {
                            if (savedList[i].filePath.Equals(optionList[j].filePath))
                            {
                                optionList[j] = savedList[i];
                            }
                        }
                    }
                    break;

                case Existence.InFolder:
                    DirectoryInfo dirInfo = new DirectoryInfo(activeDirectory);
                    DirectoryInfo[] directories = dirInfo.GetDirectories();
                    List<DirectoryInfo> folders = new List<DirectoryInfo>();

                    for (int i = 0; i < directories.Length; i++)
                    {
                        FileInfo[] files;

                        if (IsAccessible(directories[i]))
                        {
                            files = directories[i].GetFiles();
                        }
                        else 
                        {
                            continue;
                        }

                        DirectoryInfo[] dirsInDir = directories[i].GetDirectories();
                        List<string> paths = new List<string>();
                        
                        foreach (FileInfo file in files)
                        {
                            paths.Add(file.FullName);
                        }

                        foreach (DirectoryInfo dir in dirsInDir)
                        {
                            paths.Add(dir.FullName);
                        }
                        
                        for (int j = 0; j < savedList.Count; j++)
                        {
                            for (int k = 0; k < paths.Count; k++)
                            {
                                if (savedList[j].filePath == paths[k])
                                {
                                    if (savedList[j].optionType == OptionType.Folder)
                                    {
                                        DirectoryInfo di = new DirectoryInfo(savedList[j].filePath);
                                        folders.Add(di.Parent);
                                    }
                                    else
                                    {
                                        FileInfo fi = new FileInfo(savedList[j].filePath);
                                        folders.Add(fi.Directory);
                                    }
                                }
                            }
                        }
                    }

                    for (int i = 0; i < folders.Count; i++)
                    {
                        for (int j = 0; j < optionList.Count; j++)
                        {
                            if (optionList[j].optionType == OptionType.Folder && folders[i].FullName == optionList[j].filePath)
                            {
                                optionList[j].optionState = OptionState.FilesSelected;
                                break;
                            }
                        }
                    }

                    break;
            }
        }

        private void RenderExplorer(int activeSelection)
        {
            for (int i = 0; i < optionList.Count + 4; i++)
            {
                switch (i)
                {
                    case 0:
                    case 2:
                    case int j when (j == optionList.Count + 3):
                        ChangeColor(OptionState.Border, ActiveWindow.Explorer, false);
                        for (int k = 0; k <= 155; k++)
                        {
                            Console.Write("-");
                        }
                        break;

                    case 1:
                        ChangeColor(OptionState.Border, ActiveWindow.Explorer, false);
                        Console.Write("| ");

                        ChangeColor(optionList[0].optionState, ActiveWindow.Explorer, activeSelection == i - 1);
                        RenderHighlight(155);

                        Console.SetCursorPosition(6, Console.CursorTop);
                        Console.Write(optionList[0].fileName);

                        Console.ResetColor();

                        Console.SetCursorPosition(155, Console.CursorTop);
                        ChangeColor(OptionState.Border, ActiveWindow.Explorer, false);
                        Console.Write("|");

                        break;

                    case 3:
                        ChangeColor(OptionState.Border, ActiveWindow.Explorer, false);
                        Console.Write("| ");
                        Console.SetCursorPosition(6, Console.CursorTop);
                        Console.Write("File:");
                        Console.SetCursorPosition(50, Console.CursorTop);
                        Console.Write("Type:");
                        Console.SetCursorPosition(70, Console.CursorTop);
                        Console.Write("State:");
                        Console.SetCursorPosition(90, Console.CursorTop);
                        Console.Write("Created:");
                        Console.SetCursorPosition(115, Console.CursorTop);
                        Console.Write("Modified:");
                        Console.SetCursorPosition(140, Console.CursorTop);
                        Console.Write("Size:");
                        Console.SetCursorPosition(155, Console.CursorTop);
                        Console.Write("|");
                        break;

                    case int j when (j >= 4 && j < optionList.Count + 3):
                        ChangeColor(OptionState.Border, ActiveWindow.Explorer, false);
                        Console.Write("| ");

                        ChangeColor(optionList[i - 3].optionState, ActiveWindow.Explorer, activeSelection == i - 3);
                        RenderHighlight(155);

                        Console.SetCursorPosition(6, Console.CursorTop);
                        Console.Write(optionList[i - 3].fileName);
                        Console.SetCursorPosition(50, Console.CursorTop);
                        Console.Write(EnumSeparator(optionList[i - 3].optionType.ToString()));
                        Console.SetCursorPosition(70, Console.CursorTop);
                        Console.Write(EnumSeparator(optionList[i - 3].optionState.ToString()));
                        Console.SetCursorPosition(90, Console.CursorTop);
                        Console.Write(optionList[i - 3].attributes[1]);
                        Console.SetCursorPosition(115, Console.CursorTop);
                        Console.Write(optionList[i - 3].attributes[2]);
                        Console.SetCursorPosition(140, Console.CursorTop);
                        
                        if (optionList[i - 3].optionType != OptionType.Folder && optionList[i - 3].optionType != OptionType.ParentFolder)
                            RecalculateSize(optionList[i - 3].attributes[3]);

                        Console.ResetColor();

                        Console.SetCursorPosition(155, Console.CursorTop);
                        ChangeColor(OptionState.Border, ActiveWindow.Explorer, false);
                        Console.Write("|");
                        break;
                }

                Console.ResetColor();
            }
        }

        private void RenderTips()
        {

        }

        private void RenderButtons(int activeButtonSelection)
        {
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                    case 3:
                        ChangeColor(OptionState.Border, ActiveWindow.Buttons, false);
                        for (int k = 0; k <= 155; k++)
                        {
                            Console.Write("-");
                        }
                        break;

                    case 1:
                        ChangeColor(OptionState.Border, ActiveWindow.Buttons, false);
                        Console.Write("|");
                        Console.Write(" Button hint: ");
                        Console.Write(buttons[activeButtonSelection].buttonHint);
                        RenderHighlight(155);
                        Console.SetCursorPosition(155, Console.CursorTop);
                        Console.Write("|");
                        break;

                    case 2:
                        ChangeColor(OptionState.Border, ActiveWindow.Buttons, false);
                        Console.Write("| ");

                        int blankSpaces = CalculateBlankSpaces();

                        for (int k = 0; k < buttons.Count; k++)
                        {
                            ChangeColor(buttons[k].buttonState, ActiveWindow.Buttons, k == activeButtonSelection);

                            for (int j = 0; j < blankSpaces / 2; j++)
                            {
                                if (k == activeButtonSelection & j == (blankSpaces / 2) - 2)
                                {
                                    Console.Write(">");
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                            }

                            Console.Write(buttons[k].buttonText);

                            for (int j = 0; j < blankSpaces / 2; j++)
                            {
                                if (k == activeButtonSelection & j == 1)
                                {
                                    Console.Write("<");
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                            }

                            ChangeColor(OptionState.Border, ActiveWindow.Buttons, false);

                            if (k != (buttons.Count - 1))
                                Console.Write("|");
                        }

                        Console.SetCursorPosition(155, Console.CursorTop);
                        ChangeColor(OptionState.Border, ActiveWindow.Buttons, false);
                        Console.Write("|");
                        break;
                }

                Console.ResetColor();
            }
        }

        private void RenderMessage(int activeSelection)
        {

        }

        static void RenderHighlight(int endColumn)
        { 
            for (int i = Console.CursorLeft; i < endColumn - 1; i++)
            {
                Console.Write(" ");
            }
        }

        private void ChangeColor(OptionState optionState, ActiveWindow activeWindow, bool activeSelection)
        {
            if (this.activeWindow == activeWindow)
            {
                if (activeSelection)
                {
                    switch (optionState)
                    {
                        case OptionState.Selected:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("<");
                            break;

                        case OptionState.Unselected:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write(">");
                            break;

                        case OptionState.FilesSelected:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("/>");
                            break;

                        case OptionState.FilesUnselected:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write("/>");
                            break;

                        case OptionState.Unselectable:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("/<");
                            break;

                        case OptionState.Path:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(">>");
                            break;

                        case OptionState.SelectableButton:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            break;

                        case OptionState.UnselectableButton:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            break;
                    }
                }
                else
                {
                    switch (optionState)
                    {
                        case OptionState.Selected:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("+");
                            break;

                        case OptionState.FilesSelected:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("/+");
                            break;

                        case OptionState.Unselected:
                        case OptionState.FilesUnselected:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;

                        case OptionState.Unselectable:
                            Console.ResetColor();
                            break;

                        case OptionState.Path:
                            Console.ResetColor();
                            Console.Write("P>");
                            break;

                        case OptionState.SelectableButton:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;

                        case OptionState.UnselectableButton:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;

                        case OptionState.Border:
                            Console.ResetColor();
                            break;
                    }
                }
            }
            else
            {
                if (activeSelection)
                {
                    switch (optionState)
                    {
                        case OptionState.Selected:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("<");
                            break;

                        case OptionState.Unselected:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(">");
                            break;

                        case OptionState.FilesSelected:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write("/>");
                            break;

                        case OptionState.FilesUnselected:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write("/>");
                            break;

                        case OptionState.Unselectable:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write("/<");
                            break;

                        case OptionState.Path:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(">>");
                            break;

                        case OptionState.SelectableButton:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            break;

                        case OptionState.UnselectableButton:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            break;
                    }
                }
                else
                {
                    switch (optionState)
                    {
                        case OptionState.Selected:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("+");
                            break;

                        case OptionState.FilesSelected:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("/+");
                            break;

                        case OptionState.Unselected:
                        case OptionState.FilesUnselected:
                        case OptionState.Unselectable:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;

                        case OptionState.Path:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("P>");
                            break;

                        case OptionState.SelectableButton:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;

                        case OptionState.UnselectableButton:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            break;

                        case OptionState.Border:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                    }
                }
            }
        }

        static string EnumSeparator(string text)
        {
            char[] separatedChar = text.ToCharArray();
            List<int> indexes = new List<int>();
            List<string> substrings = new List<string>();
            int index = 0;

            foreach (char ch in separatedChar)
            { 
                if (char.IsUpper(ch))
                {
                    indexes.Add(index);
                }

                index++;
            }

            for (int i = 0; i < indexes.Count; i++)
            {
                if (i + 1 < indexes.Count)
                {
                    substrings.Add(text.Substring(indexes[i], indexes[i + 1] - indexes[i]));
                }
                else
                {
                    substrings.Add(text.Substring(indexes[i]));
                }
            }

            text = null;

            foreach (string part in substrings)
            {
                if (text == null)
                {
                    text = part;
                }
                else
                {
                    text = text + " " + part;
                }
            }

            return text;
        }

        static void RecalculateSize(string sizeInBytes)
        {
            if (long.TryParse(sizeInBytes, out long size))
            {
                switch (size)
                {
                    case long s when (s < 1000):
                        Console.Write(size + " B");
                        break;

                    case long s when (s < 1000000):
                        Console.Write(size / 1000 + " kB");
                        break;

                    case long s when (s < 1000000000):
                        Console.Write(size / 1000000 + " MB");
                        break;

                    case long s when (s < 1000000000000):
                        Console.Write(size / 1000000000 + " GB");
                        break;
                }
            }
        }

        private int CalculateBlankSpaces()
        {
            int blankSpaces = 153;

            foreach (Button button in buttons)
            {
                blankSpaces -= button.buttonText.Length;
            }

            blankSpaces = blankSpaces / buttons.Count;
            return blankSpaces;
        }
        
        public bool IsAccessible(DirectoryInfo directory)
        {
            try
            {
                directory.GetFiles();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ChangeDirectory()
        {
            foreach (Option option in optionList)
            {
                if (option.optionState == OptionState.Selected)
                {
                    savedList.Add(option);
                }

                CheckExistence(Existence.InSavedList);
            }

            optionList.Clear();
        }

        private (int, int) KeyControl(int activeSelection, int activeButtonSelection)
        {           
            if (activeWindow == ActiveWindow.Explorer)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Tab:
                        activeWindow = ActiveWindow.Buttons;
                        break;

                    case ConsoleKey.UpArrow:
                        activeSelection = Math.Max(0, activeSelection - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        activeSelection = Math.Min(optionList.Count - 1, activeSelection + 1);
                        break;

                    case ConsoleKey.Enter:
                        if (optionList[activeSelection].optionType == OptionType.Path)
                        {
                            // then allow user to type new path
                        }
                        else if (optionList[activeSelection].optionType == OptionType.ParentFolder)
                        {
                            activeDirectory = optionList[activeSelection].filePath;
                            cleanMemory = true;
                        }
                        else if (optionList[activeSelection].optionType == OptionType.Folder)
                        {
                            // then open or select whole folder
                            activeDirectory = optionList[activeSelection].filePath;
                            cleanMemory = true;
                        }
                        else if (optionList[activeSelection].optionType == OptionType.File)
                        {
                            // then open, select or deselect file
                            if (optionList[activeSelection].optionState == OptionState.Selected)
                            {
                                optionList[activeSelection].optionState = OptionState.Unselected;
                            }
                            else if (optionList[activeSelection].optionState == OptionState.Unselected)
                            {
                                optionList[activeSelection].optionState = OptionState.Selected;
                            }
                        }
                        break;
                }
            }
            else if (activeWindow == ActiveWindow.Buttons)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Tab:
                        activeWindow = ActiveWindow.Explorer;
                        break;

                    case ConsoleKey.LeftArrow:
                        activeButtonSelection = Math.Max(0, activeButtonSelection - 1);
                        break;

                    case ConsoleKey.RightArrow:
                        activeButtonSelection = Math.Min(buttons.Count - 1, activeButtonSelection + 1);
                        break;

                    case ConsoleKey.Enter:
                        switch (buttons[activeSelection].buttonType)
                        {
                            case ButtonType.ChangeDrive:
                                break;

                            case ButtonType.ConfirmSelection:
                                break;

                            case ButtonType.Copy:
                                break;

                            case ButtonType.Cut:
                                break;

                            case ButtonType.Delete:
                                break;

                            case ButtonType.NewFolder:
                                break;

                            case ButtonType.Open:
                                break;

                            case ButtonType.Paste:
                                break;

                            case ButtonType.Rename:
                                break;

                            case ButtonType.SwitchMode:
                                break;
                        }
                        break;  
                }
            }
            else if (activeWindow == ActiveWindow.MessagePrompt)
            {

            }
            else if (activeWindow == ActiveWindow.Settings)
            {

            }
            
            /*switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    if (optionList[activeSelection - 3].optionState == OptionState.Selected && optionList[activeSelection - 3].optionType == OptionType.File)
                    {
                        optionList[activeSelection - 3].optionState = OptionState.Unselected;
                    } 
                    else if (optionList[activeSelection - 3].optionType == OptionType.File)
                    {
                        optionList[activeSelection - 3].optionState = OptionState.Selected;
                    }
                    else if (optionList[activeSelection - 3].optionType == OptionType.Folder || optionList[activeSelection - 3].optionType == OptionType.ParentFolder)
                    {
                        activeDirectory = optionList[activeSelection - 3].filePath;
                        cleanMemory = true;
                    }
                    else if (optionList[activeSelection - 3].optionType == OptionType.Path)
                    {

                    }

                    break;
            }*/

            return (activeSelection, activeButtonSelection);
        }

        public List<string> SourcePaths
        {
            get { return sourcePaths; }
        }

        public List<string> EndPaths
        {
            get { return endPaths; }
        }

        public List<string> AllowedExtensions
        {
            get { return allowedExtensions; }
            set { allowedExtensions = value; }
        }
    }

    class Option
    {    
        private string FileName;
        private string FilePath;
        private FileExplorer.OptionType OptionType;
        private FileExplorer.OptionState OptionState;
        private FileExplorer.SavedType SavedType;
        private List<string> Attributes;

        public Option(string FileName, string FilePath, FileExplorer.OptionType OptionType, FileExplorer.OptionState OptionState, FileExplorer.SavedType SavedType, List<string> Attributes)
        {
            this.FileName = FileName;
            this.FilePath = FilePath;
            this.OptionType = OptionType;
            this.OptionState = OptionState;
            this.SavedType = SavedType;
            this.Attributes = Attributes;
        }
        
        public string fileName
        {
            get { return FileName; }
            set { FileName = value; }
        }

        public string filePath
        {
            get { return FilePath; }
        }

        public FileExplorer.OptionType optionType
        {
            get { return OptionType; }
        }

        public FileExplorer.OptionState optionState
        {
            get { return OptionState; }
            set { OptionState = value; }
        }

        public FileExplorer.SavedType savedType
        {
            get { return SavedType; }
            set { SavedType = value; }
        }

        public List<string> attributes
        {
            get { return Attributes; }
        }
    }

    class Button
    {
        private string ButtonText;
        private string ButtonHint;
        private FileExplorer.ButtonType ButtonType;
        private FileExplorer.OptionState ButtonState;

        public Button(string ButtonText, string ButtonHint, FileExplorer.ButtonType ButtonType, FileExplorer.OptionState ButtonState)
        {
            this.ButtonText = ButtonText;
            this.ButtonHint = ButtonHint;
            this.ButtonType = ButtonType;
            this.ButtonState = ButtonState;
        }

        public string buttonText
        {
            get { return ButtonText; }
        }

        public string buttonHint
        {
            get { return ButtonHint; }
            set { ButtonHint = value; }
        }

        public FileExplorer.ButtonType buttonType
        {
            get { return ButtonType; }
        }

        public FileExplorer.OptionState buttonState
        {
            get { return ButtonState; }
            set { ButtonState = value; }
        }
    }
}
