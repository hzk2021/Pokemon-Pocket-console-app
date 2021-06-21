using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using PokemonPocket;

/**
    Student Name: He Zhenkai
    Admin Number: 204304Z
    Tutorial Group: 4
**/

namespace PokemonPocket
{
    class Program
    {
        //PokemonMaster list for checking pokemon evolution availability.    
        static List<PokemonMaster> pokemonMasters = new List<PokemonMaster>(){
        new PokemonMaster("Pikachu", 2, "Raichu"),
        new PokemonMaster("Eevee", 3, "Flareon"),
        new PokemonMaster("Charmander", 1, "Charmeleon")
        };
        
        static List<Pokemon> PokemonList = new List<Pokemon>();
        static void Main(string[] args)
        {             
            DrawMenu();

            while (true)
            {
                try {
                    int UserInput = GetOption();

                    switch (UserInput)
                    {
                        case 1:
                            AddPokemon();
                            break;
                        case 2:
                            ListPokemons();
                            break;
                        case 3:
                            CheckPokemonEvolve();
                            break;
                        case 4:
                            EvolvePokemon();
                            break;
                        case 5:
                            RemovePokemon();
                            break;
                        default:
                            Console.WriteLine("Invalid Option! Please only enter [1,2,3,4] as options!");
                            break;
                    }
                } catch(FormatException)
                {
                    Console.WriteLine("Please only enter number for the previous field!");
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        //Use "Environment.Exit(0);" if you want to implement an exit of the console program
        //Start your assignment 1 requirements below.

    #region Tasks Function
        static void AddPokemon()
        {   
            string name = PrintGetAnswer("Enter Pokemon's Name: ");
            int health = int.Parse(PrintGetAnswer("Enter Pokemon's Health: "));
            int exp =  int.Parse(PrintGetAnswer("Enter Pokemon's Exp: "));

            switch(name.ToLower())
            {
                case "pikachu":
                    Pikachu p = new Pikachu(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name), health, exp);
                    PokemonList.Add(p);
                    break;
                case "eevee":
                    Eevee e = new Eevee(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name), health, exp);
                    PokemonList.Add(e);
                    break;
                case "charmander":
                    Charmander c = new Charmander(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name), health, exp);
                    PokemonList.Add(c);
                    break;
                default:
                    Console.WriteLine($"{name} is not one of the 3 pokemons!");
                    return;
            }

            Console.WriteLine($"{name} has been added to your pocket!");
        }

        static void ListPokemons()
        {
            // LINQ Method
            PokemonList = PokemonList.OrderBy(x => x.Health).ToList();
            if (PokemonList.Count == 0) Console.WriteLine("There is no pokemon in your pocket!");

            PokemonList.ForEach(pokemon => {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Name: {pokemon.Name}");
                Console.WriteLine($"HP: {pokemon.Health}");
                Console.WriteLine($"Exp: {pokemon.Exp}");
                Console.WriteLine($"Skill: {pokemon.GetSkills()}");
            });
        }

        static void CheckPokemonEvolve()
        {
            if (PokemonList.Count > 0){
                int pikachuCount = 0, charmanderCount = 0, eeveeCount = 0;

                PokemonList.ForEach(pokemon => {
                    switch(pokemon.Name){
                        case "Pikachu":
                            pikachuCount++;
                            break;
                        case "Charmander":
                            charmanderCount++;
                            break;
                        case "Eevee":
                            eeveeCount++;
                            break;
                        default:
                            break;
                    }
                });

                pokemonMasters.ForEach(pokemon => {
                    if (pokemon.Name == "Pikachu"){
                        if (pikachuCount >= pokemon.NoToEvolve){
                            Console.WriteLine($"{pokemon.Name} --> {pokemon.EvolveTo}");
                        }
                    }
                    else if (pokemon.Name == "Charmander"){
                        if (charmanderCount >= pokemon.NoToEvolve){
                            Console.WriteLine($"{pokemon.Name} --> {pokemon.EvolveTo}");
                        }
                    }
                    else if (pokemon.Name == "Eevee"){
                        if (eeveeCount >= pokemon.NoToEvolve){
                            Console.WriteLine($"{pokemon.Name} --> {pokemon.EvolveTo}");
                        }
                    }
                });
            }
            else {
                Console.WriteLine("There is no pokemon in your pocket!");
            }
        }

