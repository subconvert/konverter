using Cyrillic.Convert;
using System.Text.RegularExpressions;

namespace SubConvert
{
    public static class MyExtensions
    {
        public static string RestoreTags(this string str)
        {
            string s = str;

            s = s.Replace("<и>", "<i>");
            s = s.Replace("</и>", "</i>");
            s = s.Replace("{и}", "{i}");
            s = s.Replace("{/и}", "{/i}");

            s = s.Replace("<б>", "<b>");
            s = s.Replace("</б>", "</b>");
            s = s.Replace("{б}", "{b}");
            s = s.Replace("{/б}", "{/b}");

            s = s.Replace("<у>", "<u>");
            s = s.Replace("</у>", "</u>");
            s = s.Replace("{у}", "{u}");
            s = s.Replace("{/у}", "{/u}");

            s = s.Replace("</фонт>", "</font>");
            Regex r = new("<(?<fontTag>фонт цолор=(\"?)(.+)(\"?))>");

            s = r.Replace(s, ProcessFontTag);

            return s;
        }

        private static string ProcessFontTag(Match m)
        {
            string tagName = m.Groups["fontTag"].Value;
            return $"<{tagName.ToSerbianLatin()}>";
        }

        public static bool IsCyrillic(this string str)
        {
            string cyr = "[АБВГДЕЗИЈКЛМНОПРСТУФХЦЋЧЂШЖабвгдезијклмнопрстуфхцћчђшж]";
            string lat = "[ABVGDEZIJKLMNOPRSTUFHCĆČĐŠŽabvgdezijklmnoprstufhcćčđšž]";

            return Regex.Matches(str, cyr).Count > Regex.Matches(str, lat).Count;

        }
    }
}