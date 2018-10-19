namespace ef6.Models
{
    public class Word
    {
        public int WordId { get; set; }
        public string Transcription { get; set; }
        public int? Examples { get; set; }
    }
}
