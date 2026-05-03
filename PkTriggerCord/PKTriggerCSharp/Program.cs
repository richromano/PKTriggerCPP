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
            PKTriggerCord.PKTriggerCordDLL.pslr_set_verbosity(0);
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

                    PKTriggerCord.PslrRational shutter_speed;
                    shutter_speed.nom = 60;
                    shutter_speed.denom = 1;
                    //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 3, 0);
                    PKTriggerCord.PKTriggerCordDLL.pslr_shutter(camHandle);
                    Thread.Sleep(2000);

                    //PKTriggerCord.PKTriggerCordDLL.pslr_set_shutter(camHandle, shutter_speed);

                    //                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 13, 1);
                    //for(int i=0;i<3;i++)
                    //                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 4, 1);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 6);
                    //for (int i=9;i>-1;i--)
                    //for (int i = 1; i < 20; i++)
                    {
                        // Sensor cleaning
                        //                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 0, 0);
                        //PKTriggerCord.PKTriggerCordDLL.pslr_shutter(camHandle);
                        //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, i, 0);
                        //PKTriggerCord.PKTriggerCordDLL.pslr_bulb(camHandle, true);
                        //PKTriggerCord.PKTriggerCordDLL.pslr_shutter(camHandle);
                        //PKTriggerCord.PKTriggerCordDLL.pslr_bulb(camHandle, false);
                        //Thread.Sleep(2000);
                    }
                    //                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 1, 0);
                    //   Thread.Sleep(2000);
                    //}
                    //PKTriggerCord.PKTriggerCordDLL.pslr_shutter(camHandle);
                    //                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 13, 0);
                    //for(int i=-1;i<12;i++)
                    //                    for (int i = 20; i > 7; i--)
                    //                    for (int i = 0; i < 32; i--)
                    /*for (int i = 20; i > -1; i--)
                    {
                        PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, i, -1);
                        //Thread.Sleep(2000);
                    }*/
                    //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 13, 0);
                    //                    for (int i=0; i<32; i++)
                    //                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 2);
                    //                    PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, i);
                    //PKTriggerCord.PKTriggerCordDLL.pslr_button_test(camHandle, 5, 3);


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
