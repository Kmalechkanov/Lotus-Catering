namespace LotusCatering.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "LotusCatering.eu";

        public const string SystemBaseUrl = "https://LotusCatering.eu";

        public const string Developer = "Kaloyan Malechkanov";

        public const string Email = "kaloqnmalechkanov@gmail.com";

        public const string AdministratorRoleName = "Administrator";

        public const string ModeratorRoleName = "Moderator";

        public const string CloudUrl = "https://res.cloudinary.com/lotuscatering/image/upload/v1584887787/";

        public const string CloudUrlTemplate = "https://res.cloudinary.com/lotuscatering/image/upload/v1584887787/{0}";

        public const string CloudUrlTemplateWithFixedHeight = "https://res.cloudinary.com/lotuscatering/image/upload/c_scale,h_{1}/v1584887787/{0}";

        public const string DisplayName = "Име";

        public const string DisplayQuantity = "Количество";

        public const string DisplayDescription = "Описание";

        public const string DisplayImage = "Снимка";

        public const string DisplayTitle = "Тема";

        public const string DisplayEmail = "Поща";

        public const string DisplayPhone = "Номер";

        public const string DisplayText = "Номер";

        public const int MinLengthName = 2;

        public const int MinLengthTitle = 2;

        public const int MinLengthText = 10;

        public const int MaxLengthTitle = 50;

        public const int MaxLengthName = 30;

        public const int MaxLengthText = 500;

        public const int MaxLengthDescription = 30;

        public const int MaxLengthLargerDescription = 150;

        public const int RangeMinQuantity = 10;

        public const int RangeMaxQuantity = 300;

        public const string ErrorMessageMinLengthTitle = "Темата трябва да бъде минимум 2 символа!";

        public const string ErrorMessageMinLengthName = "Името трябва да бъде минимум 2 символа!";

        public const string ErrorMessageMinLengthText = "Текста трябва да бъде минимум 10 символа!";

        public const string ErrorMessageMaxLengthTitle = "Темата трябва да бъде максимум 50 символа!";

        public const string ErrorMessageMaxLengthName = "Името трябва да бъде максимум 30 символа!";

        public const string ErrorMessageMaxLengthText = "Текста трябва да бъде максимум 500 символа!";

        public const string ErrorMessageInvalidEmail = "Невалидна поща!";

        public const string ErrorMessageInvalidPhone = "Невалиден номер!";

        public const string ErrorMessageRequiredField = "Това поле е задължително!";

        public const string ErrorMessageRequiredName = "Трябва да въведете име!";

        public const string ErrorMessageRequiredPhone = "Трябва да въведете телефонен номер!";

        public const string ErrorMessageRequiredDescription = "Трябва да веведете описание!";

        public const string ErrorMessageRequiredTitle = "Трябва да веведете тема!";

        public const string ErrorMessageRequiredEmail = "Трябва да веведете поща!";

        public const string ErrorMessageRequiredText = "Трябва да въведете текст!";

        public static class DataSeeding
        {
            public const string AdministratorName = "Administrator";

            public const string AdministratorEmail = "Administrator@LotusCatering.eu";

            public const string ModeratorName = "Moderator";

            public const string ModeratorEmail = "Moderator@LotusCatering.eu";

            public const string UserName = "User";

            public const string UserEmail = "User@LotusCatering.eu";
        }
    }
}
