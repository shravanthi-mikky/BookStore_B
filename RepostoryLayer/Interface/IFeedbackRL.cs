using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepostoryLayer.Interface
{
    public interface IFeedbackRL
    {
        public FeedbackModel AddFeedback(FeedbackModel addfeedback);
        public List<FeedbackModel> RetrieveFeedBackDetails(int bookId);

    }
}
