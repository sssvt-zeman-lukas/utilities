using System;
using System.Collections.Generic;
using UtilitiesMain.HouseBuilder;

namespace UtilitiesMain
{
    public class HouseBuilder_program
    {
        enum Type
        {
            Doors,
            Windows,
            Houses,
            Flats,
            Floors,
            Adresses,
            TowerBlocks,
        }

        //vytvoření listů, které budou zaplněny instacemi podle typů
        private List<HouseBuilder_Door> Doors = new List<HouseBuilder_Door>();
        private List<HouseBuilder_Window> Windows = new List<HouseBuilder_Window>();
        private List<HouseBuilder_House> Houses = new List<HouseBuilder_House>();
        private List<HouseBuilder_Flat> Flats = new List<HouseBuilder_Flat>();
        private List<HouseBuilder_Floor> Floors = new List<HouseBuilder_Floor>();
        private List<HouseBuilder_Adress> Adresses = new List<HouseBuilder_Adress>();
        private List<HouseBuilder_TowerBlock> TowerBlocks = new List<HouseBuilder_TowerBlock>();

        public void HouseBuilder()
        {
            //vytvoření dveří
            HouseBuilder_Door door1 = new HouseBuilder_Door(0.9, 2.2, false);
            HouseBuilder_Door door2 = new HouseBuilder_Door(1.8, 2.1, true);
            Doors.AddRange(new List<HouseBuilder_Door>() { door1, door2 });

            //vytvoření oken
            HouseBuilder_Window window1 = new HouseBuilder_Window("Standard", 0.8, 1.5);
            HouseBuilder_Window window2 = new HouseBuilder_Window("Standard", 0.8, 1.5);
            HouseBuilder_Window window3 = new HouseBuilder_Window("Francouz", 1.0, 2.2);
            Windows.AddRange(new List<HouseBuilder_Window>() { window1, window2, window3 });

            //vytvoření domů
            HouseBuilder_House house1 = new HouseBuilder_House(8.5, 3.2, door1, window1, window2);
            HouseBuilder_House house2 = new HouseBuilder_House(12.1, 4.5, door2, window1, window3);
            Houses.AddRange(new List<HouseBuilder_House>() { house1, house2 });

            //vytvoření bytů
            HouseBuilder_Flat flat1 = new HouseBuilder_Flat(8.5, 3.2, door1, window1, window2);
            HouseBuilder_Flat flat2 = new HouseBuilder_Flat(12.1, 4.5, door2, window1, window3);
            HouseBuilder_Flat flat3 = new HouseBuilder_Flat(10.2, 3.2, door2, window1, window2);
            HouseBuilder_Flat flat4 = new HouseBuilder_Flat(5.5, 3.2, door1, window1, null);
            HouseBuilder_Flat flat5 = new HouseBuilder_Flat(8.2, 3.2, door1, window3, window3);
            Flats.AddRange(new List<HouseBuilder_Flat>() { flat1, flat2, flat3, flat4, flat5 });

            //vytvoření pater - nejdříve vytvoříme listy pro jednotlivá patra, které budou obsahovat byty na každém patře
            List<HouseBuilder_Flat> floor0_Flats = new List<HouseBuilder_Flat>();
            floor0_Flats.AddRange(new List<HouseBuilder_Flat>() { flat3, flat4 });
            List<HouseBuilder_Flat> floor1_Flats = new List<HouseBuilder_Flat>();
            floor1_Flats.AddRange(new List<HouseBuilder_Flat>() { flat5, flat1 });
            List<HouseBuilder_Flat> floor2_Flats = new List<HouseBuilder_Flat>();
            floor2_Flats.Add(flat2);

            //vytvoření pater - vytvoříme instance tří pater
            HouseBuilder_Floor floor0 = new HouseBuilder_Floor(0, "přízemí", floor0_Flats);
            HouseBuilder_Floor floor1 = new HouseBuilder_Floor(1, "byt s francouzskými okny má balkon", floor1_Flats);
            HouseBuilder_Floor floor2 = new HouseBuilder_Floor(2, "s luxusním bytem a verandou", floor2_Flats);
            Floors.AddRange(new List<HouseBuilder_Floor>() { floor0, floor1, floor2 });

            //vytvoření adres
            HouseBuilder_Adress adress1 = new HouseBuilder_Adress("K Ládví", 344, "Praha 8", 18100);
            HouseBuilder_Adress adress2 = new HouseBuilder_Adress("Vodičkova", 699, "Praha 1", 11000);
            HouseBuilder_Adress adress3 = new HouseBuilder_Adress("Sněmovní", 176, "Praha 1", 11826);
            Adresses.AddRange(new List<HouseBuilder_Adress>() { adress1, adress2, adress3 });

            //vytvoření paneláku - vytvoříme instanci paneláku
            HouseBuilder_TowerBlock towerBlock1 = new HouseBuilder_TowerBlock(adress1, Floors);
            TowerBlocks.Add(towerBlock1);

            //vypsání uložených instancí
            Write((int)Type.Doors);
            Write((int)Type.Windows);
            Write((int)Type.Houses);
            Write((int)Type.Flats);
            Write((int)Type.Floors);
            Write((int)Type.Adresses);
            Write((int)Type.TowerBlocks);

            Console.ReadKey(true);
        }

