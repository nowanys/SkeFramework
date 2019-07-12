﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SkeFramework.Core.Network.Commom;
using SkeFramework.Core.Network.Enums;

namespace SkeFramework.Core.Network.Https
{
    /// <summary>
    /// HTTP请求帮助类
    /// </summary>
    public class HttpHelper
    {
        public HttpHelper()
        {
            this.cookieContainer = new CookieContainer();
        }

        #region 单例
        /// <summary>
        /// 静态实例
        /// </summary>
        private static HttpHelper example;
        public static HttpHelper Example
        {
            get
            {
                if (HttpHelper.example == null)
                {
                    HttpHelper.example = new HttpHelper();
                }
                return example;
            }
        }
        #endregion

        /// <summary>
        /// 保存网站返回Cookie
        /// </summary>
        private CookieContainer cookieContainer;
        /// <summary>
        /// 保存网站返回Cookie字符串
        /// </summary>
        public string CookieStr;
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> m_cookies = new Dictionary<string, string>();
        /// <summary>
        /// 解决：基础连接已经关闭:未能为SSL/TLS安全通道建立信任关系。 
        /// </summary> 
        private bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            System.Console.WriteLine("Warning, trust any certificate");
            return true;
        }
        
        /// <summary>
        /// 获取指定键的cookies值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCookie(string key)
        {
            if (!m_cookies.ContainsKey(key))
            {
                return string.Empty;
            }
            return m_cookies[key];
        }
        /// <summary>
        /// 处理响应的cookies
        /// </summary>
        /// <param name="cookies"></param>
        private void ProcessCookies(CookieCollection cookies)
        {
            foreach (Cookie cookie in cookies)
            {
                if (m_cookies.ContainsKey(cookie.Name))
                {
                    m_cookies[cookie.Name] = cookie.Value;
                }
                else
                {
                    m_cookies.Add(cookie.Name, cookie.Value);
                }
                cookieContainer.Add(cookie);
            }
        }

        public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
        {
            return true;
        }

        /// <summary>
        /// 请求方法
        /// </summary>
        /// <param name="bPara">设置请求参数</param>
        /// <returns></returns>
        public string GetWebData(BrowserPara bPara)
        {
            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(bPara.Uri);
                myRequest.Accept = bPara.Accept;
                myRequest.UserAgent = bPara.UserAgent;
                myRequest.ContentType = bPara.contentType;
                myRequest.Referer = bPara.Referer;
                if (bPara.Cookies != null)
                {
                    foreach (var cookie in bPara.Cookies)
                    {
                        cookieContainer.SetCookies(new Uri(bPara.Uri), string.Format(" {0}={1}; ", cookie.Key, cookie.Value));
                    }
                }
                if (bPara.Headers != null)
                {
                    foreach (var header in bPara.Headers)
                    {
                        myRequest.Headers.Add(header.Key, header.Value);
                    }
                }
                myRequest.CookieContainer = cookieContainer;
                myRequest.Method = EnumsHelper.ValueOfRequestType(bPara.Method);
                if (bPara.Method == RequestTypeEnums.POST)
                {
                    myRequest.MediaType = bPara.MediaType;
                    byte[] byteRequest = Encoding.UTF8.GetBytes(bPara.PostData);
                    Stream rs = myRequest.GetRequestStream();
                    rs.Write(byteRequest, 0, byteRequest.Length);
                    rs.Close();
                }
                ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidate;
                var myResponse = (HttpWebResponse)myRequest.GetResponse();

                CookieStr += myResponse.Headers.Get("Set-Cookie");
                ProcessCookies(myResponse.Cookies);
                var stream = myResponse.GetResponseStream();
                var returnStream = new StreamReader(stream, Encoding.UTF8);
                var html = returnStream.ReadToEnd();
                returnStream.Close();
                myResponse.Close();
                Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
                return reg.Replace(html, delegate(Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
            }
            catch (System.Exception ex)
            {
                return string.Format("-1|Error:{0}", ex.Message);
            }
        }

    }
}