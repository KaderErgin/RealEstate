namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost"; //Token Kim Tarafindan Bilinecek
        public const string ValidIssuer = "https://localhost";//Kim Tarafindan Yayinlanacak
        public const string Key = "REALestate..0102030405Asp.NetCore8.0.1+-*/";
        public const int Expire= 5;//dk Token
    }
}
