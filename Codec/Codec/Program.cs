using System;
using NUnit.Framework;

enum Direction { North, East, South, West }

class Robot
{
    private int x;
    private int y;
    private Direction facing;
    private int gridX;
    private int gridY;

    public Robot(int gridX, int gridY)
    {
        this.x = 1;
        this.y = 1;
        this.facing = Direction.North;
        this.gridX = gridX;
        this.gridY = gridY;
    }

    public void Move(char command)
    {
        switch (command)
        {
            case 'L':
                TurnLeft();
                break;
            case 'R':
                TurnRight();
                break;
            case 'F':
                Forward();
                break;
        }
    }

    private void TurnLeft()
    {
        if (facing == Direction.North)
            facing = Direction.West;
        else
            facing = facing - 1;
    }

    private void TurnRight()
    {
        if (facing == Direction.West)
            facing = Direction.North;
        else
            facing = facing + 1;
    }

    private void Forward()
    {
        switch (facing)
        {
            case Direction.North:
                if (y < gridY)
                    y++;
                break;
            case Direction.East:
                if (x < gridX)
                    x++;
                break;
            case Direction.South:
                if (y > 1)
                    y--;
                break;
            case Direction.West:
                if (x > 1)
                    x--;
                break;
        }
    }

    public override string ToString()
    {
        return x + "," + y + "," + facing;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the grid size (x y): ");
        string[] gridSize = Console.ReadLine().Split(' ');
        int gridX = int.Parse(gridSize[1]);
        int gridY = int.Parse(gridSize[1]);

        Console.WriteLine("Enter commands: ");
        string commands = Console.ReadLine();

        Robot robot = new Robot(gridX, gridY);
        for (int i = 0; i < commands.Length; i++)
        {
            robot.Move(commands[i]);
        }

        Console.WriteLine("Final position: " + robot);
    }
}

[TestFixture]
class RobotTests
{
    [Test]
    public void Move_LeftCommand_FacingWest()
    {
        // Arrange
        Robot robot = new Robot(5, 5);
        robot.

        // Act
        robot.Move('L');

        // Assert
        Assert.AreEqual(Direction.West, robot.Facing);
    }

    [Test]
    public void Move_RightCommand_FacingEast()
    {
        // Arrange
        Robot robot = new Robot(5, 5);

        // Act
        robot.Move('R');

        // Assert
        Assert.AreEqual(Direction.East, robot.Facing);
    }

    [Test]
    public void Move_ForwardCommand_PositionYIncremented()
    {
        // Arrange
        Robot robot = new Robot(5, 5);

        // Act
        robot.Move('F');

        // Assert
        Assert.AreEqual(2, robot.Y);
    }

    [Test]
    public void Move_BackwardCommand_PositionYDecremented()
    {
        // Arrange
        Robot robot = new Robot(5, 5);
        robot.Move('F');
        robot.Move('F');

        // Act
        robot.Move('F');

        // Assert
        Assert.AreEqual(2, robot.Y);
    }
}
