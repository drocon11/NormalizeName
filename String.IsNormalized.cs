
using System;
using System.IO;

class App
{
    public static void Main(string[] args)
    {
        try
        {
            foreach (string arg in args)
            {
                if (File.Exists(arg))
                {
                    DoFile(new FileInfo(arg));
                }
                else if (Directory.Exists(arg))
                {
                    DoDirectory(new DirectoryInfo(arg));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    static void DoFile(FileInfo file)
    {
        IsNormalizedName(file);
    }

    static void DoDirectory(DirectoryInfo dir)
    {
        foreach (FileInfo f in dir.GetFiles())
        {
            DoFile(f);
        }
        foreach (DirectoryInfo d in dir.GetDirectories())
        {
            DoDirectory(d);
        }

        IsNormalizedName(dir);
    }

    static void IsNormalizedName(dynamic info)
    {
        if (!info.Name.IsNormalized())
        {
            Console.WriteLine("Unnormalized : {0}", info.FullName);
        }
    }
}
