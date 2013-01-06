using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.Web;

namespace Common
{
    public class HttpContextHelper
    {
        public static T GetSession<T>(string name)
        {
            try
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[name] != null)
                    return (T)HttpContext.Current.Session[name];
            }
            catch (Exception)
            {
                //throw;
            }

            return default(T);
        }

        public static string GetAuthCookie(string cookieName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cookieName] != null)
                return HttpContext.Current.Request.Cookies[cookieName].Value;
            return string.Empty;
        }

        public static void SetAuthCookie(string cookieName, string cookieValue, int expiredDate)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
                cookie = new HttpCookie(cookieName);

            cookie.Expires = DateTime.Now.AddDays(expiredDate);
            cookie.Value = cookieValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// Method to make sure that user's inputs are not malicious
        /// </summary>
        /// <param name="text">User's Input</param>
        /// <param name="maxLength">Maximum length of input</param>
        /// <returns>The cleaned up version of the input</returns>
        public static string InputText(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
            text = text.Replace("'", "''");
            return text;
        }

    }
}
