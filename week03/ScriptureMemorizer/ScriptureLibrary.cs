using System;
using System.Collections.Generic;

/// <summary>
/// Manages a library of scriptures. Provides random scripture selection for variety.
/// This supports the stretch challenge of having the program work with a library
/// of scriptures rather than a single one.
/// </summary>
public class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    /// <summary>
    /// Initializes the ScriptureLibrary with predefined scriptures.
    /// </summary>
    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        InitializeScriptures();
    }

    /// <summary>
    /// Populates the library with multiple scriptures.
    /// </summary>
    private void InitializeScriptures()
    {
        // Single verse scriptures
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life"
        ));

        _scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding in all your ways submit to him and he will make your paths straight"
        ));

        _scriptures.Add(new Scripture(
            new Reference("Philippians", 4, 8),
            "Finally brothers whatever is true whatever is noble whatever is right whatever is pure whatever is lovely whatever is admirable if anything is excellent or praiseworthy think about such things"
        ));

        _scriptures.Add(new Scripture(
            new Reference("Psalm", 23, 1),
            "The Lord is my shepherd I shall not be in want"
        ));

        _scriptures.Add(new Scripture(
            new Reference("Matthew", 5, 3, 10),
            "Blessed are the poor in spirit for theirs is the kingdom of heaven Blessed are those who mourn for they will be comforted Blessed are the meek for they will inherit the earth Blessed are those who hunger and thirst for righteousness for they will be filled Blessed are the merciful for they will be shown mercy Blessed are the pure in heart for they will see God Blessed are the peacemakers for they will be called children of God Blessed are those who are persecuted because of righteousness for theirs is the kingdom of heaven"
        ));

        _scriptures.Add(new Scripture(
            new Reference("1 John", 1, 9),
            "If we confess our sins he is faithful and just and will forgive us our sins and purify us from all unrighteousness"
        ));

        _scriptures.Add(new Scripture(
            new Reference("Romans", 8, 28),
            "And we know that in all things God works for the good of those who love him who have been called according to his purpose"
        ));

        _scriptures.Add(new Scripture(
            new Reference("Joshua", 1, 8, 9),
            "Keep this Book of the Law always on your lips meditate on it day and night so that you may be careful to do everything written in it Then you will be prosperous and successful Have I not commanded you Be strong and courageous Do not be afraid do not be discouraged for the Lord your God will be with you wherever you go"
        ));
    }

    /// <summary>
    /// Gets a random scripture from the library.
    /// </summary>
    /// <returns>A random scripture</returns>
    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }

    /// <summary>
    /// Gets the total number of scriptures in the library.
    /// </summary>
    /// <returns>The scripture count</returns>
    public int GetScriptureCount()
    {
        return _scriptures.Count;
    }

    /// <summary>
    /// Gets a scripture by index.
    /// </summary>
    /// <param name="index">The index</param>
    /// <returns>The scripture at the given index</returns>
    public Scripture GetScripture(int index)
    {
        if (index >= 0 && index < _scriptures.Count)
        {
            return _scriptures[index];
        }
        return null;
    }
}
