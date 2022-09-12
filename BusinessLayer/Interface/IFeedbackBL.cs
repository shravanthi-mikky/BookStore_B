using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IFeedbackBL
    {
        public FeedbackModel AddFeedback(FeedbackModel addfeedback);
        public List<FeedbackModel> RetrieveFeedBackDetails(int bookId);
    }
}
