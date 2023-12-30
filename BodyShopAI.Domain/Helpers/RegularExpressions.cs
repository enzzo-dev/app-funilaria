using System.Text.RegularExpressions;

namespace Ats.Domain.Library.Helpers
{
    public static class RegularExpressions
    {
        public const string EMAIL = "^((\\\")(\\\".+?=.(?<!\\\\)\\\"@)|((\\w((\\.(?!\\.))|[-!#\\$%&\\'\\*\\+\\/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[\\w\\-])@))((\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|((\\w[-\\w*\\w]*\\.)+))(?<TLD>[a-zA-Z]{2,9})(\\]?)$";
        public const string EMAILS = "^(((\\\")(\\\".+?=.(?<!\\\\)\\\"@)|((\\w((\\.(?!\\.))|[-!#\\$%&\\'\\*\\+\\/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[\\w\\-])@))((\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|((\\w[-\\w*\\w]*\\.)+))(?<TLD>[a-zA-Z]{2,9})(\\]?)\\s*[,;\b]{0,1}\\s*)+$";
        public const string WEBSITE = "^(http[s]?:\\/\\/){0,1}(www\\.){0,1}[\\w\\.\\-]+\\.[\\w]{2,9}(:[\\w]{1,9})?(\\/.*)?$";
        public const string URL_PROTOCOL = @"(?<protocol>http[s]?:\/\/)?";
        public const string URL_HOST = @"(?<host>(?:www\.)?[\w\.\-]+\.[a-zA-Z]{2,5})";
        public const string URL_HOST_CUSTOM = @"(?<host>(?:www\.)?(?:{0})\.[a-zA-Z]{2,5})";
        public const string URL_PORT = @"(?<port>:\b(?:[0-9]|[1-9][0-9]|[0-9][0-9][0-9]|[1-9][0-9][0-9][0-9]|[1-5][0-9][0-9][0-9][0-9]|[6][0-4][0-9][0-9][0-9]|[6][5][0-4][0-9][0-9]|[6][5][5][0-2][0-9]|[6][0-5][[0-5][0-3][0-5])\b)?";
        public const string URL_HOSTNAME = URL_HOST + URL_PORT;
        public const string URL_PATH = @"(?<path>\/.*)?";
        public const string URL_FORBIDDEN_EXT = @"(?!\/(?:.*\.\b(?:exe|application|gadget|msi|msp|com|scr|hta|cpl|msc|jar|bat|cmd|vb|vbs|vbe|js|jse|ws|wsf|wsc|wsh|ps1|ps1xml|ps2|ps2xml|psc1|psc2|msh|msh1|msh|msh1|msh2|mshxml|msh1xml|msh2xml|scf|lnk|inf|reg|doc|xls|ppt|docm|dotm|xlsm|xltm|xlam|pptm|potm|ppam|ppsm|sldm)\b))";
        public const string URL_WITHOUT_EXECUTABLES = @"^" + URL_PROTOCOL + URL_HOSTNAME + URL_FORBIDDEN_EXT + URL_PATH + "$";
        public const string URL_WITHOUT_EXECUTABLES_CUSTOM = @"^" + URL_PROTOCOL + URL_HOST_CUSTOM + URL_PORT + URL_FORBIDDEN_EXT + URL_PATH + "$";
        public const string PASSWORD = @"^.{8,}$";

        public static bool IsMatch(string pattern, string value) => new Regex(pattern).IsMatch(value ?? string.Empty);
    }
}