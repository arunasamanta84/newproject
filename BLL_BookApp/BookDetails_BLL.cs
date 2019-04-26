using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_BookApp;
using BEL_BookApp;
using DAL_BookApp;
using System.Data;

namespace BLL_BookApp
{
    public class BookDetails_BLL
    {
        public Int32 SaveBookDetails(BookDetails_BEL objBel)
        {
            BookDetails_DAL objDAL = new BookDetails_DAL();
            try {
                return objDAL.SaveBookDetails(objBel);
            
            
            }
            catch (Exception ex) {
                throw;
            }
            finally {
                objDAL = null;
            
            }
        }

        public DataSet GetBookRecords()
        {
            BookDetails_DAL objDAL = new BookDetails_DAL();

            try {

                return objDAL.GetBookRecords();
            }
            catch (Exception ex)
            { }
            finally {

                objDAL = null;
            }

            return objDAL.GetBookRecords();
        }

        public Int32 DeleteBookRecords(BookDetails_BEL objBel)
        {
            BookDetails_DAL objDal = new BookDetails_DAL();

            try {

                return objDal.DeleteBookRecord(objBel);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally {

                objDal = null;
            }
        }

        public Int32 UpdateBookRecord(BookDetails_BEL objBel)
        {
            int result;
            BookDetails_DAL objDAL = new BookDetails_DAL();

            try {
                return objDAL.UpdateBookRecord(objBel);
            }
            catch (Exception ex)
            {
            }

            finally
            {
                objDAL = null;
            }
            return objDAL.UpdateBookRecord(objBel);
        }
    }
}
