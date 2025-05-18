
internal class Trait
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }

    public Trait(string name, string description, int value)
    {
        Name = name;
        Description = description;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Name}: {Description} (Value: {Value})";
    }
}
