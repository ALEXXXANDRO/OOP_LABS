﻿using System;
using System.IO;
using System.Collections;

namespace LAB1_PARSER
{
    public class ini_parser
    {
        public String iniFilePath;
        public Hashtable keyPairs = new Hashtable();

        
        /// <summary>
        /// Структура, которая служит ключем для хэш таблицы.
        /// </summary>
        public struct SectionPair
        {
            public String Section;
            public String Key;

            public override string ToString()
            {
                return String.Format("{0}, {1}", Key, Section);
            }

            public override int GetHashCode()
            {
                return Key.GetHashCode() ^ Section.GetHashCode();
            }

        }

        
        
        /// <summary>
        /// Конструктор класса, который открывает файл INI по указанному пути и перечисляет значения в хэш таблицу.
        /// </summary>
        /// <param name="iniPath">полный путь до INI файла.</param>
        public ini_parser(String iniPath)
        {
            TextReader iniFile = null; /// абстрактный класс для чтения наборов символов
            String strLine = null;
            String currentRoot = null;
            String[] keyPair = null;
            this.iniFilePath = iniPath;
            string format = iniPath.Substring(iniFilePath.Length-4);
            
            
            if (format == ".ini")
            {
                if (File.Exists(iniPath))
                {
                    try
                    {
                        //реализует объект TextReader, который считывает символы из потока байтов в определенной кодировке.
                        iniFile = new StreamReader(iniPath);
                        strLine = iniFile.ReadLine();
                        while (strLine != null)
                        {
                            strLine = strLine.Trim();
                            if (strLine != "")
                            {
                                if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                                {
                                    currentRoot = strLine.Substring(1, strLine.Length - 2);
                                }
                                else
                                {
                                    if (strLine.IndexOf(';') != -1)
                                    {
                                        strLine = strLine.Substring(0, strLine.IndexOf(';'));
                                    }

                                    keyPair = strLine.Split(new char[] {'='}, 2);
                                    
                                    SectionPair sectionPair;
                                    String value = null;

                                    if (currentRoot == null)
                                        currentRoot = "ROOT";

                                    sectionPair.Section = currentRoot;
                                    sectionPair.Key = keyPair[0];

                                    if (keyPair.Length > 1)
                                        value = keyPair[1].Remove(0, 1); // лишний пробел вначале

                                    this.keyPairs.Add(sectionPair, value);
                                }
                            }

                            strLine = iniFile.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (iniFile != null)
                            iniFile.Close();
                    }
                }
                else
                {
                    throw new FileNotFoundException("Unable to locate " + iniPath);
                }
            }
            else
            {
                throw new IniFormatException("Bad format");
            }
        }

        
        
        
        
        /// <summary>
        ///Получение значения заданного параметра из заданной секции..
        /// </summary>
        /// <param name="sectionName">Section name.</param>
        /// <param name="settingName">Key name.</param>
        public T GetSetting<T>(String sectionName, String settingName)
        {
            SectionPair sectionPair;
            sectionPair.Section = sectionName;
            sectionPair.Key = settingName + ' ';

            if (keyPairs.ContainsKey(sectionPair))
            {
                try
                {
                    return (T) Convert.ChangeType(keyPairs[sectionPair], typeof(T));
                }
                catch (Exception exception)
                {
                    throw new IniTypeException("Unable to convert " + keyPairs[sectionPair] + " to " + typeof(T), exception);
                }
            }
            else 
                throw new IniUnknownSettingnameException("Unknown settingName/sectionName " + "\"" + sectionPair + "\"");
        }
    }
}