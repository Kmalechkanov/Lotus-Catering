namespace AnisMasterpieces.Services
{
    public static class ConvertService
    {
        private static string[] lat_up = { "A", "B", "V", "G", "D", "E", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "H", "Ts", "Ch", "Sh", "Sht", "A", "Y", "Yu", "Ya" };
        private static string[] lat_low = { "a", "b", "v", "g", "d", "e", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h", "ts", "ch", "sh", "sht", "a", "y", "yu", "ya" };
        private static string[] bg_up = { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ь", "Ю", "Я" };
        private static string[] bg_low = { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я" };

        public static string CyrillicToLatin(string str)
        {

            for (int i = 0; i < lat_up.Length; i++)
            {
                str = str.Replace(bg_up[i], lat_up[i]);
                str = str.Replace(bg_low[i], lat_low[i]);
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
