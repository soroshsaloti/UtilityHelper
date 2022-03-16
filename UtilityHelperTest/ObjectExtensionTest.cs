namespace UtilityHelperTest;
using Xunit;
using UtilityHelper;
using FluentAssertions;
using System.IO;
using System;

public class ObjectExtensionTest
{
    [Fact]
    public void WhenCompressAndDcompress()
    {
        var byt = System.Text.UTF8Encoding.UTF8.GetBytes("Test object");
        var comres = byt.Compress();
        Assert.NotNull(comres);
        var dcompres = comres.Decompress();
        Assert.NotNull(dcompres);
        dcompres.Should().BeEquivalentTo(byt);
    }

    [Fact]
    public void WhenDcompressToMemeoryStreem()
    {
        var byt = System.Text.UTF8Encoding.UTF8.GetBytes("Test object");
        var compressedStream = new MemoryStream(byt);
        var comres =  byt.Compress();
        Assert.NotNull(comres);
        var dcompres = comres.DecompressMemoryStream();
        Assert.NotNull(dcompres);
        dcompres.ToArray().Length.Should().Be(compressedStream.ToArray().Length);
        dcompres.ToArray().Should().BeEquivalentTo(compressedStream.ToArray());
    }
    [Fact]
    public void WhenGetNumberByGuid()
    {
        var id = Guid.NewGuid();
        var g1 = id.GetNumberByGuid();
        var g2 = id.ToString().GetNumberByStringGuid();
        g1.Should().Be(g2);

        
    }
}
