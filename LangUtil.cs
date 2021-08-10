using System.Globalization;

namespace rdp
{
    public class LangUtil
    {
        /// <summary>
        /// 支持的语言（区域）
        /// </summary>
        public static string[] SupportLanguages = new string[] { "zh", "en" };

        /// <summary>
        /// 应用特定区域语言
        /// </summary>
        /// <param name="culture">区域标识</param>
        public static void ApplyLang(string culture)
        {
            CultureInfo ci = new CultureInfo(culture, false);
            CultureInfo.CurrentCulture = ci;
            CultureInfo.CurrentUICulture = ci;
        }

        /// <summary>
        /// 应用默认语言
        /// </summary>
        public static void ApplyDefaultLang()
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Language))
            {
                ApplyLang(Properties.Settings.Default.Language);
            }
        }

        /// <summary>
        /// 保存默认语言的配置
        /// </summary>
        /// <param name="culture">区域（语言）</param>
        public static void SetDefaultLang(string culture)
        {
            Properties.Settings.Default.Language = culture;
            Properties.Settings.Default.Save();
        }
    }
}
