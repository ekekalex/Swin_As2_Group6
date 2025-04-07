using UnityEngine;
using System.IO;

public class InputExportLogger : MonoBehaviour
{
    // Set the folder path to E:\Unity (using @ to handle backslashes)
    public string customFolderPath = @"E:\Unity";
    private string logFilePath;

    void Start()
    {
        // Check if the directory exists; if not, create it.
        if (!Directory.Exists(customFolderPath))
        {
            Directory.CreateDirectory(customFolderPath);
        }

        // Create the full path for the log file.
        logFilePath = Path.Combine(customFolderPath, "InputLog.txt");

        // Create or clear the log file and write the header.
        File.WriteAllText(logFilePath, "Timestamp,KeyPressed\n");

        // Output the log file path to the Console.
        Debug.Log("Log file path: " + logFilePath);
    }

    void Update()
    {
        // Check if any key is pressed in the current frame.
        if (Input.anyKeyDown)
        {
            // Loop through all possible KeyCodes.
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    // Create a log entry with the current time and key pressed.
                    string logEntry = $"{Time.time:F2},{key}\n";
                    // Append the log entry to the file.
                    File.AppendAllText(logFilePath, logEntry);
                }
            }
        }
    }
}
