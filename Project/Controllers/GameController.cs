using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      while (true)
      {

        GetUserInput();
        Print();
      }
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"

      switch (command)
      {
        case "help":
          _gameService.Help();

          break;
        case "take":
          _gameService.TakeItem(option);

          break;
        case "use":
          _gameService.UseItem(option);

          break;
        case "inventory":
          _gameService.Inventory();

          break;
        case "q":
        case "quit":
          _gameService.Quit();
          break;
        case "go":
          _gameService.Go(option);
          _gameService.Look();
          break;
        case "look":
          _gameService.Look();


          break;
        case "no":
          Console.Clear();
          Console.Write($"I'm sorry to hear that.... I guess this is your end then \n *As you listen, a sudden ringing fills your ears and you lose all your strength. As you lie on the cold floor, you lose all feeling, only sure that you are about to face death*");


          Thread.Sleep(10000);
          _gameService.Quit();

          break;

        case "yes":
          _gameService.Messages.Add($"Splendid. I'm not the greatest at the things of adventure, but perhaps I can be your eyes. \n ");

          _gameService.Look();


          break;

        case "play":
          _gameService.decide(1);
          break;


        default:
          Console.Write("What did you say?");
          break;



      }

    }

    //NOTE this should print your messages for the game.
    private void Print()
    {


      Console.Clear();


      List<string> messages = _gameService.Messages;
      foreach (var message in messages)
      {
        Console.Write(message + $"\n");
      }

      messages.Clear();
      //TODO need it so console writes list of messages.
    }

  }
}