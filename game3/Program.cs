using System;
using System.Threading; // solution to make move my game at normal speed. i don't really understand but is the best solution, i found.


namespace game3
{
    struct element // 2 ways gathering data, struck and class. I tried class but it did not work. I find struck essier to understand and do. Btw i got inspired by the programing 2 class we had
    {
        public int x;
        public int y;
        public int speedx;
        public int speedy;
        public char symbol;
        public ConsoleColor color;
        public bool visible;
    }
    class Program
    {
        static bool done; //bool that will finish my game when I touch a red enemie or i get all the items
        

        static element character;
        static element[] enemies;
        static element[] items;

        static int numEnemies, numItems;
        static int leftItems;

        
        static int points;
        static Random generator;
       static string[] map =        // array that will do my map in the game, I tried 2D array, I found this easier
       {
        "##################################################",
        "#          #                             #       #",
        "#          #              #                      #",
        "#          #                                     #",
        "#          #                                     #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "#                                                #",
        "##################################################",
       };
        static int xMap, yMap;

        static void Main(string[] args)
        {
            start();

            while (!done)
            {
                
                Draw();
                movement();
                parameters();
                comfirmgamestate();
                pause();
            }
        }
        private static void start()
        {
            done = false;
            xMap = 10;
            yMap = 2;
            generator = new Random();

            character.x = 40; character.y = 12;
            character.color = ConsoleColor.Yellow;
            character.symbol = 'A';

            numEnemies = 3;
            enemies = new element[numEnemies];
            for(int i = 0; i < numEnemies; i++)
            {
                enemies[i].x = generator.Next(10, 50);
                enemies[i].y = i * 5 + 3;
                enemies[i].color = ConsoleColor.Red;
                enemies[i].symbol = 'X';
                enemies[i].speedx = 1;
            }
            numItems = 20;
            leftItems = numItems;
            items = new element[numItems];
            for (int i = 0; i < numItems; i++)
            {
                do
                {
                    items[i].x = generator.Next(10, 55);
                    items[i].y = generator.Next(2, 20);

                } while (!movement(items[i].x, items[i].y));
                items[i].color = ConsoleColor.Cyan;
                items[i].symbol = 'O';
                items[i].visible = true;
            }
            points = 0;
        }
        private static void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(30,1);
            Console.WriteLine("Welcome to TRAPPED");
            Console.SetCursorPosition(70, 1);
            Console.Write("Intructions: Get all the gemstones in blue and ");
            Console.SetCursorPosition(70, 2);
            Console.Write("avoid the three monsters in red. ");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < map.Length; i++)
            {
                Console.SetCursorPosition(xMap, yMap + i);
                Console.WriteLine(map[i]); 
            }

            Console.ForegroundColor = character.color;
            Console.SetCursorPosition(character.x,character.y);
            Console.Write(character.symbol);

            for (int i = 0; i < numEnemies; i++)
            {
                Console.ForegroundColor = enemies[i].color;
                Console.SetCursorPosition(enemies[i].x, enemies[i].y);
                Console.Write("X");
            }
            for (int i = 0; i < numItems; i++)
            {
                if (items[i].visible)
                {
                    Console.ForegroundColor = items[i].color;
                    Console.SetCursorPosition(items[i].x, items[i].y);
                    Console.Write("O");
                }
            }
            
            Console.CursorVisible = false;
            Console.SetCursorPosition(1, 1);
            Console.Write("Points: " + points);
        }
        private static void movement()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if ((tecla.Key == ConsoleKey.LeftArrow && (movement(character.x - 1, character.y))))
                {
                    character.x--;
                }
                if ((tecla.Key == ConsoleKey.RightArrow && (movement(character.x + 1, character.y))))
                {
                    character.x++;
                }
                if ((tecla.Key == ConsoleKey.UpArrow) && (movement(character.x, character.y - 1)))
                {
                    character.y--;
                }
                if ((tecla.Key == ConsoleKey.DownArrow && (movement(character.x, character.y + 1))))
                {
                    character.y++;
                }
                    
            }
        }
        private static void parameters()
        {
            for (int i = 0; i < numEnemies; i++)
            {

                enemies[i].x += enemies[i].speedx;
                if ((enemies[i].x > 58) || (enemies[i].x < 11))
                {
                    enemies[i].speedx = -enemies[i].speedx;
                }
            }
        }
        private static void comfirmgamestate()
        {
            for (int i = 0; i < numEnemies; i++)
            {
                if ((character.x == enemies[i].x) && (character.y == enemies[i].y))
                {
                    done = true;
                }
            }
            for (int i = 0; i < numItems; i++)
            {
                if ((character.x == items[i].x) && (character.y == items[i].y) && items[i].visible)
                {
                    points += 10;
                    items[i].visible = false;
                    leftItems--;
                    if (leftItems <= 0)
                    {
                        done = true;
                    }
                        
                }
            }
                
            
            
            
        }
        private static void pause()// again solution I found on internet to make my move normal speed since consoleKeyavailable was giving me trouble.
        {
            Thread.Sleep(100);
        }
        private static bool movement(int x, int y)
        {
            x -= xMap;
            y -= yMap;

            try 
            {
                if (map[y][x] == '#')
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        
    }//Larry i was doing comments on my code so you read them and see that i uderstand, but i got tired and I had a rough week so screew that, I wanna go sleep. I overworked on this too much and now im dead. So If you need more explanation about it because ik i used struck which we neve learned. ask me I will be more than happy to try explain what I learned in this proyect that gave me headache.
    // honestly it took me a long time to do this bad game, because it was a game where I expand more my knowledge instead of using well the content we saw in class. 
    // Anyways Larry have a good winter break. I did not have the chance to tell you this in person. You were my best teacher i ever got until now. I don't even know why I am even commenting this because i might send you MIO saying this same message.
}
