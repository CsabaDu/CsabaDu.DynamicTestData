// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.TheoryTestDataTypes;

/// <summary>
/// Represents a collection of test data for parameterized unit tests, specifically designed to work with test data
/// objects implementing <see cref="ITestData"/>.
/// </summary>
/// <remarks>This class extends <see cref="TheoryData{T}"/> to provide additional functionality for managing test
/// data in scenarios where the test data type implements <see cref="ITestData"/>. It also implements <see
/// cref="ITheoryTestData{TTestData}"/> to support integration with custom test data workflows.</remarks>
/// <typeparam name="TTestData">The type of test data contained in the collection. Must implement <see cref="ITestData"/>.</typeparam>
public sealed class TheoryTestData<TTestData>
: TheoryData<TTestData>,
ITheoryTestData<TTestData>
where TTestData : ITestData
{
    private TheoryTestData(TTestData testData)
    => AddTestData(testData);

    /// <inheritdoc cref="ITheoryTestData{TTestData}.AddTestData(TTestData)"/>/>
    public void AddTestData(TTestData testData)
    => Add(NotNullTestData(testData));

    /// <summary>
    /// Adds the specified test data to an existing <see cref="TheoryTestData{TTestData}"/> instance or creates a new
    /// one if none exists.
    /// </summary>
    /// <param name="theoryTestData">An optional existing <see cref="ITheoryTestData"/> instance to which the test data will be added. If null or
    /// incompatible, a new instance is created.</param>
    /// <param name="testData">The test data to add. Must be of type <typeparamref name="TTestData"/>.</param>
    /// <returns>A <see cref="TheoryTestData{TTestData}"/> instance containing the specified test data. If <paramref
    /// name="theoryTestData"/> is compatible, the data is added to it; otherwise, a new instance is returned.</returns>
    public static TheoryTestData<TTestData> AddToOrInitTheoryTestData(
        ITheoryTestData? theoryTestData,
        ITestData testData)
    {
        var validTestData =
            GetValidTestData<TTestData>(testData);

        if (theoryTestData is not TheoryTestData<TTestData> validTheoryTestData)
        {
            return new(validTestData);
        }

        validTheoryTestData.AddTestData(validTestData);
        return validTheoryTestData;
    }
}

/// <summary>
/// Represents a collection of test data for parameterized unit tests, supporting the addition of  strongly-typed test
/// data rows for use with xUnit's <see cref="Xunit.TheoryAttribute"/>.
/// </summary>
/// <remarks>This class extends <see cref="Xunit.Sdk.TheoryData{TResult, T1}"/> to provide additional
/// functionality  for managing test data in a strongly-typed manner. It also implements <see
/// cref="ITheoryTestData{T}"/>  to integrate with custom test data interfaces.</remarks>
/// <typeparam name="TResult">The type of the expected result for the test case. Must be non-null.</typeparam>
/// <typeparam name="T1">The type of the first parameter for the test case.</typeparam>
public class TheoryTestData<TResult, T1>
: TheoryData<TResult, T1>,
ITheoryTestData<ITestData<TResult, T1>>
where TResult : notnull
{
    private TheoryTestData(ITestData<TResult, T1> testData)
    => AddTestData(testData);

    /// <inheritdoc cref="ITheoryTestData{TTestData}.AddTestData(TTestData)"/>/>
    public void AddTestData(ITestData<TResult, T1> testData)
    => AddRow(PropertiesToArgs(testData));

    /// <summary>
    /// Adds the specified test data to an existing <see cref="TheoryTestData{TResult, T1}"/> instance or creates a new
    /// instance if the provided theory test data is null or incompatible.
    /// </summary>
    /// <param name="theoryTestData">An optional existing <see cref="ITheoryTestData"/> instance to which the test data will be added. If null or
    /// incompatible, a new <see cref="TheoryTestData{TResult, T1}"/> instance will be created.</param>
    /// <param name="testData">The test data to add. Must implement <see cref="ITestData{TResult, T1}"/>; otherwise, an exception is thrown.</param>
    /// <returns>A <see cref="TheoryTestData{TResult, T1}"/> instance containing the provided test data. If <paramref
    /// name="theoryTestData"/> is compatible, the test data is added to it; otherwise, a new instance is returned.</returns>
    public static TheoryTestData<TResult, T1> AddToOrInitTheoryTestData(
        ITheoryTestData? theoryTestData,
        ITestData testData)
    {
        var validTestData =
            GetValidTestData<ITestData<TResult, T1>>(testData);

        if (theoryTestData is not TheoryTestData<TResult, T1> validTheoryTestData)
        {
            return new(validTestData);
        }

        validTheoryTestData.AddTestData(validTestData);
        return validTheoryTestData;
    }
}

