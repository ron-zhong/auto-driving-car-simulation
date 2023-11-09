Console.WriteLine("1.Please indicate the width and height of the field, like: 10 10.");
string inputLine1 = Console.ReadLine() ?? string.Empty;
Console.WriteLine();

Console.WriteLine("2.Please indicate the current position and facing direction of the car, like: 1 2 N.");
string inputLine2 = Console.ReadLine() ?? string.Empty;
Console.WriteLine();

if( inputLine1 == string.Empty || inputLine2 == string.Empty)
{
    Console.WriteLine("Please enter the correct format.");
    return;
}

Console.WriteLine("Please enter the subsequent commands it will execute, like: FFRFFFRRLF");
string inputLine3 = Console.ReadLine() ?? string.Empty;
Console.WriteLine();

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
        direction = direction switch
        {
            'N' => 'W',
            'W' => 'S',
            'S' => 'E',
            'E' => 'N',
            _ => direction
        };
    }
    else if (command == 'R')
    {
        // Rotate the car 90 degrees to the right
        direction = direction switch
        {
            'N' => 'E',
            'E' => 'S',
            'S' => 'W',
            'W' => 'N',
            _ => direction
        };
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
Console.WriteLine("This is the final position and direction of the car: {x} {y} {direction}");
Console.WriteLine($"{x} {y} {direction}");
