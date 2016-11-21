using InfoSupport.AttributesDemo;
using System;
using System.Reflection;

namespace InfoSupport.TestTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load(new AssemblyName("InfoSupport.AttributesDemo"));
            BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine(" " + type.Name);
                foreach (MethodInfo method in type.GetMethods(flags))
                {
                    foreach (TestAttribute attribute in method.GetCustomAttributes<TestAttribute>())
                    {
                        MathTest instance = Activator.CreateInstance<MathTest>();
                        
                        try
                        {
                            object output = method.Invoke(instance, attribute.Input);
                            bool passed = output.Equals(attribute.ExpectedOutput);

                            string checkbox = passed ? "[X]" : "[ ]";
                            string expected = passed ? "" : $"(expected {attribute.ExpectedOutput})";

                            Console.WriteLine($"\t{checkbox} {method.Name}({string.Join(", ", attribute.Input)}) => {output} {expected}");
                        }
                        catch (TargetInvocationException exception)
                        {
                            string thrownExceptionName = exception.InnerException.GetType().Name;
                            bool passed = thrownExceptionName.Equals(attribute.ExpectedException);

                            string checkbox = passed ? "[X]" : "[ ]";
                            string expected = passed ? "" : $"(expected {attribute.ExpectedException})";

                            Console.WriteLine($"\t{checkbox} {method.Name}({string.Join(", ", attribute.Input)}) => {thrownExceptionName} {expected}");
                        }
                    }
                    Console.WriteLine();
                }
           }
        }
    }
}
