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

        private List<string> sourcePaths = new List<string>();
        private List<string> endPaths = new List<string>();
        private List<string> allowedExtensions = new List<string>();
        private List<string> optionList = new List<string>();
        private List<string> fileAttributes = new List<string>();

        private int activeSelection;
        private int savedCursorLeft;
        private int savedCursorTop;

        public void CopyFiles()
        {

        }

        public void ReadFiles()
        {

        }

        public void ExploreFiles(string openDirectory, string utilityName)
        {
            bool selected = false;
            int activeSelection = 5;
            bool showInstructions = true;
            string activeDirectory = openDirectory;

            while (!selected)
            {
                Console.WriteLine("{0} > FILE EXPLORER", utilityName);
                Console.WriteLine("---");                
                
                if (showInstructions) 
                    WriteInstructions();

                Console.WriteLine();

                fileAttributes.Clear();
                optionList.Clear();
                GenerateOptionList(activeDirectory);
                GenerateFileAttributes(activeSelection);

                savedCursorLeft = Console.CursorLeft;
                savedCursorTop = Console.CursorTop;

                RenderExplorer(activeSelection);
                RenderAttributes(activeSelection);

                activeSelection = KeyControl(activeSelection);

                Console.SetCursorPosition(0, 0);
            }
        }

        static void WriteInstructions()
        {
            Console.WriteLine("Instructions:");
            Console.WriteLine("     -> Move through the file explorer with Up and Down arrows.");
            Console.WriteLine("     -> To select a file, press Enter. The selected file will be highlighted.");
            Console.WriteLine("     -> If you are done with selecting files, press Enter on \"done\" button.");
            Console.WriteLine("     -> You are also able to paste the directory yourself at the top of the screen.");
        }

        private void GenerateOptionList(string activeDirectory)
        {
            List<string> filesInDirectory = new List<string>();

            for (int i = 0; i < allowedExtensions.Count; i++)
            {
                filesInDirectory.AddRange(Directory.GetFiles(activeDirectory, allowedExtensions[i]));
            }

            optionList.Add(activeDirectory);
            optionList.Add("... (Move to parent folder)");
            optionList.AddRange(filesInDirectory);
        }

        static void ChangeColor(ColorType colorType)
        {
            switch (colorType)
            {
                case ColorType.Selectable:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;

                case ColorType.Selected:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;

                case ColorType.SelectableSelected:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    break;

                case ColorType.Highlight:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;

                case ColorType.NoHighlight:
                    Console.ResetColor();
                    break;
            }
        }

        private void RenderAttributes(int activeSelection)
        {
            for (int line = 0; line < fileAttributes.Count + 4; line++)
            {
                switch (line)
                {
                    case 0:
                    case 2:
                    case int i when (i == fileAttributes.Count + 3):
                        Console.SetCursorPosition(105, savedCursorTop);
                        
                        for (int j = 105; j <= 145; j++)
                        {
                            Console.Write("-");
                        }

                        savedCursorTop++;

                        break;

                    case 1:
                        Console.SetCursorPosition(105, savedCursorTop);
                        Console.Write("| File Attributes");
                        Console.SetCursorPosition(145, Console.CursorTop);
                        Console.Write("|");

                        savedCursorTop++;

                        break;

                    case int i when (i >= 3 && i < fileAttributes.Count + 3):
                        Console.SetCursorPosition(105, savedCursorTop);
                        Console.Write("| ");
                        Console.Write(fileAttributes[line - 3]);
                        Console.SetCursorPosition(145, Console.CursorTop);
                        Console.Write("|");

                        savedCursorTop++;

                        break;
                }
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
                    case int k when (k == optionList.Count + 3):
                        for (int j = 0; j <= 100; j++)
                        {
                            Console.Write("-");
                        }
                        break;

                    case 1:
                        Console.Write("| ");

                        if (activeSelection == i)
                        {
                            Console.Write("> Active Directory: ");
                            ChangeColor(ColorType.Highlight);
                            Console.Write(TrimPath(optionList[0], TrimType.LineTrim));
                            RenderHighlight(100);
                        }
                        else
                        {
                            ChangeColor(ColorType.NoHighlight);
                            Console.Write("Active Directory: {0}", TrimPath(optionList[0], TrimType.LineTrim));
                            RenderHighlight(100);
                        }

                        ChangeColor(ColorType.NoHighlight);

                        Console.SetCursorPosition(100, Console.CursorTop);
                        Console.Write("|");

                        break;

                    case 3:
                        Console.Write("| File:");
                        Console.SetCursorPosition(70, Console.CursorTop);
                        Console.Write("State:");

                        Console.SetCursorPosition(100, Console.CursorTop);
                        Console.Write("|");
                        break;

                    case int j when (j >= 4 && j < optionList.Count + 3):
                        Console.Write("| ");

                        if (activeSelection == i)
                        {
                            if (sourcePaths.Contains(optionList[i - 3]))
                            {
                                ChangeColor(ColorType.SelectableSelected);
                                Console.Write("< {0}", TrimPath(optionList[i - 3], TrimType.TrimPath));
                                RenderHighlight(100);
                                Console.SetCursorPosition(70, Console.CursorTop);
                                Console.Write("Selected");
                            }
                            else
                            {
                                ChangeColor(ColorType.Selectable);
                                Console.Write("> {0}", TrimPath(optionList[i - 3], TrimType.TrimPath));
                                RenderHighlight(100);
                                Console.SetCursorPosition(70, Console.CursorTop);
                                Console.Write("Unselected");
                            }
                        }
                        else
                        {
                            if (sourcePaths.Contains(optionList[i - 3]))
                            {
                                ChangeColor(ColorType.Selected);
                                Console.Write("+ {0}", TrimPath(optionList[i - 3], TrimType.TrimPath));
                                RenderHighlight(100);
                                Console.SetCursorPosition(70, Console.CursorTop);
                                Console.Write("Selected");
                            }
                            else
                            {
                                ChangeColor(ColorType.NoHighlight);
                                Console.Write(TrimPath(optionList[i - 3], TrimType.TrimPath));
                                RenderHighlight(100);
                                Console.SetCursorPosition(70, Console.CursorTop);
                                Console.Write("Unselected");
                            }
                        }

                        ChangeColor(ColorType.NoHighlight);

                        Console.SetCursorPosition(100, Console.CursorTop);
                        Console.Write("|");
                        break;
                }

                ChangeColor(ColorType.NoHighlight);
                Console.WriteLine();
            }
        }

        private void GenerateFileAttributes(int activeSelection)
        {
            fileAttributes.Add(WriteAttribute(AttributeType.FileType, activeSelection));
            fileAttributes.Add(WriteAttribute(AttributeType.Created, activeSelection));
            fileAttributes.Add(WriteAttribute(AttributeType.Modified, activeSelection));
            fileAttributes.Add(WriteAttribute(AttributeType.FileSize, activeSelection));
        }

        private string WriteAttribute(AttributeType attributeType, int activeSelection)
        {
            string attribute = "";
            
            if (activeSelection >= 5)
            {
                switch (attributeType)
                {
                    case AttributeType.FileType:
                        attribute = "File Type: " + TrimPath(optionList[activeSelection - 3], TrimType.FileTypeTrim);
                        break;

                    case AttributeType.Created:
                        attribute = "Created: " + File.GetCreationTime(optionList[activeSelection - 3]);
                        break;

                    case AttributeType.Modified:
                        attribute = "Modified: " + File.GetLastWriteTime(optionList[activeSelection - 3]);
                        break;

                    case AttributeType.FileSize:
                        FileInfo fi = new FileInfo(optionList[activeSelection - 3]);

                        attribute = "File Size: ";

                        switch (fi.Length)
                        {
                            case long i when (i < 1000):
                                attribute += fi.Length + " Bytes";
                                break;

                            case long i when (i < 1000000):
                                attribute += fi.Length / 1000 + " kB";
                                break;

                            case long i when (i < 1000000000):
                                attribute += fi.Length / 1000000 + " MB";
                                break;

                            case long i when (i < 1000000000000):
                                attribute += fi.Length / 1000000000 + " GB";
                                break;
                        }

                        break;
                }
            }

            return attribute;
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
                    if (sourcePaths.Contains(optionList[activeSelection - 3]))
                    {
                        sourcePaths.Remove(optionList[activeSelection - 3]);
                    } 
                    else
                    {
                        sourcePaths.Add(optionList[activeSelection - 3]);
                    }
                    break;
            }

            return activeSelection;
        }

        static string TrimPath(string path, TrimType trimType)
        {
            int index = 0;
            
            switch (trimType)
            {
                case TrimType.TrimPath:
                    index = path.LastIndexOf("\\");
                    path = path.Substring(index + 1);
                    break;

                case TrimType.LineTrim:
                    index = path.Length - 79;
                    path = path.Substring(index + 21);
                    break;

                case TrimType.FileTypeTrim:
                    index = path.LastIndexOf(".");
                    path = path.Substring(index + 1);
                    break;
            }

            return path;
        }

        static void RenderHighlight(int endColumn)
        { 
            for (int i = Console.CursorLeft; i < endColumn; i++)
            {
                Console.Write(" ");
            }
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
}