        static void EvolvePokemon() // test
        {
            if (PokemonList.Count > 0){
                int pikachuCount = 0, charmanderCount = 0, eeveeCount = 0;

                PokemonList.ForEach(pokemon => {
                    switch(pokemon.Name){
                        case "Pikachu":
                            pikachuCount++;
                            break;
                        case "Charmander":
                            charmanderCount++;
                            break;
                        case "Eevee":
                            eeveeCount++;
                            break;
                        default:
                            break;
                    }
                });

                pokemonMasters.ForEach(pokemon => {
                    if (pokemon.Name == "Pikachu"){
                        if (pikachuCount >= pokemon.NoToEvolve){
                            for (var i = 0; i< PokemonList.Count; i++){
                                if (PokemonList[i].Name == pokemon.Name){
                                    PokemonList.RemoveAll(p => p.Name == pokemon.Name);
                                    break;
                                }
                            }
                            Pikachu p = new Pikachu(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pokemon.EvolveTo), 0, 0);
                            PokemonList.Add(p);
                            Console.WriteLine($"{pokemon.Name} has been evolved to {pokemon.EvolveTo}");
                        }
                    }
                    else if (pokemon.Name == "Charmander"){
                        if (charmanderCount >= pokemon.NoToEvolve){
                            for (var i = 0; i< PokemonList.Count; i++){
                                if (PokemonList[i].Name == pokemon.Name){
                                    PokemonList.RemoveAll(p => p.Name == pokemon.Name);
                                    break;
                                }
                            }
                            Charmander p = new Charmander(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pokemon.EvolveTo), 0, 0);
                            PokemonList.Add(p);
                            Console.WriteLine($"{pokemon.Name} has been evolved to {pokemon.EvolveTo}");
                        }
                    }
                    else if (pokemon.Name == "Eevee"){
                        if (eeveeCount >= pokemon.NoToEvolve){
                            for (var i = 0; i< PokemonList.Count; i++){
                                if (PokemonList[i].Name == pokemon.Name){
                                    PokemonList.RemoveAll(p => p.Name == pokemon.Name);
                                    break;
                                }
                            }
                            Eevee p = new Eevee(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pokemon.EvolveTo), 0, 0);
                            PokemonList.Add(p);
                            Console.WriteLine($"{pokemon.Name} has been evolved to {pokemon.EvolveTo}");
                        }
                    }
                });
            }
            else {
                Console.WriteLine("There is no pokemon in your pocket!");
            }
        }

        static void RemovePokemon()
        {
            if (PokemonList.Count > 0){
                int originalPokemonCount = PokemonList.Count;
                string name = PrintGetAnswer("Enter Pokemon's Name To Remove: ");
                string option = PrintGetAnswer($"Are you sure you want to delete all pokemon with the name of {name}? (Y/N): ");
                switch (option.ToUpper()){
                    case "Y":
                        var tempPokemonList = PokemonList.Where(p => p.Name.ToLower() != name.ToLower()).ToList();
                        PokemonList = tempPokemonList;
                        int newPokemonCount = PokemonList.Count;

                        if (newPokemonCount == originalPokemonCount){
                            Console.WriteLine($"{name} was not found in your pocket");
                        }
                        else {
                            Console.WriteLine($"Pokemon(s) with the name of: {name} has/have been deleted from your pocket!");
                        }
                        break;
                    case "N":
                        Console.WriteLine("No pokemon was deleted.");
                        break;
                    default:
                        Console.WriteLine("Not a valid option. Please only enter (Y/N)");
                        break;
                }
            }
            else {
                Console.WriteLine("There is no pokemon in your pocket!");
            }
        }
    #endregion


    #region ConsoleHelper
        static void DrawMenu()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Welcome to Pokemon Pocket App");
            Console.WriteLine("*****************************");
            Console.WriteLine("(1). Add pokemon to my pocket");
            Console.WriteLine("(2). List pokemon(s) in my Pocket");
            Console.WriteLine("(3). Check if I can evolve pokemon");
            Console.WriteLine("(4). Evolve pokemon");
            Console.WriteLine("(5). Remove pokemon (+ Feature)\n");
        }

        static int GetOption()
        {
            Console.Write("\nPlease only enter [1,2,3,4,5] or Q to quit: ");
            string input = Console.ReadLine();
            int num = 0;

            if (input.ToUpper() == "Q" || !int.TryParse(input, out num))
            {
                ExitConsole();
            }

            return num;
        }

        static void ExitConsole()
        {
            Environment.Exit(0);
        }

        static string PrintGetAnswer(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

    #endregion

    }
}