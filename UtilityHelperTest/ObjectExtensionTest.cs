namespace UtilityHelperTest;
using Xunit;
using UtilityHelper.Extensions;
using UtilityHelper.Infostruct;
using FluentAssertions;
using System.IO;
using System;
using System.Linq;

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
        var comres = byt.Compress();
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
        var g2 = id.ToString().GetNumberByGuid();
        g1.Should().Be(g2);
    }

    [Theory]
    [InlineData(FileContentType.aac, "audio/aac")]
    [InlineData(FileContentType.xls,   "application/vnd.ms-excel")]
    [InlineData(FileContentType.xlsx, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
    public void WhenEnumCaption(FileContentType fileContentType,string expect)
    {
        var title =  fileContentType.CaptionEnum();
        title.Should().Be(expect);  
    }

    [Fact]
    public void WhenGetTitleAtributeTitle()
    {
       var items  = typeof(FileContentType).GetTitleFields();   
        items.ToList().Count.Should().Be(74);
    }

    [Fact]
    public void WhenGetTitleAtributeCaption()
    {
        var items = typeof(FileContentType).GetCaptionFields();
        items.ToList().Count.Should().Be(74);
    }
}
