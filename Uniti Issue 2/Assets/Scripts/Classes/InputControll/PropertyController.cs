// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Linq;

    public static class PropertyController
    {
        public static void CheckString(string parameter, string parameterName)
        {
            if (string.IsNullOrEmpty(parameter))
                throw new Exception($"{parameterName} is empty");

            if (parameter.Where(char.IsPunctuation).Count() != 0)
                throw new Exception($"{parameterName} is wrong");
        }

        public static void CheckInt(int parameter, string parameterName, int min, int max)
        {
            if (parameter < min || parameter > max)
                throw new Exception($"{parameterName} is need to be between {min} and {max}");
        }
    }