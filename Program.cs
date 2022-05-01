using System;

namespace Inventory_Problem
{
    class Program
    {
        static int RN(int Range)
        {
            return (new Random()).Next(Range);
        }

        static void Main(string[] args)
        {
            int[] Stock = new int[15];
            int[] CStock = new int[15];
            int[] LD = new int[15];
            int[] RNofLD = new int[15];
            int[] Order1 = new int[15];
            int[] Date1 = new int[15];
            int D1 = 0;
            int[] Order2 = new int[15];
            int[] Date2 = new int[15];
            int D2 = 0;
            int[] RNofDemd = new int[15];
            int[] Demd = new int[15];
            int[] CDemd = new int[15];
            int[] Shortage = new int[15];
            int[] CShortage = new int[15];
            Stock[0] = 10;
            CStock[0] = 10;
            CShortage[0] = 0;

                        for (int i = 1; i < 15; i++)
            {
                RNofLD[i] = RN(100);
            }
            for (int i = 0; i < 15; i++)
            {
                if (RNofLD[i] < 20)
                {
                    LD[i] = 2;
                }
                else
                if (RNofLD[i] < 80)
                {
                    LD[i] = 3;
                }
                else
                    LD[i] = 4;
            }


                        for (int i = 1; i < 15; i++)
            {
                RNofDemd[i] = RN(100);
            }

            for (int i = 0; i < 15; i++)
            {
                if (RNofDemd[i] < 15)
                {
                    Demd[i] = 3;
                }
                else
                if (RNofDemd[i] < 45)
                {
                    Demd[i] = 4;
                }
                else
                if (RNofDemd[i] < 80)
                {
                    Demd[i] = 5;
                }
                else
                    Demd[i] = 6;

            }
            CDemd[0] = Demd[0];
            for (int i = 1; i < 15; i++)
            {
                CDemd[i] = Demd[i] + CDemd[i - 1];
            }


            int LDCounter = 0;
            int DayNumber = 1;
            int LiveStock = 15;
              for (int i = 0; i < 15; i++)
            {


                
                if (DayNumber == D1)
                {
                    D1 = 0;
                    LiveStock += 15;
                }
                if (DayNumber == D2)
                {
                    D2 = 0;
                    LiveStock += 15;
                }

               
                if (D1 == 0)
                {
                    if (LiveStock <= 10)
                    {
                        Order1[i] = 15;
                        D1 = LD[LDCounter] + DayNumber;
                        LDCounter++;
                    }
                }

              
                if (D2 == 0)
                {
                    if (LiveStock <= 5)
                    {
                        Order2[i] = 15;
                        D2 = LD[LDCounter] + DayNumber;
                        LDCounter++;
                    }
                }


                Stock[i] = LiveStock;

               
                if (i < 14)
                {
                    if (Stock[i] > Demd[i])
                    {
                        LiveStock -= Demd[i];
                        Shortage[i] = 0;
                    }
                    else
                    {
                        Shortage[i] = Demd[i] - LiveStock;
                        LiveStock = 0;
                    }
                }


                Date1[i] = D1;
                Date2[i] = D2;
                DayNumber++;
            }


            
            CStock[0] = Stock[0];
            for (int i = 1; i < 15; i++)
            {
                CStock[i] = Stock[i] + CStock[i - 1];
            }

           
            for (int i = 1; i < 15; i++)
            {
                CShortage[i] = Shortage[i] + CShortage[i - 1];
            }

           

            
            Console.WriteLine("Day  Stock  CStock  Order1    Date1     Order2  Date2  Demd  CDemd  Shortage  CShortage");
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"{i + 1}\t{Stock[i]}\t{CStock[i]}\t{Order1[i]}\t{Date1[i]}\t{ Order2[i]}\t{ Date2[i]}\t{ Demd[i]}\t{ CDemd[i]}\t  {Shortage[i]}\t  {CShortage[i]}");
                Console.WriteLine();
            }

            Console.WriteLine($"Average Stock = CStock/No.Of Days = {CStock[14] / 15}");
            Console.WriteLine($"Service Level = (CDemd-CShortage)/CDemd = {(CDemd[14] - CShortage[14]) * 100 / CDemd[14]}%");
        }
    }
}
