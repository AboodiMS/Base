using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;
using Google.Type;
using System;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;

namespace Base.Shared.Helper101
{
    public class Firebase
    {
        public async static Task SendMessageToPhonNumberAsync(string phoneNumber, string code)
        {
            //var data = FirebaseApp.Create(new AppOptions()
            //{
            //    Credential = GoogleCredential.FromJson("{\r\n  \"type\": \"service_account\",\r\n  \"project_id\": \"baseauth-5804b\",\r\n  \"private_key_id\": \"2fc8eb9858227942e5ab1a03470740359bd1d81d\",\r\n  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDEBwyhHKTtZ7fs\\n1V6K9SUQ8nLoPsNoxcq3ptvScVQLMpy1jdlU9DQ3MhOmzghxetXOhEJdJSb4oFiy\\nHlZnXJUaoR8i9Y4yfbPXLXu+G9pYkj7YxcRSY4IcHfY4b5fmUYRLONsQUPNEMw1+\\nG5zctRVd/2io+hj5goOc+2ce6mBMz60r8xFkf4amAdth61XEQ08S58s+bei4cqru\\nc9YUCygQ8OVO4HY7F7pTqsZ+9FXVIT5UdBxoaevz5aDHOImaTGrjYdQvDhl2PcbF\\n35bQhaA0VQfqGYYC0j5Q5yGjg8VQToHH1nXGg3H86nusbW1O6YxS8JshS6IUAJJp\\nKjtKLTArAgMBAAECggEAC7f3f3rUuePdQRlrpUyiEnZz+8H4xj7WGg7YYvxnD6Ok\\nbk6/Dc7q1NviWd1E8EfCwq2cbAYTDizucHjTeyqz4oYm9DI6yyDsSzJLDKKMoIaJ\\nnvA1Bs8vvC+RrxkDZdTnXuR/ZWUkIyZsKZGhWdOyJc7lelM31/6p5eIPmEUJob3J\\nEqxfI3F1kQDyP3DelP6boFU1IBTGatg95duCD3uBnVlg1ofmWR4xvZxYoZqZDB6a\\nRH+8DJsT1ddUKlZdRojcUX/YcbSAqsSXJ7leNuW9A/rWD35RSLkspkGZGVdNehFw\\nGvsbqo9R8IjMFs01mS6Jk6j+UQyiTtWaGV9Z3pId4QKBgQDpgxdfKjGOoTp4Nc9c\\njZvOVG32JHLp7kK/QvU6X7rsrlDAWsxGkINy3hkvfdjPEQqNhrKEyut9B9N3Hs8j\\nky7aXsiTKcNCTlm5c2vU8uDr/dNjhjTiwwDOXi4+uppzgzXY/YB3BipuxAXKDR7j\\nW3/qtGM4rRMfiHWPXGCiUDZyYQKBgQDW59R3Zi+2+Q9bOAQDX0jmtug1hxvGgCIV\\nuNdnHYglz1sCy9hcxelJqTSG1duXDf3mkBhD/NHmpTUcCLadY+G1sioF/dX+vxY6\\noJQEwkdpbORI1cgelIEeQ5P0p3pCsZqMYfhtItdUfucoaz4AwAirF4osZvs02vCR\\nqTsf8igGCwKBgQCtCUtkZavbeXYOZjGG8BioyL/DSjctSjWD7WYzH4UwpeuI3r/I\\n+oWttQ8MtkDXEFW1kj7vUD84o3f8KYRtZD+v6dTP2H6sv8qVNgaOAnzR44GlmmnO\\nL5qFUh0KttSFDJH2fcOYb6U592Ai3Z4p9D/R+GIeOYKWN1SGK3ogTThLgQKBgAxH\\nySNdioJ5LwB2bfxHWKIed5x/cP3h2pDFNEHnNR18AOZjAaUjhhY4fhDqbZbvLMAd\\nIdXYv6HfdO56LP1HdOFuIeqfu7fH8Zw+CtdOxsfmehETblEZCVvSXsUPQPRIs90r\\nyAdsg0OH0OvFXRCr6JLmUHYDGH3HuRGJyyAjNVhLAoGBAOGfrhwERGa8XFzsy75m\\nxhlKKdwzmxA1IpOzhdgktz7z9iesnFlFcijLk4H7MJuzsMyuk7TmhwMrRJuotQWF\\nPh99t9Ub6J8nnxMdsPe1d1iydw8NGn8Z+QU0Yua25E3LlV1t7KqrfIEqICngG4G3\\n1VBzSdQ9ubI7L0yt+afgvCXW\\n-----END PRIVATE KEY-----\\n\",\r\n  \"client_email\": \"firebase-adminsdk-tl7qp@baseauth-5804b.iam.gserviceaccount.com\",\r\n  \"client_id\": \"112562403596057365078\",\r\n  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\r\n  \"token_uri\": \"https://oauth2.googleapis.com/token\",\r\n  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\r\n  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-tl7qp%40baseauth-5804b.iam.gserviceaccount.com\"\r\n}\r\n")
            //});
            //var firebaseAuth = FirebaseAuth.DefaultInstance;
            //var verificationResult = await firebaseAuth.VerifyPhoneNumberAsync(
            //    phoneNumber,
            //    timeout: TimeSpan.FromMinutes(1),
            //    verificationId: null,
            //    verificationCode: code);


            string firebaseApiKey = "AIzaSyCf4vMpGLNb6_5UHWby91svYtX0F_lP9qw";
            //string phoneNumber = "+1XXXXXXXXXX"; // Replace with user's phone number
            string requestUrl = $"https://www.googleapis.com/identitytoolkit/v3/relyingparty/sendVerificationCode?key={firebaseApiKey}";
            string requestBody = $"{{\"phoneNumber\":\"{phoneNumber}\",\"recaptchaToken\":\"\"}}";
            using (var httpClient = new HttpClient())
            {
                var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PostAsync(requestUrl, httpContent);
                httpResponse.EnsureSuccessStatusCode();
            }

        }
    }
}
