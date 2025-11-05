Console.Write("Select map size (square): ");
int maxX = InputInRange(15, 30);
int maxY = maxX;

for (int shipNumber = 1; shipNumber <= 5; shipNumber++)
{
    bool validShip = false; // Resets for each loop iteration
    
    while (true)
    {
        if (!validShip)
        {
            // Main code + repeat if fail
            var shipCoordinates = new List<(int, int)>();
            
            Console.Write($"Input start X for ship number {shipNumber} / 5: ");
            int startX = InputInRange(0, maxX);

            Console.Write($"Input start Y for ship number {shipNumber} / 5: ");
            int startY = InputInRange(0, maxY);

            shipCoordinates.Add((startX, startY));
            
            Console.Write($"Ship number {shipNumber} length: ");
            int shipLength = InputInRange(2, 5);
            
            int xModify = 0;
            int yModify = 0;
            Console.Write($"Ship {shipNumber} direction from start point: ");
            string direction = Console.ReadLine();
            switch (direction)
            {
                case "up":
                    xModify = 0;
                    yModify = 1;
                    break;
                case "down":
                    xModify = 0;
                    yModify = -1;
                    break;
                case "left":
                    xModify = -1;
                    yModify = 0;
                    break;
                case "right":
                    xModify = 1;
                    yModify = 0;
                    break;
            }
            
            GenerateCoordinates(startX, startY, shipLength, xModify, yModify, shipCoordinates);
            
            validShip = true; // Assume ship is valid and only change to false if a coordinate is invalid

            foreach (var set in shipCoordinates)
            {
                if (set.Item1 < 0 || set.Item1 >= maxX)
                {
                    Console.WriteLine("Ship is outside X! Try again...");
                    validShip = false;
                    break;
                }
                if (set.Item2 < 0 || set.Item2 >= maxY)
                {
                    Console.WriteLine("Ship is outside Y! Try again...");
                    validShip = false;
                    break;
                }
            }
        }
        else
        {
            // If success
            validShip = true;
            break;
        }
    }
}

// P2 handover
Console.WriteLine("Player 2's turn! Are you ready to start guessing?");
while (true)
{
    Console.Write("Y / N: ");
    string ready = Console.ReadLine();

    if (ready == "Y" || ready == "y")
    {
        bool plaerTwoReady = true;
        break;
    }
}

//Methods
int InputInRange (int lower, int upper)
{
    while (true)
    {
        Console.Write($"Select number between {lower} and {upper}: ");
        int input = Convert.ToInt32(Console.ReadLine());
        
        if (input >= lower && input <= upper)
        {
            return input;
        }
        else if (input > upper)
        {
            Console.WriteLine("Too large input! Try again:");
        }
        else if (input < lower)
        {
            Console.WriteLine("Too small input! Try again:");
        }
    }
}

List <(int, int)> GenerateCoordinates
    (int startX, int startY, int shipLength, int xModify, int yModify, List<(int, int)> shipCoordinates)
{
    for (int i = 1; i < shipLength; i++)
    {
        int newX = startX + (i * xModify); int newY = startY + (i * yModify);
        shipCoordinates.Add((newX, newY));
    }
    return shipCoordinates;
}

// Check for identical coordinates / overlapping ships

// Random ship placement

// Guess and evaluate hit or miss until all ships are sunk

// Check for identical guesses