        private void Write(int type)
        {
            switch (type)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("Výpis všech uložených dveří:");

                    for (int i = 0; i < Doors.Count; i++)
                    {
                        Console.Write("     -> {0}. dveře", i + 1);
                        WriteDoors(Doors[i]);
                    }
                    
                    Console.WriteLine();
                    break;

                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Výpis všech uložených oken:");

                    for (int i = 0; i < Windows.Count; i++)
                    {
                        Console.Write("     -> {0}. okno", i + 1);
                        WriteWindows(Windows[i]);
                    }

                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Výpis všech uložených domů:");

                    for (int i = 0; i < Houses.Count; i++)
                    {
                        Console.Write("     -> {0}. dům", i + 1);
                        WriteHouses(Houses[i]);
                    }

                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Výpis všech uložených bytů:");

                    for (int i = 0; i < Flats.Count; i++)
                    {
                        Console.Write("     -> {0}. byt", i + 1);
                        WriteFlats(Flats[i]);
                    }

                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Výpis všech uložených pater:");
                    
                    for (int i = 0; i < Floors.Count; i++)
                    {
                        Console.Write("     -> {0}. patro", i + 1);
                        WriteFloors(Floors[i]);
                    }

                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine();
                    Console.WriteLine("Výpis všech uložených adres:");
                    
                    for (int i = 0; i < Adresses.Count; i++)
                    {
                        Console.Write("     -> {0}. adresa", i + 1);
                        WriteAdresses(Adresses[i]);
                    }
                    
                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine();
                    Console.WriteLine("Výpis všech uložených paneláků:");

                    for (int i = 0; i < TowerBlocks.Count; i++)
                    {
                        Console.Write("     -> {0}. panelák", i + 1);
                        WriteTowerBlocks(TowerBlocks[i]);
                    }

                    Console.WriteLine();
                    break;
            }
        }

        static void WriteDoors(HouseBuilder_Door door)
        {
            Console.WriteLine(" mají {0} metru na šířku, {1} metru na výšku a jsou " + ((door.TwoSided == false) ? "jednokřídlé." : "dvoukřídlé."), door.Width, door.Width);
        }

        static void WriteWindows(HouseBuilder_Window window)
        {
            Console.WriteLine(" typu {0} má šířku {1} metru a výšku {2} metru.", window.Name, window.Width, window.Height);
        }

