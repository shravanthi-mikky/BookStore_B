using BusinessLayer.Interface;
using CommonLayer.Model;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class FeedbackBL : IFeedbackBL
    {
        private readonly IFeedbackRL iFeedbackRL;
        public FeedbackBL(IFeedbackRL iFeedbackRL)
        {
            this.iFeedbackRL = iFeedbackRL;
        }

        public FeedbackModel AddFeedback(FeedbackModel addfeedback)
        {
            try
            {
                return iFeedbackRL.AddFeedback(addfeedback);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<FeedbackModel> RetrieveFeedBackDetails(int bookId)
        {
            try
            {
                return iFeedbackRL.RetrieveFeedBackDetails(bookId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
