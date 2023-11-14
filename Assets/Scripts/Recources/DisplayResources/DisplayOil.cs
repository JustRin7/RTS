public class DisplayOil : DisplayText
{
    protected override Resource FindResource()
    {
        return FindObjectOfType<PlayerResources>().oil;
    }
}
