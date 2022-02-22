using System;


namespace Enums
{
    
    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello enum");


            Directions directions;
            for(int i = 0; i < 10; i++)
            {
                directions = RandomDirection();
                Console.Write($"({directions})");
                PrintDirection(directions);
            }

            Console.WriteLine();
            Temp temp;
            for (int i = 0; i < 10; i++)
            {
                temp = RandomTemp();
                Console.Write(temp + " ");
                PrintTemp(temp);
            }
        }
        private static Directions RandomDirection()
        {
            Directions[] val = (Directions[])Enum.GetValues(typeof(Directions));
            return (Directions)val[rnd.Next(val.Length)];
        }

        private static Temp RandomTemp()
        {
            Temp[] val = (Temp[])Enum.GetValues(typeof(Temp));
            return (Temp)val[rnd.Next(val.Length)];
        }

        public static void PrintTemp(Temp temp)
        {
            if (!Enum.IsDefined(temp.GetType(), temp))
            {
                throw new ArgumentOutOfRangeException(
                    $"Value {temp} out of Enum");
            }
            String img = String.Empty;

            switch (temp)
            {
                case Temp.Cold: img = "10 ^C"; break;
                case Temp.Warm: img = "40 ^C"; break;
                case Temp.Hot: img = "60 ^C"; break;
            }
            Console.WriteLine(img);
        }

        private static void PrintDirection(Directions directions)
        {
            // Проверка на допустимые значения
            if( ! Enum.IsDefined(directions.GetType(), directions)) {
                throw new ArgumentOutOfRangeException($"Value {directions} out of Enum");
            }
            String img = String.Empty;
            switch (directions)
            {
                case Directions.Left: img = "<"; break;
                case Directions.Right: img = ">"; break;
                case Directions.Up: img = "^"; break;
                case Directions.Down: img = "v"; break;
            }
            Console.WriteLine(img);
        }
    }
}