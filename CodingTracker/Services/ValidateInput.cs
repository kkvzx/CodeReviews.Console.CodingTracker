﻿using Spectre.Console;

public class ValidateInput
{
    public int GetValidInt(string prompt, int min, int max)
    {
        int result;
        bool validInput;
        do
        {
            result = AnsiConsole.Ask<int>(prompt);
            validInput = result >= min && result <= max;
            if (!validInput)
            {
                AnsiConsole.Markup($"[red]Invalid input, try again. Value must be between {min} and {max}.[/]\n");
            }
        } while (!validInput);

        return result;
    }

    public TimeSpan GetValidTime(string prompt)
    {
        TimeSpan result;
        bool validInput;
        do
        {
            string input = AnsiConsole.Ask<string>(prompt);
            validInput = TimeSpan.TryParse(input, out result) && result.TotalSeconds > 0 && input.Split(":").Length == 3;
            if (!validInput)
            {
                AnsiConsole.Markup($"[red]Invalid input, try again. Please input a valid time[/]\n");
            }
        } while (!validInput);

        return result;
    }

    public bool ValidateSessionDates(DateTime startDate, DateTime endDate)
    {
        return endDate > startDate;
    }
}