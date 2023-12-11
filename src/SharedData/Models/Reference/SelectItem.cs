namespace SharedData.Models.Reference
{
    public class SelectItem<T>
    {
        public string Label { get; set; }
        public T Value { get; set; }
    }
}
