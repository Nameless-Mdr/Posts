namespace BLL.Models.Token
{
    public class TokenModel
    {
        public string AccessToken { get; set; }

        public TokenModel(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
