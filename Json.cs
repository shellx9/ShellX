using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

//using System;
//using System.Collections.Generic;
//using System.Text;
using System.Text.RegularExpressions;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.IO;
using System.Net;


namespace rdp
{
    class Get_Post_Download
    {
        /// <summary>
        /// 向指定URL发送GET方法的请求
        /// </summary>
        /// <param name="url">发送请求的URL</param>
        /// <param name="param">请求参数，请求参数应该是 name1=value1&name2=value2 的形式。</param>
        /// <returns>所代表远程资源的响应结果</returns>
        public static string SendGet(string url)//, string param  
        {
            string result = String.Empty;
            StreamReader reader = null;
            try
            {
                string urlNameString = url;  // + "?" + param;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlNameString);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                result = reader.ReadToEnd();

                reader.Close();
                responseStream.Close();
                response.Close();
                reader = null;
                responseStream = null;
                response = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("发送GET请求出现异常：" + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 向指定URL发送GET方法的请求
        /// </summary>
        /// <param name="url">发送请求的URL</param>
        /// <param name="param">请求参数，请求参数应该是 name1=value1&name2=value2 的形式。</param>
        /// <param name="encoding">设置响应信息的编码格式，如utf-8</param>
        /// <returns>所代表远程资源的响应结果</returns>
        public static string SendGet(string url, string encoding)  //, string param
        {
            string result = String.Empty;
            StreamReader reader = null;
            try
            {
                string urlNameString = url; // + "?" + param;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlNameString);
                request.Method = "GET";
                request.ContentType = "text/html;charset=" + encoding;
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream, Encoding.GetEncoding(encoding));
                result = reader.ReadToEnd();

                reader.Close();
                responseStream.Close();
                response.Close();
                reader = null;
                responseStream = null;
                response = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("发送GET请求出现异常：" + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 向指定 URL 发送POST方法的请求
        /// </summary>
        /// <param name="url">发送请求的 URL</param>
        /// <param name="jsonData">请求参数，请求参数应该是Json格式字符串的形式。</param>
        /// <returns>所代表远程资源的响应结果</returns>
        public static string SendPost(string url, string jsonData)
        {
            string result = String.Empty;
            try
            {
                CookieContainer cookie = new CookieContainer();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("x-requested-with", "XMLHttpRequest");
                request.ServicePoint.Expect100Continue = false;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)";
                request.ContentLength = Encoding.UTF8.GetByteCount(jsonData);
                request.CookieContainer = cookie;
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {

                    writer.Write(jsonData);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookie.GetCookies(response.ResponseUri);
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        result = reader.ReadToEnd();

                        reader.Close();
                    }
                    responseStream.Close();
                }
                response.Close();
                response = null;
                request = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("发送GET请求出现异常：" + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 向指定 URL 发送POST方法的请求
        /// </summary>
        /// <param name="url">发送请求的 URL</param>
        /// <param name="jsonData">请求参数，请求参数应该是Json格式字符串的形式。</param>
        /// <param name="encoding">设置响应信息的编码格式，如utf-8</param>
        /// <returns>所代表远程资源的响应结果</returns>
        public static string SendPost(string url, string jsonData, string encoding)
        {
            string result = String.Empty;
            try
            {
                CookieContainer cookie = new CookieContainer();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("x-requested-with", "XMLHttpRequest");
                request.ServicePoint.Expect100Continue = false;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)";
                request.ContentLength = Encoding.UTF8.GetByteCount(jsonData);
                request.CookieContainer = cookie;
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.GetEncoding(encoding)))
                {

                    writer.Write(jsonData);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookie.GetCookies(response.ResponseUri);
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(encoding)))
                    {
                        result = reader.ReadToEnd();

                        reader.Close();
                    }
                    responseStream.Close();
                }
                response.Close();
                response = null;
                request = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("发送GET请求出现异常：" + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 上传媒体文件
        /// </summary>
        /// <param name="url">上传媒体文件的微信公众平台接口地址</param>
        /// <param name="file">要上传的媒体文件对象</param>
        /// <returns>返回上传的响应结果，详情参看微信公众平台开发者接口文档</returns>
        public static string UploadPost(string url, string file)
        {
            string result = String.Empty;
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                byte[] responseArray = client.UploadFile(url, "POST", file);
                result = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);
                Console.WriteLine("上传result:" + result);
            }
            catch (Exception ex)
            {
                result = "Error:" + ex.Message;
                Console.WriteLine("发送GET请求出现异常：" + ex.Message);
            }
            finally
            {
                Console.WriteLine("上传MediaId:" + result);
            }
            return result;
        }

        public static bool DownloadFile(string url, string param, string outFileName)
        {
            bool result = false;
            FileStream fs = null;
            try
            {
                string urlNameString = url + "?" + param;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlNameString);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                fs = new FileStream(outFileName, FileMode.Create);
                int bufferSize = 2048;
                byte[] data = new byte[bufferSize];
                int length = 0;
                while ((length = responseStream.Read(data, 0, bufferSize)) > 0)
                {
                    fs.Write(data, 0, length);
                }
                fs.Close();
                responseStream.Close();
                response.Close();
                fs = null;
                responseStream = null;
                response = null;

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("下载媒体文件时出现异常：" + ex.Message);
               // Mesnac.Log.LogService.Instance.Error("下载媒体文件时出现异常：" + ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return result;
        }
    }
    //==============================================================================================
    class JSONConvert
    {
        /// <summary>
        /// 类  名：JSONConvert
        /// 描  述：JSON解析类
        /// 编  写：wufeng
        /// 日  期：2010-10-21
        /// 版  本：1.1.0
        /// </summary>
        //public static class JSONConvert
        //{
            #region 全局变量
            private static JSONObject _json = new JSONObject();//寄存器
            private static readonly string _SEMICOLON = "@semicolon";//分号转义符
            private static readonly string _COMMA = "@comma"; //逗号转义符
            #endregion
            #region 字符串转义
            /// <summary>
            /// 字符串转义,将双引号内的:和,分别转成_SEMICOLON和_COMMA
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            private static string StrEncode(string text)
            {
                MatchCollection matches = Regex.Matches(text, "\\\"[^\\\"]+\\\"");
                foreach (Match match in matches)
                {
                    text = text.Replace(match.Value, match.Value.Replace(":", _SEMICOLON).Replace(",", _COMMA));
                }
                return text;
            }
            /// <summary>
            /// 字符串转义,将_SEMICOLON和_COMMA分别转成:和,
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            private static string StrDecode(string text)
            {
                return text.Replace(_SEMICOLON, ":").Replace(_COMMA, ",");
            }
            #endregion
            #region JSON最小单元解析
            /// <summary>
            /// 最小对象转为JSONObject
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            private static JSONObject DeserializeSingletonObject(string text)
            {
                JSONObject jsonObject = new JSONObject();
                MatchCollection matches = Regex.Matches(text, "(\\\"(?<key>[^\\\"]+)\\\":\\\"(?<value>[^,\\\"]*)\\\")|(\\\"(?<key>[^\\\"]+)\\\":(?<value>[^,\\\"\\}]*))");
                foreach (Match match in matches)
                {
                    string value = match.Groups["value"].Value;
                    jsonObject.Add(match.Groups["key"].Value, _json.ContainsKey(value) ? _json[value] : StrDecode(value));
                }
                return jsonObject;
            }
            /// <summary>
            /// 最小数组转为JSONArray
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            private static JSONArray DeserializeSingletonArray(string text)
            {
                JSONArray jsonArray = new JSONArray();
                MatchCollection matches = Regex.Matches(text, "(\\\"(?<value>[^,\\\"]+)\")|(?<value>[^,\\[\\]]+)");
                foreach (Match match in matches)
                {
                    string value = match.Groups["value"].Value;
                    jsonArray.Add(_json.ContainsKey(value) ? _json[value] : StrDecode(value));
                }
                return jsonArray;
            }
            /// <summary>
            /// 反序列化
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            private static string Deserialize(string text)
            {
                text = StrEncode(text);//转义;和,
                int count = 0;
                string key = string.Empty;
                string pattern = "(\\{[^\\[\\]\\{\\}]+\\})|(\\[[^\\[\\]\\{\\}]+\\])";
                while (Regex.IsMatch(text, pattern))
                {
                    MatchCollection matches = Regex.Matches(text, pattern);
                    foreach (Match match in matches)
                    {
                        key = "___key" + count + "___";
                        if (match.Value.Substring(0, 1) == "{")
                            _json.Add(key, DeserializeSingletonObject(match.Value));
                        else
                            _json.Add(key, DeserializeSingletonArray(match.Value));
                        text = text.Replace(match.Value, key);
                        count++;
                    }
                }
                return text;
            }
            #endregion
            #region 公共接口
            /// <summary>
            /// 序列化JSONObject对象
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static JSONObject DeserializeObject(string text)
            {
                return _json[Deserialize(text)] as JSONObject;
            }
            /// <summary>
            /// 序列化JSONArray对象
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static JSONArray DeserializeArray(string text)
            {
                return _json[Deserialize(text)] as JSONArray;
            }
            /// <summary>
            /// 反序列化JSONObject对象
            /// </summary>
            /// <param name="jsonObject"></param>
            /// <returns></returns>
            public static string SerializeObject(JSONObject jsonObject)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("{");
                foreach (KeyValuePair<string, object> kvp in jsonObject)
                {
                    if (kvp.Value is JSONObject)
                    {
                        sb.Append(string.Format("\"{0}\":{1},", kvp.Key, SerializeObject((JSONObject)kvp.Value)));
                    }
                    else if (kvp.Value is JSONArray)
                    {
                        sb.Append(string.Format("\"{0}\":{1},", kvp.Key, SerializeArray((JSONArray)kvp.Value)));
                    }
                    else if (kvp.Value is String)
                    {
                        sb.Append(string.Format("\"{0}\":\"{1}\",", kvp.Key, kvp.Value));
                    }
                    else
                    {
                        sb.Append(string.Format("\"{0}\":\"{1}\",", kvp.Key, ""));
                    }
                }
                if (sb.Length > 1)
                    sb.Remove(sb.Length - 1, 1);
                sb.Append("}");
                return sb.ToString();
            }
            /// <summary>
            /// 反序列化JSONArray对象
            /// </summary>
            /// <param name="jsonArray"></param>
            /// <returns></returns>
            public static string SerializeArray(JSONArray jsonArray)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    if (jsonArray[i] is JSONObject)
                    {
                        sb.Append(string.Format("{0},", SerializeObject((JSONObject)jsonArray[i])));
                    }
                    else if (jsonArray[i] is JSONArray)
                    {
                        sb.Append(string.Format("{0},", SerializeArray((JSONArray)jsonArray[i])));
                    }
                    else if (jsonArray[i] is String)
                    {
                        sb.Append(string.Format("\"{0}\",", jsonArray[i]));
                    }
                    else
                    {
                        sb.Append(string.Format("\"{0}\",", ""));
                    }
                }
                if (sb.Length > 1)
                    sb.Remove(sb.Length - 1, 1);
                sb.Append("]");
                return sb.ToString();
            }
            #endregion
        }
        /// <summary>
        /// 类  名：JSONObject
        /// 描  述：JSON对象类
        /// 编  写：wufeng
        /// 日  期：2010-10-21
        /// 版  本：1.1.0
        /// 更新历史：
        ///     2010-10-21  继承Dictionary<TKey, TValue>代替this[]
        /// </summary>
        public class JSONObject : Dictionary<string, object>
        { }
        /// <summary>
        /// 类  名：JSONArray
        /// 描  述：JSON数组类
        /// 编  写：wufeng
        /// 日  期：2010-10-21
        /// 版  本：1.1.0
        /// 更新历史：
        ///     2010-10-21  继承List<T>代替this[]
        /// </summary>
        public class JSONArray : List<object>
        { }

    //}
}




