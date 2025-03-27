/* 
 * MIT License
 * 
 * Copyright (c) 2025. Csaba Dudas (CsabaDu)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class NativeTestDataSource(ArgsCode argsCode) : DynamicDataSource(argsCode)
{
    private readonly DateTime DateTimeNow = DateTime.Now;

    private DateTime _thisDate;
    private DateTime _otherDate;

    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public IEnumerable<object?[]> IsOlderReturnsArgsToList(ArgsCode? argsCode = null)
    {
        bool expected = true;
        string definition = "thisDate is greater than otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(-1);
        yield return optionalToArgs(); // 3. Call 'optionalToArgs' method.

        expected = false;
        definition = "thisDate equals otherDate";
        _otherDate = DateTimeNow;
        yield return optionalToArgs(); // 3. Call 'optionalToArgs' method.

        definition = "thisDate is less than otherDate";
        _thisDate = DateTimeNow.AddDays(-1);
        yield return optionalToArgs(); // 3. Call 'optionalToArgs' method.

        #region Local methods
        // 2. Add 'optionalToArgs' local method to the enclosing method
        // and call 'OptionalToArgs' method with the testDataToArgs and argsCode parameters.
        object?[] optionalToArgs()
        => OptionalToArgs(testDataToArgs, argsCode);

        object?[] testDataToArgs()
        => TestDataReturnsToArgs(definition, expected, _thisDate, _otherDate);
        #endregion
    }

    // 1. Add an optional 'ArgsCode?' parameter to the method signature.
    public IEnumerable<object?[]> IsOlderThrowsArgsToList(ArgsCode? argsCode = null)
    {
        string paramName = "otherDate";
        _thisDate = DateTimeNow;
        _otherDate = DateTimeNow.AddDays(1);
        yield return optionalToArgs(); // 3. Call 'optionalToArgs' method.

        paramName = "thisDate";
        _thisDate = DateTimeNow.AddDays(1);
        yield return optionalToArgs(); // 3. Call 'optionalToArgs' method.

        #region Local methods
        // 2. Add 'optionalToArgs' local method to the enclosing method
        // and call 'OptionalToArgs' method with the testDataToArgs and argsCode parameters.
        object?[] optionalToArgs()
        => OptionalToArgs(testDataToArgs, argsCode);

        object?[] testDataToArgs()
        => TestDataThrowsToArgs(getDefinition(), getExpected(), _thisDate, _otherDate);

        string getDefinition()
        => $"{paramName} is greater than the current date";

        ArgumentOutOfRangeException getExpected()
        => new(paramName, DemoClass.GreaterThanCurrentDateTimeMessage);
        #endregion
    }
}
