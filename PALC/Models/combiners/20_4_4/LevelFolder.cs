﻿using PALC.Models.Combiners._20_4_4.LevelComponents;
using System.IO;

namespace PALC.Models.Combiners._20_4_4;

public class LevelFolder
{
    public Level level;
    public string audioPath;
    public Metadata metadata;

    public LevelFolder(string levelFolderPath)
    {
        var levelFile = File.ReadAllText(Path.Join(levelFolderPath, "level.lsb"));

        level = Level.FromFileJson(levelFile);

        audioPath = Path.Combine(levelFolderPath, "level.ogg");
        if (!File.Exists(audioPath))
            throw new exceptions.AudioFileNotFoundException();

        metadata = Metadata.FromFileJson(
            File.ReadAllText(Path.Combine(levelFolderPath, "metadata.lsb"))
        );
    }
}
