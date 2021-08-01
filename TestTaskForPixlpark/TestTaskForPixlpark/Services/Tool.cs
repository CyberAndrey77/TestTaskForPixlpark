using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using TestTaskForPixlpark.Models;

namespace TestTaskForPixlpark.Tools
{
    public static class Tool
    {
        private static readonly string _requestToken = "d6755016e1be4d4caf171ea9dd36bf6b";
        private static readonly string _publicKey = "38cd79b5f2b2486d86f562e3c43034f8";
        private static readonly string _privateKey = "8e49ff607b1f46e1a5e8f6ad5d312a80";
        private static MyAccessToken _token;
        //private static string _accessToken = "";
        //private static string _refreshToken = "";

        /// <summary>
        /// Получает хэш из строки, которая была получена путем конкатенацией Request Token и Private Key.
        /// </summary>
        /// <returns>Возвращает хэш переведенный в строку</returns>
        private static string GetPassword()
        {
            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;

            sSourceData = _requestToken + _privateKey;
            tmpSource = Encoding.ASCII.GetBytes(sSourceData);
            var sha = SHA1.Create();

            tmpHash = sha.ComputeHash(tmpSource);
            return ByteArrayToString(tmpHash);
        }

        /// <summary>
        /// Переводит из байтов хэша в строку.
        /// </summary>
        /// <param name="arrInput">Массив байтов</param>
        /// <returns>Возвращает строку</returns>
        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        /// <summary>
        /// Получает путем запроса Access Token и Refresh Token.
        /// </summary>
        /// <returns></returns>
        private static void GetToken()
        {
            string grantType = "api";
            string password = GetPassword();

            string url = "http://api.pixlpark.com/oauth/accesstoken";
            string uri = $"{url}?oauth_token={_requestToken}&grant_type={grantType}&username={_publicKey}&password={password}";

            var httpWebResponse = SendRequest(uri);

            _token = new MyAccessToken();
            var serializer = new JsonSerializer();

            using (Stream stream = httpWebResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    using (JsonReader jsonReader = new JsonTextReader(reader))
                    {
                        try
                        {
                            _token = serializer.Deserialize<MyAccessToken>(jsonReader);
                        }
                        catch (Exception)
                        {
                            _token = new MyAccessToken();
                        }
                        if (_token == null)
                        {
                            _token = new MyAccessToken();
                        }
                    }
                }
            }
            httpWebResponse.Close();
        }

        private static void GetTokenByRefreshToken()
        {
            string url = "http://api.pixlpark.com/oauth/refreshtoken";
            string uri = $"{url}?refreshToken={_token.RefreshToken}";

            var httpWebResponse = SendRequest(uri);
            var serializer = new JsonSerializer();

            using (Stream stream = httpWebResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    using (JsonReader jsonReader = new JsonTextReader(reader))
                    {
                        try
                        {
                            _token = serializer.Deserialize<MyAccessToken>(jsonReader);
                        }
                        catch (Exception)
                        {
                            _token = new MyAccessToken();
                        }
                        if (_token == null)
                        {
                            _token = new MyAccessToken();
                        }
                    }
                }
            }
            httpWebResponse.Close();
        }

        private static HttpWebResponse SendRequest(string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            return (HttpWebResponse)request.GetResponse();
        }

        public static AnswerResult GetOrders()
        {

            if (_token == null)
            {
                GetToken();
            }

            string url = "http://api.pixlpark.com/orders";
            string uri = $"{url}?oauth_token={_token.AccessToken}";

            HttpWebResponse httpWebResponse;

            try
            {
                httpWebResponse = SendRequest(uri);
            }
            catch (WebException)
            {
                GetTokenByRefreshToken();
                uri = $"{url}?oauth_token={_token.AccessToken}";
                httpWebResponse = SendRequest(uri);
            }

            var serializer = new JsonSerializer();
            var result = new AnswerResult();

            using (Stream stream = httpWebResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    using (JsonReader jsonReader = new JsonTextReader(reader))
                    {
                        try
                        {
                            result = serializer.Deserialize<AnswerResult>(jsonReader);
                        }
                        catch (Exception)
                        {
                            result = new AnswerResult();
                        }
                        if (result == null)
                        {
                            result = new AnswerResult();
                        }
                    }
                }
            }
            httpWebResponse.Close();
            return result;
        }
    }
}