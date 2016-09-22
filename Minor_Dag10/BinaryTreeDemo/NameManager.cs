using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BinaryTreeDemo
{
    public class NameManager
    {
        private Tree<string> _names = Tree<string>.Create();

        public void AddNames(IEnumerable<string> names)
        {
            foreach (string name in names)
            {
                _names = _names.Add(name);
            }
        }

        public IEnumerable<string> ShortestNamesWithout(char character)
        {
            if (_names.Count == 0)
            {
                return _names;
            }

            int minimumLength = _names.Min(name => name.Length);

            return _names
                        .Where(name => name.Length == minimumLength)
                        .Where(name => !name.Contains(character));
        }

        public IEnumerable<int> LengthOfNamesWith(char character)
        {
            return _names
                        .Where(name => name.Contains(character))
                        .OrderByDescending(name => name.Length)
                        .Select(name => name.Length);
        }

        public IEnumerable<char> FirstLetterOfNamesContaining(char character)
        {

            return _names
                        .Where(name => name.ToUpper().Contains(character) || name.ToLower().Contains(character))
                        .Select(name => name[0]);
        }

        public IEnumerable<int> AmountOfNamesPerLength()
        {
            return _names
                        .GroupBy(name => name.Length)
                        .Where(group => group.Count() > 0)
                        .Select(group => group.Count());
        }
    }
}
