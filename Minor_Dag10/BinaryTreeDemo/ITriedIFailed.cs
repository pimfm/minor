using BinaryTreeDemo;
using System.Collections.Generic;
using System.Linq;

public class NameQueryBuilder
{
    private Tree<string> _names = Tree<string>.Create();
    private IEnumerable<string> _query;

    public void AddNames(IEnumerable<string> names)
    {
        foreach (string name in names)
        {
            _names.Add(name);
        }
        _query = _names;
    }

    public NameQueryBuilder ShorterThan(int length)
    {
        _query = _names.Where(name => name.Length < length);

        return this;
    }

    public NameQueryBuilder Without(char character)
    {
        _query = _names.Where(name => name.Contains(character));

        return this;
    }

    public IEnumerable<string> Build()
    {
        return _query;
    }
}