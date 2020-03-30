using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioMain.models
{
    class Stage
    {
        public Stage(String Title, String Content, int userId)
        {
            this.Title = Title;
            this.Content = Content;
            this.userId = userId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int userId { get; set; }
    }
}
