// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Text.RegularExpressions;
using UnityEngine.UI;

    public static class InputControll
    {
        private const string ForExpression = @"\d|\W";
        private const string ForWord = @"\s|\W";

        public static string ReadExpression(InputField inputField) =>
            Regex.Replace(inputField.text ?? string.Empty, ForExpression, string.Empty);
        
        public static string ReadWord(InputField inputField) =>
            Regex.Replace(inputField.text ?? string.Empty, ForWord, string.Empty);
        
        public static bool ReadInt(InputField inputField, ref int result) => int.TryParse(inputField.text, out result);
    }