using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      Room CenterRoom = new Room("The Center", "This room was where you fell, a long fall at that.From what I can tell, these are some sort of ancient ruins created to bring a beings' mind to enlightenment, altough, it has definetly strayed from such with all this rubble around. There seems to be an exit on each wall in the room, as if this may be a main hallway for the ruins");

      Room SouthRoom = new Room("The Lab", @"*A vibrant feeling of fear comes over you as you step into the southern room* 
      Hmmmm this is interesting. Beakers, cylinders, burners and more a lined up on stone counters. This room is darker than the other room we were in for sure. The walls are strewn with ash that seems to surround silhouttes of human bodies. By a burner, there is a strange object, glowing brightly.");

      Room NorthRoom = new Room("The Altar", @"*A chilling wind blows through as you enter the room, giving you a hint that your way out may be near*
      This room seems to be a caved that was repurposed. A light comes down from the ceiling, far brighter than any artificial lights in the other rooms so far. Sitting in the light appears to be an Altar of sorts, with 3 indents that look like they are supposed to be filled.");

      Room EastRoom = new Room("The Well", @"*drops of water echo as you enter this room*
      Ah, the well that has sustained me for a while. It's base is made of stone and the bucket to transport water is crested with a unique, glowing rock. Maybe It was a signet of the ancient people who lived here");

      Room WestRoom = new Room("The Boiler", @"*Strange hisses and other sounds plague the air, and for an odd reason, it seems hard to breathe*
      
      For being ruins, the technology in here is facinating. There's several Boilers in this room, each boiling a different substance I guess due to the writings on them. One boiler has a window, in which I spy a faint glow. Hmm.... I wonder if that could be something special.");


      WestRoom.AddExit("east", CenterRoom);
      CenterRoom.AddExit("east", EastRoom);
      CenterRoom.AddExit("west", WestRoom);
      CenterRoom.AddExit("south", SouthRoom);
      CenterRoom.AddExit("north", NorthRoom);
      NorthRoom.AddExit("south", CenterRoom);
      SouthRoom.AddExit("north", CenterRoom);
      EastRoom.AddExit("west", CenterRoom);

      Item strange1 = new Item("Strange Piece 1", "A strange glowing object, that seems to be the piece of something");
      Item strange2 = new Item("Strange Piece 2", "A strange glowing object, that seems to be the piece of something");
      Item strange3 = new Item("Strange Piece 3", "A strange glowing object, that seems to be the piece of something. It is different from any other pieces");

      SouthRoom.Items.Add(strange3);
      WestRoom.Items.Add(strange2);
      EastRoom.Items.Add(strange3);

      CurrentRoom = CenterRoom;
    }

    public Game()
    {
      CurrentPlayer = new Player();
      Setup();
    }
  }
}