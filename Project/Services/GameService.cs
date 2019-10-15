using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }

    public void What()
    {
      Messages.Add("What should we do?");
    }
    public void Go(string direction)
    {

      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;

      if (from == to)
      {
        Messages.Add("That way doesn't have a door.");
        return;
      }
      Messages.Add($"You have entered {to}");


    }
    public void Help()
    {
      Messages.Add(@"possible commands:
      (q)uit= exit the game
      inventory= see the items you have
      look= get a description of the current room
      use {item}= use item specified
      take {item}=add the item  to your inventory
      go {direction}= go east, west, north,or south");

      What();
    }

    public void Inventory()
    {
      if (_game.CurrentPlayer.Inventory.Count > 0)
      {

        string template = "Inventory:\n";

        foreach (var Item in _game.CurrentPlayer.Inventory)
        {
          template += @$"\t {Item.Name}\n \t \t {Item.Description} \n";
        }

        Messages.Add(template);
      }
      else
      {
        Messages.Add("You're pockets are empty....");
      }

      What();
    }

    public void Look()
    {

      Messages.Add(_game.CurrentRoom.Description + $"\n");

      What();

      Messages.Add("Items the Stranger notices:");
      foreach (var item in _game.CurrentRoom.Items)
      {
        Messages.Add($"{item.Name}\n");
      }
    }

    public void Quit()
    {
      Environment.Exit(0);
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {

    }

    public void Setup()
    {
      Messages.Add(@" I see you are waking up. Don't remember what happen? Well, it was a big fall you took from up there. 
 Hmm.... you can't seem to see anymore.... in fact.... your eyes aren't even there. I take it something brought you or drove you here then whether you liked it or not. Are you an  experienced adventurer perhaps?

 What do you say, Yes or No?
");
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {

      List<Item> items = _game.CurrentRoom.Items;
      int index = items.FindIndex(Item => Item.Name == itemName);
      if (index < items.Count && index > -1)
      {
        Messages.Add($"You have obtained {items[index].Name}");
        _game.CurrentPlayer.Inventory.Add(items[index]);
        items.Remove(items[index]);
      }
      else
      {
        Messages.Add("I have no idea what you want me to grab");
      }

      What();
    }


    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      List<Item> inv = _game.CurrentPlayer.Inventory;
      int index = inv.FindIndex(Item => Item.Name == itemName);
      Item item = inv[index];
      if (_game.CurrentRoom == _game.FinalRoom)
      {

        Messages.Add("You'd like to use this strange piece? *The stranger places the piece on what he described as an altar, and a peaceful hum is emmited* Looks like a good choice you made.");

        _game.Pieces.Add(item);

        inv.Remove(item);

        if (_game.Pieces.Count > 2)
        {
          Console.Clear();
          Messages.Add(@"*As the stranger places the piece,a bright light shines, and somehow, you see it. Around you are now your friends and family in what appears to be a hospital room.*
          
          Your Mother: YOU'RE AWAKE! We've been worried that would never happen.... the doctors were actually talking about disconnecting you from the machines. But here you are, pulling through last second. I knew we should have never let you go climbing. 
          
          *You ponder the last events, now knowing it was all in your mind as you laid in a coma. The nurses rush in the check your vitals, and discover you are just fine. Now you can go and live your life normally as any person would.");

          Thread.Sleep(20000);
          Environment.Exit(0);
        }

      }

      else
      {
        Messages.Add("*A feeling comes over you that this isn't the right place to use that*");
      }

      What();
      //EXAMPLE FROM PLANES 
      //   _game.Plane.Cargo.RemoveAll(cargo =>
      //     {
      //       if (cargo.Destination == _game.CurrentAirport)
      //       {
      //         _game.Plane.AccountBalance += cargo.Reward;
      //         deliveries++;
      //         profits += cargo.Reward;
      //         return true;
      //       }
      //       return false;
      //     });
    }


  }
}

