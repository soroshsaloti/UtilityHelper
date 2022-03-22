namespace UtilityHelperTest;

using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilityHelper.Extensions;
using Xunit;

public class RegExExtesionTests
{
    [Fact]
    public void WhenMatchTrue()
    {
        "1235".IsMatch_Digit().Should().BeTrue(); 
        "3589.25".IsMatch_Decimal().Should().BeTrue();
        "sfsfs@test.com".IsMatch_Email().Should().BeTrue();
        "http://sfsfs.com".IsMatch_WebAddress().Should().BeTrue(); 
        "02:25".IsMatch_Time12().Should().BeTrue();
        "13:20".IsMatch_Time24().Should().BeTrue();
        "23:05".IsMatch_TimeDuration().Should().BeTrue();
        "192.168.1.1".IsMatch_IPAddress().Should().BeTrue();
        "12qwasXZ".IsMatch_Password().Should().BeTrue();
    }
    [Fact]
    public void WhenMatchFalse()
    {    
        "sfsfs".IsMatch_Digit().Should().BeFalse();
        "sfsfs".IsMatch_Decimal().Should().BeFalse();
        "sfsfs".IsMatch_Email().Should().BeFalse();
        "sfsfs".IsMatch_WebAddress().Should().BeFalse(); 
        "sfsfs".IsMatch_Time12().Should().BeFalse();
        "sfsfs".IsMatch_Time24().Should().BeFalse();
        "sfsfs".IsMatch_TimeDuration().Should().BeFalse();
        "sfsfs".IsMatch_IPAddress().Should().BeFalse();
        "sfsfs".IsMatch_Password().Should().BeFalse();
    }
}
