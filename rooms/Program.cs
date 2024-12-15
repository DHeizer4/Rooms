namespace rooms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] map = new int[4, 4];

            XYCoordinate player = new XYCoordinate(0,0);
            XYCoordinate noRule = new XYCoordinate(-1,-1);

            List<MovementRule> rules = new List<MovementRule>();
            MovementRule rule = new MovementRule(new XYCoordinate(0,0), noRule, noRule, noRule, new XYCoordinate(3,0));
            rules.Add(rule);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"player position: {player.X}, {player.Y}");

                DisplayMap(player.X, player.Y, map);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                bool wasExecuted = ExecuteMovementRules(keyInfo, player, map, rules);

                NormalMovement(keyInfo, player, map);
            }
        }

        public static void DisplayMap(int playerX, int playerY, int[,] map)
        {
            int mapMaxHeight = (map.GetLength(1) * 2) + 1;
            int mapMaxWidth = (map.GetLength(0) * 2) + 1;

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    //if ((x == 0 && y == 0) || (x == mapMaxWidth - 1 && y == 0) || (x == 0 && y == mapMaxHeight - 1) || (x == mapMaxWidth - 1 && y == mapMaxHeight - 1))
                    //{
                    //    Console.Write("+");
                    //}
                    //else if (y == 0)
                    //{
                    //    Console.Write("-");
                    //}
                    //else if (x == 0)
                    //{
                    //    Console.Write("|");
                    //}



                    if (x == playerX && y == playerY)
                    {
                        Console.Write("P");
                    }
                    else
                    {
                        Console.Write(map[y, x]);
                    }
                }
                Console.WriteLine();
            }
        }

        public static void NormalMovement(ConsoleKeyInfo keyInfo, XYCoordinate player, int[,] map)
        {
            if (keyInfo.Key == ConsoleKey.W)
            {
                if (player.Y > 0)
                {
                    player.Y--;
                }
            }

            if (keyInfo.Key == ConsoleKey.S)
            {
                if (player.Y < map.GetLength(1) - 1)
                {
                    player.Y++;
                }
            }

            if (keyInfo.Key == ConsoleKey.A)
            {
                if (player.X > 0)
                {
                    player.X--;
                }
            }

            if (keyInfo.Key == ConsoleKey.D)
            {
                if (player.X < map.GetLength(1) - 1)
                {
                    player.X++;
                }
            }
        }

        public static bool ExecuteMovementRules(ConsoleKeyInfo keyInfo, XYCoordinate player, int[,] map, List<MovementRule> rules)
        {
            bool wasExecuted = false;

            foreach (MovementRule rule in rules)
            {
                if (player.X == rule.Location.X && player.Y == rule.Location.Y)
                {

                    if (keyInfo.Key == ConsoleKey.W) // UP
                    {
                        if (rule.Up.X != -1 && rule.Up.Y != -1)
                        {
                            player.X = rule.Up.X;
                            player.Y = rule.Up.Y;
                            wasExecuted = true;
                        }
                    }

                    if (keyInfo.Key == ConsoleKey.S) // UP
                    {
                        if (rule.Down.X != -1 && rule.Down.Y != -1)
                        {
                            player.X = rule.Down.X;
                            player.Y = rule.Down.Y;
                            wasExecuted = true;
                        }
                    }

                    if (keyInfo.Key == ConsoleKey.A) // Left
                    {
                        if (rule.Left.X != -1 && rule.Left.Y != -1)
                        {
                            player.X = rule.Left.X;
                            player.Y = rule.Left.Y;
                            wasExecuted = true;
                        }
                    }

                    if (keyInfo.Key == ConsoleKey.D) // Right
                    {
                        if (rule.Right.X != -1 && rule.Right.Y != -1)
                        {
                            player.X = rule.Right.X;
                            player.Y = rule.Right.Y;
                            wasExecuted = true;
                        }
                    }

                }



            }





            return wasExecuted;
        }


    }

    public class XYCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public XYCoordinate(int x, int y)
        {
            X = x; 
            Y = y;   
        }
    }

    public class MovementRule
    {
        public XYCoordinate Location { get; set; }
        public XYCoordinate Up { get; set; }
        public int UpCount { get; set; }
        public XYCoordinate Down { get; set; }
        public int DownCount { get; set; }
        public XYCoordinate Left { get; set; }
        public int LeftCount { get; set; }
        public XYCoordinate Right { get; set; }
        public int RightCount { get; set; }

        public MovementRule(XYCoordinate location, XYCoordinate upRule, XYCoordinate downRule, XYCoordinate leftRule, XYCoordinate rightRule)
        {
            Location = location;
            Up = upRule;
            Down = downRule;
            Left = leftRule;
            Right = rightRule;
        }

    }
}