/// <inheritdoc cref="TheoryTestData{TResult, T1}"/>
/// <typeparam name="T2"> The type of the second parameter for the test case.
public class TheoryTestData<TResult, T1, T2>
: TheoryData<TResult, T1, T2>,
ITheoryTestData<ITestData<TResult, T1, T2>>
where TResult : notnull
{
    private TheoryTestData(ITestData<TResult, T1, T2> testData)
    => AddTestData(testData);

    /// <inheritdoc cref="ITheoryTestData{TTestData}.AddTestData(TTestData)"/>/>
    public void AddTestData(ITestData<TResult, T1, T2> testData)
    => AddRow(PropertiesToArgs(testData));

    /// <summary>
    /// Adds the specified test data to an existing <see cref="TheoryTestData{TResult, T1, T2}"/> instance  or creates a
    /// new instance if the provided theory test data is null or incompatible.
    /// </summary>
    /// <param name="theoryTestData">An optional existing <see cref="ITheoryTestData"/> instance to which the test data will be added.  If null or
    /// incompatible, a new <see cref="TheoryTestData{TResult, T1, T2}"/> instance will be created.</param>
    /// <param name="testData">The test data to add, which must implement <see cref="ITestData{TResult, T1, T2}"/>. This parameter cannot be
    /// null.</param>
    /// <returns>A <see cref="TheoryTestData{TResult, T1, T2}"/> instance containing the provided test data. If <paramref
    /// name="theoryTestData"/> was compatible, the same instance is returned with the new data added;  otherwise, a new
    /// instance is created.</returns>
    public static TheoryTestData<TResult, T1, T2> AddToOrInitTheoryTestData(
        ITheoryTestData? theoryTestData,
        ITestData testData)
    {
        var validTestData =
            GetValidTestData<ITestData<TResult, T1, T2>>(testData);

        if (theoryTestData is not TheoryTestData<TResult, T1, T2> validTheoryTestData)
        {
            return new(validTestData);
        }

        validTheoryTestData.AddTestData(validTestData);
        return validTheoryTestData;
    }
}

/// <inheritdoc cref="TheoryTestData{TResult, T1, T2}"/>
/// <typeparam name="T3"> The type of the third parameter for the test case.
public class TheoryTestData<TResult, T1, T2, T3>
: TheoryData<TResult, T1, T2, T3>,
ITheoryTestData<ITestData<TResult, T1, T2, T3>>
where TResult : notnull
{
    private TheoryTestData(ITestData<TResult, T1, T2, T3> testData)
    => AddTestData(testData);

    /// <inheritdoc cref="ITheoryTestData{TTestData}.AddTestData(TTestData)"/>/>
    public void AddTestData(ITestData<TResult, T1, T2, T3> testData)
    => AddRow(PropertiesToArgs(testData));

    /// <summary>
    /// Adds the specified test data to an existing <see cref="TheoryTestData{TResult, T1, T2, T3}"/> instance  or
    /// creates a new instance if the provided theory test data is null or incompatible.
    /// </summary>
    /// <param name="theoryTestData">An optional existing <see cref="ITheoryTestData"/> instance to which the test data will be added.  If null or
    /// incompatible, a new <see cref="TheoryTestData{TResult, T1, T2, T3}"/> instance will be created.</param>
    /// <param name="testData">The test data to add. Must implement <see cref="ITestData{TResult, T1, T2, T3}"/>; otherwise, an exception is
    /// thrown.</param>
    /// <returns>A <see cref="TheoryTestData{TResult, T1, T2, T3}"/> instance containing the provided test data. If <paramref
    /// name="theoryTestData"/> is compatible, the test data is added to it; otherwise, a new instance is returned.</returns>
    public static TheoryTestData<TResult, T1, T2, T3> AddToOrInitTheoryTestData(
        ITheoryTestData? theoryTestData,
        ITestData testData)
    {
        var validTestData =
            GetValidTestData<ITestData<TResult, T1, T2, T3>>(testData);

        if (theoryTestData is not TheoryTestData<TResult, T1, T2, T3> validTheoryTestData)
        {
            return new(validTestData);
        }

        validTheoryTestData.AddTestData(validTestData);
        return validTheoryTestData;
    }
}

