public class DisplayWood : DisplayText
{
    protected override Resource FindResource()
    {
        return FindObjectOfType<PlayerResources>().wood;
    }
}
