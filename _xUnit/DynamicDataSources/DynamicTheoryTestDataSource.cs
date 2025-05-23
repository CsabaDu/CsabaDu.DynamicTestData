﻿// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.DynamicDataSources;

public abstract class DynamicTheoryTestDataSource(ArgsCode argsCode)
: DynamicTheoryDataSourceBase(argsCode)
{
    #region Properties
    /// <summary>
    /// Gets or sets the TheoryTestData used for parameterized tests.
    /// </summary>
    protected ITheoryTestData? TheoryTestData { get; set; } = null;
    #endregion

    #region Methods
    #region ResetTheoryTestData
    /// <summary>
    /// Resets the theory test data to its default state.
    /// </summary>
    /// <remarks>This method sets the <see cref="TheoryTestData"/> property to <see langword="null"/>, 
    /// effectively clearing any existing data. Use this method to reinitialize or clear the test data.</remarks>
    public void ResetTheoryTestData()
    {
        TheoryTestData = null;
    }
    #endregion

    #region AddOptionalToTheoryTestData
    /// <summary>
    /// Executes the provided action with an optional temporary ArgsCode override.
    /// </summary>
    /// <param name="addTestDataToTheoryTestData"></param>
    /// <param name="argsCode"></param>
    public void AddOptionalToTheoryTestData(
        Action addTestDataToTheoryTestData,
        ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(
            addTestDataToTheoryTestData,
            nameof(addTestDataToTheoryTestData));
        WithOptionalArgsCode(this,
            addTestDataToTheoryTestData,
            argsCode);
    }
    #endregion

    #region AddToTheoryTestData
    /// <summary>
    /// Adds the specified test data to the <see cref="TheoryTestData"/> collection, creating the collection if it does
    /// not already exist.
    /// </summary>
    /// <remarks>The behavior of this method depends on the value of the <see cref="ArgsCode"/> property:
    /// <list type="bullet"> <item> <description>If <see cref="ArgsCode.Instance"/> is set, the method adds the test
    /// data to a collection of type <c>ITestData&lt;TResult, T1&gt;</c>.</description> </item> <item> <description>If
    /// <see cref="ArgsCode.Properties"/> is set, the method adds the test data to a collection of type
    /// <c>TheoryTestData&lt;TResult, T1&gt;</c>.</description> </item> </list></remarks>
    /// <typeparam name="TResult">The type of the result produced by the test data. Must be non-nullable.</typeparam>
    /// <typeparam name="T1">The type of the first parameter used in the test data.</typeparam>
    /// <param name="testData">The test data to add to the <see cref="TheoryTestData"/> collection. Cannot be null.</param>
    public void AddToTheoryTestData<TResult, T1>(
        ITestData<TResult, T1> testData)
    where TResult : notnull
    {
        TheoryTestData = ArgsCode switch
        {
            ArgsCode.Instance
            => TheoryTestData<ITestData<TResult, T1>>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            ArgsCode.Properties
            => TheoryTestData<TResult, T1>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            _
            => throw ArgsCodeProperyValueInvalidOperationException,
        };
    }

    /// <inheritdoc cref="AddToTheoryTestData{TResult, T1}"/>
    /// <typeparam name="T2">The type of the second parameter used in the test data.</typeparam>
    public void AddToTheoryTestData<TResult, T1, T2>(
        ITestData<TResult, T1, T2> testData)
    where TResult : notnull
    {
        TheoryTestData = ArgsCode switch
        {
            ArgsCode.Instance
            => TheoryTestData<ITestData<TResult, T1, T2>>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            ArgsCode.Properties
            => TheoryTestData<TResult, T1, T2>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            _
            => throw ArgsCodeProperyValueInvalidOperationException,
        };
    }

    /// <inheritdoc cref="AddToTheoryTestData{TResult, T1, T2}"/>
    /// <typeparam name="T3">The type of the third parameter used in the test data.</typeparam>
    public void AddToTheoryTestData<TResult, T1, T2, T3>(
        ITestData<TResult, T1, T2, T3> testData)
    where TResult : notnull
    {
        TheoryTestData = ArgsCode switch
        {
            ArgsCode.Instance
            => TheoryTestData<ITestData<TResult, T1, T2, T3>>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            ArgsCode.Properties
            => TheoryTestData<TResult, T1, T2, T3>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            _
            => throw ArgsCodeProperyValueInvalidOperationException,
        };
    }

    /// <inheritdoc cref="AddToTheoryTestData{TResult, T1, T2, T3}"/>
    /// <typeparam name="T4">The type of the fourth parameter used in the test data.</typeparam>
    public void AddToTheoryTestData<TResult, T1, T2, T3, T4>(
        ITestData<TResult, T1, T2, T3, T4> testData)
    where TResult : notnull
    {
        TheoryTestData = ArgsCode switch
        {
            ArgsCode.Instance
            => TheoryTestData<ITestData<TResult, T1, T2, T3, T4>>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            ArgsCode.Properties
            => TheoryTestData<TResult, T1, T2, T3, T4>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            _
            => throw ArgsCodeProperyValueInvalidOperationException,
        };
    }

    /// <inheritdoc cref="AddToTheoryTestData{TResult, T1, T2, T3, T4}"/>
    /// <typeparam name="T5">The type of the fifth parameter used in the test data.</typeparam>
    public void AddToTheoryTestData<TResult, T1, T2, T3, T4, T5>(
        ITestData<TResult, T1, T2, T3, T4, T5> testData)
    where TResult : notnull
    {
        TheoryTestData = ArgsCode switch
        {
            ArgsCode.Instance
            => TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5>>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            ArgsCode.Properties
            => TheoryTestData<TResult, T1, T2, T3, T4, T5>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            _
            => throw ArgsCodeProperyValueInvalidOperationException,
        };
    }

    /// <inheritdoc cref="AddToTheoryTestData{TResult, T1, T2, T3, T4, T5}"/>
    /// <typeparam name="T6">The type of the sixth parameter used in the test data.</typeparam>
    public void AddToTheoryTestData<TResult, T1, T2, T3, T4, T5, T6>(
        ITestData<TResult, T1, T2, T3, T4, T5, T6> testData)
    where TResult : notnull
    {
        TheoryTestData = ArgsCode switch
        {
            ArgsCode.Instance
            => TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6>>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            ArgsCode.Properties
            => TheoryTestData<TResult, T1, T2, T3, T4, T5, T6>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            _
            => throw ArgsCodeProperyValueInvalidOperationException,
        };
    }

    /// <inheritdoc cref="AddToTheoryTestData{TResult, T1, T2, T3, T4, T5, T6}"/>
    /// <typeparam name="T7">The type of the seventh parameter used in the test data.</typeparam>
    public void AddToTheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7>(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7> testData)
    where TResult : notnull
    {
        TheoryTestData = ArgsCode switch
        {
            ArgsCode.Instance
            => TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7>>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            ArgsCode.Properties
            => TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            _
            => throw ArgsCodeProperyValueInvalidOperationException,
        };
    }

    /// <inheritdoc cref="AddToTheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7}"/>
    /// <typeparam name="T8">The type of the eighth parameter used in the test data.</typeparam>
    public void AddToTheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> testData)
    where TResult : notnull
    {
        TheoryTestData = ArgsCode switch
        {
            ArgsCode.Instance
            => TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            ArgsCode.Properties
            => TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            _
            => throw ArgsCodeProperyValueInvalidOperationException,
        };
    }

    /// <inheritdoc cref="AddToTheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7, T8}"/>
    /// <typeparam name="T9">The type of the ninth parameter used in the test data.</typeparam>
    public void AddToTheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> testData)
    where TResult : notnull
    {
        TheoryTestData = ArgsCode switch
        {
            ArgsCode.Instance
            => TheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            ArgsCode.Properties
            => TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>
                .AddToOrInitTheoryTestData(TheoryTestData, testData),
            _
            => throw ArgsCodeProperyValueInvalidOperationException,
        };
    
    }
    #endregion

    #region Static methods
    /// <summary>
    /// Converts the properties of the specified <see cref="ITestData"/> instance into an array of arguments.
    /// </summary>
    /// <param name="testData">The <see cref="ITestData"/> instance whose properties are to be converted to arguments. Cannot be <see
    /// langword="null"/>.</param>
    /// <returns>An array of objects representing the properties of the <paramref name="testData"/> instance. The array may
    /// contain <see langword="null"/> values if the properties are null.</returns>
    internal static object?[] PropertiesToArgs(ITestData testData)
    => NotNullTestData(testData)
        .PropertiesToArgs(testData is IExpected);

    /// <summary>
    /// Retrieves the specified test data instance if it is valid and of the expected type.
    /// </summary>
    /// <typeparam name="TTestData">The expected type of the test data, which must implement <see cref="ITestData"/>.</typeparam>
    /// <param name="testData">The test data to validate. This parameter cannot be <see langword="null"/>.</param>
    /// <returns>The test data instance cast to the specified type <typeparamref name="TTestData"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="testData"/> is <see langword="null"/>.</exception>
    internal static TTestData GetValidTestData<TTestData>(
        ITestData? testData)
    where TTestData : ITestData
    => NotNullTestData(testData)
        is TTestData typedTestData ?
            typedTestData
            : throw ArgumentsMismatchException;

    /// <summary>
    /// Ensures that the provided test data is not null.
    /// </summary>
    /// <typeparam name="T">The type of the test data.</typeparam>
    /// <param name="testData">The test data to validate. Must not be <see langword="null"/>.</param>
    /// <returns>The provided <paramref name="testData"/> if it is not <see langword="null"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="testData"/> is <see langword="null"/>.</exception>
    internal static T NotNullTestData<T>(T? testData)
    => testData ?? throw new ArgumentNullException(nameof(testData));
    #endregion
    #endregion
}