/// <inheritdoc cref="TheoryTestData{TResult, T1, T2, T3}"/>
/// <typeparam name="T4"> The type of the fourth parameter for the test case.
public class TheoryTestData<TResult, T1, T2, T3, T4>
: TheoryData<TResult, T1, T2, T3, T4>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4>>
where TResult : notnull
{
    private TheoryTestData(ITestData<TResult, T1, T2, T3, T4> testData)
    => AddTestData(testData);

    /// <inheritdoc cref="ITheoryTestData{TTestData}.AddTestData(TTestData)"/>/>
    public void AddTestData(ITestData<TResult, T1, T2, T3, T4> testData)
    => AddRow(PropertiesToArgs(testData));

    /// <summary>
    /// Adds the specified test data to an existing <see cref="TheoryTestData{TResult, T1, T2, T3, T4}"/> instance  or
    /// creates a new instance if the provided theory test data is null or incompatible.
    /// </summary>
    /// <param name="theoryTestData">An optional existing <see cref="ITheoryTestData"/> instance to which the test data will be added.  If null or
    /// incompatible, a new <see cref="TheoryTestData{TResult, T1, T2, T3, T4}"/> instance will be created.</param>
    /// <param name="testData">The test data to add. Must implement <see cref="ITestData{TResult, T1, T2, T3, T4}"/>; otherwise, an exception
    /// is thrown.</param>
    /// <returns>A <see cref="TheoryTestData{TResult, T1, T2, T3, T4}"/> instance containing the provided test data. If <paramref
    /// name="theoryTestData"/> is compatible, the test data is added to it; otherwise, a new instance is returned.</returns>
    public static TheoryTestData<TResult, T1, T2, T3, T4> AddToOrInitTheoryTestData(
        ITheoryTestData? theoryTestData,
        ITestData testData)
    {
        var validTestData =
            GetValidTestData<ITestData<TResult, T1, T2, T3, T4>>(testData);

        if (theoryTestData is not TheoryTestData<TResult, T1, T2, T3, T4> validTheoryTestData)
        {
            return new(validTestData);
        }

        validTheoryTestData.AddTestData(validTestData);
        return validTheoryTestData;
    }
}

