using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Common
{
    public static void CreateDirectoryForFile(string filePath)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
    }
}
