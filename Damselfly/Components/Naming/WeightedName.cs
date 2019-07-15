namespace Damselfly.Components.Naming
{
    public readonly struct WeightedName
    {
        readonly public int Weight;

        readonly public string Name;

        public WeightedName(int weight, string name)
        {
            Weight = weight;
            Name = name;
        }
    }
}
