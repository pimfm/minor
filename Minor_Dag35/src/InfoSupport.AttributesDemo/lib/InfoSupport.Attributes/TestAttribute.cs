using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class TestAttribute : Attribute
{
    public readonly object[] Input;
    public object ExpectedOutput { get; set; }
    public string ExpectedException { get; set; }

    public TestAttribute(params object[] input)
    {
        Input = input;
    }
}