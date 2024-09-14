namespace ElementalForms.Test;

public class ElementalFormsTest
{
    [Fact]
    public void EmptyStringTest()
    {
        ElementalForms elemental = new ElementalForms();

        string[][] result = elemental.GetElementalForms("");

        Assert.Empty(result);
    }
}