﻿/* 
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
namespace CsabaDu.DynamicTestData.xUnit.Attributes;

/// <summary>
/// A custom attribute that resets a specified data source after a test method is executed.
/// This attribute is intended to be used with xUnit test methods to ensure that the data source
/// is reset to its initial state after each test run.
/// </summary>
public class ResetTheoryDataSourceAttribute(ArgsCode argsCode, string dataSourceName) : BeforeAfterTestAttribute
{
    private readonly ArgsCode _argsCode = argsCode.Defined(nameof(argsCode));
    private readonly string _dataSourceName
        = dataSourceName ?? throw new ArgumentNullException(nameof(dataSourceName));

    internal const string MethodInfoArgumentCannotBeNullMessage
        = "MethodInfo argument cannot be null.";

    internal const string DeclaringTypeOfTestMethodCannotBeNullMessage
        = "Declaring type of the test method is null.";

    internal string GetDataSourceFieldNotFoundMessage(string testClassTypeName)
    => $"Data source field '{_dataSourceName}' not found in type '{testClassTypeName}'.";

    internal string DataSourceIsNullMessage
    => $"Data source '{_dataSourceName}' is null.";

    internal string DataSourceDoesNotImplementIResettableDataSourceMessage
    => $"Data source '{_dataSourceName}' does not implement IResettableDataSource.";

    /// <summary>
    /// Executes after the test method has run. Resets the specified data source by creating
    /// a new instance of the data source type and invoking the <see cref="IResettableTheoryDataSource.ResetTheoryData"/> method.
    /// </summary>
    /// <param name="testMethod">The <see cref="MethodInfo"/> of the test method that was executed.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if:
    /// - The <paramref name="testMethod"/> is null.
    /// - The declaring type of the test method is null.
    /// - The specified data source field is not found in the test class.
    /// - The data source field value is null.
    /// - The data source does not implement <see cref="IResettableTheoryDataSource"/>.
    /// </exception>
    public override void After(MethodInfo testMethod)
    {
        _ = nullChecked(testMethod, MethodInfoArgumentCannotBeNullMessage, new ArgumentNullException(nameof(testMethod)));

        Type testClassType = nullChecked(testMethod.DeclaringType, MethodInfoArgumentCannotBeNullMessage);
        FieldInfo? dataSource = nullChecked(getDataSourceFieldOfTestMethod(), GetDataSourceFieldNotFoundMessage(testClassType.Name));
        object? dataSourceObject = nullChecked(dataSource.GetValue(null), DataSourceIsNullMessage);
        Type dataSourceType = dataSourceObject.GetType();
        var instance = Activator.CreateInstance(dataSourceType, _argsCode);

        nullChecked(instance as IResettableTheoryDataSource, DataSourceDoesNotImplementIResettableDataSourceMessage, new InvalidCastException())
            .ResetTheoryData();

        #region Local methods
        static T nullChecked<T>(T? arg, string message, Exception? innerException = null)
            => arg is not null ? arg : throw new InvalidOperationException(message, innerException);
        FieldInfo? getDataSourceFieldOfTestMethod()
            => testClassType.GetField(_dataSourceName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        #endregion
    }
}
