namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{"Этот компьютер",60}");
            Console.WriteLine("".PadRight(120, '-'));

            int position = 2;
            int upperbound = 2;
            int lowerbound = DriveInfo.GetDrives().Count();

            ConsoleKeyInfo key;

            do
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();

                foreach (DriveInfo driver in allDrives)
                {
                    Console.Write($"->{driver.Name}\tФормат диска: {driver.DriveFormat}\tСвободное место: {driver.AvailableFreeSpace / 1073741824} ГБ из {driver.TotalSize / 1073741824} ГБ");
                }

                key = Console.ReadKey(true);

                position = Arrows(key, position, upperbound, lowerbound);

            } while (true);
        }

        static void Explorer()
        {

        }

        public static int Arrows(ConsoleKeyInfo key, int position, int upperBound, int lowerBound) // Метод стрелочек - прекрасно работает, нужно ограничить
        {
            int prevPosition = 2;

            if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W))
            {
                if (position == upperBound)
                {
                    position = upperBound;
                    prevPosition = upperBound;
                }

                else
                {
                    prevPosition = position;
                    position--;
                }
            }

            else if ((key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
            {
                if (position == lowerBound)
                {
                    position = lowerBound;
                    prevPosition = lowerBound;
                }

                else
                {
                    prevPosition = position;
                    position++;
                }
            }

            Console.SetCursorPosition(0, prevPosition);
            Console.Write("  ");
            Console.SetCursorPosition(0, position);
            Console.Write("->");

            return position;
        }
    }
}