using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PKTriggerCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //PKTriggerCord.PKTriggerCordDLL.pslr_set_verbosity(0);
            // Example usage of PKTriggerCordDLL
            IntPtr camHandle = PKTriggerCord.PKTriggerCordDLL.pslr_init(null, null);
            if (camHandle != IntPtr.Zero)
            {
                int result = PKTriggerCord.PKTriggerCordDLL.pslr_connect(camHandle);
                if (result == 0)
                {
                    Console.WriteLine("Connected to camera successfully!");

                    // Get camera status
                    PKTriggerCord.PslrStatus status = new PKTriggerCord.PslrStatus();
                    result = PKTriggerCord.PKTriggerCordDLL.pslr_get_status(camHandle, ref status);
                    if (result == 0)
                    {
                        Console.WriteLine("Current ISO: " + status.current_iso);
                        Console.WriteLine("Current shutter speed: " + status.current_shutter_speed.nom + "/" + status.current_shutter_speed.denom);
                    }

                    //PKTriggerCord.PKTriggerCordDLL.pslr_bulb(camHandle, true);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_continuous(camHandle, true);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_shutter(camHandle);
                    //3 is continuous shooting
                    //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 3, 0);
                    //Thread.Sleep(2000);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 3, 0);
                                        int test = 1;
                                        {
                                            //PKTriggerCord.PKTriggerCordDLL.pslr_focus(camHandle);
                                            //Thread.Sleep(1000);
                                            Console.WriteLine("0");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 0, test);
                                            Thread.Sleep(1000);
                                            Console.WriteLine("1");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 1, test);
                                            Thread.Sleep(1000);
                                            Console.WriteLine("2");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 2, test);
                                            Thread.Sleep(1000);
                                            Console.WriteLine("4");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 4, test);
                                            Thread.Sleep(1000);
                                            Console.WriteLine("9");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 9, test);
                                            Thread.Sleep(1000);
                                            Console.WriteLine("11");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 11, test);
                                            Thread.Sleep(1000);
                        Console.WriteLine("12");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 12, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("13");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 13, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("14");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 14, test);
                                            Thread.Sleep(1000);
                                            Console.WriteLine("15");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 15, test);
                                            Thread.Sleep(1000);
                                            Console.WriteLine("16");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 16, test);
                                            Thread.Sleep(1000);
                                            Console.WriteLine("18");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 18, test);
                                            Thread.Sleep(1000);
                                            Console.WriteLine("19");
                                            PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 19, test);
                                        }
                    //PKTriggerCord.PKTriggerCordDLL.pslr_shutter(camHandle);
                    Console.WriteLine("5");
                    PKTriggerCord.PslrRational shutter_speed;
                    shutter_speed.nom = 10;
                    shutter_speed.denom = 1;
                    PKTriggerCord.PKTriggerCordDLL.pslr_set_shutter(camHandle, shutter_speed);

                    Console.WriteLine("5-1");
                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, -1);
                    Console.WriteLine("51");
                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 1);
                    Console.WriteLine("52");
                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 2);
                    Console.WriteLine("53");
                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 3);
                    Thread.Sleep(1000);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 3);
                    Console.WriteLine("50");
                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 0);
                    Console.WriteLine("5-1");
                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, -1);
                    Console.WriteLine("51");
                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 1);
                    Console.WriteLine("52");
                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 2);
                    Console.WriteLine("53");
                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 3);
                    /*for (int num = 0; num < 16; num++)
                    {
                        Console.WriteLine(num.ToString());
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, num);
                    }*/
                    test = -1;
                    {
                        //PKTriggerCord.PKTriggerCordDLL.pslr_focus(camHandle);
                        //Thread.Sleep(1000);
                        Console.WriteLine("0");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 0, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("1");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 1, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("2");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 2, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("4");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 4, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("9");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 9, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("11");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 11, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("12");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 12, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("13");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 13, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("14");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 14, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("15");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 15, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("16");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 16, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("18");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 18, test);
                        Thread.Sleep(1000);
                        Console.WriteLine("19");
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 19, test);
                    }
                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, -1);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 3, 4);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 3, 4);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 3, 2);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_shutter(camHandle);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_bulb(camHandle, false);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_continuous(camHandle, false);

                    for (int j = 20; j < 32; j++)
                        for (int i = -1; i < 4; i++)
                    {
                        Console.WriteLine(i.ToString()+" "+j.ToString());
                        Thread.Sleep(1000);
                       PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, j, i);
                    }

                    // Disconnect
                    PKTriggerCord.PKTriggerCordDLL.pslr_disconnect(camHandle);
                }
                else
                {
                    Console.WriteLine("Failed to connect to camera.");
                }
            }
            else
            {
                Console.WriteLine("Failed to initialize camera.");
            }
        }
    }
}
