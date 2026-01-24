using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKTriggerCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
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
