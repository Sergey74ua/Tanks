using System;
using System.Threading.Tasks;

namespace Tanks
{
    class Sound
    {
        //Звук выстрела
        async public static void Shot()
        {
            await Task.Run(() => Console.Beep(400, 50));
        }

        //Звук взрыва
        async public static void Bang()
        {
            await Task.Run(() => Console.Beep(100, 100));
        }

        //Музыкальная заставка
        async public static void StarWars()
        {
            await Task.Run(() =>
            {
                Console.Beep(440, 500);
                Console.Beep(440, 500);
                Console.Beep(440, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 1000);
                Console.Beep(659, 500);
                Console.Beep(659, 500);
                Console.Beep(659, 500);
                Console.Beep(698, 350);
                Console.Beep(523, 150);
                Console.Beep(415, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 1000);
            });
        }
    }
}
