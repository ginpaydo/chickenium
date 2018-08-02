using Microsoft.EntityFrameworkCore;

namespace Chickenium.Dao
{
    /// <summary>
    /// 時間足
    /// </summary>
    public class TimeScale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int SecondsValue { get; set; }

        public TimeScale()
        {
        }

        public TimeScale(int Id, string Name, string DisplayName, int SecondsValue)
        {
            this.Id = Id;
            this.Name = Name;
            this.DisplayName = DisplayName;
            this.SecondsValue = SecondsValue;
        }

    }
}
