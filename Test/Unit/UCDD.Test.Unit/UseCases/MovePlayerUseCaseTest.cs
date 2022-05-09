using NUnit.Framework;
using UCDD.Core.UseCases;

namespace UCDD.Test.Unit.UseCases;

public class Tests
{
    private MovePlayerUseCase? _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new MovePlayerUseCase();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}