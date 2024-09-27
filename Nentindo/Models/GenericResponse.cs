namespace Nentindo.Models
{
    public class GenericResponse<T>
    {
        public T Result { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public List<string> Warnings { get; set; } = new List<string>();
        public bool IsSuccessful => Errors.Count == 0;
        public void AddError(string message)
        {
            Errors.Add(message);
        }
        public void AddWarning(string message)
        {
            Errors.Add(message);
        }
    }
}
