namespace UtilityHelperTest;
using Xunit;
using UtilityHelper.Extensions;
using FluentAssertions;
using System;

public class StringExtensionTests
{
    [Fact]
    public void WhenStringIsNullOrEmpty()
    {
        string str = string.Empty;
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
        var result = str.Add_Zero_After(5);
        result.Should().Be(str + "0");
    }

    [Fact]
    public void WhenStringAddZeroBefor()
    {
        string str = "Test";
        var result = str.Add_Zero_Before(5);
        result.Should().Be("0" + str);
    }

    [Fact]
    public void WhenStringAddSpace()
    {
        string str = "Test";
        var result = str.Add_SpaceAfter(5);
        result.Should().Be(str + " ");
    }
    [Fact]
    public void WhenStringDecimal()
    {
        var str = "235.4878";
        var result = str.ToDecimal();
        result.Should().Be((decimal)235.4878);
    }
    [Fact]
    public void WhenStringNotDecimal()
    {
        var str = "Test";
        var result = str.ToDecimal();
        result.Should().Be(0);
    }
    [Fact]
    public void WhenStringDecimalNull()
    {
        var str = "Test";
        var result = str.ToDecimalNull();
        result.Should().Be(null);
    }
    [Fact]
    public void WhenStringDecimalNotNull()
    {
        var str = "235.4878";
        var result = str.ToDecimalNull();
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be((decimal)235.4878);
    }

    //
    [Fact]
    public void WhenStringInt16()
    {
        var str = "235";
        var result = str.ToInt16();
        result.Should().Be((Int16)235);
    }
    [Fact]
    public void WhenStringNotInt16()
    {
        var str = "Test";
        var result = str.ToInt16();
        result.Should().Be(0);
    }
    [Fact]
    public void WhenStringInt16Null()
    {
        var str = "Test";
        var result = str.ToInt16Null();
        result.Should().Be(null);
    }
    [Fact]
    public void WhenStringInt16NotNull()
    {
        var str = "235";
        var result = str.ToInt16Null();
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be((Int16)235);
    }
    //
    [Fact]
    public void WhenStringByte()
    {
        var str = "235";
        var result = str.ToByte();
        result.Should().Be((Byte)235);
    }
    [Fact]
    public void WhenStringNotByte()
    {
        var str = "Test";
        var result = str.ToByte();
        result.Should().Be(0);
    }
    [Fact]
    public void WhenStringByteNull()
    {
        var str = "656565562";
        var result = str.ToByteNull();
        result.Should().Be(null);
    }
    [Fact]
    public void WhenStringByteNotNull()
    {
        var str = "235";
        var result = str.ToByteNull();
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be((Byte)235);
    }

    //
    [Fact]
    public void WhenStringInt32()
    {
        var str = "235";
        var result = str.ToInt32();
        result.Should().Be((Int32)235);
    }
    [Fact]
    public void WhenStringNotInt32()
    {
        var str = "Test";
        var result = str.ToInt32();
        result.Should().Be(0);
    }
    [Fact]
    public void WhenStringInt32Null()
    {
        var str = "Test";
        var result = str.ToInt32Null();
        result.Should().Be(null);
    }
    [Fact]
    public void WhenStringInt32NotNull()
    {
        var str = "235";
        var result = str.ToInt32Null();
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be((Int32)235);
    }

    //
    [Fact]
    public void WhenStringInt64()
    {
        var str = "235";
        var result = str.ToInt64();
        result.Should().Be((Int64)235);
    }
    [Fact]
    public void WhenStringNotInt64()
    {
        var str = "Test";
        var result = str.ToInt64();
        result.Should().Be(0);
    }
    [Fact]
    public void WhenStringInt64Null()
    {
        var str = "Test";
        var result = str.ToInt64Null();
        result.Should().Be(null);
    }
    [Fact]
    public void WhenStringInt64NotNull()
    {
        var str = "235";
        var result = str.ToInt64Null();
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be((Int64)235);
    }

    //
    [Fact]
    public void WhenStringDouble()
    {
        var str = "235.889985";
        var result = str.ToDouble();
        result.Should().Be((Double)235.889985);
    }
    [Fact]
    public void WhenStringNotDouble()
    {
        var str = "Test";
        var result = str.ToDouble();
        result.Should().Be(0);
    }
    [Fact]
    public void WhenStringDoubleNull()
    {
        var str = "Test";
        var result = str.ToDoubleNull();
        result.Should().Be(null);
    }
    [Fact]
    public void WhenStringDoubleNotNull()
    {
        var str = "235.889985";
        var result = str.ToDoubleNull();
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be((Double)235.889985);
    }
    //
    [Fact]
    public void WhenStringFloat()
    {
        var str = "235.889985";
        var result = str.ToFloat();
        result.Should().Be((float)235.889985);
    }
    [Fact]
    public void WhenStringNotFloat()
    {
        var str = "Test";
        var result = str.ToFloat();
        result.Should().Be(0);
    }
    [Fact]
    public void WhenStringFloatNull()
    {
        var str = "Test";
        var result = str.ToFloatNull();
        result.Should().Be(null);
    }
    [Fact]
    public void WhenStringFloatNotNull()
    {
        var str = "235.889985";
        var result = str.ToFloatNull();
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be((float)235.889985);
    }
    //
    [Fact]
    public void WhenStringGuid()
    {
        var str = "{FE700FE1-F034-492A-A8C0-1A290EBFECFB}";
        var result = str.ToGuid();
        result.Should().Be(new Guid("{FE700FE1-F034-492A-A8C0-1A290EBFECFB}"));
    }
    [Fact]
    public void WhenStringNotGuid()
    {
        var str = "Test";
        var result = str.ToGuid();
        result.Should().Be(Guid.Empty);
    }
    [Fact]
    public void WhenStringGuidNull()
    {
        var str = "Test";
        var result = str.ToGuidNull();
        result.Should().Be(Guid.Empty);
    }
    [Fact]
    public void WhenStringGuidNotNull()
    {
        var str = "{FE700FE1-F034-492A-A8C0-1A290EBFECFB}";
        var result = str.ToGuidNull();
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be(new Guid("{FE700FE1-F034-492A-A8C0-1A290EBFECFB}"));
    }
    
}

