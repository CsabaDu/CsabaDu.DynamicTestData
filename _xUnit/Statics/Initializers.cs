namespace CsabaDu.DynamicTestData.xUnit.Statics;

public class Initializers
{
    #region TestData
    #region InitTheoryData
    public static TheoryData<T1?> InitTheoryData<T1>() => [];
    public static TheoryData<T1?, T2?> InitTheoryData<T1, T2>() => [];
    public static TheoryData<T1?, T2?, T3?> InitTheoryData<T1, T2, T3>() => [];
    public static TheoryData<T1?, T2?, T3?, T4?> InitTheoryData<T1, T2, T3, T4>() => [];
    public static TheoryData<T1?, T2?, T3?, T4?, T5?> InitTheoryData<T1, T2, T3, T4, T5>() => [];
    public static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?> InitTheoryData<T1, T2, T3, T4, T5, T6>() => [];
    public static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?> InitTheoryData<T1, T2, T3, T4, T5, T6, T7>() => [];
    public static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> InitTheoryData<T1, T2, T3, T4, T5, T6, T7, T8>() => [];
    public static TheoryData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> InitTheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9>() => [];
    #endregion

    #region InitTestDataTheoryData
    public static TheoryData<TestData<T1?>> InitTestDataTheoryData<T1>() => [];
    public static TheoryData<TestData<T1?, T2?>> InitTestDataTheoryData<T1, T2>() => [];
    public static TheoryData<TestData<T1?, T2?, T3?>> InitTestDataTheoryData<T1, T2, T3>() => [];
    public static TheoryData<TestData<T1?, T2?, T3?, T4?>> InitTestDataTheoryData<T1, T2, T3, T4>() => [];
    public static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?>> InitTestDataTheoryData<T1, T2, T3, T4, T5>() => [];
    public static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?>> InitTestDataTheoryData<T1, T2, T3, T4, T5, T6>() => [];
    public static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?>> InitTestDataTheoryData<T1, T2, T3, T4, T5, T6, T7>() => [];
    public static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>> InitTestDataTheoryData<T1, T2, T3, T4, T5, T6, T7, T8>() => [];
    public static TheoryData<TestData<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>> InitTestDataTheoryData<T1, T2, T3, T4, T5, T6, T7, T8, T9>() => [];
    #endregion
    #endregion

    #region TestDataReturns
    #region InitReturnsTheoryData
    public static TheoryData<TStruct, T1?> InitReturnsTheoryData<TStruct, T1>() where TStruct : struct => [];
    public static TheoryData<TStruct, T1?, T2?> InitReturnsTheoryData<TStruct, T1, T2>() where TStruct : struct => [];
    public static TheoryData<TStruct, T1?, T2?, T3?> InitReturnsTheoryData<TStruct, T1, T2, T3>() where TStruct : struct => [];
    public static TheoryData<TStruct, T1?, T2?, T3?, T4?> InitReturnsTheoryData<TStruct, T1, T2, T3, T4>() where TStruct : struct => [];
    public static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?> InitReturnsTheoryData<TStruct, T1, T2, T3, T4, T5>() where TStruct : struct => [];
    public static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?> InitReturnsTheoryData<TStruct, T1, T2, T3, T4, T5, T6>() where TStruct : struct => [];
    public static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?> InitReturnsTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7>() where TStruct : struct => [];
    public static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> InitReturnsTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>() where TStruct : struct => [];
    public static TheoryData<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> InitReturnsTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>() where TStruct : struct => [];
    #endregion

    #region InitTestDataReturnsTheoryData
    public static TheoryData<TestDataReturns<TStruct, T1?>> InitTestDataReturnsTheoryData<TStruct, T1>() where TStruct : struct => [];
    public static TheoryData<TestDataReturns<TStruct, T1?, T2?>> InitTestDataReturnsTheoryData<TStruct, T1, T2>() where TStruct : struct => [];
    public static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?>> InitTestDataReturnsTheoryData<TStruct, T1, T2, T3>() where TStruct : struct => [];
    public static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?>> InitTestDataReturnsTheoryData<TStruct, T1, T2, T3, T4>() where TStruct : struct => [];
    public static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?>> InitTestDataReturnsTheoryData<TStruct, T1, T2, T3, T4, T5>() where TStruct : struct => [];
    public static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?>> InitTestDataReturnsTheoryData<TStruct, T1, T2, T3, T4, T5, T6>() where TStruct : struct => [];
    public static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?>> InitTestDataReturnsTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7>() where TStruct : struct => [];
    public static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>> InitTestDataReturnsTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>() where TStruct : struct => [];
    public static TheoryData<TestDataReturns<TStruct, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>> InitTestDataReturnsTheoryData<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>() where TStruct : struct => [];
    #endregion
    #endregion

    #region TestDataThrows
    #region InitThrowsTheoryData
    public static TheoryData<TException, T1?> InitThrowsTheoryData<TException, T1>() where TException : Exception => [];
    public static TheoryData<TException, T1?, T2?> InitThrowsTheoryData<TException, T1, T2>() where TException : Exception => [];
    public static TheoryData<TException, T1?, T2?, T3?> InitThrowsTheoryData<TException, T1, T2, T3>() where TException : Exception => [];
    public static TheoryData<TException, T1?, T2?, T3?, T4?> InitThrowsTheoryData<TException, T1, T2, T3, T4>() where TException : Exception => [];
    public static TheoryData<TException, T1?, T2?, T3?, T4?, T5?> InitThrowsTheoryData<TException, T1, T2, T3, T4, T5>() where TException : Exception => [];
    public static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?> InitThrowsTheoryData<TException, T1, T2, T3, T4, T5, T6>() where TException : Exception => [];
    public static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?> InitThrowsTheoryData<TException, T1, T2, T3, T4, T5, T6, T7>() where TException : Exception => [];
    public static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?> InitThrowsTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8>() where TException : Exception => [];
    public static TheoryData<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?> InitThrowsTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>() where TException : Exception => [];
    #endregion

    #region InitTestDataThrowsTheoryData
    public static TheoryData<TestDataThrows<TException, T1?>> InitTestDataThrowsTheoryData<TException, T1>() where TException : Exception => [];
    public static TheoryData<TestDataThrows<TException, T1?, T2?>> InitTestDataThrowsTheoryData<TException, T1, T2>() where TException : Exception => [];
    public static TheoryData<TestDataThrows<TException, T1?, T2?, T3?>> InitTestDataThrowsTheoryData<TException, T1, T2, T3>() where TException : Exception => [];
    public static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?>> InitTestDataThrowsTheoryData<TException, T1, T2, T3, T4>() where TException : Exception => [];
    public static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?>> InitTestDataThrowsTheoryData<TException, T1, T2, T3, T4, T5>() where TException : Exception => [];
    public static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?>> InitTestDataThrowsTheoryData<TException, T1, T2, T3, T4, T5, T6>() where TException : Exception => [];
    public static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?>> InitTestDataThrowsTheoryData<TException, T1, T2, T3, T4, T5, T6, T7>() where TException : Exception => [];
    public static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>> InitTestDataThrowsTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8>() where TException : Exception => [];
    public static TheoryData<TestDataThrows<TException, T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>> InitTestDataThrowsTheoryData<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>() where TException : Exception => [];
    #endregion
    #endregion
}
