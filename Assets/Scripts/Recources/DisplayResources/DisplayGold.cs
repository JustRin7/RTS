using System;


public class DisplayGold : DisplayText
{
    protected override Resource FindResource()
    {
        return FindObjectOfType<PlayerResources>().gold;
    }
}