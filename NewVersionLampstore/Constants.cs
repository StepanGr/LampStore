using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewVersionLampstore
{
    public static class Constants
    {
        public const string TITLE = "Интернет Магазин Велика Лампа";

        public static readonly List<string> RESERVED_WORDS = new List<string>()
        {
            "home","account","index","details","create","edit","delete","up","down",
            "logon","logoff","register","changepassword","changepasswordsuccess",
            "manufacturer"
        };
        public const string BREADCRUMBS_SEPARATOR = " > ";
        public const int PAGER_LINKS_PER_PAGE = 4; // Количество объектов на одной странице
        public const int PAGER_NUMBER_OF_VISABLE_LINKS = 5;

        public const string ROLE_ADMIN = "admin";
        public const string ROLE_CONTENT_MANAGER = "contentmanager";
        public const string ROLES_ADMIN_CONTENT_MANAGER = "admin,contentmanager";

        public const string PROFILE_FIRST_NAME = "FirstName";
        public const string PROFILE_LAST_NAME = "LastName";
        public const string PROFILE_PHONE = "Phone";
        public const string PROFILE_ADDRESS = "Address";

        public const string COLLECTION_MINI_IMAGES_FOLDER = "CollectionMiniImages";
        public const int COLLECTION_NUMBER_PER_ROW = 2;
        public const int COLLECTION_MINI_IMAGE_HEIGHT = 168;
        public const int COLLECTION_MINI_IMAGE_WIDTH = 238;

        // Папки для загрузки картинок для фотогалереи раздела Коллекции
        public const string COLLECTION_IMAGE_FOLDER = "CollectionImages";
        public const string COLLECTION_IMAGE_PREVIEW_FOLDER = "Preview";

        // Размеры уменьшенной и увеличенной картинки для фотогалереи раздела Коллекции
        public const int COLLECTION_IMAGE_HEIGHT = 0;
        public const int COLLECTION_IMAGE_WIDTH = 750;
        public const int COLLECTION_IMAGE_PREVIEW_HEIGHT = 100;
        public const int COLLECTION_IMAGE_PREVIEW_WIDTH = 0;
        public const int COLLECTION_IMAGE_PREVIEW_COUNT = 5;

        // Папки для загрузки картинок для раздела Товари
        public const string PRODUCT_IMAGES_FOLDER = "ProductImages";
        public const string PRODUCT_IMAGES_MINI_FOLDER = "Mini";
       

        // Размеры картинок для раздела Товари
        public const int PRODUCT_IMAGE_HEIGHT = 0;
        public const int PRODUCT_IMAGE_WIDTH = 250;
        public const int PRODUCT_IMAGE_MINI_HEIGHT = 168;
        public const int PRODUCT_IMAGE_MINI_WIDTH = 238;

        // Количество мини-изображений товара в одной строке на странице списка
        public const int PRODUCT_NUMBER_IN_ROW = 2;

        // Переменные сеанса
        public const string SESSION_CART = "Cart";
        public const string SESSION_FILTER = "Filtr";

        public static readonly Dictionary<char, string> TRANSLIT = new Dictionary<char, string>()
        {
            {'а',"a"}, {'б',"b"}, {'в',"v"}, {'г',"g"}, {'д',"d"}, {'е',"e"}, {'ё',"jo"}, {'ж',"z"}, {'з',"z"}, {'и',"i"}, {'й',"j"},
            {'к',"k"}, {'л',"l"}, {'м',"m"}, {'н',"n"}, {'о',"o"}, {'п',"p"}, {'р',"r"}, {'с',"s"}, {'т',"t"}, {'у',"u"}, {'ф',"f"},
            {'х',"h"}, {'ц',"c"}, {'ч',"c"}, {'ш',"s"}, {'щ',"sc"}, {'ъ',""}, {'ы',"y"}, {'ь',""}, {'э',"e"}, {'ю',"ju"}, {'я',"ja"},
            {'А',"a"}, {'Б',"b"}, {'В',"v"}, {'Г',"g"}, {'Д',"d"}, {'Е',"e"}, {'Ё',"jo"}, {'Ж',"z"}, {'З',"z"}, {'И',"i"}, {'Й',"j"},
            {'К',"k"}, {'Л',"l"}, {'М',"m"}, {'Н',"n"}, {'О',"o"}, {'П',"p"}, {'Р',"r"}, {'С',"s"}, {'Т',"t"}, {'У',"u"}, {'Ф',"f"},
            {'Х',"h"}, {'Ц',"c"}, {'Ч',"c"}, {'Ш',"s"}, {'Щ',"sc"}, {'Ъ',""}, {'Ы',"y"}, {'Ь',""}, {'Э',"e"}, {'Ю',"ju"}, {'Я',"ja"},
            {'a',"a"}, {'b',"b"}, {'c',"c"}, {'d',"d"}, {'e',"e"}, {'f',"f"}, {'g',"g"}, {'h',"h"}, {'i',"i"}, {'j',"j"}, {'k',"k"},
            {'l',"l"}, {'m',"m"}, {'n',"n"}, {'o',"o"}, {'p',"p"}, {'q',"q"}, {'r',"r"}, {'s',"s"}, {'t',"t"}, {'u',"u"}, {'v',"v"},
            {'w',"w"}, {'x',"x"}, {'y',"y"}, {'z',"z"},
            {'A',"a"}, {'B',"b"}, {'C',"c"}, {'D',"d"}, {'E',"e"}, {'F',"f"}, {'G',"g"}, {'H',"h"}, {'I',"i"}, {'J',"j"}, {'K',"k"},
            {'L',"l"}, {'M',"m"}, {'N',"n"}, {'O',"o"}, {'P',"p"}, {'Q',"q"}, {'R',"r"}, {'S',"s"}, {'T',"t"}, {'U',"u"}, {'V',"v"},
            {'W',"w"}, {'X',"x"}, {'Y',"y"}, {'Z',"z"},
            {'0',"0"}, {'1',"1"}, {'2',"2"}, {'3',"3"}, {'4',"4"}, {'5',"5"}, {'6',"6"}, {'7',"7"}, {'8',"8"}, {'9',"9"}, {'_',"_"}
        };
    }
}