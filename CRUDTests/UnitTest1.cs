namespace CRUDTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        MyMath mm = new MyMath();
        int a = 2, b = 3;
        int expected = 5;

        //Act
        int actual = mm.Add(a, b);


        //Assert
        Assert.Equal(expected, actual);
    }
}