////序列化
//JSONArray _array = new JSONArray();
//_array.Add("1");
//_array.Add("2");
//_array.Add("3");
//_array.Add("4");
//JSONObject _object = new JSONObject();//新建json对象作为内嵌
//_object.Add("oneKey", "one");
//_object.Add("twoArray", _array);
//JSONArray jsonArray = new JSONArray();
//jsonArray.Add("2006");
//jsonArray.Add("2007");
//jsonArray.Add("2008");
//jsonArray.Add("2009");
//jsonArray.Add("2010");
//JSONObject jsonObject = new JSONObject();
//jsonObject.Add("domain", "mzwu.com");
//jsonObject.Add("two", _object);//添加json对象
//jsonObject.Add("years", jsonArray);
//Console.WriteLine("json序列化为字符串");
//Console.WriteLine(JSONConvert.SerializeObject(jsonObject));//执行序列化
//                                                           //反序列化
//JSONObject json = JSONConvert.DeserializeObject("{\"domain\":\"mzwu.com\",\"two\":{\"oneKey\":\"one\",\"twoArray\":[1,2,3,4]},\"years\":[2006,2007,2008,2009,2010]}");//执行反序列化
//if (json != null)
//{
//    Console.WriteLine("将json结构的字符串反序列化为json对象并调用");
//    Console.WriteLine(json["domain"]);
//    Console.WriteLine(((JSONObject)json["two"])["oneKey"]);
//    Console.WriteLine(((JSONArray)((JSONObject)json["two"])["twoArray"])[0]);
//    Console.WriteLine(((JSONArray)json["years"])[3]);
//}
//Console.ReadLine();

//json序列化为字符串
//{ "domain":"mzwu.com","two":{ "oneKey":"one","twoArray":["1","2","3","4"]},"years":["2006","2007","2008","2009","2010"]}
//将json结构的字符串反序列化为json对象并调用
//mzwu.com
//one
//1
//2009