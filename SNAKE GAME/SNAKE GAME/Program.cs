using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE_GAME
{
    class Program
    {
        #region FUNCTION METHODS
        static void buildwall()
        {
            for (int i = 1; i < 31; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(70, i);
                Console.Write("#");
            }
            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(i, 30);
                Console.Write("#");
            }
        }
        private static bool DidSnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 30) return true; return false;
        }
        private static void setApplePositionOnScreen(Random random, out int applexdim, out int appleydim)
        {
            applexdim = random.Next(0 + 2, 70 - 2);
            appleydim = random.Next(0 + 2, 30 - 2);
        }
        private static void paintApple(int applexdim, int appleydim)
        {
            Console.SetCursorPosition(applexdim, appleydim);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((char)64);
        }

        private static bool determineifapplewaseaten(int xPosition, int yPosition, int applexdim, int appleydim)
        {
            if (xPosition == applexdim && yPosition == appleydim) return true; return false;
        }

        //make snake longer and paint the snake
        private static void paintsnake(int appleseaten, int[] xPositionin, int[] yPositionin, out int[] xPositionout, out int[] yPositionout)
        {
            //paint the head
            Console.SetCursorPosition(xPositionin[0], yPositionin[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((char)214);
            //paint the body
            for (int i = 1; i < appleseaten + 1; i++)
            {
                Console.SetCursorPosition(xPositionin[i], yPositionin[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }
            //erase last part of snake
            Console.SetCursorPosition(xPositionin[appleseaten + 1], yPositionin[appleseaten + 1]);

            Console.WriteLine(" ");
            //record location of each body part
            for (int i = appleseaten + 1; i > 0; i--)
            {
                xPositionin[i] = xPositionin[i - 1];
                yPositionin[i] = yPositionin[i - 1];
            }
            //return new array
            xPositionout = xPositionin;
            yPositionout = yPositionin;
            // end  paint the snake
        }
        #endregion

        static bool gamemenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\tWELCOME TO THE SNAKE GAME");
            Console.WriteLine("\nEnjoy your Game and Achieve Maximum Score ");
            Console.WriteLine("\nChoose an Option:");
            Console.WriteLine("1) TO READ INSTRUCTIONS");
            Console.WriteLine("2) TO PLAY THE GAME");
            Console.WriteLine("3) TO EXIT THE PROGRAM");
            Console.Write("\r\nSelect an option you want to Perform: ");

            switch (Console.ReadLine())
            {

                case "1":
                    Console.Clear();
                    buildwall();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(5, 4);
                    Console.WriteLine("1)There is a 4 size Playing Field Border.");
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("2)Use your Arrow Keys to move Snake around the Field.");
                    Console.SetCursorPosition(5, 6);
                    Console.WriteLine("3)Snake will Die if it Hits the Wall.");
                    Console.SetCursorPosition(5, 7);
                    Console.WriteLine("4)You will gain Points By Eating Apple.");
                    Console.SetCursorPosition(5, 8);
                    Console.WriteLine("5)By Eating Apple your Snake get Bigger and Faster.");
                    Console.SetCursorPosition(5, 9);
                    Console.WriteLine("6)On Eating One Apple you Get 100 Points.");
                    Console.SetCursorPosition(5, 10);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press Enter to Return to Main Menu");
                    Console.SetCursorPosition(5, 11);
                    Console.ReadLine();
                    Console.Clear();

                    return true;
                case "2":
                    Console.Clear();
                    buildwall();


                    #region var
                    int[] xPosition = new int[50];
                    xPosition[0] = 35;
                    int[] yPosition = new int[50];
                    yPosition[0] = 20;
                    int applexdim = 10;
                    int appleydim = 10;
                    int appleseaten = 0;


                    decimal gamespeed = 150m;


                    bool isgameon = true;
                    bool iswallhit = false;
                    bool isappleeaten = false;

                    Random random = new Random();

                    Console.CursorVisible = false;
                    #endregion
                    #region GAME SETUP
                    //GET THE SNAKE TO APPEAR ON SCREEN

                    Console.SetCursorPosition(xPosition[0], yPosition[0]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine((char)214);

                    //set apple on screen

                    setApplePositionOnScreen(random, out applexdim, out appleydim);
                    paintApple(applexdim, appleydim);

                    //build a boundary
                    buildwall();

                    //get snake to move

                    ConsoleKey command = Console.ReadKey().Key;
                    #endregion

                    do
                    {
                        #region CHANGE DIRECTIONS
                        switch (command)
                        {
                            case ConsoleKey.LeftArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.Write(" ");
                                xPosition[0]--;
                                break;

                            case ConsoleKey.UpArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.Write(" ");
                                yPosition[0]--;
                                break;

                            case ConsoleKey.RightArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.Write(" ");
                                xPosition[0]++;
                                break;

                            case ConsoleKey.DownArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.Write(" ");
                                yPosition[0]++;
                                break;
                        }
                        #endregion
                        //paint the snake
                        #region PLAYING GAME
                        paintsnake(appleseaten, xPosition, yPosition, out xPosition, out yPosition);




                        iswallhit = DidSnakeHitWall(xPosition[0], yPosition[0]);

                        //detect when snake hit boundary

                        if (iswallhit)
                        {
                            isgameon = false;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(15, 19);
                            Console.WriteLine("GAME OVER");
                            Console.SetCursorPosition(15, 20);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Your Snake Hit the Wall and Died.");

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(15, 21);
                            Console.Write("Your score is " + (appleseaten * 100) + " !");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(15, 22);
                            Console.WriteLine("Press Enter to Continue");
                            appleseaten = 0;
                            Console.ReadLine();
                            Console.Clear();
                        }
                        //detect when apple was eaten

                        isappleeaten = determineifapplewaseaten(xPosition[0], yPosition[0], applexdim, appleydim);

                        //Place apple on board randomly
                        if (isappleeaten)
                        {
                            setApplePositionOnScreen(random, out applexdim, out appleydim);
                            paintApple(applexdim, appleydim);
                            //keep track of how many apples were eaten
                            appleseaten++;

                            //make snake faster
                            gamespeed *= .925m;
                        }


                        if (Console.KeyAvailable) command = Console.ReadKey().Key;
                        //slow down the game
                        System.Threading.Thread.Sleep(Convert.ToInt32(gamespeed));
                        #endregion
                    }
                    while (isgameon);



                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }


        static void Main(string[] args)
            {
                bool menu = true;
                while (menu)
                {
                    menu = gamemenu();
                }








                //make snake longer



                //build welcome screen

                //give player option to read direction

                //show score

                //give player option to replay the game



            }


        }
    }
