using System;

string inputLine1 = Console.ReadLine();
string inputLine2 = Console.ReadLine();
string inputLine3 = Console.ReadLine();

// Parse the field width and height
string[] fieldDimensions = inputLine1.Split(' ');
int width = int.Parse(fieldDimensions[0]);
int height = int.Parse(fieldDimensions[1]);

// Parse the current position and facing direction
string[] currentPosition = inputLine2.Split(' ');
int x = int.Parse(currentPosition[0]);
int y = int.Parse(currentPosition[1]);
char direction = char.Parse(currentPosition[2]);

// Parse and execute the commands
foreach (char command in inputLine3)
{
    if (command == 'L')
    {
        // Rotate the car 90 degrees to the left
        switch (direction)
        {
            case 'N':
                direction = 'W';
                break;
            case 'W':
                direction = 'S';
                break;
            case 'S':
                direction = 'E';
                break;
            case 'E':
                direction = 'N';
                break;
        }
    }
    else if (command == 'R')
    {
        // Rotate the car 90 degrees to the right
        switch (direction)
        {
            case 'N':
                direction = 'E';
                break;
            case 'E':
                direction = 'S';
                break;
            case 'S':
                direction = 'W';
                break;
            case 'W':
                direction = 'N';
                break;
        }
    }
    else if (command == 'F')
    {
        // Move the car forward if within the field boundary
        switch (direction)
        {
            case 'N':
                if (y < height)
                    y++;
                break;
            case 'E':
                if (x < width)
                    x++;
                break;
            case 'S':
                if (y > 0)
                    y--;
                break;
            case 'W':
                if (x > 0)
                    x--;
                break;
        }
    }
}

// Print the final position and direction
Console.WriteLine($"{x} {y} {direction}");
