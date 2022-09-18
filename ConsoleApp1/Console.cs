using System;
using System.Threading;
using static System.Console;

namespace ConsoleApp1
{
    class Console
    {
        private static string[] menuOptions =
                  {"Value type / Tipos de valor",
                    "Reference type / Tipos de referencia",
                    "Diferencias Valor VS Referencia",
                    "Stack",
                    "Heap",
                    "Diferencias Stack VS Heap",
                    "Boxing",
                    "Unboxing",
                    "Diferencias Boxing VS Unboxing",
                    "Salir"};

     
        static void Main(string[] args)
        {
            bool loop = true;
            int counter = 0;
            ConsoleKeyInfo tecla;

            int x = CursorLeft;
            int y = CursorTop;

            string resultado = SettingMenu(menuOptions, counter);

            while (loop)
            {
                tecla = Navegation(ref counter, x, y, ref resultado);
                string description;

                switch (counter)
                {   
                    //Value type / Tipos de valor
                    case 0:
                        description =   "Los tipos de datos llamados “por valor” son tipos sencillos que almacenan un \n" +
                                        "dato concreto y que se almacenan en la pila. Por ejemplo, los tipos primitivos de \n" +
                                        ".NET como int o bool, las estructuras o las enumeraciones.";
                        SetContent(counter, description);
                        break;
                    //Reference type / Tipos de referencia
                    case 1:
                        description =   "Los tipos “por referencia” son todos los demás, y en concreto todas las clases \n" +
                                        "de objetos en .NET, así como algunos tipos primitivos que no tienen un tamaño determinado \n" +
                                        "(como las cadenas).Estos tipos de datos se alojan siempre en el montón, por lo que la gestión \n" +
                                        "de la memoria que ocupan es más compleja, y el uso de los datos es menos eficiente \n" + 
                                        "(y de menor rendimiento) que con los tipos por valor.";
                        SetContent(counter, description);
                        break;
                    //Diferencias Valor VS Referencia
                    case 2:
                        description = default;
                        SetContent(counter, description);
                        break;
                    //Stack
                    case 3:
                        description =   "Es una zona de memoria reservada para almacenar información de uso inmediato \n" +
                                        "por parte del hilo de ejecución actual del programa. Por ejemplo, cuando se llama\n" +
                                        "a una función se reserva un bloque en la parte superior de esta zona de memoria \n" +
                                        "(de la pila) para almacenar los parámetros y demás variables de ámbito local. \n" +
                                        "Cuando se llama a la siguiente función este espacio se “libera”";
                        SetContent(counter, description);
                        break;
                    //Heap
                    case 4:
                        description =   "Es una zona de memoria reservada para poder asignarla de manera dinámica.\n" +
                                        "Al contrario que en el stack no existen “normas” para poder asignar o desasignar \n" +
                                        "información en el montón, pudiendo almacenar y eliminar datos en cualquier momento, \n" + 
                                        "lo cual hace más complicada la gestión de la memoria en esta ubicación.";
                        SetContent(counter, description);
                        break;
                    //Diferencias Stack VS Heap
                    case 5:
                        description =   "Finalmente, hemos mencionado que el stack se limpia solo al salir de la función,\n" +
                                        "en el heap no, es el desarrollador el que tiene que limpiar el heap.";
                        SetContent(counter, description);
                        break;
                    //Boxing
                    case 6:
                        description =   "Lo que hacemos es asignar un tipo por valor a una variable pensada para albergar un \n" +
                                        "tipo por referencia compatible.En este caso object es la clase base de todas las demás, \n" +
                                        "así que se le puede asignar cualquier cosa a la variable obj:\n" +
                                        "int num = 1;\n" +
                                        "object obj = num;";
                        SetContent(counter, description);
                        break;
                    //Unboxing
                    case 7:
                        description =   "Se produce cuando el tipo por referencia se convierte o se asigna a un tipo por \n" +
                                        "valor de nuevo. Forzaríamos un unboxing con una situación así:\n" +
                                        "object obj = 3;\n" +
                                        "int num2 = (int)obj;";
                        SetContent(counter, description);
                        break;
                    //Diferencias Boxing VS Unboxing
                    case 8:
                        description =   "Boxing = De valor a referencia\n" + 
                                        "Unboxing = De referencia a valor";
                        SetContent(counter, description);
                        break;
                    //Salir
                    case 9:
                        WriteLine("Adios!!");
                        Thread.Sleep(1000);
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SetContent(int counter, string description)
        {
            var tittle = menuOptions.GetValue(counter);
            WriteLine("-------------------------------------------------------------------------------");
            WriteLine(tittle + "\n");
            WriteLine(description);
            WriteLine("-------------------------------------------------------------------------------");
            ShowingMenuAfterSelection(counter);
        }
        private static void ShowingMenuAfterSelection(int counter)
        {
            WriteLine("\n \n Presione cualquier tecla para volver a navegar");
            ReadKey();
            Clear();
            SettingMenu(menuOptions, counter);
        }
        private static ConsoleKeyInfo Navegation(ref int counter, int x, int y, ref string resultado)
        {
            ConsoleKeyInfo tecla;
            while ((tecla = ReadKey(true)).Key != ConsoleKey.Enter)
            {
                switch (tecla.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (counter > menuOptions.Length - 2) continue;
                        counter++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (counter == 0) continue;
                        counter--;
                        break;
                    default:
                        break;
                }

                CursorLeft = x;
                CursorTop = y;

                resultado = SettingMenu(menuOptions, counter);

            }

            return tecla;
        }
        private static string SettingMenu(string[] items, int option)
        {
            CursorVisible = false;
            WriteLine("Selecciona una opción:" + Environment.NewLine);

            
            string currentSelection = string.Empty;
            int selected = 0;

            Array.ForEach(items, element =>
           {
               if (selected == option)
               {
                   ForegroundColor = ConsoleColor.Yellow;
                   BackgroundColor = ConsoleColor.Red;
                   WriteLine(" > " + element + " < ");
                   ForegroundColor = ConsoleColor.White;
                   BackgroundColor = ConsoleColor.Black;
                   currentSelection = element;
               }
               else
               {
                   Write(new string(' ', WindowWidth));
                   CursorLeft = 0;
                   WriteLine(element);
               }
               selected++;
           });
            return currentSelection;
        }
    }
}

