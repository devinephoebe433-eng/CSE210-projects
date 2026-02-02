/// <summary>
/// Represents a scripture reference (e.g., "John 3:16" or "Proverbs 3:5-6").
/// Encapsulates the book name, chapter, and verse(s).
/// </summary>
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    private bool _isRange;

    /// <summary>
    /// Initializes a Reference for a single verse (e.g., "John 3:16").
    /// </summary>
    /// <param name="book">The book name</param>
    /// <param name="chapter">The chapter number</param>
    /// <param name="verse">The verse number</param>
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
        _isRange = false;
    }

    /// <summary>
    /// Initializes a Reference for a verse range (e.g., "Proverbs 3:5-6").
    /// </summary>
    /// <param name="book">The book name</param>
    /// <param name="chapter">The chapter number</param>
    /// <param name="verse">The starting verse number</param>
    /// <param name="endVerse">The ending verse number</param>
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
        _isRange = true;
    }

    /// <summary>
    /// Gets the string representation of the reference.
    /// </summary>
    /// <returns>The formatted reference (e.g., "John 3:16" or "Proverbs 3:5-6")</returns>
    public string GetReference()
    {
        if (_isRange)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        return $"{_book} {_chapter}:{_verse}";
    }

    /// <summary>
    /// Gets the book name.
    /// </summary>
    /// <returns>The book name</returns>
    public string GetBook()
    {
        return _book;
    }

    /// <summary>
    /// Gets the chapter number.
    /// </summary>
    /// <returns>The chapter number</returns>
    public int GetChapter()
    {
        return _chapter;
    }

    /// <summary>
    /// Gets the starting verse number.
    /// </summary>
    /// <returns>The verse number</returns>
    public int GetVerse()
    {
        return _verse;
    }

    /// <summary>
    /// Gets the ending verse number (same as starting verse if not a range).
    /// </summary>
    /// <returns>The ending verse number</returns>
    public int GetEndVerse()
    {
        return _endVerse;
    }
}
