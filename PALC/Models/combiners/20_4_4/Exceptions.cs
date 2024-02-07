﻿using System;

namespace PALC.Models.Combiners._20_4_4.exceptions
{
    public class AudioFileNotFoundException(Exception? inner) : Exception("The audio file cannot be found or is invalid.", inner)
    {
        public AudioFileNotFoundException() : this(null) { }
    }

    public class ThemeInFolderNotFoundException(string themeId, Exception? inner) : Exception($"The theme bearing ID {themeId} cannot be found.", inner)
    {
        public ThemeInFolderNotFoundException(string themeId) : this(themeId, null) { }
    }
}
