namespace UtilityHelperTest;
using Xunit;
using UtilityHelper.Extensions;
using FluentAssertions;

public class StringExtensionTests
{
    [Fact]
    public void WhenStringIsNullOrEmpty()
    {
        string str = null;
        Assert.True(str.IsNullOrEmpty());
    }

    [Fact]
    public void WhenStringIsNotNullOrEmptyWithSpace()
    {
        string str = " ";
        Assert.False(str.IsNullOrEmpty());
    }

    [Fact]
    public void WhenStringIsNullOrEmptyWithSpace()
    {
        string str = " ";
        Assert.True(str.IsNullOrEmpty(true));
    }

    [Fact]
    public void WhenStringAddZeroAfter()
    {
        string str = "Test";
        var result= str.Add_Zero_After(5);
        result.Should().Be(str + "0");
    }

    [Fact]
    public void WhenStringAddSpace()
    {
        string str = "Test";
        var result = str.Add_SpaceAfter(5);
        result.Should().Be(str + " ");
    }

}

