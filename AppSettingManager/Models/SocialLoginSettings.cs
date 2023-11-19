namespace AppSettingManager.Models
{
    public class SocialLoginSettings
    {
        public bool SocialLoginEnabled { get; set; }
        public KeyValueSetings FacebookSettings { get; set; }
        public KeyValueSetings GoogleSettings { get; set; }
    }

    public class KeyValueSetings
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
