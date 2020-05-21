using System;

namespace WebApp.Common.Helpers
{
    public class EnumDescriptionAttribute : Attribute
    {
        private string m_strDescription;
        public EnumDescriptionAttribute(string strPrinterName)
        {
            m_strDescription = strPrinterName;
        }

        public string Description
        {
            get { return m_strDescription; }
        }
    }
}