/// <inheritdoc cref="TheoryTestData{TResult, T1, T2, T3, T4}"/>
/// <typeparam name="T5"> The type of the fifth parameter for the test case.
public class TheoryTestData<TResult, T1, T2, T3, T4, T5>
: TheoryData<TResult, T1, T2, T3, T4, T5>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5>>
where TResult : notnull
{
    private TheoryTestData(ITestData<TResult, T1, T2, T3, T4, T5> testData)
    => AddTestData(testData);

    /// <inheritdoc cref="ITheoryTestData{TTestData}.AddTestData(TTestData)"/>/>
    public void AddTestData(ITestData<TResult, T1, T2, T3, T4, T5> testData)
    => AddRow(PropertiesToArgs(testData));

    /// <summary>
    /// Adds the specified test data to an existing <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5}"/> instance
    /// or creates a new instance if the provided theory test data is null or incompatible.
    /// </summary>
    /// <param name="theoryTestData">An optional existing <see cref="ITheoryTestData"/> instance to which the test data will be added. If null or
    /// incompatible, a new <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5}"/> instance will be created.</param>
    /// <param name="testData">The test data to add. Must implement <see cref="ITestData{TResult, T1, T2, T3, T4, T5}"/>.</param>
    /// <returns>A <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5}"/> instance containing the provided test data. If
    /// <paramref name="theoryTestData"/> is compatible, the same instance is returned with the new data added.
    /// Otherwise, a new instance is created and returned.</returns>
    public static TheoryTestData<TResult, T1, T2, T3, T4, T5> AddToOrInitTheoryTestData(
        ITheoryTestData? theoryTestData,
        ITestData testData)
    {
        var validTestData =
            GetValidTestData<ITestData<TResult, T1, T2, T3, T4, T5>>(testData);

        if (theoryTestData is not TheoryTestData<TResult, T1, T2, T3, T4, T5> validTheoryTestData)
        {
            return new(validTestData);
        }

        validTheoryTestData.AddTestData(validTestData);
        return validTheoryTestData;
    }
}

/// <inheritdoc cref="TheoryTestData{TResult, T1, T2, T3, T4, T5}"/>
/// <typeparam name="T6"> The type of the sixth parameter for the test case.
public class TheoryTestData<TResult, T1, T2, T3, T4, T5, T6>
: TheoryData<TResult, T1, T2, T3, T4, T5, T6>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6>>
where TResult : notnull
{
    private TheoryTestData(ITestData<TResult, T1, T2, T3, T4, T5, T6> testData)
    => AddTestData(testData);

    /// <inheritdoc cref="ITheoryTestData{TTestData}.AddTestData(TTestData)"/>/>
    public void AddTestData(ITestData<TResult, T1, T2, T3, T4, T5, T6> testData)
    => AddRow(PropertiesToArgs(testData));

    /// <summary>
    /// Adds the specified test data to an existing <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6}"/>
    /// instance  or creates a new instance if the provided theory test data is null or incompatible.
    /// </summary>
    /// <param name="theoryTestData">An optional existing <see cref="ITheoryTestData"/> instance to which the test data will be added.  If null or
    /// incompatible, a new <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6}"/> instance will be created.</param>
    /// <param name="testData">The test data to add. Must implement <see cref="ITestData{TResult, T1, T2, T3, T4, T5, T6}"/>; otherwise, an
    /// exception is thrown.</param>
    /// <returns>A <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6}"/> instance containing the provided test data. If
    /// <paramref name="theoryTestData"/> is compatible, the test data is added to it; otherwise, a new instance is
    /// returned.</returns>
    public static TheoryTestData<TResult, T1, T2, T3, T4, T5, T6> AddToOrInitTheoryTestData(
        ITheoryTestData? theoryTestData,
        ITestData testData)
    {
        var validTestData =
            GetValidTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6>>(testData);

        if (theoryTestData is not TheoryTestData<TResult, T1, T2, T3, T4, T5, T6> validTheoryTestData)
        {
            return new(validTestData);
        }

        validTheoryTestData.AddTestData(validTestData);
        return validTheoryTestData;
    }
}

/// <inheritdoc cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6}"/>
/// <typeparam name="T7"> The type of the seventh parameter for the test case.
public class TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7>
: TheoryData<TResult, T1, T2, T3, T4, T5, T6, T7>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7>>
where TResult : notnull
{
    private TheoryTestData(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7> testData)
    => AddTestData(testData);

    /// <inheritdoc cref="ITheoryTestData{TTestData}.AddTestData(TTestData)"/>/>
    public void AddTestData(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7> testData)
    => AddRow(PropertiesToArgs(testData));

    /// <summary>
    /// Adds the specified test data to an existing <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7}"/>
    /// instance or creates a new instance if the provided theory test data is null or incompatible.
    /// </summary>
    /// <param name="theoryTestData">An optional instance of <see cref="ITheoryTestData"/> to which the test data will be added.  If null or
    /// incompatible, a new <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7}"/> instance will be created.</param>
    /// <param name="testData">The test data to add, which must implement <see cref="ITestData{TResult, T1, T2, T3, T4, T5, T6, T7}"/>.</param>
    /// <returns>A <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7}"/> instance containing the provided test data.
    /// If <paramref name="theoryTestData"/> is compatible, the test data is added to it; otherwise, a new instance is
    /// returned.</returns>
    public static TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7> AddToOrInitTheoryTestData(
        ITheoryTestData? theoryTestData,
        ITestData testData)
    {
        var validTestData =
            GetValidTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7>>(testData);

        if (theoryTestData is not TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7> validTheoryTestData)
        {
            return new(validTestData);
        }

        validTheoryTestData.AddTestData(validTestData);
        return validTheoryTestData;
    }
}

