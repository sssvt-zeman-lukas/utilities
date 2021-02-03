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
        enum ColorType
        {
            Selectable,
            Selected,
            SelectableSelected,
            Highlight,
            NoHighlight,
        }

        enum Attribute
        {
            Folder,
            File,
        }

        enum Buttons
        {
            AllControls,
            RequiredSelection,
            AddSelection,
            NoControls,
        }

        public enum OptionType
        {
            Folder,
            ParentFolder,
            File,
            Path,
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
        }

        enum Existence
        {
            InSavedList,
            InOptionsList,
            InFolder,
        }

        enum AttributeType
        {
            FileSize,
            Created,
            Modified,
            FileType,
        }

        enum TrimType
        {
            TrimPath,
            FileTypeTrim,
            LineTrim,
        }

        private List<int> sourcePaths = new List<int>();
        private List<int> endPaths = new List<int>();
        private List<Option> optionList = new List<Option>();
        private List<Option> savedList = new List<Option>();
        private int fileID = 0;
        private bool cleanMemory = false;
        
        private List<string> allowedExtensions;
        private string activeDirectory;
        private string utilityName;

        private int savedCursorLeft;
        private int savedCursorTop;

        public FileExplorer(List<string> allowedExtensions, string activeDirectory, string utilityName)
        {
            this.allowedExtensions = allowedExtensions;
            this.activeDirectory = activeDirectory;
            this.utilityName = utilityName;
        }

        public void ExploreFiles()
        {
            bool selected = false;
            int activeSelection = 5;

            GenerateList(activeDirectory, fileID);

            while (!selected)
            {
                Console.WriteLine("{0} > FILE EXPLORER", utilityName);
                Console.WriteLine("---");                

                Console.WriteLine();

                savedCursorLeft = Console.CursorLeft;
                savedCursorTop = Console.CursorTop;

                RenderExplorer(activeSelection);

                activeSelection = KeyControl(activeSelection);

                if (cleanMemory)
                {
                    ChangeDirectory();
                    activeSelection = 4;
                    GenerateList(activeDirectory, 2);
                    Console.Clear();
                    cleanMemory = false;
                }

                Console.SetCursorPosition(0, 0);
            }
        }

        private void GenerateList(string activeDirectory, int fileID)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(activeDirectory);

            optionList.Add(new Option(0, DirInfo.Name, DirInfo.FullName, OptionType.Path, OptionState.Path, SavedType.None, GetAttributes(DirInfo.FullName, Attribute.Folder)));
            
            if (DirInfo.Root.ToString() != DirInfo.FullName)
                optionList.Add(new Option(1, "... " + DirInfo.Parent.Name, DirInfo.Parent.FullName, OptionType.ParentFolder, OptionState.Unselectable, SavedType.None, GetAttributes(DirInfo.Parent.FullName, Attribute.Folder)));         

            foreach (FileInfo file in DirInfo.GetFiles())
            {                
                optionList.Add(new Option(fileID, file.Name, file.FullName, OptionType.File, OptionState.Unselected, SavedType.None, GetAttributes(file.FullName, Attribute.File)));
                fileID++;
            }

            foreach(DirectoryInfo directory in DirInfo.GetDirectories())
            {
                optionList.Add(new Option(fileID, directory.Name, directory.FullName, OptionType.Folder, OptionState.FilesUnselected, SavedType.None, GetAttributes(directory.FullName, Attribute.Folder)));
            }

            CheckExistence(Existence.InOptionsList);
            //CheckExistence(Existence.InFolder);
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
                        FileInfo[] files = directories[i].GetFiles();
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
                        for (int k = 0; k <= 150; k++)
                        {
                            Console.Write("-");
                        }
                        break;

                    case 1:
                        Console.Write("| ");

                        ChangeColor(optionList[0].optionState, activeSelection == i);
                        RenderHighlight(150);

                        Console.SetCursorPosition(6, Console.CursorTop);
                        Console.Write(optionList[0].fileName);

                        Console.ResetColor();

                        Console.SetCursorPosition(150, Console.CursorTop);
                        Console.Write("|");

                        break;

                    case 3:
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
                        Console.SetCursorPosition(150, Console.CursorTop);
                        Console.Write("|");
                        break;

                    case int j when (j >= 4 && j < optionList.Count + 3):
                        Console.Write("| ");

                        ChangeColor(optionList[i - 3].optionState, activeSelection == i);
                        RenderHighlight(150);

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

                        Console.SetCursorPosition(150, Console.CursorTop);
                        Console.Write("|");
                        break;
                }

                Console.ResetColor();
                Console.WriteLine();
            }
        }

        private void RenderTips()
        {

        }

        private void RenderButtons(int activeSelection)
        {

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

        static void ChangeColor(OptionState optionState, bool activeSelection)
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

        private void ChangeDirectory()
        {
            foreach (Option option in optionList)
            {
                if (option.optionState == OptionState.Selected || option.optionState == OptionState.FilesSelected)
                {
                    savedList.Add(option);
                }

                CheckExistence(Existence.InSavedList);
            }

            optionList.Clear();
        }

        private int KeyControl(int activeSelection)
        {           
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    switch (activeSelection)
                    {
                        case 4:
                            activeSelection = 1;
                            break;

                        default:
                            activeSelection = Math.Max(1, activeSelection - 1); 
                            break;
                    }
                    break;
                
                case ConsoleKey.DownArrow:
                    switch (activeSelection)
                    {
                        case 1:
                            activeSelection = 4;
                            break;

                        default:
                            activeSelection = Math.Min(optionList.Count + 2, activeSelection + 1);
                            break;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    break;

                case ConsoleKey.RightArrow:
                    break;

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
            }

            return activeSelection;
        }

        public List<int> SourcePaths
        {
            get { return sourcePaths; }
        }

        public List<int> EndPaths
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
        private int ID;
        private string FileName;
        private string FilePath;
        private FileExplorer.OptionType OptionType;
        private FileExplorer.OptionState OptionState;
        private FileExplorer.SavedType SavedType;
        private List<string> Attributes;

        public Option(int ID, string FileName, string FilePath, FileExplorer.OptionType OptionType, FileExplorer.OptionState OptionState, FileExplorer.SavedType SavedType, List<string> Attributes)
        {
            this.ID = ID;
            this.FileName = FileName;
            this.FilePath = FilePath;
            this.OptionType = OptionType;
            this.OptionState = OptionState;
            this.SavedType = SavedType;
            this.Attributes = Attributes;
        }

        public int id
        {
            get { return ID; }
            set { ID = value; }
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
}
