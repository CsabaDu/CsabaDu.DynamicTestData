// SPDX-License-Identifier: MIT
// Copyright (c) 2025. Csaba Dudas (CsabaDu)

namespace CsabaDu.DynamicTestData.xUnit.Attributes;

public sealed class MemberTestDataAttribute(
    string memberName,
    params object[] parameters)
: MemberTestDataAttributeBase(
    memberName,
    parameters);