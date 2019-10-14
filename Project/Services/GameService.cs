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
      take {item}=add the item to your inventory");
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      throw new System.NotImplementedException();
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {

      //EXAMPLE FROM PLANES 
      //     _game.Plane.Cargo.AddRange(_game.CurrentAirport.Pickups);
      //     _game.CurrentAirport.Pickups.Clear();
      throw new System.NotImplementedException();
    }


    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();



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

