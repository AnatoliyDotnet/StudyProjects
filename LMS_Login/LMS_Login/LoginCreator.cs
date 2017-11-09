using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Login
{
    public static class LoginCreator
    {
        private static readonly Dictionary<char, string> RussianUnique = new Dictionary<char, string>
        {
            {'а',"a"},{'б',"b"},{'в',"v"},{'г',"g"},{'д',"d"},{'е',"e"},{'ё',"e"},{'ж',"zh"},{'з',"z"},{'и',"i"},{'й',"i"},{'к',"k"},{'л',"l"},{'м',"m"},{'н',"n"},{'о',"o"},{'ь',""},
            {'п',"p"},{'р',"r"},{'с',"s"},{'т',"t"},{'у',"u"},{'ф',"f"},{'х',"kh"},{'ц',"ts"},{'ч',"ch"},{'ш',"sh"},{'щ',"shch"},{'ы',"y"},{'ъ',"ie"},{'э',"e"},{'ю',"iu"},{'я',"ia"}
        };
        private static readonly Dictionary<char, string> UkrainianUnique = new Dictionary<char, string>
        {
            {'а',"a"},{'к',"k"},{'х',"kh"},{'б',"b"},{'л',"l"},{'ц',"ts"},{'в',"v"},{'м',"m"},{'ч',"ch"}, {'г',"h"},{'ґ',"g"},{'н',"n"},{'ш',"sh"},{'д',"d"},{'о',"o"},{'щ',"shch"},
            {'е',"e"},{'п',"p"},{'є',"ie"},{'р',"r"},{'ж',"zh"},{'с',"s"},{'з',"z"},{'т',"t"},{'и',"y"},{'у',"u"},{'ю',"iu"},{'і',"i"},{'ф',"f"},{'я',"ia"},{'ї',"i"},{'й',"i"},{'ь',""}
        };

        private static readonly Dictionary<char, string> UkrainianBigVowels = new Dictionary<char, string>
        {
            {'Є',"ye"},{'Ю',"yu"},{'Я',"ya"},{'Ї',"yi"},{'Й',"y"}
        };

        public enum Languages
        {
            Russian,
            Ukrainain
        }

        public static string Create(string firstName, string lastName, Languages lang = Languages.Russian)
        {
            return new StringBuilder(ToEnglishLogin(firstName, lang)).Append('.').Append(ToEnglishLogin(lastName, lang)).ToString();
        }

        private static string ToEnglishLogin(string name, Languages lang)
        {
            try
            {
                string firstLetters;
                if (lang == Languages.Russian)
                {
                    firstLetters = RussianUnique[char.ToLower(name[0])];
                }
                else
                {
                    firstLetters = UkrainianBigVowels.ContainsKey(name[0])
                        ? UkrainianBigVowels[name[0]]
                        : UkrainianUnique[char.ToLower(name[0])];
                }
                var result = new StringBuilder().Append(firstLetters);
                result.Append(lang == Languages.Russian
                    ? string.Concat(name.Skip(1).Select(x => RussianUnique[x]))
                    : string.Concat(name.Skip(1).Select(x => UkrainianUnique[x])));
                return result.ToString();
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
