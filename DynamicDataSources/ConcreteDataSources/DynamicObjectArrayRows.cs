// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)


namespace CsabaDu.DynamicTestData.DynamicDataSources.ConcreteDataSources
{
    public class DynamicObjectArrayRows(ArgsCode argsCode) : DynamicDataSourceBase<object?[]>(argsCode)
    {
        protected override IEnumerable<object?[]>? DataRowList {get; set; } = [];

        public override void ResetDataRowList()
        {
            throw new NotImplementedException();
        }

        public void Add<T1>(string definition, string expected, T1? arg1)
        {
            throw new NotImplementedException();
        }

        public void Add<T1, T2>(string definition, string expected, T1? arg1, T2? arg2)
        {
            throw new NotImplementedException();
        }

        public void Add<T1, T2, T3>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3)
        {
            throw new NotImplementedException();
        }

        public void Add<T1, T2, T3, T4>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
        {
            throw new NotImplementedException();
        }

        public void Add<T1, T2, T3, T4, T5>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5)
        {
            throw new NotImplementedException();
        }

        public void Add<T1, T2, T3, T4, T5, T6>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6)
        {
            throw new NotImplementedException();
        }

        public void Add<T1, T2, T3, T4, T5, T6, T7>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7)
        {
            throw new NotImplementedException();
        }

        public void Add<T1, T2, T3, T4, T5, T6, T7, T8>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8)
        {
            throw new NotImplementedException();
        }

        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, string expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9)
        {
            throw new NotImplementedException();
        }

        public void AddReturns<TStruct, T1>(string definition, TStruct expected, T1? arg1) where TStruct : struct
        {
            throw new NotImplementedException();
        }

        public void AddReturns<TStruct, T1, T2>(string definition, TStruct expected, T1? arg1, T2? arg2) where TStruct : struct
        {
            throw new NotImplementedException();
        }

        public void AddReturns<TStruct, T1, T2, T3>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3) where TStruct : struct
        {
            throw new NotImplementedException();
        }

        public void AddReturns<TStruct, T1, T2, T3, T4>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TStruct : struct
        {
            throw new NotImplementedException();
        }

        public void AddReturns<TStruct, T1, T2, T3, T4, T5>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TStruct : struct
        {
            throw new NotImplementedException();
        }

        public void AddReturns<TStruct, T1, T2, T3, T4, T5, T6>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6) where TStruct : struct
        {
            throw new NotImplementedException();
        }

        public void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TStruct : struct
        {
            throw new NotImplementedException();
        }

        public void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8) where TStruct : struct
        {
            throw new NotImplementedException();
        }

        public void AddReturns<TStruct, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TStruct expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9) where TStruct : struct
        {
            throw new NotImplementedException();
        }

        public void AddThrows<TException, T1>(string definition, TException expected, T1? arg1) where TException : Exception
        {
            throw new NotImplementedException();
        }

        public void AddThrows<TException, T1, T2>(string definition, TException expected, T1? arg1, T2? arg2) where TException : Exception
        {
            throw new NotImplementedException();
        }

        public void AddThrows<TException, T1, T2, T3>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3) where TException : Exception
        {
            throw new NotImplementedException();
        }

        public void AddThrows<TException, T1, T2, T3, T4>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4) where TException : Exception
        {
            throw new NotImplementedException();
        }

        public void AddThrows<TException, T1, T2, T3, T4, T5>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5) where TException : Exception
        {
            throw new NotImplementedException();
        }

        public void AddThrows<TException, T1, T2, T3, T4, T5, T6>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6) where TException : Exception
        {
            throw new NotImplementedException();
        }

        public void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7) where TException : Exception
        {
            throw new NotImplementedException();
        }

        public void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8) where TException : Exception
        {
            throw new NotImplementedException();
        }

        public void AddThrows<TException, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string definition, TException expected, T1? arg1, T2? arg2, T3? arg3, T4? arg4, T5? arg5, T6? arg6, T7? arg7, T8? arg8, T9? arg9) where TException : Exception
        {
            throw new NotImplementedException();
        }
    }
}
