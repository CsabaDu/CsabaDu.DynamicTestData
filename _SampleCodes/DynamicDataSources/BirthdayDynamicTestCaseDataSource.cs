﻿// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

using CsabaDu.DynamicTestData.TestDataHolders.Interfaces;

namespace CsabaDu.DynamicTestData.SampleCodes.DynamicDataSources;

public class BirthdayDynamicTestCaseDataSource<TestCaseData>(ArgsCode argsCode, bool? withExpected)
: DynamicDataSource<TestCaseData>(argsCode, withExpected)
{
    private static readonly DateOnly Today =
        DateOnly.FromDateTime(DateTime.Now);
    private const string ValidName = "valid name";

    protected override ITestDataRow<TTestData, TestCaseData> CreateTestDataRow<TTestData>(TTestData testData)
    {
        throw new NotImplementedException();
    }

    protected override void InitDataRowHolder<TTestData>(TTestData testData)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TestCaseData>? GetBirthDayConstructorInvalidArgs(ArgsCode? argsCode = null)
    {
        string paramName = "name";

        // name is null => throws ArguemntNullException
        string description = $"{paramName} is null";
        ArgumentException expected = new ArgumentNullException(paramName);
        string name = null!;
        add();

        // name is empty => throws ArgumentException
        description = $"{paramName} is empty";
        expected = new ArgumentException(
            $"The value cannot be an empty string " +
            $"or composed entirely of whitespace.",
            paramName);
        name = string.Empty;
        add();

        // name is white space => throws ArgumentException
        description = $"{paramName} is white space";
        name = " ";
        add();

        paramName = "dateOfBirth";

        // dateOfBirth is greater than the current day => throws ArgumentOutOfRangeException
        description = $"{paramName} is greater than the current day";
        expected = new ArgumentOutOfRangeException(paramName, BirthDay.GreaterThanTheCurrentDateMessage);
        name = ValidName;
        add();

        return GetRows(argsCode);

        #region Local Methods
        void add()
        => AddThrows(
            description,
            expected,
            name);
        #endregion
    }

    public IEnumerable<TestCaseData>? GetBirthDayConstructorValidArgs(ArgsCode? argsCode = null)
    {
        string expected = "creates BirthDay instance";
        string paramName = "dateOfBirth";

        // dateOfBirth is equal with the current day => creates BirthDay instance
        string description = $"{paramName} is equal with the current day";
        DateOnly dateOfBirth = Today;
        add();

        // dateOfBirth is less than the current day => creates BirthDay instance
        description = $"{paramName} is less than the current day";
        dateOfBirth = Today.AddDays(-1);
        add();

        return GetRows(argsCode);

        #region Local Methods
        void add()
        => Add(
            description,
            expected,
            dateOfBirth);
        #endregion
    }

    public IEnumerable<TestCaseData>? GetCompareToArgs(ArgsCode? argsCode = null)
    {
        DateOnly dateOfBirth = Today.AddDays(-1);

        // other is null => returns 1
        string description = "other is null";
        int expected = -1;
        BirthDay? other = null;
        add();

        // this.DateOfBirth is greater than other.DateOfBirth => returns -1
        description = "this.DateOfBirth is greater than other.DateOfBirth";
        other = new(ValidName, dateOfBirth.AddDays(1));
        add();

        // this.DateOfBirth is equal with other.DateOfBirth => return 0
        description = "this.DateOfBirth is equal with other.DateOfBirth";
        expected = 0;
        other = new(ValidName, dateOfBirth);
        add();

        // this.DateOfBirth is less than other.DateOfBirth => returns 1
        description = "this.DateOfBirth is less than other.DateOfBirth";
        expected = 1;
        other = new(ValidName, dateOfBirth.AddDays(-1));
        add();

        return GetRows(argsCode);

        #region Local Methods
        void add()
        => AddReturns(
            description,
            expected,
            dateOfBirth,
            other);
        #endregion
    }
}
