using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Coding_Dojo_01
{
    class Program
    {
        private const string APP_NAME = "TempConvert";
        private const char MENU_CELSIUS = 'c';
        private const char MENU_FAHRENHEIT = 'f';
        private const char MENU_KELVIN = 'k';
        private const char MENU_REAMUR = 'r';

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to {0}!", APP_NAME);
       
            do
            {
                PrintMenu();

                char selection = Console.ReadKey().KeyChar;
                if (selection != MENU_CELSIUS &&
                    selection != MENU_FAHRENHEIT &&
                    selection != MENU_KELVIN &&
                    selection != MENU_REAMUR)
                {
                    break;
                }

                Console.Write("\n\nTemperature to convert: ");

                float temperature = 0;
                bool conversionOk = float.TryParse(Console.ReadLine(), out temperature);

                if (!conversionOk)
                {
                    Console.WriteLine("\nThe supplied value is not valid! Exiting now.");

                }

                float celsius = 0;
                float fahrenheit = 0;
                float kelvin = 0;
                float reamur = 0;
                // first convert to celsius
                switch (selection)
                {
                    case MENU_CELSIUS:
                        celsius = temperature;
                        break;

                    case MENU_FAHRENHEIT:
                        celsius = ConvertFahrenheitToCelsius(temperature);
                        break;
                    case MENU_KELVIN:
                        celsius = ConvertKelvinToCelsisus(temperature);
                        break;
                    case MENU_REAMUR:
                        celsius = ConvertReamurToCelsius(temperature);
                        break;
                }

                fahrenheit = ConvertCelsiusToFahrenheit(celsius);
                kelvin = ConvertCelsiusToKelvin(celsius);
                reamur = ConvertCelsiusToReamur(celsius);

                PrintTemperatures(celsius, fahrenheit, kelvin, reamur);

                Console.Write("\n\nOnce again?[y/n]");

            } while (Console.ReadKey().KeyChar == 'y');

            Console.WriteLine("\n\nThank you for using {0}. Bye!", APP_NAME);

        }

        private static void PrintMenu()
        {
            Console.WriteLine("\nConvert from");
            Console.WriteLine("\t{0}: Celsius", MENU_CELSIUS);
            Console.WriteLine("\t{0}: Fahrenheit", MENU_FAHRENHEIT);
            Console.WriteLine("\t{0}: Kelvin", MENU_KELVIN);
            Console.WriteLine("\t{0}: Reamur", MENU_REAMUR);
            Console.WriteLine("\nPress any other key to exit");
        }

        private static void PrintTemperatures(float celsius, float fahrenheit, float kelvin, float reamur)
        {
            Console.WriteLine("Convertion results");
            Console.WriteLine("\t{0}° Celsius", celsius);
            Console.WriteLine("\t{0}° Fahrenheit", fahrenheit);
            Console.WriteLine("\t{0} Kelvin", kelvin);
            Console.WriteLine("\t{0}° Reamur", reamur);
        }

        private static float ConvertCelsiusToFahrenheit(float c)
        {
            return c * 1.8f + 32;
        }

        private static float ConvertCelsiusToKelvin(float c)
        {
            return c + 273.15f;
        }

        private static float ConvertCelsiusToReamur(float c)
        {
            return c * 0.8f;
        }

        private static float ConvertFahrenheitToCelsius(float f)
        {
            return (f - 32) * (5f / 9f);
        }

        private static float ConvertKelvinToCelsisus(float k)
        {
            return k - 273.15f;
        }

        private static float ConvertReamurToCelsius(float r)
        {
            return r * 1.25f;
        }
    }
}
