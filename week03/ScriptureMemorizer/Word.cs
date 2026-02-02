/// <summary>
/// Represents a single word in a scripture. Encapsulates the word's text and its shown/hidden state.
/// </summary>
public class Word
{
    private string _text;
    private bool _isHidden;

    /// <summary>
    /// Initializes a new Word with the given text and initially shown state.
    /// </summary>
    /// <param name="text">The word text</param>
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    /// <summary>
    /// Hides the word by marking it as hidden.
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// Returns the word text if visible, otherwise returns underscores matching the word length.
    /// </summary>
    /// <returns>The word text or underscores</returns>
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }

    /// <summary>
    /// Gets whether this word is hidden.
    /// </summary>
    /// <returns>True if hidden, false if shown</returns>
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// Gets the original text of the word.
    /// </summary>
    /// <returns>The word text</returns>
    public string GetText()
    {
        return _text;
    }
}
