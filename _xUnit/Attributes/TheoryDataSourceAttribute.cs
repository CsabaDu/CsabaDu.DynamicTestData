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
namespace CsabaDu.DynamicTestData.xUnit.Attributes;

public abstract class TheoryDataSourceAttribute(ArgsCode argsCode) : BeforeAfterTestAttribute
{
    protected readonly ArgsCode _argsCode = argsCode.Defined(nameof(argsCode));

    #region Exception Messages
    /// <summary>
    /// The message to display when the <see cref="MethodInfo"/> argument is null.
    /// </summary>
    internal const string MethodInfoArgumentCannotBeNullMessage
        = "MethodInfo argument cannot be null.";

    /// <summary>
    /// The message to display when the declaring type of the test method is null.
    /// </summary>
    internal const string DeclaringTypeOfTestMethodCannotBeNullMessage
        = "Declaring type of the test method is null.";

    /// <summary>
    /// The message to display when the specified data source field is not found in the test class.
    /// </summary>
    /// <param name="testClassType">The type of the test class notated with the attribute.</param>
    /// <returns></returns>

    /// <summary>
    /// The message to display when the data source field value is null.
    /// </summary>
    internal const string DataSourceIsNullMessage
    = "Data source is null.";

    /// <summary>
    /// The message to display when the data source does not implement <see cref="IResettableTheoryDataSource"/> interface.
    /// </summary>
    internal static string DataSourceDoesNotImplementIResettableTheoryDataSourceInterfaceMessage
    = $"Data source field not found in type '{typeof(IResettableTheoryDataSource).Name} interface.";

    internal static string GetNoStaticFieldFoundMessage(Type testClassType)
    => $"No static field of type derived from {nameof(DynamicTheoryDataSource)} found in {testClassType.Name}.";
    #endregion

    protected void BeforeAfter(MethodInfo dataSourceMethod)
    {
        _ = nullChecked(dataSourceMethod, MethodInfoArgumentCannotBeNullMessage, new ArgumentNullException(nameof(dataSourceMethod)));

        Type testClassType = nullChecked(dataSourceMethod.DeclaringType, MethodInfoArgumentCannotBeNullMessage);
        FieldInfo dataSourceField = getNullCheckedDataSourceField(testClassType);
        object? dataSourceObject = nullChecked(dataSourceField.GetValue(null), DataSourceIsNullMessage);
        Type dataSourceType = dataSourceObject.GetType();
        var instance = Activator.CreateInstance(dataSourceType, _argsCode) as IResettableTheoryDataSource;

        nullChecked(instance, DataSourceDoesNotImplementIResettableTheoryDataSourceInterfaceMessage, new InvalidCastException())
            .ResetTheoryData();

        #region Local Methods
        static FieldInfo getNullCheckedDataSourceField(Type testClassType)
        {
            FieldInfo?[] fields = testClassType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            FieldInfo? dataSourceField = fields.FirstOrDefault(f => typeof(DynamicTheoryDataSource).IsAssignableFrom(f?.FieldType));
            return nullChecked(dataSourceField, GetNoStaticFieldFoundMessage(testClassType));
        }

        static T nullChecked<T>(T? arg, string message, Exception? innerException = null)
        => arg is not null ? arg : throw new InvalidOperationException(message, innerException);
        #endregion
    }
}

