﻿namespace Phase03_FullTextSearchRefactor.Domain;

public class FileContents
{
    public Dictionary<string, string> Contents { get; set; }
    public FileContents()
    {
        Contents = new Dictionary<string, string>();
    }
}