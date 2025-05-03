// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.TestHelpers.TestParameters;

public class TestDataThrowsInstances
{
    /// <summary>
    /// Test data that throws a DummyException with one argument.
    /// </summary>
    public static readonly TestDataThrows<DummyException, int> TestDataThrowsArgs1
        = new(ActualDefinition, DummyExceptionInstance, Arg1);

    /// <summary>
    /// Test data that throws a DummyException with two arguments.
    /// </summary>
    public static readonly TestDataThrows<DummyException, int, object> TestDataThrowsArgs2
        = new(ActualDefinition, DummyExceptionInstance, Arg1, Arg2);

    /// <summary>
    /// Test data that throws a DummyException with three arguments.
    /// </summary>
    public static readonly TestDataThrows<DummyException, int, object, DateTime> TestDataThrowsArgs3
        = new(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3);

    /// <summary>
    /// Test data that throws a DummyException with four arguments.
    /// </summary>
    public static readonly TestDataThrows<DummyException, int, object, DateTime, string> TestDataThrowsArgs4
        = new(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4);

    /// <summary>
    /// Test data that throws a DummyException with five arguments.
    /// </summary>
    public static readonly TestDataThrows<DummyException, int, object, DateTime, string, double> TestDataThrowsArgs5
        = new(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5);

    /// <summary>
    /// Test data that throws a DummyException with six arguments.
    /// </summary>
    public static readonly TestDataThrows<DummyException, int, object, DateTime, string, double, bool> TestDataThrowsArgs6
        = new(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6);

    /// <summary>
    /// Test data that throws a DummyException with seven arguments.
    /// </summary>
    public static readonly TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char> TestDataThrowsArgs7
        = new(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7);

    /// <summary>
    /// Test data that throws a DummyException with eight arguments.
    /// </summary>
    public static readonly TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass> TestDataThrowsArgs8
        = new(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8);

    /// <summary>
    /// Test data that throws a DummyException with nine arguments.
    /// </summary>
    public static readonly TestDataThrows<DummyException, int, object, DateTime, string, double, bool, char, DummyClass, object[]> TestDataThrowsArgs9
        = new(ActualDefinition, DummyExceptionInstance, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8, Arg9);
}
