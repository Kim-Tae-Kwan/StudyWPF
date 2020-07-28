using System;

namespace WPF_MVVM_App.Helpers
{
    public class Commons
    {
        public static bool IsValidEmail(string email)
        {
            string[] parts = email.Split('@'); //@로 짜름, @이 없으면 배열 1, @있으면 배열 2
            if (parts.Length != 2) return false;
            return (parts[1].Split('.').Length >= 2);
        }

        public static int CalcAge(DateTime date)
        {
            int middle;
            var now = DateTime.Now;
            if (now.Month <= date.Month && now.Day < date.Day)
                middle = now.Year - date.Year - 1;
            else
                middle = now.Year - date.Year;

            return middle;
        }

        public static string GetChineseZodiac(DateTime date)
        {
            var value = date.Year % 12;
            switch (value)
            {
                case 0:
                    return "원숭이띠";
                case 1:
                    return "닭띠";
                case 2:
                    return "개띠";
                case 3:
                    return "돼지띠";
                case 4:
                    return "쥐띠";
                case 5:
                    return "소띠";
                case 6:
                    return "호랑이띠";
                case 7:
                    return "토끼띠";
                case 8:
                    return "용띠";
                case 9:
                    return "뱀띠";
                case 10:
                    return "말띠";
                case 11:
                    return "양띠";
                default:
                    return "";
            }
        }

        public static string GetCalcZodiac(DateTime date)
        {
            string result;
            if (date.Month <= 1 && date.Day <= 20)
                result = "염소자리";
            else if (date.Month <= 2 && date.Day <= 18)
                result = "물병자리";
            else if (date.Month <= 3 && date.Day <= 20)
                result = "물고기자리";
            else if (date.Month <= 4 && date.Day <= 20)
                result = "양자리";
            else if (date.Month <= 5 && date.Day <= 20)
                result = "황소자리";
            else if (date.Month <= 6 && date.Day <= 21)
                result = "쌍둥이자리";
            else if (date.Month <= 7 && date.Day <= 22)
                result = "게자리";
            else if (date.Month <= 8 && date.Day <= 22)
                result = "사자자리";
            else if (date.Month <= 9 && date.Day <= 22)
                result = "처녀자리";
            else if (date.Month <= 10 && date.Day <= 23)
                result = "천칭자리";
            else if (date.Month <= 11 && date.Day <= 22)
                result = "전갈자리";
            else
                result = "궁수자리";

            return result;
        }
    }
}
