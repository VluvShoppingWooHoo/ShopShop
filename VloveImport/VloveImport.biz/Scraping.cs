using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.data;

namespace VloveImport.biz
{
    class Scraping
    {
        public ScrapingDataModel Handle(string URL, int web)
        {
            ScrapingDataModel model = new ScrapingDataModel();
            string html = ScrapingProcess(URL);
            switch (web)
            {
                case 1:
                    model = TAOBAO(html);
                    break;
                case 2:
                    model = TMALL(html);
                    break;
                case 3:
                    model = W1688(html);
                    break;
                default:
                    model = null;
                    break;
            }

            return model;
        }
        #region Function
        private ScrapingDataModel TAOBAO(string html)
        {
            ScrapingDataModel model = new ScrapingDataModel();

            return model;
        }

        private ScrapingDataModel TMALL(string html)
        {
            ScrapingDataModel model = new ScrapingDataModel();

            return model;
        }

        private ScrapingDataModel W1688(string html)
        {
            ScrapingDataModel model = new ScrapingDataModel();

            return model;
        }

        private string ScrapingProcess(string URL)
        {
            string html = string.Empty;

            return html;
        }
        #endregion
    }
}