/// <inheritdoc cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7}"/>
/// <typeparam name="T8"> The type of the eighth parameter for the test case.
public class TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>
: TheoryData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>>
where TResult : notnull
{
    private TheoryTestData(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> testData)
    => AddTestData(testData);

    /// <inheritdoc cref="ITheoryTestData{TTestData}.AddTestData(TTestData)"/>/>
    public void AddTestData(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> testData)
    => AddRow(PropertiesToArgs(testData));

    /// <summary>
    /// Adds the specified test data to an existing <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7,
    /// T8}"/> instance or creates a new one if the provided theory test data is null or incompatible.
    /// </summary>
    /// <param name="theoryTestData">An existing <see cref="ITheoryTestData"/> instance to which the test data will be added, or <c>null</c> to
    /// create a new instance.</param>
    /// <param name="testData">The test data to add. Must implement <see cref="ITestData{TResult, T1, T2, T3, T4, T5, T6, T7, T8}"/>.</param>
    /// <returns>A <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7, T8}"/> instance containing the provided test
    /// data. If <paramref name="theoryTestData"/> is compatible, the test data is added to it; otherwise, a new
    /// instance is created.</returns>
    public static TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> AddToOrInitTheoryTestData(
        ITheoryTestData? theoryTestData,
        ITestData testData)
    {
        var validTestData =
            GetValidTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8>>(testData);

        if (theoryTestData is not TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8> validTheoryTestData)
        {
            return new(validTestData);
        }

        validTheoryTestData.AddTestData(validTestData);
        return validTheoryTestData;
    }
}

/// <inheritdoc cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7, T8}"/>
/// <typeparam name="T9"> The type of the ninth parameter for the test case.
public class TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>
: TheoryData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>,
ITheoryTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>>
where TResult : notnull
{
    private TheoryTestData(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> testData)
    => AddTestData(testData);

    /// <inheritdoc cref="ITheoryTestData{TTestData}.AddTestData(TTestData)"/>/>
    public void AddTestData(ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> testData)
    => AddRow(PropertiesToArgs(testData));

    /// <summary>
    /// Adds the specified test data to an existing <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7, T8,
    /// T9}"/> instance or creates a new instance if the provided theory test data is null or incompatible.
    /// </summary>
    /// <param name="theoryTestData">An optional instance of <see cref="ITheoryTestData"/> to which the test data will be added.  If null or
    /// incompatible, a new <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> instance will be
    /// created.</param>
    /// <param name="testData">The test data to add, which must implement <see cref="ITestData{TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9}"/>.</param>
    /// <returns>A <see cref="TheoryTestData{TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> instance containing the provided
    /// test data. If <paramref name="theoryTestData"/> was compatible, the same instance is returned with the new data
    /// added. Otherwise, a new instance is returned.</returns>
    public static TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> AddToOrInitTheoryTestData(
        ITheoryTestData? theoryTestData,
        ITestData testData)
    {
        var validTestData =
            GetValidTestData<ITestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>>(testData);

        if (theoryTestData is not TheoryTestData<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> validTheoryTestData)
        {
            return new(validTestData);
        }

        validTheoryTestData.AddTestData(validTestData);
        return validTheoryTestData;
    }
}