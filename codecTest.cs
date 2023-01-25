using System;

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
                GoForward();
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

    private void GoForward()
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