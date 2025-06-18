// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.DynamicDataSources;

/// <summary>
/// An base class that provides a dynamic dataRows source with the ability to temporarily override argument codes.
/// </summary>
public abstract class DynamicDataSourceBase
: IDataStrategy
{
    #region Fields
    private readonly ArgsCode _argsCode;
    private readonly AsyncLocal<ArgsCode?> _tempArgsCode = new();

    #region Test helpers
    internal const string ArgsCodeName = nameof(_argsCode);
    internal const string TempArgsCodeName = nameof(_tempArgsCode);
    internal const string DisposableMementoName = nameof(DisposableMemento);
    #endregion
    #endregion

    #region Properties
    /// <summary>
    /// Gets the current ArgsCode value used for argument conversion,
    /// which is either the temporary override value or the default value.
    /// </summary>
    public ArgsCode ArgsCode
    => _tempArgsCode.Value ?? _argsCode;

    public abstract bool? WithExpected { get; protected set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicParams"/> class with the specified ArgsCode.
    /// </summary>
    /// <param name="argsCode">The default ArgsCode to use when no override is specified.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argsCode"/> is null.</exception>
    protected DynamicDataSourceBase(ArgsCode argsCode)
    {
        _argsCode = argsCode.Defined(nameof(argsCode));
        _tempArgsCode.Value = null;
    }
    #endregion

    #region Embedded DisposableMemento Cless
    /// <summary>
    /// A disposable class that manages temporary ArgsCode overrides and restores the previous value when disposed.
    /// </summary>
    private sealed class DisposableMemento : IDisposable
    {
        #region Fields  
        [NotNull]
        private readonly DynamicDataSourceBase _dataSource;
        private readonly ArgsCode? _tempArgsCodeValue;
        private bool _disposed = false;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableMemento"/> class.
        /// </summary>
        /// <param name="dataSource">The enclosing dataRows source to manage overrides for.</param>
        /// <param name="argsCode">The new ArgsCode to temporarily apply.</param>
        internal DisposableMemento(DynamicDataSourceBase dataSource, ArgsCode argsCode)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
            _tempArgsCodeValue = _dataSource._tempArgsCode.Value;
            _dataSource._tempArgsCode.Value = argsCode.Defined(nameof(argsCode));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Restores the previous ArgsCode value.
        /// </summary>
        public void Dispose()
        {
            if (_disposed) return;

            _dataSource._tempArgsCode.Value = _tempArgsCodeValue;
            _disposed = true;
        }
        #endregion
    }
    #endregion

    #region Static methods
    #region GetDisplayName
    /// <summary>
    /// Gets the display name of the test method and the test case description, or null if any of these is null or empty.
    /// This method is called by the DynamicDataAttribute os MSTest framevork to get the display name of the test method
    /// when its DynamicDataDisplayName property is initialized by this method call. For sample usage see the <see href="path/to/README.md">README file</see>.
    /// This method's  return value can be used in NUnit framework when TestCaseData is used. The return valuse can be used as the
    /// parameter of the TestCaseData's SetName method. For sample usage see the <see href="path/to/README.md">README file</see>.
    /// </summary>
    /// <param name="testMethodName">The name of the test method for which the display name is generated.</param>
    /// <param name="args">The arguments passed to the test method.</param>
    /// <returns>A string representing the display name of the test method and its first argument.</returns>
    public static string? GetDisplayName(
        string? testMethodName,
        params object?[]? args)
    {
        if (string.IsNullOrEmpty(testMethodName))
        {
            return null;
        }

        var testCaseName = args?.FirstOrDefault();

        return !string.IsNullOrEmpty(testCaseName?.ToString()) ?
            $"{testMethodName}(testData: {testCaseName})"
            : null;
    }
    #endregion

    #region TestDataToParams
    /// <inheritdoc cref="TestDataToParams(ITestData, ArgsCode, out string) string"/>
    /// <param name="withExpected">A value indicating whether the expected result should be included in the returned parameters.</param>
    public static object?[] TestDataToParams(
        [NotNull] ITestData testData,
        ArgsCode argsCode,
        bool withExpected,
        out string testCaseName)
    {
        testCaseName = testData?.TestCaseName
            ?? throw new ArgumentNullException(nameof(testData));

        return testData.ToParams(
            argsCode,
            withExpected);
    }

    /// <summary>
    /// Converts test dataRows into an array of parameters for use in test execution.
    /// </summary>
    /// <param name="testData">The test dataRows to be converted. Cannot be <see langword="null"/>.</param>
    /// <param name="argsCode">Specifies the argument configuration to use when converting the test dataRows.</param>
    /// <param name="testCaseName">When this method returns, contains the test case identifier from the provided <paramref name="testData"/>.</param>
    /// <returns>An array of objects representing the parameters derived from the test dataRows.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="testData"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidEnumArgumentException">Thrown if <paramref name="argsCode"/> is not a valid value.</exception>
    public static object?[] TestDataToParams<TExpected>(
        [NotNull] ITestData testData,
        ArgsCode argsCode,
        string? expectedTypeName,
        out string testCaseName)
    where TExpected : IExpected
    => TestDataToParams(
        testData,
        argsCode,
        testData is TExpected,
        out testCaseName);
    #endregion

    #region WithOptionalArgsCode
    /// <summary>
    /// Executes a test dataRows generator within an optional memento pattern context.
    /// </summary>
    /// <typeparam name="TDataSource">The type of dynamic dataRows source, must inherit from <see cref="DynamicParams"/></typeparam>
    /// <typeparam name="T">The type of dataRows to generate, must be non-nullable</typeparam>
    /// <param name="dataSource">The dataRows source to use for memento creation (cannot be null)</param>
    /// <param name="dataRowGenerator">The function that generates test dataRows (cannot be null)</param>
    /// <param name="argsCode">
    /// The optional memento state code. When null, executes without memento pattern.
    /// When specified, creates a <see cref="DisposableMemento"/> for the operation.
    /// </param>
    /// <returns>The result of the test dataRows generator</returns>
    /// <remarks>
    /// <para>
    /// This method provides thread-safe execution of dataRows generation operations with optional
    /// state preservation through the memento pattern.
    /// </para>
    /// <para>
    /// When <paramref name="argsCode"/> is specified, the operation will be wrapped in a
    /// disposable memento context that automatically cleans up after execution.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="dataSource"/> or <paramref name="dataRowGenerator"/> is null
    /// </exception>
    protected static T WithOptionalArgsCode<TDataSource, T>(
        [NotNull] TDataSource dataSource,
        [NotNull] Func<T> dataRowGenerator,
        ArgsCode? argsCode)
    where TDataSource : DynamicDataSourceBase
    {
        if (!argsCode.HasValue)
        {
            return dataRowGenerator();
        }

        using (new DisposableMemento(dataSource, argsCode.Value))
        {
            return dataRowGenerator();
        }
    }

    public bool Equals(IDataStrategy? other)
    => other is not null
        && ArgsCode == other.ArgsCode
        && WithExpected == other.WithExpected;

    public override bool Equals(object? obj)
    => obj is IDataStrategy other
        && Equals(other);

    public override int GetHashCode()
    => HashCode.Combine(
        ArgsCode,
        WithExpected);
    #endregion
    #endregion
}

public abstract class DynamicDataSourceBase<TRow>(ArgsCode argsCode)
: DynamicDataSourceBase(argsCode)
{
    #region Methods
    protected TRow WithOptionalArgsCode(
        Func<TRow> dataRowGenerator,
        ArgsCode? argsCode)
    {
        ArgumentNullException.ThrowIfNull(dataRowGenerator, nameof(dataRowGenerator));
        return WithOptionalArgsCode(this, dataRowGenerator, argsCode);
    }
    #endregion
}
