using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.data;

namespace VloveImport.dal
{
    public class CMSContentDal
    {
        #region Constructor
        public CommandData SqlCommandData;
        public CMSContentDal(string strConnection)
        {
            SqlCommandData = new CommandData(strConnection);
        }
        #endregion

        public List<ContentData> GetContent(int page)
        {
            List<ContentData> models = new List<ContentData>();
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CONTENT");

                SqlCommandData.SetParameter_Input_INT("Page", SqlDbType.Int, ParameterDirection.Input, page);
                DataSet ds = new DataSet();
                ds = SqlCommandData.ExecuteDataSet();
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        ContentData model = new ContentData();
                        model.ContentID = Convert.ToInt16(item["CONTENT_ID"]);
                        model.ContentTitle = item["CONTENT_TITLE"].ToString();
                        model.ContentDetail = item["CONTENT_DETAIL"].ToString();
                        model.ContentImage = item["CONTENT_IMG"].ToString();
                        model.ContentType = item["HEADER_TYPE"].ToString();
                        model.HEADER_TITLE = item["HEADER_TITLE"].ToString();
                        model.HEADER_IMG = item["HEADER_IMG"].ToString();
                        model.HEADER_TYPE = item["HEADER_TYPE"].ToString();
                        model.HEADER_ORDER = item["HEADER_ORDER"].ToString();
                        model.ContentDate = Convert.ToDateTime(item["CREATE_DATE"]);
                        models.Add(model);
                    }
                }
            }
            catch (Exception ex) { }
            return models;
        }

        public ContentData GetContentByID(int ID)
        {
            ContentData model = new ContentData();
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CONTENT_BY_ID");

                SqlCommandData.SetParameter_Input_INT("ContentID", SqlDbType.Int, ParameterDirection.Input, ID);
                DataSet ds = new DataSet();
                ds = SqlCommandData.ExecuteDataSet();
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRow item = ds.Tables[0].Rows[0];
                    model.ContentID = Convert.ToInt16(item["CONTENT_ID"]);
                    model.ContentTitle = item["CONTENT_TITLE"].ToString();
                    model.ContentDetail = item["CONTENT_DETAIL"].ToString().Replace('[', '<').Replace(']', '>');
                    model.ContentImage = item["CONTENT_IMG"].ToString();
                    model.ContentType = item["CONTENT_TYPE"].ToString();
                    model.ContentDate = Convert.ToDateTime(item["CREATE_DATE"]);
                }
            }
            catch (Exception ex) { }
            return model;
        }

    }
}