        static void WriteHouses(HouseBuilder_House house)
        {
            string windowsHouse;

            if (house.Window2 == null)
            {
                windowsHouse = "jedno okno typu " + house.Window1.Name;
            }
            else if (house.Window1.Name == house.Window2.Name)
            {
                windowsHouse = "dvě okna typu " + house.Window1.Name;
            }
            else
            {
                windowsHouse = "jedno okno typu " + house.Window1.Name + " a jedno typu " + house.Window2.Name;
            }

            Console.WriteLine(" má šířku {0} metru a výšku {1} metru. Je tvořen " + ((house.Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {2}.", house.Width, house.Height, windowsHouse);
        }

        static void WriteFlats(HouseBuilder_Flat flat)
        {
            string windowsFlat;

            if (flat.Window2 == null)
            {
                windowsFlat = "jedno okno typu " + flat.Window1.Name;
            }
            else if (flat.Window1.Name == flat.Window2.Name)
            {
                windowsFlat = "dvě okna typu " + flat.Window1.Name;
            }
            else
            {
                windowsFlat = "jedno okno typu " + flat.Window1.Name + " a jedno typu " + flat.Window2.Name;
            }

            Console.WriteLine(" má šířku {0} metru a výšku {1} metru. Je tvořen " + ((flat.Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {2}.", flat.Width, flat.Height, windowsFlat);
        }

        static void WriteFloors(HouseBuilder_Floor floor)
        {
            string windowsFlat;

            Console.WriteLine(" má číslo {0} ({1}) a jsou na něm následující byty: ", floor.FloorNumber, floor.FloorDescription);

            for (int i = 0; i < floor.Flat.Count; i++)
            {
                if (floor.Flat[i].Window2 == null)
                {
                    windowsFlat = "jedno okno typu " + floor.Flat[i].Window1.Name;
                }
                else if (floor.Flat[i].Window1.Name == floor.Flat[i].Window2.Name)
                {
                    windowsFlat = "dvě okna typu " + floor.Flat[i].Window1.Name;
                }
                else
                {
                    windowsFlat = "jedno okno typu " + floor.Flat[i].Window1.Name + " a jedno typu " + floor.Flat[i].Window2.Name;
                }

                Console.WriteLine("          -> {0}. byt má šířku {1} metru a výšku {2} metru. Je tvořen " + ((floor.Flat[i].Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {3}.", i + 1, floor.Flat[i].Width, floor.Flat[i].Height, windowsFlat);
            }
        }

        static void WriteAdresses(HouseBuilder_Adress adress)
        {
            Console.WriteLine(" je: {0} {1}, {2}, {3}", adress.Adress, adress.HouseNumber, adress.City, adress.PostalCode);
        }

        static void WriteTowerBlocks(HouseBuilder_TowerBlock towerBlock)
        {
            string windowsFlat;

            Console.WriteLine(" má adresu: {0} {1}, {2}, {3} a má tyto patra:", towerBlock.Adress.Adress, towerBlock.Adress.HouseNumber, towerBlock.Adress.City, towerBlock.Adress.PostalCode);

            for (int i = 0; i < towerBlock.Floors.Count; i++)
            {
                Console.WriteLine("          -> {0}. patro s číslem {0} ({1}) jsou na něm následující byty: ", i + 1, towerBlock.Floors[i].FloorNumber, towerBlock.Floors[i].FloorDescription);

                for (int j = 0; j < towerBlock.Floors[i].Flat.Count; j++)
                {
                    if (towerBlock.Floors[i].Flat[j].Window2 == null)
                    {
                        windowsFlat = "jedno okno typu " + towerBlock.Floors[i].Flat[j].Window1.Name;
                    }
                    else if (towerBlock.Floors[i].Flat[j].Window1.Name == towerBlock.Floors[i].Flat[j].Window2.Name)
                    {
                        windowsFlat = "dvě okna typu " + towerBlock.Floors[i].Flat[j].Window1.Name;
                    }
                    else
                    {
                        windowsFlat = "jedno okno typu " + towerBlock.Floors[i].Flat[j].Window1.Name + " a jedno typu " + towerBlock.Floors[i].Flat[j].Window2.Name;
                    }

                    Console.WriteLine("               -> {0}. byt má šířku {1} metru a výšku {2} metru. Je tvořen " + ((towerBlock.Floors[i].Flat[j].Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {3}.", j + 1, towerBlock.Floors[i].Flat[j].Width, towerBlock.Floors[i].Flat[j].Height, windowsFlat);
                }
            }
        }
    }
}
