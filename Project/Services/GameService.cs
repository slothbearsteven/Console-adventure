using System;
using System.Collections.Generic;
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
      (i)nventory= see the items you have
      (l)ook= get a description of the current room
      use {item}= use item specified
      take {item's number}=add the item  to your inventory");
    }

    public void Inventory()
    {
      string template = "Inventory:\n";

      foreach (var Item in _game.CurrentPlayer.Inventory)
      {
        template += @$"\t {Item.Name}\n \t \t {Item.Description} \n";
      }

      Messages.Add(template);
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.Description);
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

    public void Setup(string playerName)
    {
      _game.Setup();

      Messages.Add(@" I see you are waking up. Don't remember what happen? Well, it was a big fall you took from up there. 
 Hmm.... you can't seem to see anymore.... in fact.... your eyes aren't even there. I take it something brought you or drove you here then whether you liked it or not. Are you an  experienced adventurer perhaps?
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
      if (_game.CurrentRoom == _game.FinalRoom)
      {

        Messages.Add("You'd like to use this strange piece? *The stranger places the piece on what he described as an altar, and a peaceful hum is emmited* Looks like a good choice you made.");

        _game.Pieces.Add(inv[index]);

        inv.Remove(inv[index]);

      }



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

