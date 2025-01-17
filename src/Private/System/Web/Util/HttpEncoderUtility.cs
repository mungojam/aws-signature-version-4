﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#if NET45
#pragma warning disable IDE0066 // Use 'switch' expression

using System.Diagnostics;

// ReSharper disable once CheckNamespace
namespace System.Web.Util
{
    internal static class HttpEncoderUtility
    {
        public static int HexToInt(char h) =>
            h >= '0' && h <= '9'
                ? h - '0'
                : h >= 'a' && h <= 'f'
                    ? h - 'a' + 10
                    : h >= 'A' && h <= 'F'
                        ? h - 'A' + 10
                        : -1;

        public static char IntToHex(int n)
        {
            Debug.Assert(n < 0x10);

            return n <= 9 ? (char)(n + '0') : (char)(n - 10 + 'a');
        }

        // Set of safe chars, from RFC 1738.4 minus '+'
        public static bool IsUrlSafeChar(char ch)
        {
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9'))
            {
                return true;
            }

            switch (ch)
            {
                case '-':
                case '_':
                case '.':
                case '!':
                case '*':
                case '(':
                case ')':
                    return true;
            }

            return false;
        }
    }
}

#pragma warning restore IDE0066 // Use 'switch' expression
#endif
