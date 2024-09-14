namespace ElementalForms.Test;

public class ElementalFormsTest
{
    [Fact]
    public void EmptyStringTest()
    {
        string[][] result = ElementalForms.GetElementalForms("");

        Assert.Empty(result);
    }

    [Fact]
    public void SimpleElementalWords()
    {
        var cases = new[] {
            ("", new string[0][]),
            ("Yes", new[] { new[] {"Yttrium (Y)", "Einsteinium (Es)"} }),
            ("beach", new[] { new[] {"Beryllium (Be)", "Actinium (Ac)", "Hydrogen (H)"} }),
            ("snack", new[] {
                new[] {"Sulfur (S)", "Nitrogen (N)", "Actinium (Ac)", "Potassium (K)"},
                new[] {"Sulfur (S)", "Sodium (Na)", "Carbon (C)", "Potassium (K)"},
                new[] {"Tin (Sn)", "Actinium (Ac)", "Potassium (K)"}
            }),
        };

        
        foreach (var (word, expected) in cases) {
            var actual = ElementalForms.GetElementalForms(word);
            Assert.Equal(expected, actual);
        }
    }
}