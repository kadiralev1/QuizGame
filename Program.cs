﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;



using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace QuizGame
{
    class Program
    {

        static void Main(string[] args)
        {
            mainMenu mm = new mainMenu();
            mm.displayMainMenu();
            GameManager gm = new GameManager();
            

            Console.ReadLine();
        }

    }
}