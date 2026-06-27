namespace ExpressionTree.Example;

internal class Person
{
    public required string Name { get; init; }
    public int Age { get; init; }

    public override string ToString()
    {
        return $"{Name} is {Age} years old";
    }
}