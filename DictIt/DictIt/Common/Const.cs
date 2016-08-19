namespace DictIt.Common
{
    public static class Const
    {
        public static string PathToTerms = "..\\..\\Data\\Data.xml";

        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
        public const int MinPasswordLength = 5;
        public const int MaxPasswordLength = 30;
        public const int MinCommentLength = 3;
        public const int MaxCommentLength = 200;

        public const int MinWheels = 2;
        public const int MaxWheels = 10;

        public const string StringMustBeBetweenMinAndMax = "{0} must be between {1} and {2} characters long!";
        public const string NumberMustBeBetweenMinAndMax = "{0} must be between {1} and {2}!";
        public const string ObjectCanNotBeNull = "{0} can not be null or empty!";

        public const string UsernamePattern = "^[A-Za-z0-9]+$";
        public const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";
    }
}