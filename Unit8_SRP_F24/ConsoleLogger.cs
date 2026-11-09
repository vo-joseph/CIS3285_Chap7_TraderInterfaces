using System;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;

public class ConsoleLogger : ILogger
{
    // Sample call to LogMessage
    // LogMessage("WARN: Trade price on line {0} not a valid decimal: '{1}'", currentLine, fields[2]);

    public void LogMessage(string message, params object[] args)
    {
        string type = "INFO"; // default to INFO
        if (message.StartsWith("WARN"))
        {
            type = "WARN";
        }
        else if (message.StartsWith("ERROR"))
        {
            type = "ERROR";
        }

        Console.WriteLine(type + ": " + message, args);
        using (StreamWriter logfile = File.AppendText("log.xml"))
        {
            logfile.WriteLine("<log><type>" + type + "</type><message>" + message + "</message></log> ", args);
        }
    }
}
