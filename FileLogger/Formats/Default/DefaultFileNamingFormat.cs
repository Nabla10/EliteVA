﻿using EliteVA.FileLogger.Formats.Abstractions;

namespace EliteVA.FileLogger.Formats.Default;

public class DefaultFileNamingFormat : IFileNamingFormat
{
    internal DefaultFileNamingFormat()
    {

    }

    /// <inheritdoc />
    public string NameFile(DirectoryInfo directory, string name)
    {
        var i = 0;

        while (true)
        {
            i++;

            var file = $"{name}.{i:000}.log";

            if (directory.GetFiles(file).Length == 0)
            {
                return file;
            }
        }
    }
}