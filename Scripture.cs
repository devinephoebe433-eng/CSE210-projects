using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            
            // Split text into words and create Word objects
            // We use whitespace to split.
            string[] parts = text.Split(' ');
            foreach (string part in parts)
            {
                _words.Add(new Word(part));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            int wordsToHide = numberToHide;

            // Get indices of words that are not yet hidden
            List<int> visibleIndices = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden())
                {
                    visibleIndices.Add(i);
                }
            }

            // If we have fewer visible words than we want to hide, just hide all of them
            if (visibleIndices.Count <= wordsToHide)
            {
                foreach (int index in visibleIndices)
                {
                    _words[index].Hide();
                }
                return;
            }

            // Otherwise, pick random indices from the visible ones
            for (int i = 0; i < wordsToHide; i++)
            {
                if (visibleIndices.Count == 0) break;

                int randomIndex = random.Next(visibleIndices.Count);
                int wordIndex = visibleIndices[randomIndex];
                
                _words[wordIndex].Hide();
                
                // Remove the index so we don't pick it again
                visibleIndices.RemoveAt(randomIndex);
            }
        }

        public string GetDisplayText()
        {
            string scriptureText = "";
            foreach (Word word in _words)
            {
                if (scriptureText.Length > 0)
                {
                    scriptureText += " ";
                }
                scriptureText += word.GetDisplayText();
            }

            return $"{_reference.GetDisplayText()} {scriptureText}";
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
