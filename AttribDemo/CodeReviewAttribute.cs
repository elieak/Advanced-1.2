using System;

namespace AttribDemo
{
    internal class CodeReviewAttribute : Attribute
    {
        internal string _reviewerName { get; private set; }
        internal string _reviewerDate
        {
            get { return DateTime.Today.ToString("M"); }
            private set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }
        internal bool _approved { get; private set; }

        public CodeReviewAttribute(string name, string date, bool isApproved)
        {
            _reviewerName = name;
            _reviewerDate = date;
            _approved = isApproved;
        }
    }
}
