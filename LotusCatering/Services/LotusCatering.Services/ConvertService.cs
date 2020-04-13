namespace LotusCatering.Services
{
    public static class ConvertService
    {
        private static readonly string[] LatUp = { "A", "B", "V", "G", "D", "E", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "H", "Ts", "Ch", "Sh", "Sht", "A", "Y", "Yu", "Ya" };
        private static readonly string[] LatLow = { "a", "b", "v", "g", "d", "e", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h", "ts", "ch", "sh", "sht", "a", "y", "yu", "ya" };
        private static readonly string[] BgUp = { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ь", "Ю", "Я" };
        private static readonly string[] BgLow = { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я" };

        public static string CyrillicToLatin(string str, bool spacing = false)
        {
            if (spacing)
            {
                str = RemoveSpaces(str);
            }

            for (int i = 0; i < LatUp.Length; i++)
            {
                str = str.Replace(BgUp[i], LatUp[i]);
                str = str.Replace(BgLow[i], LatLow[i]);
            }

            return str;
        }

        public static string RemoveSpaces(string str)
        {
            var newStr = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    newStr += char.ToUpper(str[++i]);
                    continue;
                }

                newStr += str[i];
            }

            return newStr;
        }
    }
}
