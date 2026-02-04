using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a complete scripture with its reference and text.
/// Encapsulates the behavior of displaying, hiding words, and tracking completion.
/// </summary>
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    /// <summary>
    /// Initializes a Scripture with a reference and text.
    /// </summary>
    /// <param name="reference">The scripture reference</param>
    /// <param name="text">The scripture text</param>
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split text into words and create Word objects
        string[] wordArray = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    /// <summary>
    /// Gets the full display text of the scripture (reference + text).
    /// </summary>
    /// <returns>The formatted scripture display</returns>
    public string GetDisplayText()
    {
        string reference = _reference.GetReference();
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{reference} - {text}";
    }

    /// <summary>
    /// Hides a random word from the scripture. If the stretch challenge is enabled,
    /// it will only hide unhidden words. Otherwise, it may re-hide already hidden words.
    /// </summary>
    public void HideRandomWord()
    {
        List<Word> unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();

        if (unhiddenWords.Count > 0)
        {
            Random random = new Random();
            int randomIndex = random.Next(unhiddenWords.Count);
            unhiddenWords[randomIndex].Hide();
        }
        
    }

    /// <summary>
    /// Checks if all words in the scripture are hidden.
    /// </summary>
    /// <returns>True if all words are hidden, false otherwise</returns>
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    /// <summary>
    /// Gets the number of words in the scripture.
    /// </summary>
    /// <returns>The word count</returns>
    public int GetWordCount()
    {
        return _words.Count;
    }

    /// <summary>
    /// Gets the number of words currently hidden.
    /// </summary>
    /// <returns>The count of hidden words</returns>
    public int GetHiddenWordCount()
    {
        return _words.Count(w => w.IsHidden());
    }

    /// <summary>
    /// Gets the reference object.
    /// </summary>
    /// <returns>The reference</returns>
    public Reference GetReference()
    {
        return _reference;
    }

    /// <summary>
    /// Gets the list of words.
    /// </summary>
    /// <returns>The words list</returns>
    public List<Word> GetWords()
    {
        return _words;
    }
}
