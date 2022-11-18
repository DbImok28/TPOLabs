import org.example.Calculator;
import org.junit.Assert;
import org.junit.Test;

public class TestCalculator {
    @Test
    public void multiplyTest()
    {
        Double expected = 2.0 * 5.0 * 5.0;
        String expr = "2 * 5 * 5";
        Double result = Calculator.evaluate(expr);
        Assert.assertEquals(expected, result);
    }
    @Test
    public void additionTest()
    {
        Double expected = 80.0 + 6.0 + 1.0;
        String expr = "80 + 6 + 1";
        Double result = Calculator.evaluate(expr);
        Assert.assertEquals(expected, result);
    }
    @Test
    public void subtractTest()
    {
        Double expected = 89.0 - 19.0;
        String expr = "89 - 19";
        Double result = Calculator.evaluate(expr);
        Assert.assertEquals(expected, result);
    }
    @Test
    public void divideTest()
    {
        Double expected = 15.0 / 5.0 / 3.0;
        String expr = "15 / 5 / 3";
        Double result = Calculator.evaluate(expr);
        Assert.assertEquals(expected, result);
    }
    @Test
    public void bracketTest()
    {
        Double expected = 8.0 / ( 12.0 - 8.0 ) - 1.0;
        String expr = "8 / ( 12 - 8 ) - 1";
        Double result = Calculator.evaluate(expr);
        Assert.assertEquals(expected, result);
    }
    @Test
    public void manyTest()
    {
        Double expected = 12.0 / 6.0 * 32.0 / 2.0;
        String expr = "12 / 6 * 32 / 2";
        Double result = Calculator.evaluate(expr);
        Assert.assertEquals(expected, result);
    }
    @Test
    public void priorityTest()
    {
        Double expected = 12.0 + 6.0 * 32.0;
        String expr = "12 + 6 * 32";
        Double result = Calculator.evaluate(expr);
        Assert.assertEquals(expected, result);
    }
    @Test
    public void priorityWithBracketTest()
    {
        Double expected = ( 12.0 + 6.0 ) * 32.0 - 4.0 * 6.0;
        String expr = "( 12 + 6 ) * 32 - 4 * 6";
        Double result = Calculator.evaluate(expr);
        Assert.assertEquals(expected, result);
    }
    @Test
    public void negativeNumbersTest()
    {
        Double expected = ( -12.0 * 6.0 ) * -32.0;
        String expr = "( -12 * 6 ) * -32";
        Double result = Calculator.evaluate(expr);
        Assert.assertEquals(expected, result);
    }
    @Test
    public void devideByZeroTest()
    {
        String expr = "14 / 0";
        Double result = Calculator.evaluate(expr);
        Assert.assertTrue(Double.isInfinite(result));
    }
}
