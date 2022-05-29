﻿//////////////////////////////////
//      CLASE 9 - TAREA 6       //
// ALUMNO:  GIACOBINI GASTON    //
// FECHA:   25/05/2022          //
//////////////////////////////////

Console.Title = "PoloTic Cordoba - Tarea 6 - GIACOBINI GASTÓN 2022 - v2.0";

int ROWS = 3;
int COLUMNS = 9;
int WHITESPACE = 99;

Random RandomInt = new Random();

Console.WriteLine("\n");

for (int amountOfCartons = 0; amountOfCartons < 6; amountOfCartons++)
{
    int[,] carton = new int[ROWS, COLUMNS];

    // Generador de 12 espacios en blanco 2.0
    int whitespaces = 12;
    while (whitespaces > 0)
    {
        int randomRowIndex = RandomInt.Next(0, ROWS);
        int randomColumnIndex = RandomInt.Next(0, COLUMNS);

        int whitespacesInCurrentColumn = 0;
        for (int iRowChecker = 0; iRowChecker < ROWS; iRowChecker++)
            if (carton[iRowChecker, randomColumnIndex] == WHITESPACE)
                whitespacesInCurrentColumn++;

        int whitespacesInCurrentRow = 0;
        for (int iColumnChecker = 0; iColumnChecker < COLUMNS; iColumnChecker++)
            if (carton[randomRowIndex, iColumnChecker] == WHITESPACE)
                whitespacesInCurrentRow++;

        if (carton[randomRowIndex, randomColumnIndex] != WHITESPACE &&
            whitespacesInCurrentColumn <= 1 &&
            whitespacesInCurrentRow < 4)
        {
            carton[randomRowIndex, randomColumnIndex] = WHITESPACE;
            whitespaces--;
        }
    }
    /* Ejemplo de output
    ||=============================================||=============================================||
    ||              carton(antes):                 ||                 carton(despues):            ||
    ||=============================================||=============================================||
    || {                                           || {                                           ||
    ||     { 00, 00, 00, 00, 00, 00, 00, 00, 00 }, ||     { 00, ██, 00, 00, ██, ██, 00, ██, 00 }, ||
    ||     { 00, 00, 00, 00, 00, 00, 00, 00, 00 }, ||     { ██, 00, 00, ██, 00, ██, ██, 00, 00 }, ||
    ||     { 00, 00, 00, 00, 00, 00, 00, 00, 00 }  ||     { ██, 00, ██, 00, 00, 00, ██, 00, ██ }  || 
    || }                                           || }                                           ||
    ||=============================================||=============================================||
    */

    // Genero los numeros aleatorios para el carton respetando los huecos de las dos primeras filas
    for (int iRow = 0; iRow < ROWS; iRow++)
    {
        for (int iColumn = 0; iColumn < COLUMNS; iColumn++)
        {
            // Genero un numero aleatorio entre el rango de la columna actual
            int randomNumberForCarton = RandomInt.Next(
                (((iColumn == 0) ? 1 : 0) + (iColumn * 10)), // Min: 1 -> 10 -> 20 -> 30 -> ... -> 70 -> 80 
                (((iColumn == (COLUMNS - 1)) ? 11 : 10) + (iColumn * 10)) // Max 10 -> 20 -> 30 .. -> 80 -> 91 (11 + (8 * 10))
                );
            /* randomNumberForCarton:  ( 1,10) (10,20) (20,30) (30,40) (40,50) (50,60) (60,70) (70,80) (80,91) 
                rangos            ->  |  1-9  | 10-19 | 20-29 | 30-39 | 40-49 | 50-59 | 60-69 | 70-79 | 80-90 |
               columnas           ->      c0      c1      c2      c3      c4      c5      c6      c7      c8
            */

            bool isRandomNumberInCarton = false;
            foreach (int cartonNumber in carton)
            {
                if (cartonNumber == randomNumberForCarton)
                {
                    isRandomNumberInCarton = true;
                    break;
                }
            }

            if (isRandomNumberInCarton)
                iColumn--;
            else if (carton[iRow, iColumn] != WHITESPACE)
                carton[iRow, iColumn] = randomNumberForCarton;
        }
    }
    /* Ejemplo de output
    ||=============================================||=============================================||
    ||              carton(antes):                 ||                 carton(despues):            ||
    ||=============================================||=============================================||
    || {                                           || {                                           ||
    ||     { 00, ░░, 00, 00, ░░, ░░, 00, ░░, 00 }, ||     { 05, ░░, 28, 37, ░░, ░░, 64, ░░, 90 }, ||
    ||     { ░░, 00, 00, ░░, 00, ░░, ░░, 00, 00 }, ||     { ░░, 16, 20, ░░, 41, ░░, ░░, 77, 82 }, ||
    ||     { ░░, 00, ░░, 00, 00, 00, ░░, 00, ░░ }  ||     { ░░, 12, ░░, 33, 49, 56, ░░, 75, ░░ }  ||
    || }                                           || }                                           ||
    ||=============================================||=============================================||
    */

    // Muestro el Carton
    for (int iRow = 0; iRow < ROWS; iRow++)
    {
        Console.Write("\t");
        for (int iColumn = 0; iColumn < COLUMNS; iColumn++)
        {
            Console.Write($"{ (iColumn == 0 && carton[iRow, iColumn] != WHITESPACE ? "0" : "") }{ (carton[iRow, iColumn] != WHITESPACE ? carton[iRow, iColumn] : "██") } ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();

}
