﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Tsp;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace StartupProject_Asp.NetCore_PostGRE.Library
{
    public class Adapter
    {
        /*
        internal static string Base64EncodedCurrentTime()
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(DateTime.UtcNow.ToString());
            return Convert.ToBase64String(plainTextBytes);
        }
        */

        internal static DateTime? Base64DecodTime(string encodedTimeString)
        {
            try
            {
                byte[] base64EncodedBytes = Convert.FromBase64String(encodedTimeString);
                return DateTime.Parse(Encoding.UTF8.GetString(base64EncodedBytes));
            }
            catch (Exception)
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(encodedTimeString);
                    TimeStampResponse timeStampResponse = new TimeStampResponse(bytes);
                    return timeStampResponse.TimeStampToken.TimeStampInfo.GenTime;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //throw ex;
                    return null;
                }
            }
        }

        internal static async Task<string> ReadAsStringAsync(IFormFile file)
        {
            StringBuilder result = new StringBuilder();
            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }
            return result.ToString().Trim();
        }

        internal static XmlDocument SerializeToXml<T>(T source)
        {
            XmlDocument document = new XmlDocument();
            XPathNavigator navigator = document.CreateNavigator();
            using (var writer = navigator.AppendChild())
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, source);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return document;
        }

        // Calling -> Adapter.DeSerializeFromXml<DemoData>(xmlDocument);
        internal static T DeSerializeFromXml<T>(XmlDocument xmlDocument)
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(new StringReader(xmlDocument.OuterXml));
        }
    }
}
