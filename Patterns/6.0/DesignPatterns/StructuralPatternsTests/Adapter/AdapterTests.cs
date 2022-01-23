// Copyright Information
// ==================================
// DesignPatterns - StructuralPatternsTests - AdapterTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatternsTests.Adapter;

[Collection("AdapterTests")]
public class AdapterTests
{
    [Fact]
    public void ShouldReturnICharacterFromMoose()
    {
        ICharacter bullwinkle = new MooseAdapter(new Moose());
        Assert.Equal(10, bullwinkle.Attack());
        Assert.Equal(5, bullwinkle.Chase());
        Assert.Equal(5, bullwinkle.Flee());
    }

    [Fact]
    public void ShouldReturnICharacterFromFlyingSquirrel()
    {
        ICharacter rocky = new FlyingSquirrelAdapter(new FlyingSquirrel());
        Assert.Equal(1, rocky.Attack());
        Assert.Equal(20, rocky.Chase());
        Assert.Equal(20, rocky.Flee());
    }

    [Fact]
    public void ShouldReturnICharacterFromBadGuy()
    {
        ICharacter boris = new BadGuyAdapter(new BadGuy());
        Assert.Equal(50, boris.Attack());
        Assert.Equal(30, boris.Chase());
        Assert.Throws<Exception>(() => boris.Flee());
    }
}